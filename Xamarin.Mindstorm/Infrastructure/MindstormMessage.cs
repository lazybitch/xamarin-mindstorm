namespace Xamarin.Mindstorm.Infrastructure
{
    public class MindstormMessage
    {
        public MindstormMessage(int size)
        {
            Payload = new byte[size];
        }

        public byte[] Payload { set; get; }
    }
}