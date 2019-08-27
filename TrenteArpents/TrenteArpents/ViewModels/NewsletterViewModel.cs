namespace TrenteArpents.ViewModels
{
    public class NewsletterViewModel : BaseViewModel
    {
        public NewsletterViewModel()
        {
            Title = "Infolettre";
        }

        public string Url
        {
            get => "https://mailchi.mp/c99dc0abfcc1/30arpents";
        }
    }
}
