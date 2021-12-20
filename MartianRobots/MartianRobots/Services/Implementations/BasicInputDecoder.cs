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
            //3 lines of input is the set of instructions for each robot.
            int i = 0;
            var instructionList
                = from s in args
                let num = i++
                group s by num / 3 into g
                select g.ToArray();

            var instructionSets = instructionList.ToArray();

            foreach (var instructionSet in instructionSets)
            {
                var upperLimitCoords = instructionSet[0];
                var currentPosition = instructionSet[1];
                var instructions = instructionSet[2];

                //TODO ^^ perform validations on input/ null check etc.

                _instructionProcessor.Process(new Position(currentPosition), instructions);
            }
        }
    }
}