using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
namespace WebServer
{
    public class WebServer
    {
        public bool running = false; // 判断是否在运行的标志

        private int timeout = 8; // 超时时间
        private Encoding charEncoder = Encoding.UTF8; 
        private Socket serverSocket; // 服务器socket
        private string contentPath; // 服务器路径

        
        private Dictionary<string, string> extensions = new Dictionary<string, string>()
        { 
            //{ "extension", "content type" }
            { "htm", "text/html" },
            { "html", "text/html" },
            { "xml", "text/xml" },
            { "txt", "text/plain" },
            { "css", "text/css" },
            {"aspx","text/aspx" },
            {"php","text/php" },
            { "png", "image/png" },
            { "gif", "image/gif" },
            { "jpg", "image/jpg" },
            { "jpeg", "image/jpeg" },
            { "zip", "application/zip"}
        };
        public bool start(IPAddress ipAddress, int port, int maxNOfCon, string contentPath)
        {
            if (running)  return false; // 如果已经在运行就退出程序

            try
            {
                // A tcp/ip socket (ipv4)一个ipvv4的tcp/ip socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                               ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, port));
                serverSocket.Listen(maxNOfCon);
                serverSocket.ReceiveTimeout = timeout;
                serverSocket.SendTimeout = timeout;
                running = true;
                this.contentPath = contentPath;
            }
            catch { return false; }

            
            //监听线程，在此线程中会创建新线程处理连接请求
            Thread requestListenerT = new Thread(() =>
            {
                while (running)
                {
                    Socket clientSocket;
                    try
                    {
                        clientSocket = serverSocket.Accept();
                        
                        //创建一个新线程处理请求并且继续监听
                        Thread requestHandler = new Thread(() =>
                        {
                            clientSocket.ReceiveTimeout = timeout;
                            clientSocket.SendTimeout = timeout;
                            try { handleTheRequest(clientSocket); }
                            catch
                            {
                                try { clientSocket.Close(); } catch { }
                            }
                        });
                        requestHandler.Start();
                    }
                    catch { }
                }
            });
            requestListenerT.Start();

            return true;
        }
        public void stop()
        {
            if (running)
            {
                running = false;
                try { serverSocket.Close(); }
                catch { }
                serverSocket = null;
            }
        }
       
        private void handleTheRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[10240]; // 设置10kb的缓冲区，以防万一
            int receivedBCount = clientSocket.Receive(buffer); // 接受请求
            string strReceived = charEncoder.GetString(buffer, 0, receivedBCount);
            string strtemp = strReceived;
            // 解析请求功能
            //
            int a = strReceived.LastIndexOf("Host")-2;

            int b = strReceived.IndexOf("Content-Type")+14;
            string type = strReceived.Substring(b, a - b);
            string httpMethod = strReceived.Substring(0, strReceived.IndexOf(" "));
            int start = strReceived.IndexOf(httpMethod) + httpMethod.Length + 1;
            int length = strReceived.LastIndexOf("HTTP") - start - 1;
            string requestedUrl = strReceived.Substring(start, length);

            string requestedFile;
            if (httpMethod.Equals("GET") || httpMethod.Equals("POST"))
                requestedFile = requestedUrl.Split('?')[0];
            else // 你可以实现其他操作
            {
                notImplemented(clientSocket);
                return;
            }
            requestedFile = requestedFile.Replace("/", @"\").Replace("\\..", "");
            start = requestedFile.LastIndexOf('.') + 1;
            
            
                
                //判断请求文件是否支持
                if (start > 0)
                {
                    length = requestedFile.Length - start;
                    string extension = requestedFile.Substring(start, length);
                if (extensions.ContainsKey(extension))
                { // 检查是否支持这种文件类型
                    if (httpMethod.Equals("POST"))
                    {
                        string filepath = contentPath + requestedFile;
                        
                        string filename = requestedFile.Substring(1, requestedFile.Length-1);
 
                        StreamWriter sw = new StreamWriter(filepath,false);
                        sw.WriteLine(strtemp);
                        sw.Close();
                                                   
                    }
                    if (File.Exists(contentPath + requestedFile)) //如果确实支持
                                                                  // 发送对应内容类型的响应报文
                        sendOkResponse(clientSocket,
                          File.ReadAllBytes(contentPath + requestedFile), extensions[extension]);
                    else
                        notFound(clientSocket); //不支持这种格式
                }
                }
                else
                {
                    // 如果没有指定请求文件，发送index.htm或者index.html
                    if (requestedFile.Substring(length - 1, 1) != @"\")
                        requestedFile += @"\";
                    if (File.Exists(contentPath + requestedFile + "index.htm"))
                        sendOkResponse(clientSocket,
                          File.ReadAllBytes(contentPath + requestedFile + "\\index.htm"), "text/html");
                    else if (File.Exists(contentPath + requestedFile + "index.html"))
                        sendOkResponse(clientSocket,
                          File.ReadAllBytes(contentPath + requestedFile + "\\index.html"), "text/html");
                    else
                        notFound(clientSocket);
                }
          
        }
        private void notImplemented(Socket clientSocket)
        {

            sendResponse(clientSocket, "<html><head><metahttp - equiv =\"Content-Type\" content=\"text/html; charset = utf - 8\"></ head >< body >< h2 > Simple WebServer </ h2 >< div > 501 - Method Not Implemented </ div ></ body ></ html > ", "501 Not Implemented", "text/html");

        }

        private void notFound(Socket clientSocket)
        {

            sendResponse(clientSocket, "<html><head><metahttp-equiv =\"Content-Type\" content=\"text/html;charset=utf-8\"></head><body><h2>Simple Web Server</h2><div>404-NotFound</div></body></html>", "404 Not Found", "text/html");
        }

        private void sendOkResponse(Socket clientSocket, byte[] bContent, string contentType)
        {
            sendResponse(clientSocket, bContent, "200 OK", contentType);
        }
        // 发送字符串响应报文
        private void sendResponse(Socket clientSocket, string strContent, string responseCode,
                                  string contentType)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            sendResponse(clientSocket, bContent, responseCode, contentType);
        }

        // 发送bytes响应报文
        private void sendResponse(Socket clientSocket, byte[] bContent, string responseCode,
                                  string contentType)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(
                                    "HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: Simple Web Server\r\n"
                                  + "Content-Length: " + bContent.Length.ToString() + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
                clientSocket.Send(bHeader);
                clientSocket.Send(bContent);
                clientSocket.Close();
            }
            catch { }
        }
    }
}
