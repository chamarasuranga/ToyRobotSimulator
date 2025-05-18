using ToyRobotSimulator.Infrastructure.Contracts;
using ToyRobotSimulator.Infrastructure.Parsing;
using ToyRobotSimulator.Models;

[CommandKeyword("PLACE", hasArguments: true)]
public class PlaceCommand : ICommand
{
    public int? X { get; }
    public int? Y { get; }
    public Direction? Facing { get; }

    public PlaceCommand(int? x, int? y, Direction? facing) => (X, Y, Facing) = (x, y, facing);

    public static ICommand FromArgs(string args)
    {
        int? x = null, y = null;
        Direction? dir = null;

        if (!string.IsNullOrWhiteSpace(args))
        {
            var parts = args.Split(',');

            if (parts.Length > 0 && int.TryParse(parts[0], out var tempX)) x = tempX;
            if (parts.Length > 1 && int.TryParse(parts[1], out var tempY)) y = tempY;
            if (parts.Length > 2 && Enum.TryParse(parts[2], true, out Direction parsedDir)) dir = parsedDir;
        }

        return new PlaceCommand(x, y, dir);
    }
}