using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace DeliveriesApp
{
    public class DeliveredFragment : Android.Support.V4.App.ListFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        //After changing the class that is inherited from, from Fragment to ListFragment, the following is no longer needed

        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    // Use this to return your custom view for this Fragment
        //     return inflater.Inflate(Resource.Layout.Delivered, container, false);

        //    //return base.OnCreateView(inflater, container, savedInstanceState);
        //}
    }
}