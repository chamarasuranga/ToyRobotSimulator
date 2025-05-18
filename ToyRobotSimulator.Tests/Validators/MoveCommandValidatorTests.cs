using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Commands;
using ToyRobotSimulator.Models;
using ToyRobotSimulator.Validators;

namespace ToyRobotSimulator.Tests.Validators
{

    public class MoveCommandValidatorTests
    {
        private readonly TableSettings _settings = new() { Size = 5 };

        [Fact]
        public void ValidMoveWithinBounds_ShouldPass()
        {
            var robot = new Robot { X = 1, Y = 1, Facing = Direction.NORTH };
            var validator = new MoveCommandValidator(robot, _settings);
            var result = validator.TestValidate(new MoveCommand());
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void MoveOffTable_ShouldFail()
        {
            var robot = new Robot { X = 0, Y = 4, Facing = Direction.NORTH };
            var validator = new MoveCommandValidator(robot, _settings);
            var result = validator.TestValidate(new MoveCommand());
            result.ShouldHaveValidationErrorFor(_ => _);
        }
    }
}
