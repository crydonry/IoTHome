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
using Firebase.Auth;
using Firebase.Database;
using Firebase;
using Java.Util;
using System;

namespace IoTHome.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class ColorPickerActivity : Activity
    {
        SeekBar seekBarRed;
        TextView textViewRed;
        SeekBar seekBarBlue;
        TextView textViewBlue;
        SeekBar seekBarGreen;
        TextView textViewGreen;

        Button btnChangeColor;
        int redvalue = 0;
        int bluevalue = 0;
        int greenvalue = 0;
        FirebaseDatabase database;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
   

            SetContentView(Resource.Layout.lightRGB);

            btnChangeColor = (Button)FindViewById(Resource.Id.btnChangeColor);

            btnChangeColor.Click += BtntestConnection_Click ;


            seekBarRed = (SeekBar)FindViewById(Resource.Id.seekBarRed);
            textViewRed = (TextView)FindViewById(Resource.Id.textViewRed);
            seekBarRed.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
                if (e.FromUser)
                {
                    textViewRed.Text = string.Format("Red = {0}", e.Progress);
                    redvalue = e.Progress;
                }
            };

            seekBarBlue = (SeekBar)FindViewById(Resource.Id.seekBarBlue);
            textViewBlue = (TextView)FindViewById(Resource.Id.textViewBlue);
            seekBarBlue.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
                if (e.FromUser)
                {
                    textViewBlue.Text = string.Format("Blue = {0}", e.Progress);
                    bluevalue = e.Progress;
                }
            };

            seekBarGreen = (SeekBar)FindViewById(Resource.Id.seekBarGreen);
            textViewGreen = (TextView)FindViewById(Resource.Id.textViewGreen);
            seekBarGreen.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
                if (e.FromUser)
                {
                    textViewGreen.Text = string.Format("Green = {0}", e.Progress);
                    greenvalue = e.Progress;

                }
            };
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

            DatabaseReference red = database.GetReference("LED/red");
            red.SetValue(redvalue);

            DatabaseReference blue = database.GetReference("LED/blue");
            blue.SetValue(bluevalue);

            DatabaseReference green = database.GetReference("LED/green");
            green.SetValue(greenvalue);

            Toast.MakeText(this, "Completed", ToastLength.Short).Show();
        }

    }
}