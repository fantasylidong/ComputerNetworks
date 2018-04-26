using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Web_Proxy;
namespace Web_Proxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            TcpListener tcplistener = new TcpListener(Int32.Parse(port.Text));
            tcplistener.Start();
            while (true)
            {
                Socket socket = tcplistener.AcceptSocket();
                //并获取传送和接收数据的Scoket实例  
                Proxy proxy = new Proxy(socket);
                //Proxy类实例化  
                Thread thread = new Thread(new ThreadStart(proxy.Run));
                //创建线程  
                thread.Start();
                //启动线程  
              
            }
        }
    }
}
