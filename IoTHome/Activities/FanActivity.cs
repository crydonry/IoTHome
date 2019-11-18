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
    public class FanActivity : Activity
    {
        FirebaseDatabase database;

        Switch swithchBtnPower;
        Switch SwitchFan1;
        Switch SwitchFan2;
        Switch SwitchFan3;

        Button btnFan;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource


            SetContentView(Resource.Layout.FanControl);


            btnFan = (Button)FindViewById(Resource.Id.btnFan);

            btnFan.Click += ConnectionFan_Click;





        }

        private void ConnectionFan_Click(object sender, System.EventArgs e)
        {
            Initializedatabase();
        }

        private void Initializedatabase()
        {

            swithchBtnPower = (Switch)FindViewById(Resource.Id.PowerSwitch);
            swithchBtnPower.CheckedChange += (s, b) =>
            {
                bool isChecked = b.IsChecked;
                if (isChecked)
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

                    DatabaseReference red = database.GetReference("IoT/Fan/power");
                    red.SetValue("1");
                    Toast.MakeText(this, "Power is On", ToastLength.Short).Show();
                }
                else
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

                    DatabaseReference red = database.GetReference("IoT/Fan/power");
                    red.SetValue("0");
                    Toast.MakeText(this, "Power is Off", ToastLength.Short).Show();
                }


            };

            SwitchFan1 = (Switch)FindViewById(Resource.Id.SwitchFan1);
            
            SwitchFan1.CheckedChange += (s, b) =>
            {
                bool isChecked = b.IsChecked;
                if (isChecked)
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

                    DatabaseReference red = database.GetReference("IoT/Fan/lowpower");
                    red.SetValue("1");
                    Toast.MakeText(this, "LowPower is On", ToastLength.Short).Show();
                }
                else
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

                    DatabaseReference red = database.GetReference("IoT/Fan/lowpower");
                    red.SetValue("0");
                    Toast.MakeText(this, "LowPower is Off", ToastLength.Short).Show();
                }


            };

            SwitchFan2 = (Switch)FindViewById(Resource.Id.SwitchFan2);
            SwitchFan2.CheckedChange += (s, b) =>
            {
                bool isChecked = b.IsChecked;
                if (isChecked)
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

                    DatabaseReference red = database.GetReference("IoT/Fan/midpower");
                    red.SetValue("1");
                    Toast.MakeText(this, "Midpower is On", ToastLength.Short).Show();
                }
                else
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

                    DatabaseReference red = database.GetReference("IoT/Fan/midpower");
                    red.SetValue("0");
                    Toast.MakeText(this, "Midpower is Off", ToastLength.Short).Show();
                }


            };

            SwitchFan3 = (Switch)FindViewById(Resource.Id.SwitchFan3);
            SwitchFan3.CheckedChange += (s, b) =>
            {
                bool isChecked = b.IsChecked;
                if (isChecked)
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

                    DatabaseReference red = database.GetReference("IoT/Fan/highpower");
                    red.SetValue("1");
                    Toast.MakeText(this, "Highpower is On", ToastLength.Short).Show();
                }
                else
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

                    DatabaseReference red = database.GetReference("IoT/Fan/highpower");
                    red.SetValue("0");
                    Toast.MakeText(this, "Highpower is Off", ToastLength.Short).Show();
                }


            };
        }


    }
}
