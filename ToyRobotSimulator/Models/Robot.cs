using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Models
{
    public class Robot
    {
        public int? X { get; set; }
        public int? Y { get; set; }
        public Direction Facing { get; set; }
    }
}
