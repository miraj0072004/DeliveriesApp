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

namespace DeliveryPersonApp
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        private EditText emailEditText, passwordEditText, confirmPasswordEditText;
        private Button  registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register);

            emailEditText = FindViewById<EditText>(Resource.Id.registerEmail);
            passwordEditText = FindViewById<EditText>(Resource.Id.registerPassword);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.registerConfirmPassword);
            registerButton = FindViewById<Button>(Resource.Id.registerSaveButton);

            registerButton.Click += RegisterButton_Click;
            // Create your application here
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}