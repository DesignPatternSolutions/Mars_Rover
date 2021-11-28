using MarsRover.Interfaces;

namespace MarsRover.Models
{
    public class MoveForwardCommand : IMoveCommand
    {
        private IRover _marsRover;
        private int _distance;
        public MoveForwardCommand(IRover rover, int distance)
        {
            this._marsRover = rover;
            this._distance = distance;
        }
        public bool CanExecute()
        {
            return this._marsRover.CanMove();
        }

        public void Execute()
        {
            this._marsRover.MoveForward(this._distance);
        }

        public void Undo()
        {
            int back = -this._distance; 
            this._marsRover.MoveForward(back);
        }
    }
}