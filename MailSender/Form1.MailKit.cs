using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        private List<MailListItem> getMails()
        {
            var list = new List<MailListItem>();
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.yandex.ru", 993, true);
                    client.Authenticate(Properties.Settings.Default.YandexUser, Properties.Settings.Default.YandexPass);

                    client.Inbox.Open(FolderAccess.ReadOnly);

                    var uids = client.Inbox.Search(SearchQuery.SentSince(DateTime.Now.AddDays(-7)));

                    var messages = client.Inbox.Fetch(uids, MessageSummaryItems.Full);

                    if (messages != null && messages.Count > 0)
                    {
                        foreach (var msg in messages)
                        {
                            var textPart = msg.BodyParts.First(b => b.ContentType.MediaType == "text");
                            MimeKit.TextPart body = null;
                            if (textPart != null)
                            {
                                body = client.Inbox.GetBodyPart(msg.UniqueId, msg.BodyParts.First()) as MimeKit.TextPart;
                            }

                            list.Add(new MailListItem
                            {
                                Date = msg.Date.ToString(),
                                From = msg.Envelope.From.ToString(),
                                Subj = msg.Envelope.Subject,
                                HasAttachments = msg.Attachments != null && msg.Attachments.Count() > 0,
                                Body = body?.Text,
                            });

                            foreach (var att in msg.Attachments.OfType<BodyPartBasic>())
                            {
                                var part = (MimePart)client.Inbox.GetBodyPart(msg.UniqueId, att);

                                var pathDir = Path.Combine(Environment.CurrentDirectory, "Emails", msg.UniqueId.ToString());
                                if (!Directory.Exists(pathDir))
                                {
                                    Directory.CreateDirectory(pathDir);
                                }

                                var path = Path.Combine(pathDir, part.FileName);
                                if (!File.Exists(path))
                                {
                                    using (var strm = File.Create(path))
                                    {
                                        part.Content.DecodeTo(strm);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return list;
        }
    }
}
