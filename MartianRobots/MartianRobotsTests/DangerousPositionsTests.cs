using System;
using System.Collections.Generic;
using System.Text;
using MartianRobots.Models;
using Xunit;

namespace MartianRobotsTests
{
    public class DangerousPositionsTests
    {
        Grid grid;

        public DangerousPositionsTests()
        {
            grid = new Grid("53");
        }

        [Fact]
        public void ShouldBeAbleToIdentifyDangerousInstructionsFromPastSuccessfully_SimilarPosition()
        {
            grid.RecordDangerousPositionAndInstruction(new Position(new CoOrdinate(3, 3), Orientation.N), "F");

            var currentPosition = new Position(new CoOrdinate(3, 3), Orientation.N);
            var result = grid.IsThisDangerous(currentPosition, "F");

            Assert.True(result);
        }

        [Fact]
        public void ShouldBeAbleToIdentifyDangerousInstructionsFromPastSuccessfully_SamePosition()
        {
            var currentPosition = new Position(new CoOrdinate(3, 3), Orientation.N);
            grid.RecordDangerousPositionAndInstruction(currentPosition, "F");
            var result = grid.IsThisDangerous(currentPosition, "F");

            Assert.True(result);
        }
    }
}
