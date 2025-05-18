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
    public class PlaceCommandHandler : IRequestHandler<PlaceCommand, Unit>
    {
        private readonly Robot _robot;
        public PlaceCommandHandler(Robot robot) => _robot = robot;
        public Task<Unit> Handle(PlaceCommand request, CancellationToken _)
        {
            _robot.X = request.X; _robot.Y = request.Y; _robot.Facing = request.Facing ?? Direction.NORTH;
            return Task.FromResult(Unit.Value);
        }
    }
}
