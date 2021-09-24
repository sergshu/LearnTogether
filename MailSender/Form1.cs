using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace MailSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cmbServer.SelectedIndex = 0;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (cmbServer.SelectedIndex == 0) // Google
            {
                sendGMail();
            }
            else //Yandex
            {
                sendYandex();
            }
        }

        private void sendGMail()
        {
            try
            {
                using (var smtp = new SmtpClient())
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential
                    {
                        Password = Properties.Settings.Default.GooglePass,
                        UserName = Properties.Settings.Default.GoogleUser,
                    };
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    var msg = new MailMessage()
                    {
                        Subject = txtSubj.Text,
                        Body = txtText.Text,
                        From = new MailAddress("learningtogethercsharp@gmail.com"),
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                    };

                    msg.To.Add(new MailAddress(txtTo.Text));

                    smtp.Send(msg);
                }
            }
            catch (Exception ex) { }
        }
    }
}
