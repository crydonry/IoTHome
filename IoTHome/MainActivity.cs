using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Database;
using IoTHome.Activities;
using System;

namespace IoTHome
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        FirebaseDatabase database;
        Button btntestConnection;
        TextView clickTolightRGB;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            clickTolightRGB = (TextView)FindViewById(Resource.Id.tolightRGB);
            clickTolightRGB.Click += tolightRGB;
        }

        private void BtntestConnection_Click(object sender, System.EventArgs e)
        {
            Initializedatabase();
        }

        private void Initializedatabase()
        {


            var app = FirebaseApp.InitializeApp(this);

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()

                    .SetApplicationId("uber-clone-da636")
                    .SetApiKey("AIzaSyBpBjZCW6lj0r9KbfZ0ymvpzDziJvaJeu4")
                    .SetDatabaseUrl("https://uber-clone-da636.firebaseio.com")
                    .SetStorageBucket("uber-clone-da636.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(this, options);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }

            DatabaseReference dbref = database.GetReference("UserSupport");
            dbref.SetValue("Ticket1");

            Toast.MakeText(this, "Completed", ToastLength.Short).Show();
        }
        private void tolightRGB(object sender, EventArgs e)
        {
            StartActivity(typeof(ColorPickerActivity));
        }

    }
}