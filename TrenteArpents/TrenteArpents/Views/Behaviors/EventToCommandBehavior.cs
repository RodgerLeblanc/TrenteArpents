using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TrenteArpents.Views
{
    public partial class EventToCommandBehavior : Behavior<Element>
    {
        private EventInfo eventInfo;
        private Delegate eventHandler;
        private ICommand internalCommand;

        public Element View { get; private set; }

        public static readonly BindableProperty EventNameProperty =
          BindableProperty.Create(nameof(EventName), typeof(string), typeof(EventToCommandBehavior), null, propertyChanged: OnEventNameChanged);

        public static readonly BindableProperty CommandProperty =
          BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior), null, propertyChanged: OnCommandChanged);

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EventToCommandBehavior behavior)
            {
                if (behavior.internalCommand != newValue)
                {
                    behavior.internalCommand = (ICommand)newValue;
                }
            }
        }

        public static readonly BindableProperty CommandParameterProperty =
          BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(EventToCommandBehavior), null);

        public static readonly BindableProperty InputConverterProperty =
          BindableProperty.Create(nameof(Converter), typeof(IValueConverter), typeof(EventToCommandBehavior), null);

        public string EventName { get; set; }
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        public IValueConverter Converter { get; set; }

        protected override void OnAttachedTo(Element bindable)
        {
            base.OnAttachedTo(bindable);

            View = bindable;

            RegisterEvent(EventName);
        }

        protected override void OnDetachingFrom(Element bindable)
        {
            DeregisterEvent();

            base.OnDetachingFrom(bindable);
        }

        void RegisterEvent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            eventInfo = View.GetType().GetRuntimeEvent(name);

            if (eventInfo == null)
            {
                throw new ArgumentException($"Can't register the {name} event.");
            }

            MethodInfo methodInfo = GetMethod(nameof(OnEvent));
            eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(View, eventHandler);
        }

        private MethodInfo GetMethod(string methodName)
        {
            return typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod(methodName);
        }

        void OnEvent(object sender, object eventArgs)
        {
            if (internalCommand == null)
            {
                return;
            }

            object resolvedParameter = GetParameter(eventArgs);

            if (internalCommand.CanExecute(resolvedParameter))
            {
                internalCommand.Execute(resolvedParameter);
            }
        }

        private object GetParameter(object eventArgs)
        {
            if (CommandParameter != null)
            {
                return CommandParameter;
            }

            if (Converter != null)
            {
                return Converter.Convert(eventArgs, typeof(object), null, null);
            }

            return eventArgs;
        }

        private static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EventToCommandBehavior behavior)
            {
                behavior.DeregisterEvent();
                behavior.RegisterEvent((string)newValue);
            }
        }

        private void DeregisterEvent()
        {
            eventInfo?.RemoveEventHandler(View, eventHandler);
        }
    }
}
