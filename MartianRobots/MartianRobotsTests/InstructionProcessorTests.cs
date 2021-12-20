using System;
using System.Collections.Generic;
using System.Text;
using MartianRobots.Models;
using MartianRobots.Services.Implementations;
using Xunit;

namespace MartianRobotsTests
{
    public class InstructionProcessorTests
    {
        //ideally I would write a specflow acceptance or an end to end test to cover this
        //for now, in the interests of time, am writing it as a unit test

        [Fact]
        public void ShouldReturnCorrectFinalPosition()
        {
            var instructionProcessor = new BasicInstructionProcessor();
            var grid = new Grid("53");
            var currentCoordinates = new CoOrdinate(1, 1);
            var currentPosition = new Position(currentCoordinates, Orientation.E);

            var result = instructionProcessor.Process(grid, currentPosition, "RFRFRFRF");

            Assert.Equal(1, result.CoOrdinate.X);
            Assert.Equal(1, result.CoOrdinate.Y);
            Assert.Equal(Orientation.E, result.Orientation);
        }

        [Fact]
        public void ShouldDetectLostRobotAndReportLastKnownGoodCoordinatesCorrectly()
        {
            var instructionProcessor = new BasicInstructionProcessor();
            var grid = new Grid("53");
            var currentCoordinates = new CoOrdinate(3, 2);
            var currentPosition = new Position(currentCoordinates, Orientation.N);

            var result = instructionProcessor.Process(grid, currentPosition, "FRRFLLFFRRFLL");

            Assert.Equal(3, result.CoOrdinate.X);
            Assert.Equal(3, result.CoOrdinate.Y);
            Assert.Equal(Orientation.N, result.Orientation);
            Assert.True(result.GetType() == typeof(LostPosition));
        }

        [Fact]
        public void ShouldDetectDangerousInstructionsAndIgnore()
        {
            var instructionProcessor = new BasicInstructionProcessor();
            var grid = new Grid("53");

            //setup to detect a dangerous position first 
            var currentCoordinates = new CoOrdinate(3, 2);
            var currentPosition = new Position(currentCoordinates, Orientation.N);

            instructionProcessor.Process(grid, currentPosition, "FRRFLLFFRRFLL");

            //33, N and F is a dangerous combination at this point


            currentCoordinates = new CoOrdinate(0, 3);
            currentPosition = new Position(currentCoordinates, Orientation.W);

            var result = instructionProcessor.Process(grid, currentPosition, "LLFFFLFLFL");

            Assert.Equal(2, result.CoOrdinate.X);
            Assert.Equal(3, result.CoOrdinate.Y);
            Assert.Equal(Orientation.S, result.Orientation);
        }
    }
}
