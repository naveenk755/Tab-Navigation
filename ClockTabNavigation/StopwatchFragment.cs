using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Timers;

namespace ClockTabNavigation
{
    public class StopwatchFragment: Android.Support.V4.App.Fragment
    {
        Timer timer;
        TimeSpan ticks;
        TextView timeTextView;
        Button StartStopButton;
        Button resetButton;

        public StopwatchFragment()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnElapsed;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Stopwatch, container, false);
            StartStopButton = view.FindViewById<Button>(Resource.Id.StartStopButton);
            resetButton = view.FindViewById<Button>(Resource.Id.resetButton);
            timeTextView = view.FindViewById<TextView>(Resource.Id.stopwatchtimeTextView);

            StartStopButton.Click += OnStartStopClick;
            resetButton.Click += OnResetClick;

            return view;
        }

        void OnStartStopClick(object sender, EventArgs e)
        {
            if (StartStopButton.Text == "START")
            {
                timer.Start();
                StartStopButton.Text = "STOP";
            }
            else
            {
                timer.Stop();
                StartStopButton.Text = "START";
            }
        }



        void OnResetClick(object sender, EventArgs e)
        {
            timeTextView.Text = "0:00:00";
            ticks = TimeSpan.Zero;
            StartStopButton.Text = "START";
            timer.Stop();
        }

        void OnElapsed(object sender, ElapsedEventArgs e)
        {
            ticks = ticks.Add(TimeSpan.FromSeconds(1));
            base.Activity.RunOnUiThread(() => timeTextView.Text = ticks.ToString("g"));
        }
    }
}