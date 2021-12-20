using System;
using System.Collections.Generic;
using System.Text;
using MartianRobots.Extensions;
using MartianRobots.Models;
using Xunit;

namespace MartianRobotsTests
{
    public class CoorindinateExtensionTests
    {
        [Theory]
        [InlineData(0, 0, Orientation.N, 0, 1)]
        [InlineData(3, 3, Orientation.E, 4, 3)]
        [InlineData(0, 2, Orientation.S, 0, 1)]
        [InlineData(1, 2, Orientation.W, 0, 2)]
        [InlineData(0, 0, Orientation.W, -1, 0)]
        //TODO - add more variety of test cases
        public void MoveForwardShouldReturnCorrectCoordinates(int X, int Y, Orientation currentOrientation, int newX, int newY)
        {
            var coord = new CoOrdinate(X, Y);
            var newCoord = coord.MoveForward(currentOrientation);
            Assert.Equal(newX, newCoord.X);
            Assert.Equal(newY, newCoord.Y);
        }
    }
}
