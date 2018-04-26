using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// 添加命名空间
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Sockets;
using System.IO;
using jmail;

namespace MailSendAndReceive
{
    public partial class mainfrm : Form
    {
        // 定义邮件发送类
        private SmtpClient smtpClient;
        
        
 
        public mainfrm()
        {
            InitializeComponent();

            // 初始化界面
 
            // 这里收件人地址是Sina邮箱，你可以根据自己情况选择发送到自己的邮箱中
            txbSendTo.Text = "918899283@qq.com";
            txbSubject.Text = "测试邮件";
            richtbxBody.Text = "这是一封测试邮件，由系统自动发出，无须回复";

            
            tabControlMyMailbox.Enabled = true;
        }

        #region 邮件发送功能代码
        // 添加附件
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            // 只接受有效的文件名
            openFileDialog.ValidateNames = true;
            // 允许一次选择多个文件作为附件
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (openFileDialog.FileNames.Length > 0)
            {
                // 因为这里允许选择多个文件，所以这里用AddRange而没有用Add方法
                cmbAttachment.Items.AddRange(openFileDialog.FileNames);
            }
        }

        // 删除附件
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            int index = cmbAttachment.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("请选择要删除的附件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                cmbAttachment.Items.RemoveAt(index);
            }
        }

        // 发送邮件
        private void btnSend_Click(object sender, EventArgs e)
        {
            // 界面控件控制

            smtpClient = new SmtpClient();
            smtpClient.Host = tbxSmtpServer.Text;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Port = 25;
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            string mail = tbxUserMail.Text; string pass = txbPassword.Text;
            smtpClient.Credentials = new System.Net.NetworkCredential(mail, pass);
            this.Cursor = Cursors.WaitCursor;
            // 实例化一个发送的邮件
            // 相当于与现实生活中先写信，程序中把信（邮件）抽象为邮件类了
            MailMessage mailMessage = new MailMessage();
            // 指明邮件发送的地址，主题，内容等信息
            // 发信人的地址为登录收发器的地址，这个收发器相当于我们平时Web版的邮箱或者是OutLook中配置的邮箱
            mailMessage.From = new MailAddress(mail);
            string[] toarray = txbSendTo.Text.Split(';');
            int k = toarray.Length;
            for(int j=0;j<k;j++) mailMessage.To.Add(toarray[j]);
            mailMessage.Subject = txbSubject.Text;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = richtbxBody.Text;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            // 设置邮件正文不是Html格式的内容
            mailMessage.IsBodyHtml = false;
            // 设置邮件的优先级为普通优先级
            mailMessage.Priority = MailPriority.High;


            // 封装发送的附件
            System.Net.Mail.Attachment attachment = null;
            if (cmbAttachment.Items.Count > 0)
            {
                for (int i = 0; i < cmbAttachment.Items.Count; i++)
                {
                    string fileNamePath = cmbAttachment.Items[i].ToString();
                    string extName = Path.GetExtension(fileNamePath).ToLower();
                    if (extName == ".rar" || extName == ".zip")
                    {
                        attachment = new System.Net.Mail.Attachment(fileNamePath, MediaTypeNames.Application.Zip);
                    }
                    else
                    {
                        attachment = new System.Net.Mail.Attachment(fileNamePath,MediaTypeNames.Application.Octet);
                    }

                    // 表示MIMEContent-Disposition标头信息
      
                    
                    ContentDisposition cd = attachment.ContentDisposition;
                    cd.CreationDate = File.GetCreationTime(fileNamePath);
                    cd.ModificationDate = File.GetLastWriteTime(fileNamePath);
                    cd.ReadDate = File.GetLastAccessTime(fileNamePath);
                    // 把附件对象加入到邮件附件集合中
                    mailMessage.Attachments.Add(attachment);
                }
            }

            // 发送写好的邮件
            try
            {
                // SmtpClient类用于将邮件发送到SMTP服务器
                // 该类封装了SMTP协议的实现，
                // 通过该类可以简化发送邮件的过程，只需要调用该类的Send方法就可以发送邮件到SMTP服务器了。
                smtpClient.Send(mailMessage);
                MessageBox.Show("邮件发送成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(SmtpException smtpError)
            {
                MessageBox.Show("邮件发送失败：[" + smtpError.StatusCode + "]；[" 
                    + smtpError.Message+"];\r\n["+smtpError.StackTrace+"]."
                    ,"错误",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
            finally
            {
                mailMessage.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        // 取消发送
        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            if (cmbAttachment.Items.Count > 0)
            {
                cmbAttachment.Items.Clear();
                cmbAttachment.Text = "";
            }

            
        }


    }
}
