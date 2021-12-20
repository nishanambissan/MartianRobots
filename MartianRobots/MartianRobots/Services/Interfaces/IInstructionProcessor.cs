using MartianRobots.Models;

namespace MartianRobots.Services.Interfaces
{
    public interface IInstructionProcessor
    {
        /// <summary>
        /// Given a current position, and a set of Instructions which is a string with a series of instructions
        /// like 'LRFFRR' for example. L = Left, R = Right, Forward = Forward, this Process method returns the final position
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="instructionSet"></param>
        /// <returns></returns>
        Position Process(Position currentPosition, string instructionSet);
    }
}