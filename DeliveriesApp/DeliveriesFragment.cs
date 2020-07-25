using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace DeliveriesApp
{
    public class DeliveriesFragment : Android.Support.V4.App.ListFragment
    {
        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            var deliveries = await Delivery.GetDeliveries();
            //ListAdapter = new ArrayAdapter(Activity, Android.Resource.Layout.SimpleListItem1, deliveries);
            ListAdapter = new DeliveryAdapter(Activity, deliveries);
        }
        //After changing the class that is inherited from, from Fragment to ListFragment, the following is no longer needed

        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    // Use this to return your custom view for this Fragment
        //     return inflater.Inflate(Resource.Layout.Deliveries, container, false);

        //    //return base.OnCreateView(inflater, container, savedInstanceState);
        //}
    }
}