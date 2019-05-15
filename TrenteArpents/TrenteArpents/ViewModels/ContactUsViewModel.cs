using System;
using System.Net.Mail;
using System.Threading.Tasks;
using TrenteArpents.Extensions;
using TrenteArpents.Models;
using TrenteArpents.Repos;
using TrenteArpents.Services;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class ContactUsViewModel : BaseViewModel
    {
        public ContactUsViewModel(IRepo<Email> repo, IAlertService alertService)
        {
            Title = "Contactez-nous";

            Repo = repo;
            AlertService = alertService;

            SendCommand = new Command(async () => await SendAsync(), CanSend);
        }

        private IRepo<Email> Repo { get; }
        private IAlertService AlertService { get; }

        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Command SendCommand { get; }

        private async Task SendAsync()
        {
            try
            {
                Email email = new Email
                {
                    From = From,
                    Subject = Subject,
                    Body = Body
                };

                await Repo.PostAsync<Email>(email).SetIsBusy(this);

                await AlertService.DisplayAlert("Envoyé avec succès", "Votre message a bien été envoyé.", "OK").SetIsBusy(this);

                From = string.Empty;
                Subject = string.Empty;
                Body = string.Empty;
            }
            catch (Exception)
            {
                await AlertService.DisplayAlert("Erreur lors de l'envoi", "Une erreur est survenue pendant l'envoi de votre message, veuillez réessayer plus tard.", "OK").SetIsBusy(this);
            }
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