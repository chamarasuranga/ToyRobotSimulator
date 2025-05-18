using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Commands;

namespace ToyRobotSimulator.Tests.CommandParsers
{
    public class CommandParserTests
    {
        [Theory]
        [InlineData("PLACE 0,0,NORTH", typeof(PlaceCommand))]
        [InlineData("move", typeof(MoveCommand))]
        [InlineData("LEFT", typeof(LeftCommand))]
        [InlineData("right", typeof(RightCommand))]
        [InlineData("RePoRt", typeof(ReportCommand))]
        public void Parse_ValidCommand_ReturnsCorrectType(string input, System.Type expectedType)
        {
            CommandParser.Parse(input);
            var command = CommandParser.Parse(input);
            Assert.NotNull(command);
            Assert.IsType(expectedType, command);
        }

        [Theory]
        [InlineData("")]
        [InlineData("PLACE1")]
        [InlineData("PLACE2 9,9,NORTH")]
        [InlineData("INVALID")]
        public void Parse_InvalidCommand_ReturnsNull(string input)
        {
            var command = CommandParser.Parse(input);
            Assert.Null(command);
        }
    }
}