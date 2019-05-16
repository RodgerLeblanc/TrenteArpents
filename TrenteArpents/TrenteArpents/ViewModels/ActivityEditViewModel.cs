using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TrenteArpents.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class ActivityEditViewModel : BaseEditViewModel<Activity>
    {
        public ActivityEditViewModel(Activity activity) : base(activity)
        {
            Title = activity.Name;

            ShareCommand = new Command(async () => await ShareAsync());
        }

        public string Name { get => Model.Name; }
        public string ShortDescription { get => Model.ShortDescription; }
        public string Description { get => Model.Description; }
        public string Time { get => Model.Time; }
        public Uri ImageUrl { get => Model.ImageUrl; }

        public ICommand ShareCommand { get; }

        private async Task ShareAsync()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Title = "Partager",
                Subject = "Regarde ce que j'ai trouvé dans l'application Fête 30 Arpents",
                Text = $"Je crois que cette activité à la fête de quartier du Domaine des 30 Arpents le 17 août 2019 pourrait te plaire :" +
                $"\n\n" +
                $"{Model.Name}" +
                $"\n" +
                $"{Model.Time}" +
                $"\n" +
                $"{Model.Description}" +
                $"\n\n" +
                $"Partagé grâce à l'application Fête 30 Arpents, disponible sur Android et iPhone",
            });
        }
    }
}