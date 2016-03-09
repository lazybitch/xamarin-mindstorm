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
    }
}