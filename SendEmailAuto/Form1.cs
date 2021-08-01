using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SendEmailAuto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Attachment file = null;
            try
            {
                FileInfo fileinfo = new FileInfo(txtFile.Text);
                file = new Attachment(txtFile.Text);
            }
            catch
            {
            }
            StreamReader sr = new StreamReader(txtTo.Text);
            string mail;
            while ((mail = sr.ReadLine()) != null)
            {
                MailMessage message = new MailMessage(txtFrom.Text, mail, txtSubject.Text, txtMessage.Text);
                if (file != null)
                {
                    message.Attachments.Add(file);
                }
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(txtFrom.Text, txtPass.Text);
                smtpClient.Send(message);
            }
            MessageBox.Show("Send Email Successfully");
           

        }

        private void buttonFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                txtFile.Text = file.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtTo.Text = file.FileName;
            }
        }
    }
}
