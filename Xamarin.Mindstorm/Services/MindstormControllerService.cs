namespace Xamarin.Mindstorm.Services
{
    using Constants;
    using Infrastructure;

    public class MindstormControllerService
    {
        private const int ZeroSpeed = 0;
        private const int FullSpeed = 50;
        private const int HallfSpeed = 25;

        private readonly MindstormCommunicator communicator;

        public MindstormControllerService()
        {
            communicator = new MindstormCommunicator();
            communicator.Connect();

            var sensorModeMessage = MindstormCommandService.GetSensorModeMessage(
                MindstormSensor.First,
                MindstormSensorType.Touch,
                MindstormSensorMode.Boolean);

            communicator.WriteMessage(sensorModeMessage);
            communicator.ReadMessage();
        }

        public bool IsMovementAllowed()
        {
            var readInputMessage = MindstormCommandService.GetSensorReadMessage(MindstormSensor.First);
            communicator.WriteMessage(readInputMessage);

            var readOutputMessage = communicator.ReadMessage();
            var sensorResponse = MindstormResponseService.GetSensorResponse(readOutputMessage);

            return sensorResponse.Scaled == 0;
        }

        public void ProcessBreak()
        {
            if (IsMovementAllowed())
            {
                return;
            }

            communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, ZeroSpeed));
            communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorB, ZeroSpeed));
        }

        public void ProcessMovement(MindstormMovement movement)
        {
            switch (movement)
            {
                case MindstormMovement.None:
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, ZeroSpeed));
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorB, ZeroSpeed));
                    break;

                case MindstormMovement.Forward | MindstormMovement.Left:
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, HallfSpeed));
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorB, FullSpeed));
                    break;

                case MindstormMovement.Forward | MindstormMovement.Right:
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, FullSpeed));
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorB, HallfSpeed));
                    break;

                case MindstormMovement.Forward:
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, FullSpeed));
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorB, FullSpeed));
                    break;

                case MindstormMovement.Left:
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, ZeroSpeed));
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorB, FullSpeed));
                    break;

                case MindstormMovement.Right:
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorA, FullSpeed));
                    communicator.WriteMessage(MindstormCommandService.GetMotorMessage(MindstormComponents.MotorB, ZeroSpeed));
                    break;
            }
        }
    }
}