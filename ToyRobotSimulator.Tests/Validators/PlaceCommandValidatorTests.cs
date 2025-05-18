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

    public class PlaceCommandValidatorTests
    {
        private readonly TableSettings _settings = new() { Size = 5 };

        [Fact]
        public void ValidCommand_ShouldPass()
        {
            var validator = new PlaceCommandValidator(_settings);
            var command = new PlaceCommand(2, 2, Direction.EAST);
            var result = validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void InvalidCommand_ShouldFail()
        {
            var validator = new PlaceCommandValidator(_settings);
            var command = new PlaceCommand(-1, 10, Direction.EAST);
            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.X);
            result.ShouldHaveValidationErrorFor(x => x.Y);
        }
    }

}
