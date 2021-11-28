using MarsRover.Interfaces;

namespace MarsRover.Models
{
    public class RotateLeftCommand : IRotateCommand
    {
        private IRover _marsRover;
        public RotateLeftCommand(IRover rover)
        {
            this._marsRover = rover;
        }

        public void Execute()
        {
            this._marsRover.RotateLeft();
        }
    }
}