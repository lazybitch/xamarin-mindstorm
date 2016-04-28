namespace Xamarin.Mindstorm.Activities
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Android.App;
    using Android.OS;
    using Android.Widget;
    using Constants;
    using Infrastructure;
    using Services;

    [Activity(Label = "Ultrasonic", Theme = "@android:style/Theme.Holo.Light")]
    public class UltrasonicActivity : Activity
    {
        private MindstormCommunicator communicator;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Sensor);

            communicator = new MindstormCommunicator();
            communicator.Connect();

            var sensorModeMessage = MindstormCommandService.GetSensorModeMessage(MindstormSensor.Fourth, MindstormSensorType.Lowspeed9V, MindstormSensorMode.Boolean);
            communicator.WriteMessage(sensorModeMessage);
            communicator.ReadMessage();

            Thread.Sleep(500);

            var buttonTest = FindViewById<Button>(Resource.Id.ButtonTest);

            buttonTest.Click += (s, e) =>
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        var readInputMessage = MindstormCommandService.GetSensorReadMessage(MindstormSensor.Fourth);
                        communicator.WriteMessage(readInputMessage);
      
                        var readOutputMessage = communicator.ReadMessage();
                        var sensorResponse = MindstormResponseService.GetSensorResponse(readOutputMessage);

                        Console.WriteLine("{0} {1} {2} {3} ",
                            sensorResponse.Scaled,
                            sensorResponse.Raw,
                            sensorResponse.Normalized,
                            sensorResponse.Calibrated);

                        Thread.Sleep(100);
                    }
                });
            };
        }
    }
}