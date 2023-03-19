using DailyQuotes.DTOs;

namespace DailyQuotes.Repositories
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}