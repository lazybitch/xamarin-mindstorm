namespace Xamarin.Mindstorm.Activities
{
    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using Constants;
    using Services;

    [Activity(Label = "Controller", Theme = "@android:style/Theme.Holo.Light")]
    public class ControllerActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Controller);

            var controllerService = new MindstormControllerService();

            FindViewById<ImageButton>(Resource.Id.ButtonForward).Touch += (s, e) =>
            {
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        controllerService.ProcessMovement(MindstormMovement.Forward);
                        break;
                    case MotionEventActions.Up:
                        controllerService.ProcessMovement(MindstormMovement.None);
                        break;
                }
            };

            FindViewById<ImageButton>(Resource.Id.ButtonForwardLeft).Touch += (s, e) =>
            {
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        controllerService.ProcessMovement(MindstormMovement.Forward | MindstormMovement.Left);
                        break;
                    case MotionEventActions.Up:
                        controllerService.ProcessMovement(MindstormMovement.None);
                        break;
                }
            };

            FindViewById<ImageButton>(Resource.Id.ButtonLeft).Touch += (s, e) =>
            {
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        controllerService.ProcessMovement(MindstormMovement.Left);
                        break;
                    case MotionEventActions.Up:
                        controllerService.ProcessMovement(MindstormMovement.None);
                        break;
                }
            };

            FindViewById<ImageButton>(Resource.Id.ButtonForwardRight).Touch += (s, e) =>
            {
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        controllerService.ProcessMovement(MindstormMovement.Forward | MindstormMovement.Right);
                        break;
                    case MotionEventActions.Up:
                        controllerService.ProcessMovement(MindstormMovement.None);
                        break;
                }
            };

            FindViewById<ImageButton>(Resource.Id.ButtonRight).Touch += (s, e) =>
            {
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        controllerService.ProcessMovement(MindstormMovement.Right);
                        break;
                    case MotionEventActions.Up:
                        controllerService.ProcessMovement(MindstormMovement.None);
                        break;
                }
            };
        }
    }
}