namespace Xamarin.Mindstorm.Infrastructure
{
    using System;
    using System.IO;
    using System.Linq;
    using Android.Bluetooth;
    using Data;
    using Java.Util;

    public class MindstormCommunicator
    {
        private const string DeviceName = "NXT";
        private const string SppId = "00001101-0000-1000-8000-00805F9B34FB";

        private readonly byte[] buffer = new byte[1024];

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

            var header = new byte[]
            {
                (byte) message.Payload.Length,
                0
            };

            socket.OutputStream.Write(header, 0, header.Length);
            socket.OutputStream.Write(message.Payload, 0, message.Payload.Length);
        }

        public MindstormMessage ReadMessage()
        {
            if (socket == null || !socket.IsConnected || socket.InputStream == null)
            {
                throw new IOException("Mindstor communication - input socket error.");
            }

            var length = socket.InputStream.Read(buffer, 0, buffer.Length);
            var result = new MindstormMessage(length);

            Array.Copy(buffer, 0, result.Payload, 0, length);

            return result;
        }
    }
}