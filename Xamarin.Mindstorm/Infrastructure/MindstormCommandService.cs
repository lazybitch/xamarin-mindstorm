namespace Xamarin.Mindstorm.Infrastructure
{
    using Constants;

    public static class MindstormCommandService
    {
        public static MindstormMessage GetToneMessage(int frequency, int duration)
        {
            var message = new MindstormMessage(8)
            {
                Payload =
                {
                    [0] = 6,
                    [1] = 0,
                    [2] = MindstormCommands.DirectCommandNoReply,
                    [3] = MindstormCommands.PlayTone,
                    [4] = (byte) frequency,
                    [5] = (byte) (frequency >> 8),
                    [6] = (byte) duration,
                    [7] = (byte) (duration >> 8)
                }
            };

            return message;
        }
    }
}