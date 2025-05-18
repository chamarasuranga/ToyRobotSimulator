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
    public class MoveCommandValidator : AbstractValidator<MoveCommand>
    {
        public MoveCommandValidator(Robot state, TableSettings settings)
        {
            RuleFor(_ => _).Must(_ => state.X.HasValue && state.Y.HasValue).WithMessage("Invalid command");
            RuleFor(_ => _).Must(_ =>
            {
                if (!state.X.HasValue || !state.Y.HasValue) return false;
                int x = state.X.Value, y = state.Y.Value;
                switch (state.Facing)
                {
                    case Direction.NORTH: y++; break;
                    case Direction.SOUTH: y--; break;
                    case Direction.EAST: x++; break;
                    case Direction.WEST: x--; break;
                }
                return x >= 0 && x < settings.Size && y >= 0 && y < settings.Size;
            }).WithMessage("Invalid command");
        }
    }
}
