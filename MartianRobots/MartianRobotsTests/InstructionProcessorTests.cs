using System;
using MartianRobots.Extensions;
using MartianRobots.Models;
using Xunit;

namespace MartianRobotsTests
{
    public class OrientationExtensionTests
    {
        [Theory]
        [InlineData(Orientation.N, Orientation.E)]
        [InlineData(Orientation.E, Orientation.S)]
        [InlineData(Orientation.S, Orientation.W)]
        [InlineData(Orientation.W, Orientation.N)]
        public void GetRightShouldReturnCorrectOrientation(Orientation orientation, Orientation expectedResultOrientation)
        {
            Assert.Equal(expectedResultOrientation, orientation.GetRight());
        }

        [Theory]
        [InlineData(Orientation.N, Orientation.W)]
        [InlineData(Orientation.W, Orientation.S)]
        [InlineData(Orientation.S, Orientation.E)]
        [InlineData(Orientation.E, Orientation.N)]
        public void GetLeftShouldReturnCorrectOrientation(Orientation orientation, Orientation expectedResultOrientation)
        {
            Assert.Equal(expectedResultOrientation, orientation.GetLeft());
        }
    }
}
