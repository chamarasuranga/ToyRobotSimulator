using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Commands;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Handlers
{
    public class MoveCommandHandler : IRequestHandler<MoveCommand, Unit>
    {
        private readonly Robot _robot;
        private readonly TableSettings _settings;
        public MoveCommandHandler(Robot robot, TableSettings settings) => (_robot, _settings) = (robot, settings);
        public Task<Unit> Handle(MoveCommand request, CancellationToken _)
        {
            int newX = _robot.X.Value, newY = _robot.Y.Value;
            switch (_robot.Facing)
            {
                case Direction.NORTH: newY++; break;
                case Direction.SOUTH: newY--; break;
                case Direction.EAST: newX++; break;
                case Direction.WEST: newX--; break;
            }
            if (newX >= 0 && newX < _settings.Size && newY >= 0 && newY < _settings.Size)
            {
                _robot.X = newX; _robot.Y = newY;
            }
            return Task.FromResult(Unit.Value);
        }
    }
}
