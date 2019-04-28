using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrenteArpents.ViewModels;
using Xamarin.Forms;

namespace TrenteArpents.Views
{
    public partial class EventToCommandBehavior
    {
        public static bool GetAttachAppearing(BindableObject obj)
        {
            return (bool)obj.GetValue(AttachAppearingProperty);
        }

        public static void SetAttachAppearing(BindableObject obj, bool value)
        {
            obj.SetValue(AttachAppearingProperty, value);
        }

        public static readonly BindableProperty AttachAppearingProperty =
            BindableProperty.CreateAttached(
                "AttachAppearing", 
                typeof(bool), 
                typeof(EventToCommandBehavior), 
                defaultValue: false, 
                propertyChanged: OnAttachAppearingChanged);

        private static void OnAttachAppearingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is VisualElement view))
            {
                return;
            }

            if (view.Behaviors.OfType<EventToCommandBehavior>().Any(b => b.EventName == nameof(ContentPage.Appearing)))
            {
                return;
            }

            view.Behaviors.Add(CreateAppearingEventToCommandBehavior(view));
        }

        private static Behavior CreateAppearingEventToCommandBehavior(VisualElement view)
        {
            var behavior = new EventToCommandBehavior { EventName = nameof(ContentPage.Appearing) };

            view.BindingContextChanged += (s, e) =>
            {
                behavior.SetBinding(CommandProperty, new Binding(nameof(BaseViewModel.AppearingCommand))
                {
                    Source = view.BindingContext
                });
            };

            return behavior;
        }
    }
}
