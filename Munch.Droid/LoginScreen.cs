
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

namespace Munch
{
    [Activity(Label = "LoginScreen", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/android:Theme.Holo.Light.NoActionBar")]
    public class LoginScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.LoginScreen);
            Button login = FindViewById<Button>(Resource.Id.login);

            login.Click += (object sender, EventArgs e) =>
                Android.Widget.Toast.MakeText(this, "Login Button Clicked!", Android.Widget.ToastLength.Short).Show();
        }
    }
}