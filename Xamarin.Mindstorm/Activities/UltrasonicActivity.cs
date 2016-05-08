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

            var sensorModeMessage = MindstormCommandService.GetSensorModeMessage(MindstormSensor.First, MindstormSensorType.Lowspeed9V, MindstormSensorMode.Raw);
            communicator.WriteMessage(sensorModeMessage);
            communicator.ReadMessage();

            Thread.Sleep(500);

            var buttonTest = FindViewById<Button>(Resource.Id.ButtonTest);

            buttonTest.Click += (s, e) =>
            {
                Thread.Sleep(500);

                Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(100);

                        var writeMsg = MindstormCommandService.GetLowSpeedWriteMessage(MindstormSensor.First);
                        communicator.WriteAndReadMessage(writeMsg);

                        Thread.Sleep(100);

                        var statusMsg = MindstormCommandService.GetLowSpeedStatusMessage(MindstormSensor.First);
                        var statusMsgRaw = communicator.WriteAndReadMessage(statusMsg);
                        var statusMsgResponse = MindstormResponseService.GetStatusResponse(statusMsgRaw);

                        Thread.Sleep(100);

                        if (!statusMsgResponse.IsReady)
                        {
                            continue;
                        }

                        var readMsg = MindstormCommandService.GetLowSpeedReadMessage(MindstormSensor.First);
                        var readMsgRaw = communicator.WriteAndReadMessage(readMsg);

                        Console.WriteLine(readMsgRaw.ToString());
                    }
                });
            };
        }
    }
}