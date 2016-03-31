namespace Xamarin.Mindstorm.Constants
{
    using System;

    [Flags]
    public enum MindstormMovement
    {
        None = 0,

        Forward = 1,

        Left = 2,

        Right = 4,

        Stop = 8
    }
}