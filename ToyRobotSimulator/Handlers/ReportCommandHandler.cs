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
   
    public class ReportCommandHandler : IRequestHandler<ReportCommand, Unit>
    {
        private readonly Robot _robot;
        public ReportCommandHandler(Robot robot) => _robot = robot;
        public Task<Unit> Handle(ReportCommand request, CancellationToken _)
        {
            Console.WriteLine($"{_robot.X},{_robot.Y},{_robot.Facing}");
            return Task.FromResult(Unit.Value);
        }
    }
}
