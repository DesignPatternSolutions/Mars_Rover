using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using MarsRover.Interfaces;
using MarsRover.Models;
using System.Collections;

namespace MarsRover
{
    public class User
    {
        ///<summary>
        /// Mars Rover.
        ///</summary>
        private IRover _marsRover;

        ///<summary>
        /// Command Queue.
        ///</summary>
        private Queue _commandList;

        ///<summary>
        /// Stack of executed commands.
        ///</summary>
        private Stack _execList;

        ///<param name="rover">
        /// Mars rover.
        ///</param>
        public User(IRover rover)
        {
            this._commandList = new Queue();
            this._execList = new Stack();
            this._marsRover = rover;
        }

        ///<summary>
        /// Create the command list.
        ///</summary>
        ///<param name="command">
        /// Command text.
        ///</param>
        public void Operate(string command)
        {
            string input = string.Empty;
            int distance = 0;
            IMoveCommand cmdMove = default;
            IRotateCommand cmdRotate = default;

            switch (command)
            {
                case var ch when ch.EndsWith('m'):
                    input = new string(ch.SkipLast<char>(1).ToArray<char>());
                    distance = 0;
                    if (int.TryParse(input, out distance))
                    {
                        cmdMove = new MoveForwardCommand(this._marsRover, distance);
                        this._commandList.Enqueue(cmdMove);
                    }
                    break;
                case var ch when ch.SequenceEqual<char>(Direction.Left.ToString()):
                    input = ch;
                    cmdRotate = new RotateLeftCommand(this._marsRover);
                    this._commandList.Enqueue(cmdRotate);
                    break;
                case var ch when ch.SequenceEqual<char>(Direction.Right.ToString()):
                    input = ch;
                    cmdRotate = new RotateRightCommand(this._marsRover);
                    this._commandList.Enqueue(cmdRotate);
                    break;
                default:
                    break;
            }
        }

        ///<summary>
        /// Execute the command list.
        ///</summary>
        public bool Execute()
        {
            IMoveCommand moveCommand = default;
            IRotateCommand rotateCommand = default;
            while (this._commandList.Count != 0)
            {
                var command = this._commandList.Dequeue();
                switch (command.GetType().Name)
                {
                    case "MoveForwardCommand":
                        moveCommand = (MoveForwardCommand)command;
                        moveCommand.Execute();
                        this._execList.Push(moveCommand);
                        if (!moveCommand.CanExecute())
                            return moveCommand.CanExecute();
                        else
                            break;
                    case "RotateLeftCommand":
                        rotateCommand = (RotateLeftCommand)command;
                        rotateCommand.Execute();
                        this._execList.Push(rotateCommand);
                        break;
                    case "RotateRightCommand":
                        rotateCommand = (RotateRightCommand)command;
                        rotateCommand.Execute();
                        this._execList.Push(rotateCommand);
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        ///<summary>
        /// Revert the last executed command.
        ///</summary>
        public void UndoOperation()
        {
            IMoveCommand moveCommand = (MoveForwardCommand)this._execList.Pop();
            moveCommand.Undo();
        }

        ///<summary>
        /// Clear the stack ond command queue list.
        ///</summary>
        public void ClearAll()
        {
            this._execList.Clear();
            this._commandList.Clear();
        }

        ///<summary>
        /// Log the location of the Mars Rover.
        ///</summary>
        ///<param name="path">Path of the output file where location is logged.</param>
        public async Task<string> LogLocationAsync(string path)
        {
            string location = $"Current location of Mars Rover: {this._marsRover.Location}";
            path += "/output.txt";
            await File.WriteAllTextAsync(path, location);
            Task.WaitAll();
            return "Logging Successful.";
        }

    }

}