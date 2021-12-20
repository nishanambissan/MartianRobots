using System;
using System.Collections.Generic;
using System.Text;
using MartianRobots.Models;
using Xunit;

namespace MartianRobotsTests
{
    public class GridTests
    {
        [Theory]
        [InlineData(5, 4)]
        [InlineData(-1, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 5)]
        public void ShouldIdentifyOffGridCoordsCorrectly(int x, int y)
        {
            var grid = new Grid("53");
            var newCoords = new CoOrdinate(x, y);
            Assert.True(grid.IsOffGrid(newCoords));
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(0, 0)]
        [InlineData(2, 2)]
        [InlineData(1, 0)]
        [InlineData(0, 3)]
        public void ShouldIdentifyOnGridCoordsCorrectly(int x, int y)
        {
            var grid = new Grid("53");
            var newCoords = new CoOrdinate(x, y);
            Assert.False(grid.IsOffGrid(newCoords));
        }
    }
}
