using Microsoft.AspNetCore.Identity.UI.Services;

namespace WebAppAutorization.Services.Email
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //TODO Create email service
            await Task.CompletedTask;
        }
    }
}
