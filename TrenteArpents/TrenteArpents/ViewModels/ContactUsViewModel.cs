using System;
using System.Net.Mail;
using System.Threading.Tasks;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class ContactUsViewModel : BaseViewModel
    {
        public ContactUsViewModel(IRepo<Email> repo)
        {
            Title = "Contactez-nous";

            Repo = repo;

            SendCommand = new Command(async () => await SendAsync(), CanSend);
        }

        private IRepo<Email> Repo { get; }

        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Command SendCommand { get; }

        private async Task SendAsync()
        {
            Email response = await Repo.PostAsync<Email>(new Email
            {
                From = From,
                Subject = Subject,
                Body = Body
            });
        }

        private bool CanSend()
        {
            return !string.IsNullOrEmpty(From) &&
                IsValid(From) &&
                !string.IsNullOrEmpty(Subject) &&
                !string.IsNullOrEmpty(Body);
        }

        private bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress email = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void OnFromChanged()
        {
            SendCommand.ChangeCanExecute();
        }

        public void OnSubjectChanged()
        {
            SendCommand.ChangeCanExecute();
        }

        public void OnBodyChanged()
        {
            SendCommand.ChangeCanExecute();
        }
    }
}