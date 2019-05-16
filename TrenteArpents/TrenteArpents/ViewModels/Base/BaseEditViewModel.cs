using TrenteArpents.Models;

namespace TrenteArpents.ViewModels
{
    public class BaseEditViewModel<TModel> : BaseViewModel
        where TModel : IModel, new()
    {
        public BaseEditViewModel(TModel model)
        {
            Model = model;
        }

        protected TModel Model { get; }
    }
}