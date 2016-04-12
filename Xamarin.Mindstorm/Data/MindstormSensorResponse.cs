namespace Xamarin.Mindstorm.Data
{
    using Constants;

    public class MindstormSensorResponse
    {
        public bool IsValid { get; set; }

        public bool IsCalibrated { get; set; }

        public MindstormSensorType SensorType { get; set; }

        public MindstormSensorMode SensorMode { get; set; }

        public ushort Raw { get; set; }

        public ushort Normalized { get; set; }

        public short Scaled { get; set; }

        public short Calibrated { get; set; }
    }
}