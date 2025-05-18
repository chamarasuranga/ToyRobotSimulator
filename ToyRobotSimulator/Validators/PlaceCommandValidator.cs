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
    public class PlaceCommandValidator : AbstractValidator<PlaceCommand>
    {
        public PlaceCommandValidator(TableSettings settings)
        {
            RuleFor(cmd => cmd.X).InclusiveBetween(0, settings.Size - 1).WithMessage("Invalid command");
            RuleFor(cmd => cmd.Y).InclusiveBetween(0, settings.Size - 1).WithMessage("Invalid command");
            RuleFor(cmd => cmd.Facing).IsInEnum().WithMessage("Invalid command");
        }
    }
}
