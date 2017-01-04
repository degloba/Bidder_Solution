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

        const string TAG = "MainActivity";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            msgText = FindViewById<TextView>(Resource.Id.msgText);


            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                }
            }



            IsPlayServicesAvailable();



            // Tokens Firebase - Messaging
            var logTokenButton = FindViewById<Button>(Resource.Id.logTokenButton);
            logTokenButton.Click += delegate {
                Log.Debug(TAG, "InstanceID token: " + FirebaseInstanceId.Instance.Token);

                Log.Debug(TAG, "google app id: " + Resource.String.google_app_id);
            };


            // Subscribe to a Topic
            var subscribeButton = FindViewById<Button>(Resource.Id.subscribeButton);
            subscribeButton.Click += delegate {
                FirebaseMessaging.Instance.SubscribeToTopic("news");
                Log.Debug(TAG, "Subscribed to remote notifications");
            };


        }


        // https://iid.googleapis.com/iid/v1/IID_TOKEN/rel/topics/TOPIC_NAME
        // https://iid.googleapis.com/iid/v1/f7a7joMMZ2o:APA91bEVtjyAOXLtjXX4Nz2nK4--cXnZB8i9cTdXH8BtjVAVhGXfHTY7D3rqBXps3zoh6Jix8YppmIi3dXW14KfqWnj7QLlOWd_s4DSwASetrfoZMuTt8DBFPBZZLSeFMnguOAYQaBCb/rel/topics/news

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                { 
                    msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                    
                    string A = GoogleApiAvailability.Instance.GetOpenSourceSoftwareLicenseInfo(this);
                    GoogleApiAvailability.Instance.GetErrorDialog(this,resultCode,  1).Show();



                }

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

