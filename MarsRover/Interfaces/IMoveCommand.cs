namespace MarsRover.Interfaces
{
    public interface IMoveCommand : IRotateCommand
    {       
        bool CanExecute();

        void Undo();
    }
}