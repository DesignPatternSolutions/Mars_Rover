using System;
using Xunit;
using MarsRover;
using MarsRover.Models;

namespace MarsRoverTest
{
    public class RoverTest
    {
        [Fact]
        public void InitialSettingsTest()
        {
            //Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 1);
            //When
            string location = "102 south";
            (int, int) position = (1, 1);
            CardinalDirection direction = CardinalDirection.south;
            //Then
            Assert.Equal<string>(location, marsRover.Location);
            Assert.Equal<CardinalDirection>(direction, marsRover.Direction);
            Assert.Equal<(int, int)>(position, marsRover.CurrentCoordinate);
        }

        [Fact]
        public void RotateRightTest()
        {
            //Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            //When
            CardinalDirection direction = CardinalDirection.west;
            string location = "1 west";
            marsRover.RotateRight();
            //Then
            Assert.Equal<string>(location, marsRover.Location);
            Assert.Equal<CardinalDirection>(direction, marsRover.Direction);
        }

        [Fact]
        public void RotateLeftTest()
        {
            //Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            //When
            CardinalDirection direction = CardinalDirection.east;
            string location = "1 east";
            marsRover.RotateLeft();
            //Then
            Assert.Equal<string>(location, marsRover.Location);
            Assert.Equal<CardinalDirection>(direction, marsRover.Direction);
        }
        [Fact]
        public void MoveForwardTest()
        {
            //Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            //When
            int distance = 20;
            string location = "2001 south";
            CardinalDirection direction = CardinalDirection.south;
            (int x, int y) position = (0, 20);
            marsRover.MoveForward(distance);
            //Then
            Assert.Equal<string>(location, marsRover.Location);
            Assert.Equal<CardinalDirection>(direction, marsRover.Direction);
            Assert.Equal<string>(location, marsRover.Location);
            Assert.Equal<(int, int)>(position, marsRover.CurrentCoordinate);
        }

        [Fact]
        public void GetCurrentSquareTest()
        {
            //Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            //When
            marsRover.MoveForward(50);
            marsRover.RotateLeft();
            marsRover.MoveForward(21);
            marsRover.RotateLeft();
            marsRover.MoveForward(20);
            CardinalDirection direction = CardinalDirection.north;
            (int x, int y) position = (21, 30);
            int square = marsRover.GetCurrentSquare(position);
            string location = square.ToString() + " " + direction.ToString();
            //Then
            Assert.Equal<int>(3022, square);
            Assert.Equal<CardinalDirection>(direction, marsRover.Direction);
            Assert.Equal<string>(location, marsRover.Location);
            Assert.Equal<(int, int)>(position, marsRover.CurrentCoordinate);
        }
        [Fact]
        public void CanMoveTest()
        {
            //Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            //When
            marsRover.MoveForward(50);
            marsRover.RotateLeft();
            marsRover.MoveForward(21);
            marsRover.RotateLeft();
            marsRover.MoveForward(60);
            bool result = marsRover.CanMove();
            //Then
            Assert.False(result);
        }
    }
}