namespace Xamarin.Mindstorm.Infrastructure
{
    using System.IO;
    using System.Linq;
    using Android.Bluetooth;
    using Java.Util;

    public class MindstormCommunicator
    {
        private const string DeviceName = "NXT";
        private const string SppId = "00001101-0000-1000-8000-00805F9B34FB";

        private BluetoothSocket socket;

        public void Connect()
        {
            var adapter = BluetoothAdapter.DefaultAdapter;
            var device = adapter.BondedDevices
                .FirstOrDefault(o => o.Name == DeviceName);

            if (device == null)
            {
                throw new IOException("Mindstorm Communicator - device not found.");
            }

            socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString(SppId));
            socket.Connect();

            if (!socket.IsConnected)
            {
                throw new IOException("Mindstorm Communicator - connection was not opened correctly.");
            }
        }

        public void Disconnect()
        {
            socket.Close();
        }

        public void WriteMessage(MindstormMessage message)
        {
            if (socket == null || !socket.IsConnected || socket.OutputStream == null)
            {
                throw new IOException("Mindstor communication - output socket error.");
            }

            socket.OutputStream.Write(message.Payload, 0, message.Payload.Length);
        }
    }
}