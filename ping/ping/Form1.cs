using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ping_Click(sender, EventArgs.Empty);
            }
        }
        private void ping_Click(object sender, EventArgs e)
        {
            
            Listbox1.Items.Clear();
            String Hostclient = Textbox1.Text;
            int K;
            int j = Convert.ToInt16(textBox2.Text);
            for(K = 0 ; K < j; K++ )
　           {
                Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
                IPHostEntry Hostinfo;
                try{


                    //解析主机ip入口
                    Hostinfo = Dns.GetHostByName(Hostclient);
                }
                catch(Exception)

                {   
                    //解析主机名错误。
                    Listbox1.Items.Add("没有发现此主机！");
                    return;
                }
                // 取服务器端主机的30号端口
                EndPoint Hostpoint = (EndPoint)new IPEndPoint(Hostinfo.AddressList[0], 30);
                IPHostEntry Clientinfo;
                Clientinfo = Dns.GetHostByName(Hostclient);
                // 取客户机端主机的30端口
                EndPoint Clientpoint = (EndPoint)new IPEndPoint(Clientinfo.AddressList[0], 30);
                //设置icmp报文
                int Datasize = Convert.ToInt16(textBox3.Text); // Icmp数据包大小 ;
                int Packetsize = Datasize + 8;//总报文长度
                const int Icmp_echo = 8;
                IcmpPacket Packet = new IcmpPacket(Icmp_echo, 0, 0, 45, 0, Datasize);
                Byte[] Buffer = new Byte[Packetsize];
                int Index = Packet.CountByte(Buffer);
                //报文出错
                if(Index != Packetsize)

                {
                    Listbox1.Items.Add("报文出现问题!");
                    return;
                }
                int Cksum_buffer_length = (int)Math.Ceiling(((Double)Index) / 2);
                UInt16[] Cksum_buffer = new UInt16[Cksum_buffer_length];
                int Icmp_header_buffer_index = 0;
                for(int I = 0 ; I < Cksum_buffer_length; I++ )
　　              {
                    //将两个byte转化为一个uint16
                    Cksum_buffer[I] = BitConverter.ToUInt16(Buffer, Icmp_header_buffer_index);
                    Icmp_header_buffer_index += 2;
                }
                //将校验和保存至报文里
                Packet.CheckSum = IcmpPacket.SumOfCheck(Cksum_buffer);
                // 保存校验和后，再次将报文转化为数据包
                Byte[] Senddata = new Byte[Packetsize];
                Index = Packet.CountByte(Senddata);
                //报文出错
                if(Index != Packetsize)

                {
                    Listbox1.Items.Add("报文出现问题!");
                    return;
                }
                int Nbytes = 0;
                //系统计时开始
                int Starttime = Environment.TickCount;
                //发送数据包
                if((Nbytes = Socket.SendTo(Senddata, Packetsize, SocketFlags.None, Hostpoint)) == -1)

                {
                    Listbox1.Items.Add("无法传送报文！");
                }
                Byte[] Receivedata = new Byte[256]; //接收数据
                Nbytes = 0;
                int Timeout = 0;
                int Timeconsume = 0;
                while(true)

                {
                    Nbytes = Socket.ReceiveFrom(Receivedata, 256, SocketFlags.None, ref Clientpoint);
                    if(Nbytes == -1)

                {
                        Listbox1.Items.Add("主机没有响应！");
                        break;
                    }
                    else if(Nbytes > 0 )
　　　             {
                        Timeconsume = System.Environment.TickCount - Starttime;
                        //得到发送报文到接收报文之间花费的时间
                        Listbox1.Items.Add("reply From " + Hostinfo.AddressList[0].ToString() + " In "
                    + Timeconsume + "ms :bytes Received " + Nbytes+" TTL="+Receivedata[8]);

                        break;
                    }
                    Timeconsume = Environment.TickCount - Starttime;
                    if(Timeout > 1000)

                    {       
                        Listbox1.Items.Add("time Out");
                        break;
                    }
                }
                //关闭套接字
                Socket.Close();
            }
        }
    }

}
