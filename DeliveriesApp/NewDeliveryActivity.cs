using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
//using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using DeliveriesModels;

namespace DeliveriesApp
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity,IOnMapReadyCallback, ILocationListener
    {
        private Button saveButton;
        private EditText packageNamEditText;
        private MapFragment mapFragment, destinationMapFragment;
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
            destinationMapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.destinationMapFragment);
            //mapFragment.GetMapAsync(this);
            //mapFragment.GetMapAsync(this);

            saveButton.Click += SaveButton_Click;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            //var originLocation = mapFragment.;

            Delivery delivery = new Delivery{
                Name = packageNamEditText.Text,
                Status = 0,
                OriginLatitude = latitude,
                OriginLongitude = longitude,
                DestinationLatitude = latitude,
                DestinationLongitude = longitude
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

            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(latitude,longitude),10 ));
        }

        protected override void OnResume()
        {
            base.OnResume();

            

            
                if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessFineLocation) ==
                    (int)Permission.Granted &&
                    ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessCoarseLocation) ==
                    (int)Permission.Granted)
                {
                    RequestLocationUpdates();
                }
                else
                {
                    //Toast.MakeText(this, "You do not have permission", ToastLength.Long).Show();
                    ActivityCompat.RequestPermissions(this, new String[] {
                            Manifest.Permission.AccessFineLocation,
                            Manifest.Permission.AccessCoarseLocation }, 1
                        );
                }
                
            

            //if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessNetworkState) ==
            //    (int)Permission.Granted)
            //{

            //}
            //var location = locationManager.GetLastKnownLocation(LocationManager.NetworkProvider);
            //latitude = location.Latitude;
            //longitude = location.Longitude;
            mapFragment.GetMapAsync(this);
            destinationMapFragment.GetMapAsync(this);
        }

        private void RequestLocationUpdates()
        {
            locationManager = GetSystemService(Context.LocationService) as LocationManager;
            string provider = LocationManager.GpsProvider;
            if (locationManager.IsProviderEnabled(provider))
            {
                locationManager.RequestLocationUpdates(provider, 5000, 100, this);
            }
        }

        public void OnLocationChanged(Location location)
        {
            //throw new NotImplementedException();
            latitude = location.Latitude;
            longitude = location.Longitude;
            mapFragment.GetMapAsync(this);
            destinationMapFragment.GetMapAsync(this);
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == 1)
            {
                RequestLocationUpdates();
            }
        }
    }
}