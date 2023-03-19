using DailyQuotes.DTOs;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace DailyQuotes.Repositories
{
    public class EmailSender : IEmailSender
    {

        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient("61ad72cb57d19e529e18f9340ea6730b", "ded532f83c336c0cf6a6273cfbaa38d4")//_config["Mailjet : APIKey"], _config["Mailjet : SecretKey"])
            {

            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }


            .Property(Send.FromEmail, "ajeigbekehinde160@gmail.com")
            .Property(Send.FromName, "Daily Quote")
            .Property(Send.Subject, subject)
            .Property(Send.HtmlPart, htmlMessage)
            .Property(Send.Recipients, new JArray {
                new JObject {
                 {"Email",email}
                 }
                });

            MailjetResponse response = await client.PostAsync(request);
        }

    }
}
