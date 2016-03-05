namespace Xamarin.Mindstorm
{
    using Android.App;
    using Android.OS;

    [Activity(Label = "Xamarin.Mindstorm", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
        }
    }
}