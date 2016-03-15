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

        public static MindstormMessage GetMotorMessage(int motor, int speed, int step)
        {
            if (speed > 100)
            {
                speed = 100;
            }

            if (speed < -100)
            {
                speed = -100;
            }

            var message = new MindstormMessage(14)
            {
                Payload =
                {
                    [0] = 12,
                    [1] = 0,
                    [2] = MindstormCommands.DirectCommandNoReply,
                    [3] = MindstormCommands.SetOutputState,
                    [4] = (byte) motor
                }
            };

            if (speed == 0)
            {
                message.Payload[5] = 0;
                message.Payload[6] = 0;
                message.Payload[7] = 0;
                message.Payload[8] = 0;
                message.Payload[9] = 0;
            }
            else
            {
                message.Payload[5] = (byte) speed;
                message.Payload[6] = MindstormCommands.MotorOn + MindstormCommands.Brake;
                message.Payload[7] = MindstormCommands.RegulationModeMotorSpeed;
                message.Payload[8] = 0x00;
                message.Payload[9] = MindstormCommands.MotorRunStateRunning;
            }

            message.Payload[10] = (byte) step;
            message.Payload[11] = (byte) (step >> 8);
            message.Payload[12] = (byte) (step >> 16);
            message.Payload[13] = (byte) (step >> 24);

            return message;
        }
    }
}