using Xamarin.Forms;

namespace CellNinja.Controls
{
    public class CNTwoStateImage : Image
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            SetSource();
        }

        public static readonly BindableProperty StateProperty =
            BindableProperty.Create(nameof(State), typeof(State), typeof(CNTwoStateImage), State.Off, propertyChanged: OnStateChanged);

        public State State
        {
            get { return (State)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly BindableProperty IsOnProperty =
            BindableProperty.Create(nameof(IsOn), typeof(bool), typeof(CNTwoStateImage), false, propertyChanged: IsOnChanged);

        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        public static readonly BindableProperty OnSourceProperty =
            BindableProperty.Create(nameof(OnSource), typeof(ImageSource), typeof(CNTwoStateImage), null);

        public ImageSource OnSource
        {
            get { return (ImageSource)GetValue(OnSourceProperty); }
            set { SetValue(OnSourceProperty, value); }
        }

        public static readonly BindableProperty OffSourceProperty =
            BindableProperty.Create(nameof(OffSource), typeof(ImageSource), typeof(CNTwoStateImage), null);

        public ImageSource OffSource
        {
            get { return (ImageSource)GetValue(OffSourceProperty); }
            set { SetValue(OffSourceProperty, value); }
        }

        public static readonly BindableProperty AnimateStateChangesProperty =
            BindableProperty.Create(nameof(AnimateOnStateChange), typeof(bool), typeof(CNTwoStateImage), true);

        public bool AnimateOnStateChange
        {
            get { return (bool)GetValue(AnimateStateChangesProperty); }
            set { SetValue(AnimateStateChangesProperty, value); }
        }

        private static void OnStateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CNTwoStateImage)bindable).OnStateChanged((State)oldValue, (State)newValue);
        }

        protected virtual void OnStateChanged(State oldValue, State newValue)
        {
            bool isOn = newValue == State.On;

            if (AnimateOnStateChange)
            {
                Animate(oldValue, newValue);
            }
            else
            {
                SetSource();
            }

            if (IsOn != isOn)
            {
                IsOn = isOn;
            }
        }

        private async void Animate(State oldValue, State newValue)
        {
            await this.ScaleTo(1.5, 250, Easing.SpringIn);

            SetSource();

            await this.ScaleTo(1, 250, Easing.SpringOut);
        }

        private void SetSource()
        {
            Source = State == State.On ? OnSource : OffSource;
        }

        private static void IsOnChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CNTwoStateImage)bindable).IsOnChanged((bool)oldValue, (bool)newValue);
        }

        protected virtual void IsOnChanged(bool oldValue, bool newValue)
        {
            State state = newValue ? State.On : State.Off;

            if (State != state)
            {
                State = state;
            }
        }
    }

    public enum State
    {
        On,
        Off
    }
}
