using System;
using System.ComponentModel;
using System.Linq;

namespace MartianRobots.Models
{
    public class Position
    {
        public Position(string coOrdinatesAndOrientation) //example 11E
        {
            ParseCoordinates(coOrdinatesAndOrientation);
            ParseOrientation(coOrdinatesAndOrientation);
        }

        public Position(CoOrdinate coOrdinate, Orientation orientation) //example 11E
        {
            CoOrdinate = coOrdinate;
            Orientation = orientation;
        }

        private void ParseOrientation(string coOrdinatesAndOrientation)
        {
            var orientationAsString = coOrdinatesAndOrientation?.Last();
            Orientation = (Orientation)Enum.Parse(typeof(Orientation), orientationAsString.ToString(), true);
            //TODO validation and throw exception if invalid value ^^
        }

        private void ParseCoordinates(string coOrdinatesAndOrientation)
        {
            var coordinateAsString = coOrdinatesAndOrientation?.SkipLast(1).ToArray();

            //This logic below will change if the grid limits are increased to have 2 digit numbers for co-ordinates- think of introducing comma or something as a delimiter then

            CoOrdinate = new CoOrdinate(Int32.Parse(coordinateAsString[0].ToString()), Int32.Parse(coordinateAsString[1].ToString())); 
        }

        public CoOrdinate CoOrdinate { get; set; }
        public Orientation Orientation { get; set; }
        
    }
}