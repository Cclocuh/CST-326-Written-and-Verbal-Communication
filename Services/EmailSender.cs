using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Log the email sending process for development purposes
            System.Diagnostics.Debug.WriteLine($"Sending email to {email} with subject {subject}");
            return Task.CompletedTask;
        }
    }
}
