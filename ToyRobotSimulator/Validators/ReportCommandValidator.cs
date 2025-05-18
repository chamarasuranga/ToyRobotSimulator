using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Commands;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Validators
{

    public class ReportCommandValidator : AbstractValidator<ReportCommand>
    {
        public ReportCommandValidator(Robot state) => RuleFor(_ => _)
            .Must(_ => state.X.HasValue && state.Y.HasValue).WithMessage("Invalid command.robot not placed.");
    }
}
