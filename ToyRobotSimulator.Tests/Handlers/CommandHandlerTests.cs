using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Commands;
using ToyRobotSimulator.Handlers;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Tests.Handlers
{

    public class CommandHandlerTests
    {
        private readonly TableSettings _settings = new TableSettings { Size = 5 };

        [Fact]
        public async Task PlaceCommandHandler_UpdatesState()
        {
            var state = new Robot();
            var handler = new PlaceCommandHandler(state);
            var command = new PlaceCommand(1, 3, Direction.WEST);

            await handler.Handle(command, CancellationToken.None);

            Assert.Equal(1, state.X);
            Assert.Equal(3, state.Y);
            Assert.Equal(Direction.WEST, state.Facing);
        }

        [Fact]
        public async Task MoveCommandHandler_MovesForward()
        {
            var state = new Robot { X = 1, Y = 1, Facing = Direction.NORTH };
            var handler = new MoveCommandHandler(state, _settings);

            await handler.Handle(new MoveCommand(), CancellationToken.None);

            Assert.Equal(1, state.X);
            Assert.Equal(2, state.Y);
        }

        [Theory]
        [InlineData(Direction.NORTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.EAST)]
        [InlineData(Direction.EAST, Direction.NORTH)]
        public async Task LeftCommandHandler_TurnsLeft(Direction start, Direction expected)
        {
            var state = new Robot { Facing = start };
            var handler = new LeftCommandHandler(state);

            await handler.Handle(new LeftCommand(), CancellationToken.None);

            Assert.Equal(expected, state.Facing);
        }

        [Theory]
        [InlineData(Direction.NORTH, Direction.EAST)]
        [InlineData(Direction.EAST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.NORTH)]
        public async Task RightCommandHandler_TurnsRight(Direction start, Direction expected)
        {
            var state = new Robot { Facing = start };
            var handler = new RightCommandHandler(state);

            await handler.Handle(new RightCommand(), CancellationToken.None);

            Assert.Equal(expected, state.Facing);
        }

        [Fact]
        public async Task ReportCommandHandler_PrintsOutput()
        {
            var state = new Robot { X = 1, Y = 2, Facing = Direction.SOUTH };
            var handler = new ReportCommandHandler(state);

            await handler.Handle(new ReportCommand(), CancellationToken.None);
            // Expect no exception thrown
        }
    }
}
