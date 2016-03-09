namespace Xamarin.Mindstorm.Infrastructure
{
    using Constants;

    public static class MindstormCommandService
    {
        public static MindstormMessage GetToneMessage(int frequency, int duration)
        {
            var message = new MindstormMessage(6)
            {
                Payload =
                {
                    [0] = MindstormCommands.DirectCommandNoReply,
                    [1] = MindstormCommands.PlayTone,
                    [2] = (byte) frequency,
                    [3] = (byte) (frequency >> 8),
                    [4] = (byte) duration,
                    [5] = (byte) (duration >> 8)
                }
            };

            return message;
        }
    }
}