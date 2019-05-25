using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using System.IO;
using System.Threading.Tasks;

namespace TrenteArpentsEmail
{
    public static class SendEmail
    {
        [FunctionName(nameof(SendEmail))]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest request,
            [SendGrid(ApiKey = "SendGridApiKey")] IAsyncCollector<SendGridMessage> messages)
        {
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();

            Email email = JsonConvert.DeserializeObject<Email>(requestBody);

            var message = new SendGridMessage();
            message.AddTo("cq30arpents@hotmail.com");
            message.AddContent("text/html", email.Body);
            message.SetFrom(new EmailAddress(email.From));
            message.SetSubject(email.Subject);

            await messages.AddAsync(message);
        }
    }
}
