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
        private Android.Support.V7.Widget.Toolbar tabsToolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Tabs);

            //tabs layout
            tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout);
            tabLayout.TabSelected += TabLayout_TabSelected;
            
            //tabs toolbar
            tabsToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tabsToolbar);
            tabsToolbar.InflateMenu(Resource.Menu.tabsMenu);
            tabsToolbar.MenuItemClick += TabsToolbar_MenuItemClick;

            FragmentNavigate(new DeliveriesFragment());
        }

        private void TabsToolbar_MenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            if (e.Item.ItemId == Resource.Id.action_add)
            {
                StartActivity(typeof(NewDeliveryActivity));
            }
        }

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Resource.Id.
        //    }
        //}

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigate(new DeliveriesFragment());
                    break;
                case 1:
                    FragmentNavigate(new DeliveredFragment());
                    break;
                case 2:
                    FragmentNavigate(new ProfileFragment());
                    break;
            }
        }

        private void FragmentNavigate(Fragment fragment)
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.contentFrame, fragment);
            transaction.Commit();
        }
    }
}