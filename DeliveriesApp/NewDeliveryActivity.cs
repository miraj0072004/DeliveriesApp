using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DeliveriesApp
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity,IOnMapReadyCallback, ILocationListener
    {
        private Button saveButton;
        private EditText packageNamEditText;
        private MapFragment mapFragment;
        private double latitude, longitude;
        private LocationManager locationManager;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);

            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            packageNamEditText = FindViewById<EditText>(Resource.Id.packageNameEditText);
            mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mapFragment);
            //mapFragment.GetMapAsync(this);

            saveButton.Click += SaveButton_Click;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery{
                Name = packageNamEditText.Text,
                Status = 0
            };
            var deliveryStatus = await Delivery.InsertDelivery(delivery);
            if (deliveryStatus)
            {
                Toast.MakeText(this, "Delivery Added", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Failed to add delivery", ToastLength.Long).Show();
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //throw new NotImplementedException();
            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(latitude, longitude));
            marker.SetTitle("Your Location");

            googleMap.AddMarker(marker);
        }

        protected override void OnResume()
        {
            base.OnResume();

            locationManager = GetSystemService(Context.LocationService) as LocationManager;
            string provider = LocationManager.GpsProvider;

            if (locationManager.IsProviderEnabled(provider))
            {
                locationManager.RequestLocationUpdates(provider,5000,100,this);
            }
        }

        public void OnLocationChanged(Location location)
        {
            //throw new NotImplementedException();
            latitude = location.Latitude;
            longitude = location.Longitude;
            mapFragment.GetMapAsync(this);
        }

        public void OnProviderDisabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            //throw new NotImplementedException();
        }

        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }
    }
}