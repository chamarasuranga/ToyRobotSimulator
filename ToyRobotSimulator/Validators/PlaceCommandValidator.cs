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
            RuleFor(cmd => cmd.X)
                .NotNull()
                .InclusiveBetween(0, settings.Size - 1)
                .WithMessage("Invalid position in command");

            RuleFor(cmd => cmd.Y)
                .NotNull()
                .InclusiveBetween(0, settings.Size - 1)
                .WithMessage("Invalid position in command");

            RuleFor(cmd => cmd.Facing)
                .NotNull()
                .WithMessage("Invalid direction in command");
        }
    }
}
