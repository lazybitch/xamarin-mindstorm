namespace Xamarin.Mindstorm.Activities
{
    using System.Threading;
    using System.Threading.Tasks;
    using Android.App;
    using Android.OS;
    using Android.Widget;
    using Constants;
    using Infrastructure;
    using Services;

    [Activity(Label = "Motor", Theme = "@android:style/Theme.Holo.Light")]
    public class SensorActivity : Activity
    {
        private MindstormCommunicator communicator;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Sensor);

            communicator = new MindstormCommunicator();
            communicator.Connect();

            var sensorModeMessage = MindstormCommandService.GetSensorModeMessage(MindstormSensor.First, MindstormSensorType.Touch, MindstormSensorMode.Boolean);
            communicator.WriteMessage(sensorModeMessage);
            communicator.ReadMessage();

            var buttonTest = FindViewById<Button>(Resource.Id.ButtonTest);

            buttonTest.Click += (s, e) =>
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        var readInputMessage = MindstormCommandService.GetSensorReadMessage(MindstormSensor.First);
                        communicator.WriteMessage(readInputMessage);

                        var readOutputMessage = communicator.ReadMessage();

                        Thread.Sleep(100);
                    }
                });
            };
        }
    }
}