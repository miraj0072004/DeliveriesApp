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
using DeliveriesModels;

namespace DeliveriesApp
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        private EditText emailEditText, passwordEditText, confirmPasswordEditText;
        private Button registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            emailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.registerConfirmPasswordEditText);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            registerButton.Click += RegisterButton_Click;

            string email = Intent.GetStringExtra("email");
            emailEditText.Text = email;
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            if (await User.Register(emailEditText.Text,passwordEditText.Text,confirmPasswordEditText.Text))
            {
                Toast.MakeText(this, "Success", ToastLength.Long).Show();
                return;
            }
            Toast.MakeText(this, "There was an error, Please try again", ToastLength.Long).Show();
            
        }
    }
}