namespace MailSender
{
    internal class MailListItem
    {
        public string Date { get; internal set; }
        public string From { get; internal set; }
        public string Subj { get; internal set; }
        public bool HasAttachments { get; internal set; }
        public string Body { get; internal set; }
    }
}