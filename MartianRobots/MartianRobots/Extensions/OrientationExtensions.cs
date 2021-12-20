using MartianRobots.Models;

namespace MartianRobots.Extensions
{
    public static class OrientationExtensions
    {
        public static Orientation GetLeft(this Orientation duration)
        {
            switch (duration)
            {
                case Orientation.E: return Orientation.N;
                case Orientation.N: return Orientation.W;
                case Orientation.W: return Orientation.S;
                case Orientation.S: return Orientation.E;
                default: return Orientation.Default;
            }
        }

        public static Orientation GetRight(this Orientation duration)
        {
            switch (duration)
            {
                case Orientation.N: return Orientation.E;
                case Orientation.E: return Orientation.S;
                case Orientation.S: return Orientation.W;
                case Orientation.W: return Orientation.N;
                default: return Orientation.Default;
            }
        }
    }
}