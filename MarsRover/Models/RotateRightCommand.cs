using MarsRover.Interfaces;

namespace MarsRover.Models
{
    public class RotateRightCommand : IRotateCommand
    {
        private IRover _marsRover;

        public RotateRightCommand(IRover rover)
        {
            this._marsRover = rover;
        }
        public void Execute()
        {
            this._marsRover.RotateRight();
        }
    }
}