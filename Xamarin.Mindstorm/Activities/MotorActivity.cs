namespace Xamarin.Mindstorm.Activities
{
    using Android.App;
    using Android.OS;
    using Android.Widget;
    using Constants;
    using Infrastructure;
    using Services;

    [Activity(Label = "Motor", Theme = "@android:style/Theme.Holo.Light")]
    public class MotorActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Motor);

            var communicator = new MindstormCommunicator();

            communicator.Connect();

            var buttonTestSound = FindViewById<Button>(Resource.Id.ButtonTestSound);

            buttonTestSound.Click += (s, e) =>
            {
                var message = MindstormCommandService.GetToneMessage(3500, 1000);

                communicator.WriteMessage(message);
            };

            var buttonTestMotor = FindViewById<Button>(Resource.Id.ButtonTestMotor);

            buttonTestMotor.Click += (s, e) =>
            {
                var message = MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, 100, 100);

                communicator.WriteMessage(message);
            };

            var seekBarSpeed = FindViewById<SeekBar>(Resource.Id.SeekBarSpeed);

            seekBarSpeed.ProgressChanged += (s, e) =>
            {
                var speed = e.Progress;
                var message = MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, speed);

                communicator.WriteMessage(message);
            };

            var buttonStartMotor = FindViewById<Button>(Resource.Id.ButtonStartMotor);

            buttonStartMotor.Click += (s, e) =>
            {
                var speed = 50;
                seekBarSpeed.Progress = speed;

                var message = MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, speed);

                communicator.WriteMessage(message);
            };

            var buttonStopMotor = FindViewById<Button>(Resource.Id.ButtonStopMotor);

            buttonStopMotor.Click += (s, e) =>
            {
                seekBarSpeed.Progress = 0;
                var message = MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, 0);

                communicator.WriteMessage(message);
            };
        }
    }
}