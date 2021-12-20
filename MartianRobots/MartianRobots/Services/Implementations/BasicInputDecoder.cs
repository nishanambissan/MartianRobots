using System;
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
            throw new NotImplementedException();

            //TODO - something like this
            //_instructionProcessor.Process()
        }
    }
}