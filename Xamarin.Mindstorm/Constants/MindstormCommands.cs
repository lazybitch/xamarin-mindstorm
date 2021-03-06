namespace Xamarin.Mindstorm.Constants
{
    public static class MindstormCommands
    {
        // Direct headers
        public const byte DirectCommandReply = 0x00;
        public const byte DirectCommandNoReply = 0x80;

        // Direct commands
        public const byte PlayTone = 0x03;
        public const byte SetOutputState = 0x04;
        public const byte ResetMotorPosition = 0x0A;
        public const byte ReadSensor = 0x07;
        public const byte SetSensorMode = 0x05;

        // Regulation modes
        public const byte RegulationModeMotorSpeed = 0x01;

        // MotorRunStates
        public const byte MotorOn = 0x01;
        public const byte Brake = 0x02;
        public const byte MotorRunStateRunning = 0x20;

        // Low Speed Bus
        public const byte LowSpeedWrite = 0x0F;
        public const byte LowSpeedStatus = 0x0E;
        public const byte LowSpeedRead = 0x10;
    }
}