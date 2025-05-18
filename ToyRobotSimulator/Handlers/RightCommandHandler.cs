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
   
    public class RightCommandHandler : IRequestHandler<RightCommand, Unit>
    {
        private readonly Robot _robot;
        public RightCommandHandler(Robot robot) => _robot = robot;
        public Task<Unit> Handle(RightCommand request, CancellationToken _)
        {
            _robot.Facing = _robot.Facing switch
            {
                Direction.NORTH => Direction.EAST,
                Direction.EAST => Direction.SOUTH,
                Direction.SOUTH => Direction.WEST,
                Direction.WEST => Direction.NORTH,
                _ => _robot.Facing
            };
            return Task.FromResult(Unit.Value);
        }
    }
}
