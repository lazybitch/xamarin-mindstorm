namespace Xamarin.Mindstorm.Activities
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Widget;

    [Activity(MainLauncher = true, Label = "Xamarin Mindstorm", Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var buttonTestMotor = FindViewById<Button>(Resource.Id.ButtonMotorTest);

            buttonTestMotor.Click += (s, e) =>
            {
                var intent = new Intent(this, typeof (MotorActivity));

                StartActivity(intent);
            };

            var buttonMotorController = FindViewById<Button>(Resource.Id.ButtonMotorController);

            buttonMotorController.Click += (s, e) =>
            {
                var intent = new Intent(this, typeof (ControllerActivity));

                StartActivity(intent);
            };

            var buttonSensorTest = FindViewById<Button>(Resource.Id.ButtonSensorTest);

            buttonSensorTest.Click += (s, e) =>
            {
                var intent = new Intent(this, typeof (SensorActivity));

                StartActivity(intent);
            };
        }
    }
}