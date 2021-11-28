using System;
using Xunit;
using MarsRover;
using MarsRover.Models;

namespace MarsRoverTest
{
    public class UserTest
    {
        [Theory]
        [InlineData("50m")]
        [InlineData("Left")]
        [InlineData("23m")]
        [InlineData("Left")]
        [InlineData("4m")]
        public void OperateTest(string input)
        {
            // Given
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            User user = new User(marsRover);
            user.Operate(input);

            // When
            bool result = user.Execute();

            // Then
            Assert.True(result);

        }

        [Fact]
        public void OperateFailTest()
        {
            //Given
            string text = "100m";
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            User user = new User(marsRover);
            user.Operate(text);
            //When
            bool result = user.Execute();
            //Then
            Assert.False(result);
        }

        [Fact]
        public void ExecuteTest()
        {
            //Given
            string[] text = {"50m", "Left", "23m", "Left", "4m"};
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            User user = new User(marsRover);
            foreach (string cmd in text)
            {
                user.Operate(cmd);   
            }
            //When
            bool result = user.Execute();
            string location = "4624 north";
            //Then
            Assert.True(result);
            Assert.Equal<string>(location, marsRover.Location);
        }
        [Fact]
        public void UndoOperationTest()
        {
            //Given
            string text = "100m";
            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            User user = new User(marsRover);
            user.Operate(text);
            //When
            bool result = user.Execute();
            user.UndoOperation();
            string location = "1 south";
            //Then
            Assert.False(result);
            Assert.Equal<string>(location, marsRover.Location);
        }

    }
}
