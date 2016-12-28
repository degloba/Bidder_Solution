using Android.App;
using Android.Widget;
using Android.OS;

using Android.Gms.Common;

using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;


namespace AndroidBidder
{
    [Activity(Label = "AndroidBidder", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 0;
        TextView msgText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            msgText = FindViewById<TextView>(Resource.Id.msgText);
            IsPlayServicesAvailable();
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
                    msgText.Text = "This device is not supported";
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

