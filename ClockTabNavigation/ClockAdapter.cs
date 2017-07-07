using Java.Lang;

namespace ClockTabNavigation
{
    class ClockAdapter : Android.Support.V4.App.FragmentPagerAdapter
    {
        Android.Support.V4.App.Fragment[] Fragments;
        ICharSequence[] Titles;
        public ClockAdapter(Android.Support.V4.App.FragmentManager fm, Android.Support.V4.App.Fragment[] fragments, ICharSequence[] titles)
            :base(fm)
        {
            Fragments = fragments;
            Titles = titles;
        }
        public override int Count
        {
            get
            {
                return Fragments.Length;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return Fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return Titles[position];
        }
    }
}