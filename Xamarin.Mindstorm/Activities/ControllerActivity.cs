namespace Xamarin.Mindstorm.Activities
{
    using Android.App;
    using Android.OS;

    [Activity(Label = "Controller", Theme = "@android:style/Theme.Holo.Light")]
    public class ControllerActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Controller);
        }
    }
}