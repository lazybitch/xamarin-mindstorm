namespace Xamarin.Mindstorm.Services
{
    using System;
    using Constants;
    using Data;

    public class MindstormResponseService
    {
        public static MindstormSensorResponse GetSensorResponse(MindstormMessage message)
        {
            if (message == null || message.Payload.Length != 18)
            {
                throw new ArgumentException("Invalid message.");
            }

            var result = new MindstormSensorResponse
            {
                IsValid = message.Payload[6] != 0,
                IsCalibrated = message.Payload[7] != 0,
                SensorType = (MindstormSensorType) message.Payload[8],
                SensorMode = (MindstormSensorMode) message.Payload[9],
                Raw = (ushort) (message.Payload[10] | (uint) message.Payload[11] << 8),
                Normalized = (ushort) (message.Payload[12] | (uint) message.Payload[13] << 8),
                Scaled = (short) (message.Payload[14] | message.Payload[15] << 8),
                Calibrated = (short) (message.Payload[16] | message.Payload[17] << 8)
            };

            return result;
        }
    }
}