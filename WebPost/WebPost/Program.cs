using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace WebPost
{
    class Program
    {
        public static string PostHttp(string url, string body, string contentType)
        {

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 2000000;

            byte[] btBodys = Encoding.UTF8.GetBytes(body);
            long a = btBodys.Length;
            httpWebRequest.ContentLength = a;
            using (var stream = httpWebRequest.GetRequestStream())
            {
                stream.Write(btBodys, 0, btBodys.Length);
            }





            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();

            return responseContent;
        }
        

        static void Main(string[] args)
        {
            string type = "application/x-www-form-urlencoded";
            string url = "http://localhost:8888/post.html";
            string body = "<html><head><metahttp-equiv =\"Content-Type\" content=\"text/html;charset=utf-8\"></head><body><h2>Post test</h2><div>success</div></body></html>";
            PostHttp(url, body, type);
        }
    }

}