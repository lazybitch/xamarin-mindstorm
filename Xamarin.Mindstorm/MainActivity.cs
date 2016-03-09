namespace Xamarin.Mindstorm
{
    using Android.App;
    using Android.OS;
    using Android.Widget;
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

            var button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                var message1 = MindstormCommandService.GetToneMessage(3500, 1000);

                communicator.WriteMessage(message1);
            };
        }
    }
}