using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Models
{
    public class Grid
    {
        public CoOrdinate UpperLimit { get; set; }

        public CoOrdinate LowerLimit = new CoOrdinate(0, 0);
    }
}
