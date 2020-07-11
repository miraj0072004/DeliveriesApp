using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace DeliveriesApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText emailEditText;
        EditText passwordEditText;
        Button signinButton;
        Button registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            registerButton = FindViewById<Button>(Resource.Id.loginRegisterButton);

            signinButton.Click += SigninButton_Click;
            registerButton.Click += RegisterButton_Click;



        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            
        }

        private void SigninButton_Click(object sender, System.EventArgs e)
        {
            
        }

        //private void HelloButton_Click(object sender, System.EventArgs e)
        //{
        //    Toast.MakeText(this,$"Hello {namEditText.Text}", ToastLength.Long).Show();
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}