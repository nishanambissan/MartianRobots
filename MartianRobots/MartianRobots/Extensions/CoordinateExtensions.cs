namespace MartianRobots.Models
{
    public static class CoordinateExtensions
    {
        public static CoOrdinate MoveForward(this CoOrdinate currentCoOrdinate, Orientation currentOrientation)
        {
            switch (currentOrientation)
            {
                case Orientation.E:
                    return new CoOrdinate(currentCoOrdinate.X + 1, currentCoOrdinate.Y);
                case Orientation.S:
                    return new CoOrdinate(currentCoOrdinate.X, currentCoOrdinate.Y - 1);
                case Orientation.W:
                    return new CoOrdinate(currentCoOrdinate.X - 1, currentCoOrdinate.Y);
                case Orientation.N:
                    return new CoOrdinate(currentCoOrdinate.X, currentCoOrdinate.Y + 1);

                default: return currentCoOrdinate;
            }
        }

        //TODO : we may need a move backward instrution some day.
    }
}