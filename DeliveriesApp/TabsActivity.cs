using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace DeliveriesApp
{
    [Activity(Label = "TabsActivity")]
    public class TabsActivity : FragmentActivity
    {
        private TabLayout tabLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Tabs);

            tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout);
            tabLayout.TabSelected += TabLayout_TabSelected;
            // Create your application here

            FragmanetNavigate(new DeliveriesFragment());
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmanetNavigate(new DeliveriesFragment());
                    break;
                case 1:
                    FragmanetNavigate(new DeliveredFragment());
                    break;
                case 2:
                    FragmanetNavigate(new ProfileFragment());
                    break;
            }
        }

        private void FragmanetNavigate(Fragment fragment)
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.contentFrame, fragment);
            transaction.Commit();
        }
    }
}