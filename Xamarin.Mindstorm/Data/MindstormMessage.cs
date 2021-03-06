namespace Xamarin.Mindstorm.Data
{
    public class MindstormMessage
    {
        public MindstormMessage(int size)
        {
            Payload = new byte[size];
        }

        public byte[] Payload { set; get; }

        public override string ToString()
        {
            var result = string.Join(" ", Payload);

            return result;
        }
    }
}