using System;
using Xunit;
using MarsRover;
using MarsRover.Models;

namespace MarsRoverTest
{
    public class CommandTest
    {
        [Fact]
        public void RotateLeftCommandTest()
        {
            //Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 1);
            RotateLeftCommand command = new RotateLeftCommand(marsRover);
            //When
            command.Execute();
            //Then
            Assert.Equal<CardinalDirection>(CardinalDirection.east, marsRover.Direction);
        }
        [Fact]
        public void RotateRightCommandTest()
        {
            //Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 1);
            marsRover.RotateLeft();
            RotateRightCommand command = new RotateRightCommand(marsRover);
            //When
            command.Execute();
            //Then
            Assert.Equal<CardinalDirection>(CardinalDirection.south, marsRover.Direction);
        }
        [Fact]
        public void MoveForwardCommandTest()
        {
            //Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 1);
            marsRover.RotateLeft();
            MoveForwardCommand command = new MoveForwardCommand(marsRover, 1);
            //When
            command.Execute();
            bool result = command.CanExecute();
            (int x, int y) position = (2, 1);
            int square = marsRover.GetCurrentSquare(position);
            string location = square.ToString() + " " + CardinalDirection.east;
            //Then
            Assert.Equal<CardinalDirection>(CardinalDirection.east, marsRover.Direction);
            Assert.Equal<(int, int)>(position, marsRover.CurrentCoordinate);
            Assert.Equal<string>(location, marsRover.Location);
            Assert.True(result);
        }

    }
}