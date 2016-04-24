namespace Xamarin.Mindstorm.Services
{
    using System;
    using Constants;
    using Data;

    public class MindstormResponseService
    {
        public static MindstormSensorResponse GetSensorResponse(MindstormMessage message)
        {
            if (message == null || message.Payload.Length != 16)
            {
                throw new ArgumentException("Invalid message.");
            }

            var result = new MindstormSensorResponse
            {
                IsValid = message.Payload[4] != 0,
                IsCalibrated = message.Payload[5] != 0,
                SensorType = (MindstormSensorType) message.Payload[6],
                SensorMode = (MindstormSensorMode) message.Payload[7],
                Raw = (ushort) (message.Payload[8] | (uint) message.Payload[9] << 8),
                Normalized = (ushort) (message.Payload[10] | (uint) message.Payload[11] << 8),
                Scaled = (short) (message.Payload[12] | message.Payload[13] << 8),
                Calibrated = (short) (message.Payload[14] | message.Payload[15] << 8)
            };

            return result;
        }
    }
}