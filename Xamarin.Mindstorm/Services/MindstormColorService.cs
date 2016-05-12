namespace Xamarin.Mindstorm.Services
{
    using Constants;
    using Data;
    using Infrastructure;

    public class MindstormColorService
    {
        private readonly MindstormCommunicator communicator;

        public MindstormColorService()
        {
            communicator = new MindstormCommunicator();
            communicator.Connect();
        }

        public MindstormColorResponse GetColor(MindstormSensor sensor)
        {
            var result = new MindstormColorResponse
            {
                Red = GetValue(sensor, MindstormSensorType.ColorRed),
                Blue = GetValue(sensor, MindstormSensorType.ColorBlue),
                Green = GetValue(sensor, MindstormSensorType.ColorGreen)
            };

            return result;
        }

        private ushort GetValue(MindstormSensor sensor, MindstormSensorType sensorType)
        {
            var sensorModeMessage = MindstormCommandService.GetSensorModeMessage(
                sensor,
                sensorType,
                MindstormSensorMode.Raw);

            communicator.WriteAndReadMessage(sensorModeMessage);

            var readInputMessage = MindstormCommandService.GetSensorReadMessage(MindstormSensor.First);
            communicator.WriteMessage(readInputMessage);

            var readOutputMessage = communicator.ReadMessage();
            var sensorResponse = MindstormResponseService.GetSensorResponse(readOutputMessage);

            return sensorResponse.Raw;
        }
    }
}