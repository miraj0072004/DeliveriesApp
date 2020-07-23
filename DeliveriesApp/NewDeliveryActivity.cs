using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DeliveriesApp
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity
    {
        private Button saveButton;
        private EditText packageNamEditText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);

            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            packageNamEditText = FindViewById<EditText>(Resource.Id.packageNameEditText);

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
    }
}