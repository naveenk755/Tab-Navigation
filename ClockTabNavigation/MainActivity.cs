using Android.App;
using Android.OS;
using Android.Runtime;

namespace ClockTabNavigation
{
    [Activity(Label = "Clock", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Android.Support.V4.App.FragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
             SetContentView (Resource.Layout.Main);

            var viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewPager);

            var fragments = new Android.Support.V4.App.Fragment[]
            {
                new TimeFragment(),
                new StopwatchFragment(),
                new AboutFragment()
            };

            var Titles = CharSequence.ArrayFromStringArray(new string[]
            {
                "Clock",
                "Stop Watch",
                "About"
            });

            var adapter = new ClockAdapter(base.SupportFragmentManager, fragments, Titles);
            viewPager.Adapter = adapter;
        }
    }
}

