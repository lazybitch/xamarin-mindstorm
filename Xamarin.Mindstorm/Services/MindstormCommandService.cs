namespace Xamarin.Mindstorm.Services
{
    using Constants;
    using Data;

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

            var message = new MindstormMessage(12)
            {
                Payload =
                {
                    [0] = MindstormCommands.DirectCommandNoReply,
                    [1] = MindstormCommands.SetOutputState,
                    [2] = (byte) motor
                }
            };

            if (speed == 0)
            {
                message.Payload[3] = 0;
                message.Payload[4] = 0;
                message.Payload[5] = 0;
                message.Payload[6] = 0;
                message.Payload[7] = 0;
            }
            else
            {
                message.Payload[3] = (byte) speed;
                message.Payload[4] = MindstormCommands.MotorOn + MindstormCommands.Brake;
                message.Payload[5] = MindstormCommands.RegulationModeMotorSpeed;
                message.Payload[6] = 0x00;
                message.Payload[7] = MindstormCommands.MotorRunStateRunning;
            }

            message.Payload[8] = (byte) step;
            message.Payload[9] = (byte) (step >> 8);
            message.Payload[10] = (byte) (step >> 16);
            message.Payload[11] = (byte) (step >> 24);

            return message;
        }

        public static MindstormMessage GetMotorMessage(int motor, int speed)
        {
            return GetMotorMessage(motor, speed, 0);
        }

        public static MindstormMessage GetResetMessage(int motor)
        {
            var message = new MindstormMessage(4)
            {
                Payload =
                {
                    [0] = MindstormCommands.DirectCommandNoReply,
                    [1] = MindstormCommands.ResetMotorPosition,
                    [2] = (byte) motor,
                    [3] = 0
                }
            };

            return message;
        }

        public static MindstormMessage GetSensorReadMessage(MindstormSensor sensor)
        {
            var message = new MindstormMessage(3)
            {
                Payload =
                {
                    [0] = MindstormCommands.DirectCommandReply,
                    [1] = MindstormCommands.ReadSensor,
                    [2] = (byte) sensor
                }
            };

            return message;
        }

        public static MindstormMessage GetSensorModeMessage(MindstormSensor sensor, MindstormSensorType type, MindstormSensorMode mode)
        {
            var message = new MindstormMessage(5)
            {
                Payload =
                {
                    [0] = MindstormCommands.DirectCommandReply,
                    [1] = MindstormCommands.SetSensorMode,
                    [2] = (byte) sensor,
                    [3] = (byte) type,
                    [4] = (byte) mode
                }
            };

            return message;
        }
    }
}