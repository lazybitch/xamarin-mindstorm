namespace Xamarin.Mindstorm
{
    using Android.App;
    using Android.OS;
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
            communicator.Disconnect();
        }
    }
}