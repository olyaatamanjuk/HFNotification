﻿using Android.App;
using Android.Gms.Common;
using Android.Net;
using Android.OS;
using Android.Widget;
using Android.Util;


namespace HFNotification
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        const string TAG = "MainActivity";
        TextView msgText;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Check if Internet is available
            if (isOnline())
            {
                // code here
            }
            else
            {
                // code
                //MessageBox.Show("Internet connections are not available");
            }
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Test if GPS is available
            msgText = FindViewById<TextView>(Resource.Id.msgText);

            IsPlayServicesAvailable();
        }


        //Check if Internet is available
        public bool isOnline()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            return (activeConnection != null) && activeConnection.IsConnected;
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    msgText.Text = "Sorry, this device is not supported";
                    Finish();
                }
                return false;
            }
            else
            {
                msgText.Text = "Google Play Services is available.";
                return true;
            }
        }


    }
}