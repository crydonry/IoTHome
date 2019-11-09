using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using IoTHome.EventListeners;

namespace IoTHome.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class LoginActivity : AppCompatActivity
    {

        EditText emailText;
        EditText passwordText;
        TextView clickToRegisterText;
        Button loginButton;
        CoordinatorLayout rootView;
        FirebaseAuth mAuth;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.login);

            emailText = (EditText)FindViewById(Resource.Id.emailText);
            passwordText = (EditText)FindViewById(Resource.Id.passwordText);
            rootView = (CoordinatorLayout)FindViewById(Resource.Id.rootView);
            loginButton = (Button)FindViewById(Resource.Id.loginButton);
            clickToRegisterText = (TextView)FindViewById(Resource.Id.clickToRegisterText);

            clickToRegisterText.Click += ClickToRegisterText_Click;
            loginButton.Click += LoginButton_Click;

            InitializeFirebase();
        }

        private void ClickToRegisterText_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterationActivity));
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string email, password;

            email = emailText.Text;
            password = passwordText.Text;

            if (!email.Contains("@"))
            {
                
                Snackbar.Make(rootView, "Please provide a valid email", Snackbar.LengthShort).Show();
                return;
            }
            else if (password.Length < 8)
            {
                Snackbar.Make(rootView, "Please provide a valid password", Snackbar.LengthShort).Show();
                return;
            }

            TaskCompletionListener taskCompletionListener = new TaskCompletionListener();
            taskCompletionListener.Success += TaskCompletionListener_Success;
            taskCompletionListener.Failure += TaskCompletionListener_Failure;

            mAuth.SignInWithEmailAndPassword(email, password)
                .AddOnSuccessListener(taskCompletionListener)
                .AddOnFailureListener(taskCompletionListener);


        }

        private void TaskCompletionListener_Failure(object sender, EventArgs e)
        {
            Snackbar.Make(rootView, "Login Failed", Snackbar.LengthShort).Show();
        }

        private void TaskCompletionListener_Success(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        void InitializeFirebase()
        {
            var app = FirebaseApp.InitializeApp(this);

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()

                    .SetApplicationId("iothome-49684")
                    .SetApiKey("AIzaSyCSO0Od2tSBEt2Agm8-wQ-J7_x9I2bVPSM")
                    .SetDatabaseUrl("https://iothome-49684.firebaseio.com")
                    .SetStorageBucket("iothome-49684.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(this, options);
                mAuth = FirebaseAuth.Instance;
            }
            else
            {
                mAuth = FirebaseAuth.Instance;
            }


        }

    }
}