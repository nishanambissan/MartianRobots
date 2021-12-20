using System.ComponentModel;

namespace MartianRobots.Models
{
    public enum Orientation
    {
        [Description("East")]
        E,

        [Description("West")]
        W,

        [Description("North")]
        N,

        [Description("South")]
        S
    }
}