using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace MailSender
{
    public partial class Form1
    {
        private void sendYandex()
        {
            try
            {
                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.yandex.ru", 465, true);
                    smtp.Authenticate(Properties.Settings.Default.YandexUser, Properties.Settings.Default.YandexPass);

                    var bodyBldr = new BodyBuilder();
                    bodyBldr.TextBody = txtText.Text;
                    bodyBldr.HtmlBody = txtText.Text;

                    var msg = new MimeMessage()
                    {
                        Subject = txtSubj.Text,
                        Body = bodyBldr.ToMessageBody(),
                    };

                    msg.To.Add(MailboxAddress.Parse(txtTo.Text));
                    msg.From.Add(new MailboxAddress("Learning Together c#", "learningtogethersharp@yandex.ru"));

                    smtp.Send(msg);
                }
            }
            catch (Exception ex) { }
        }
    }
}
