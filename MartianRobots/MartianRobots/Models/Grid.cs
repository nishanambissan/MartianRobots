using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Models
{
    public class Grid
    {
        public CoOrdinate UpperLimit { get; }

        public CoOrdinate LowerLimit = new CoOrdinate(0, 0);

        private Dictionary<KeyValuePair<Position, string>, bool> _dangerousPositions = new Dictionary<KeyValuePair<Position, string>, bool>();

        public Grid(string upperLimitCoords)
        {
            //TODO : parse and validate that its 2 digit input upstream in decoder

            var x = upperLimitCoords.First();
            var y = upperLimitCoords.Last();

            UpperLimit = new CoOrdinate(Int32.Parse(x.ToString()), Int32.Parse(y.ToString()));
        }

        public void RecordDangerousPositionAndInstruction(Position currentPosition, string instruction)
        {
            var keyValuePair = new KeyValuePair<Position, string>(currentPosition, instruction);
            _dangerousPositions.Add(keyValuePair, true);
        }

        public bool IsThisDangerous(Position currentPosition, string newInstruction)
        {
            var key = new KeyValuePair<Position, string>(currentPosition, newInstruction);
            
            if (_dangerousPositions.ContainsKey(key)) //TODO make this efficient to be using override of equals
            {
                return true;
            }

            return false;
        }

        public bool IsOffGrid(CoOrdinate newCoords)
        {
            if (newCoords.X > UpperLimit.X || newCoords.X < 0 || newCoords.Y > UpperLimit.Y || newCoords.Y < 0)
            {
                return true;
            }

            return false;
        }
    }
}
