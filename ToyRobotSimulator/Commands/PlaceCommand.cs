using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Infrastructure.Contracts;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Commands
{
    [CommandKeyword("PLACE", hasArguments: true)]
    public class PlaceCommand : ICommand
    {
        public int X { get; }
        public int Y { get; }
        public Direction Facing { get; }

        public PlaceCommand(int x, int y, Direction facing) => (X, Y, Facing) = (x, y, facing);

        public static ICommand FromArgs(string args)
        {
            var parts = args.Split(',');
            if (parts.Length == 3 &&
                int.TryParse(parts[0], out int x) &&
                int.TryParse(parts[1], out int y) &&
                Enum.TryParse(parts[2], true, out Direction dir))
            {
                return new PlaceCommand(x, y, dir);
            }
            return null;
        }
    }
}
