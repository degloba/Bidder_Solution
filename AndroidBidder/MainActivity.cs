using Android.App;
using Android.Widget;
using Android.OS;

//using Android.Gms.Common;

//using Firebase.Messaging;
//using Firebase.Iid;
using Android.Util;


namespace AndroidBidder
{
    [Activity(Label = "AndroidBidder", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        TextView msgText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            msgText = FindViewById<TextView>(Resource.Id.msgText);
            //IsPlayServicesAvailable();
        }


        //public bool IsPlayServicesAvailable()
        //{
        //    int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
        //    if (resultCode != ConnectionResult.Success)
        //    {
        //        if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
        //            msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
        //        else
        //        {
        //            msgText.Text = "This device is not supported";
        //            Finish();
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        msgText.Text = "Google Play Services is available.";
        //        return true;
        //    }
        //}

    }
}

