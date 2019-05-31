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
        private static readonly string IsHeartedPreferenceName = $"{nameof(ActivityEditViewModel)}.{nameof(ActivityEditViewModel.IsHearted)}";

        public ActivityEditViewModel(Activity activity) : base(activity)
        {
            Title = activity.Name;

            ShareCommand = new Command(async () => await ShareAsync());

            IsHearted = Preferences.Get($"{IsHeartedPreferenceName}_{Id}", false);

            TappedCommand = new Command(() => Navigation.NavigateTo(ViewModelLocator.ActivityEditPageKey, this));
            ChangeIsHeartedCommand = new Command(() => IsHearted = !IsHearted);
        }

        public int Id { get => Model.Id; }
        public string Name { get => Model.Name; }
        public string ShortDescription { get => Model.ShortDescription; }
        public string Description { get => Model.Description; }
        public string Time { get => Model.Time; }
        public Uri ImageUrl { get => Model.ImageUrl; }
        public bool IsVisible { get => Model.IsVisible; }

        public bool IsHearted { get; set; }

        public ICommand TappedCommand { get; }
        public ICommand ChangeIsHeartedCommand { get; }

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

        public void OnIsHeartedChanged()
        {
            Preferences.Set($"{IsHeartedPreferenceName}_{Id}", IsHearted);
        }
    }
}