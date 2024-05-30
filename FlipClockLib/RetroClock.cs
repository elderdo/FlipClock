#region Using Directives

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#endregion

namespace Standard.Controls
{
    public enum TimeFormats
    {
        Hour12,
        Hour24
    }

    public class RetroClock : Control
    {
        public static readonly DependencyProperty Hour1Property =
            DependencyProperty.Register("Hour1", typeof (string),
                                        typeof (RetroClock),
                                        new UIPropertyMetadata("0"));

        public static readonly DependencyProperty Hour2Property =
            DependencyProperty.Register("Hour2", typeof (string),
                                        typeof (RetroClock),
                                        new UIPropertyMetadata("0"));

        public static readonly DependencyProperty HourProperty =
            DependencyProperty.Register("Hour", typeof (string),
                                        typeof (RetroClock),
                                        new UIPropertyMetadata(DateTime.Now.Hour.ToString()));

        public static readonly DependencyProperty IncludeLeadingZeroProperty =
            DependencyProperty.Register("IncludeLeadingZero", typeof (bool),
                                        typeof (RetroClock),
                                        new UIPropertyMetadata(true));

        public static readonly DependencyProperty IsAmPmVisibleProperty =
            DependencyProperty.Register("IsAmPmVisible", typeof (bool),
                                        typeof (RetroClock),
                                        new UIPropertyMetadata(false));

        public static readonly DependencyProperty MinuteProperty =
            DependencyProperty.Register("Minute", typeof (string),
                                        typeof (RetroClock),
                                        new UIPropertyMetadata(DateTime.Now.Minute.ToString()));

        public static readonly DependencyProperty TimeFormatProperty =
            DependencyProperty.Register("TimeFormat", typeof (TimeFormats),
                                        typeof (RetroClock),
                                        new UIPropertyMetadata(TimeFormats.Hour12));

        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof (DateTime),
                                        typeof (RetroClock),
                                        new UIPropertyMetadata(DateTime.Now));

        private static DispatcherTimer Timer;
        //  private Storyboard _HourFlipStoryboard;
        // private StackPanel _HourTextPanel;

        static RetroClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (RetroClock), new FrameworkPropertyMetadata(typeof (RetroClock)));
        }

        public RetroClock()
        {
            Timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 1)};
            Timer.Tick += TimerTick;
            Timer.Start();
        }


        public DateTime Time
        {
            get { return (DateTime) GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public TimeFormats TimeFormat
        {
            get { return (TimeFormats) GetValue(TimeFormatProperty); }
            set
            {
                SetValue(TimeFormatProperty, value);

                if (value == TimeFormats.Hour24)
                {
                    IsAmPmVisible = false;
                }
                //_HourFlipStoryboard.Begin();
            }
        }

        public bool IncludeLeadingZero
        {
            get { return (bool) GetValue(IncludeLeadingZeroProperty); }
            set { SetValue(IncludeLeadingZeroProperty, value); }
        }

        public bool IsAmPmVisible
        {
            get { return (bool) GetValue(IsAmPmVisibleProperty); }
            set { SetValue(IsAmPmVisibleProperty, value); }
        }

        public string Hour
        {
            get { return (string) GetValue(HourProperty); }
            set { SetValue(HourProperty, value); }
        }

        public string Hour1
        {
            get { return (string) GetValue(Hour1Property); }
            set { SetValue(Hour1Property, value); }
        }

        public string Hour2
        {
            get { return (string) GetValue(Hour2Property); }
            set { SetValue(Hour2Property, value); }
        }

        public string Minute
        {
            get { return (string) GetValue(MinuteProperty); }
            set { SetValue(MinuteProperty, value); }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var newHour = string.Empty;

            if (TimeFormat.Equals(TimeFormats.Hour12))
            {
                newHour = DateTime.Now.Hour > 12 ? (DateTime.Now.Hour - 12).ToString("00") : DateTime.Now.Hour.ToString("00");
            }
            else if (TimeFormat.Equals(TimeFormats.Hour24))
            {
                newHour = DateTime.Now.Hour.ToString("00");
            }

            var newMinute = DateTime.Now.Minute.ToString("00");


            if (newHour != Hour)
            {
                FlipHour(newHour);
            }

            if (Minute != newMinute)
            {
                FlipMinute(newMinute);
            }
        }

        private void FlipHour(string newHour)
        {
            Hour1 = newHour.Substring(0, 1);
            Hour2 = newHour.Substring(1, 1);
            Hour = newHour;
        }

        private void FlipMinute(string newMinute)
        {
            Minute = newMinute;
        }

        public override void OnApplyTemplate()
        {
            // _HourTextPanel = Template.FindName("_HourTextPanel", this) as StackPanel;
            //_HourFlipStoryboard = _HourTextPanel.Resources["_HourFlipStoryboard"] as Storyboard;
        }
    }
}