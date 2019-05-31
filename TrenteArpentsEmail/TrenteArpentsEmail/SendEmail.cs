using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TrenteArpentsEmail
{
    public static class SendEmail
    {

        [FunctionName(nameof(SendEmail))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log,
            ExecutionContext context)
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(context.FunctionAppDirectory)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                Email email = JsonConvert.DeserializeObject<Email>(requestBody);

                if (await SendEmailAsync(email, config, log))
                {
                    return new OkObjectResult(email);
                }

                return new BadRequestObjectResult("Unable to send the email.");
            }
            catch (System.Exception)
            {
                return new BadRequestObjectResult("Unable to get the email informations from the request body.");
            }
        }

        private static async Task<bool> SendEmailAsync(Email email, IConfigurationRoot config, ILogger log)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    using (SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"))
                    {
                        mail.From = new MailAddress(email.From);
                        mail.To.Add("cq30arpents@hotmail.com");
                        mail.ReplyToList.Add(new MailAddress(email.From));
                        mail.Subject = email.Subject;
                        mail.Body = $"Message de {email.From} à partir de l'application Fête 30 Arpents :" +
                            $"\n\n" +
                            $"{email.Body}";

                        smtpServer.Port = 587;
                        smtpServer.Host = "smtp.gmail.com";
                        smtpServer.EnableSsl = true;
                        smtpServer.UseDefaultCredentials = false;

                        var emailUsername = config["EmailUsername"];
                        var emailPassword = config["EmailPassword"];
                        smtpServer.Credentials = new NetworkCredential(emailUsername, emailPassword);

                        await smtpServer.SendMailAsync(mail);

                        return true;
                    }
                }
            }
            catch (System.Exception e)
            {
                log.LogInformation(e, $"Error sending email: {e.Message}");

                return false;
            }
        }
    }
}
