using System.ComponentModel;

namespace MartianRobots.Models
{
    public enum Orientation
    {
        Default,

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