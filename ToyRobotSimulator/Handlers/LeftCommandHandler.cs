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
    public class LeftCommandHandler : IRequestHandler<LeftCommand, Unit>
    {
        private readonly Robot _robot;
        public LeftCommandHandler(Robot robot) => _robot = robot;
        public Task<Unit> Handle(LeftCommand request, CancellationToken _)
        {
            _robot.Facing = _robot.Facing switch
            {
                Direction.NORTH => Direction.WEST,
                Direction.WEST => Direction.SOUTH,
                Direction.SOUTH => Direction.EAST,
                Direction.EAST => Direction.NORTH,
                _ => _robot.Facing
            };
            return Task.FromResult(Unit.Value);
        }
    }
}
