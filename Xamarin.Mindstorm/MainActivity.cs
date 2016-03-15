namespace Xamarin.Mindstorm
{
    using Android.App;
    using Android.OS;
    using Android.Widget;
    using Constants;
    using Infrastructure;

    [Activity(Label = "Xamarin.Mindstorm", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var communicator = new MindstormCommunicator();

            communicator.Connect();

            var buttonTestSound = FindViewById<Button>(Resource.Id.ButtonTestSound);

            buttonTestSound.Click += (s, e) =>
            {
                var message1 = MindstormCommandService.GetToneMessage(3500, 1000);

                communicator.WriteMessage(message1);
            };

            var buttonTestMotor = FindViewById<Button>(Resource.Id.ButtonTestMotor);

            buttonTestMotor.Click += (s, e) =>
            {
                var message1 = MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, 100, 100);

                communicator.WriteMessage(message1);
            };
        }
    }
}