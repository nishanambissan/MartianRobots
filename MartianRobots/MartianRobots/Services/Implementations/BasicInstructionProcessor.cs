using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using MartianRobots.Extensions;
using MartianRobots.Models;
using MartianRobots.Services.Interfaces;

namespace MartianRobots.Services.Implementations
{
    public class BasicInstructionProcessor : IInstructionProcessor
    {
        private readonly string[] _validInstructionSet = {"R", "L", "F"};

        public Position Process(Grid grid, Position currentPosition, string instructionSet)
        {
            instructionSet = instructionSet.ToUpper();

            foreach (var instruction in instructionSet)
            {
                if (IsValid(instruction))
                {
                    if (instruction == 'R')
                    {
                        currentPosition.Orientation = currentPosition.Orientation.GetRight();
                    }
                    else if (instruction == 'L')
                    {
                        currentPosition.Orientation = currentPosition.Orientation.GetLeft();
                    }
                    else if (instruction == 'F')
                    {
                        var newCoords = currentPosition.CoOrdinate.MoveForward(currentPosition.Orientation);

                        if (grid.IsThisDangerous(currentPosition, instruction.ToString()))
                        {
                            continue; //ignore
                        }

                        if (grid.IsOffGrid(newCoords))
                        {
                            grid.RecordDangerousPositionAndInstruction(currentPosition, instruction.ToString());
                            return new LostPosition(currentPosition.CoOrdinate, currentPosition.Orientation);
                        }
                        else
                        {
                            currentPosition.CoOrdinate = newCoords;
                        }
                    }
                }
            }

            return currentPosition;
        }


        //TODO : create custom validator for this and the ValidInstructionSet should belong there in the Validator
        private bool IsValid(char instruction)
        {
            return _validInstructionSet.Contains(instruction.ToString().ToUpper());
        }
    }
}
