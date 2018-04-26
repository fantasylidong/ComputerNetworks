namespace MailSendAndReceive
{
    partial class mainfrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControlMyMailbox = new System.Windows.Forms.TabControl();
            this.tabPageWriteLetter = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.cmbAttachment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richtbxBody = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbSendTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.logingroupbox = new System.Windows.Forms.GroupBox();
            this.tbxSmtpServer = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxUserMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControlMyMailbox.SuspendLayout();
            this.tabPageWriteLetter.SuspendLayout();
            this.logingroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.tabControlMyMailbox);
            this.panel1.Controls.Add(this.logingroupbox);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 633);
            this.panel1.TabIndex = 1;
            // 
            // tabControlMyMailbox
            // 
            this.tabControlMyMailbox.Controls.Add(this.tabPageWriteLetter);
            this.tabControlMyMailbox.Location = new System.Drawing.Point(16, 185);
            this.tabControlMyMailbox.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMyMailbox.Name = "tabControlMyMailbox";
            this.tabControlMyMailbox.SelectedIndex = 0;
            this.tabControlMyMailbox.Size = new System.Drawing.Size(403, 444);
            this.tabControlMyMailbox.TabIndex = 0;
            // 
            // tabPageWriteLetter
            // 
            this.tabPageWriteLetter.Controls.Add(this.btnCancel);
            this.tabPageWriteLetter.Controls.Add(this.btnSend);
            this.tabPageWriteLetter.Controls.Add(this.btnDeleteFile);
            this.tabPageWriteLetter.Controls.Add(this.btnAddFile);
            this.tabPageWriteLetter.Controls.Add(this.cmbAttachment);
            this.tabPageWriteLetter.Controls.Add(this.label8);
            this.tabPageWriteLetter.Controls.Add(this.richtbxBody);
            this.tabPageWriteLetter.Controls.Add(this.label7);
            this.tabPageWriteLetter.Controls.Add(this.txbSubject);
            this.tabPageWriteLetter.Controls.Add(this.label6);
            this.tabPageWriteLetter.Controls.Add(this.txbSendTo);
            this.tabPageWriteLetter.Controls.Add(this.label5);
            this.tabPageWriteLetter.Location = new System.Drawing.Point(4, 25);
            this.tabPageWriteLetter.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageWriteLetter.Name = "tabPageWriteLetter";
            this.tabPageWriteLetter.Size = new System.Drawing.Size(395, 415);
            this.tabPageWriteLetter.TabIndex = 1;
            this.tabPageWriteLetter.Text = "写信";
            this.tabPageWriteLetter.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(279, 366);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(76, 366);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 29);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(307, 329);
            this.btnDeleteFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(56, 29);
            this.btnDeleteFile.TabIndex = 9;
            this.btnDeleteFile.Text = "删除";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(240, 329);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(64, 29);
            this.btnAddFile.TabIndex = 8;
            this.btnAddFile.Text = "添加";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // cmbAttachment
            // 
            this.cmbAttachment.FormattingEnabled = true;
            this.cmbAttachment.Location = new System.Drawing.Point(76, 332);
            this.cmbAttachment.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAttachment.Name = "cmbAttachment";
            this.cmbAttachment.Size = new System.Drawing.Size(155, 23);
            this.cmbAttachment.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 342);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "附件";
            // 
            // richtbxBody
            // 
            this.richtbxBody.Location = new System.Drawing.Point(76, 84);
            this.richtbxBody.Margin = new System.Windows.Forms.Padding(4);
            this.richtbxBody.Name = "richtbxBody";
            this.richtbxBody.Size = new System.Drawing.Size(285, 230);
            this.richtbxBody.TabIndex = 5;
            this.richtbxBody.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 95);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "内容";
            // 
            // txbSubject
            // 
            this.txbSubject.Location = new System.Drawing.Point(76, 45);
            this.txbSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txbSubject.Name = "txbSubject";
            this.txbSubject.Size = new System.Drawing.Size(285, 25);
            this.txbSubject.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "主题：";
            // 
            // txbSendTo
            // 
            this.txbSendTo.Location = new System.Drawing.Point(76, 10);
            this.txbSendTo.Margin = new System.Windows.Forms.Padding(4);
            this.txbSendTo.Name = "txbSendTo";
            this.txbSendTo.Size = new System.Drawing.Size(285, 25);
            this.txbSendTo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "收件人:";
            // 
            // logingroupbox
            // 
            this.logingroupbox.Controls.Add(this.tbxSmtpServer);
            this.logingroupbox.Controls.Add(this.txbPassword);
            this.logingroupbox.Controls.Add(this.label3);
            this.logingroupbox.Controls.Add(this.label2);
            this.logingroupbox.Controls.Add(this.tbxUserMail);
            this.logingroupbox.Controls.Add(this.label1);
            this.logingroupbox.Location = new System.Drawing.Point(16, 15);
            this.logingroupbox.Margin = new System.Windows.Forms.Padding(4);
            this.logingroupbox.Name = "logingroupbox";
            this.logingroupbox.Padding = new System.Windows.Forms.Padding(4);
            this.logingroupbox.Size = new System.Drawing.Size(351, 162);
            this.logingroupbox.TabIndex = 1;
            this.logingroupbox.TabStop = false;
            this.logingroupbox.Text = "登录";
            // 
            // tbxSmtpServer
            // 
            this.tbxSmtpServer.Location = new System.Drawing.Point(103, 128);
            this.tbxSmtpServer.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSmtpServer.Name = "tbxSmtpServer";
            this.tbxSmtpServer.Size = new System.Drawing.Size(211, 25);
            this.tbxSmtpServer.TabIndex = 2;
            this.tbxSmtpServer.Text = "smtp.163.com";
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(93, 82);
            this.txbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(211, 25);
            this.txbPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "SMTP服务器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // tbxUserMail
            // 
            this.tbxUserMail.Location = new System.Drawing.Point(103, 49);
            this.tbxUserMail.Margin = new System.Windows.Forms.Padding(4);
            this.tbxUserMail.Name = "tbxUserMail";
            this.tbxUserMail.Size = new System.Drawing.Size(211, 25);
            this.tbxUserMail.TabIndex = 1;
            this.tbxUserMail.Text = "fantasygood@163.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "邮箱地址：";
            // 
            // mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 691);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainfrm";
            this.Text = "邮件收发软件";
            this.panel1.ResumeLayout(false);
            this.tabControlMyMailbox.ResumeLayout(false);
            this.tabPageWriteLetter.ResumeLayout(false);
            this.tabPageWriteLetter.PerformLayout();
            this.logingroupbox.ResumeLayout(false);
            this.logingroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxSmtpServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox logingroupbox;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxUserMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlMyMailbox;
        private System.Windows.Forms.TabPage tabPageWriteLetter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.ComboBox cmbAttachment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richtbxBody;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbSendTo;
        private System.Windows.Forms.Label label5;

    }
}

