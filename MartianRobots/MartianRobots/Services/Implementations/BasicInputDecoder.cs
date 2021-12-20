using System;
using System.Linq;
using MartianRobots.Models;
using MartianRobots.Services.Interfaces;

namespace MartianRobots.Services.Implementations
{
    public class BasicInputDecoder : IInputDecoder
    {
        private readonly IInstructionProcessor _instructionProcessor;

        public BasicInputDecoder(IInstructionProcessor instructionProcessor)
        {
            _instructionProcessor = instructionProcessor;
        }

        public void Decode(string[] args)
        {
            var upperLimitCoords = args[0];
            var grid = new Grid(upperLimitCoords);

            args = args.Skip(1).ToArray();

            //3 lines of input is the set of instructions for each robot.
            int i = 0;
            var instructionList
                = from s in args
                let num = i++
                group s by num / 2 into g
                select g.ToArray();

            var instructionSets = instructionList.ToArray();

            foreach (var instructionSet in instructionSets)
            {
                var currentPosition = instructionSet[0];
                var instructions = instructionSet[1];

                //TODO ^^ perform validations on input/ null check etc.

                var finalPosition = _instructionProcessor.Process(grid, new Position(currentPosition), instructions);
                var isLost = finalPosition.GetType() == typeof(LostPosition) ? "LOST" : string.Empty;
                Console.WriteLine($"{finalPosition.CoOrdinate.X}{finalPosition.CoOrdinate.Y}{finalPosition.Orientation}{isLost}");
            }
        }
    }
}