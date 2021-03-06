﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DeliveryPersonApp
{
    [Activity(Label = "DeliverActivity")]
    public class DeliverActivity : Activity
    {
        MapFragment mapFragment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.deliver);

            mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.deliverMapFragment);
        }
    }
}