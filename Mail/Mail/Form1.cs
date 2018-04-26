using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

//添加私有成员
private MailMessage msg;      //用于构造邮件属性和方法
private Attachment att;       //用于构造邮件附件属性和方法
namespace Mail
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            //To邮件收信人地址属性 只读属性不能赋值
            msg.To.Add(textBox1.Text);
            //From邮件发件人地址属性
            msg.From = new MailAddress(textBox2.Text);
            //Subject邮件主题属性
            msg.Subject = textBox3.Text;
            msg.SubjectEncoding = Encoding.Default;
            //Body设置邮件内容属性
            msg.Body = richTextBox1.Text;
            msg.BodyEncoding = Encoding.Default;

            //设置邮件的优先级Priority属性
            if (radioButton1.Checked)
                msg.Priority = MailPriority.High;
            else if (radioButton2.Checked)
                msg.Priority = MailPriority.Low;
            else if (radioButton3.Checked)
                msg.Priority = MailPriority.Normal;
            else
                msg.Priority = MailPriority.Normal;

            //发送邮件
            SmtpClient client = new SmtpClient();
            //邮件服务器设置smtp端口 默认25
            client.Host = "smtp.163.com";
            client.Port = 25;
            //邮件发送方式 通过网络发送到SMTP服务器
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //凭证 发件人登录邮箱的用户名和密码
            client.Credentials = new System.Net.NetworkCredential("1520161xxxx", "19911203xxxx");
            client.Send(msg);
            MessageBox.Show("邮件发送成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception m) //异常处理
        {
            MessageBox.Show(m.Message);
        }
    }

    //点击"添加附件"按钮
    private void button2_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.CheckFileExists = true;  //不存在文件名显示警告
        openFileDialog.ValidateNames = true;    //值接受Win32文件
        openFileDialog.Multiselect = false;     //不允许多选文件
        openFileDialog.Filter = "所有文件(*.*)|*.*";

        //添加附件 现仅支持添加一个附件
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            richTextBox1.Text = openFileDialog.FileName;
            att = new Attachment(openFileDialog.FileName);
            msg.Attachments.Add(att);
        }
    }

    //点击"删除附件"按钮
    private void button3_Click(object sender, EventArgs e)
    {
        msg.Attachments.Clear();
    }
}
