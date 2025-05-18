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
    public class LeftCommandValidatorTests
    {
        [Fact]
        public void RobotNotPlaced_ShouldFail()
        {
            var robot = new Robot();
            var validator = new LeftCommandValidator(robot);
            var result = validator.TestValidate(new LeftCommand());
            result.ShouldHaveValidationErrorFor(_ => _);
        }

        [Fact]
        public void RobotPlaced_ShouldPass()
        {
            var robot = new Robot { X = 1, Y = 1 };
            var validator = new LeftCommandValidator(robot);
            var result = validator.TestValidate(new LeftCommand());
            result.ShouldNotHaveAnyValidationErrors();
        }
    }

}
