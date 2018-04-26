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
using System.Threading;
using System.IO;

namespace WebServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            button2.Enabled = false;
        }
        WebServer server = new WebServer();

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox3.Text.ToString();
            IPAddress ipAddress = IPAddress.Parse(textBox1.Text.ToString());
            int port = int.Parse(textBox2.Text);
            // to start it
            if (server.start(ipAddress,port, 100, path))
            {
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show(this, "Couldn't start the server. Make sure port " + textBox2.Text + " is not being listened by other servers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.stop();
            button2.Enabled = false;
            button1.Enabled = true;
        }
    }
}
