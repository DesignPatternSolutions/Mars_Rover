using MarsRover.Models;

namespace MarsRover.Interfaces
{
    public interface IRover
    {
        ///<summary>
        /// Current Direction of the Rover.
        ///</summary>
        CardinalDirection Direction { get; }

        ///<summary>
        /// Current Location of the Rover.
        ///</summary>
        string Location { get; }

        ///<summary>
        /// Current Co-ordinate of the Rover.
        ///</summary>
        (int x, int y) CurrentCoordinate { get; }

        ///<summary>
        ///Turn Rover Left.
        ///</summary>
        void RotateLeft();

        ///<summary> 
        ///Turn Rover Right.
        ///</summary>
        void RotateRight();

        ///<summary>
        /// Move the Rover Forward.
        ///</summary>
        ///<param name="distance">Distance to move forward in meters.</param>
        void MoveForward(int distance);

        ///<summary>
        /// Check if the Rover breached the perimeter.
        ///</summary>
        bool CanMove();

        ///<summary>
        /// Current Square in which Rover is loacated.
        ///</summary>
        ///<param name="position">The x-coordinate and y-coordinate of the Rover.</param>
        int GetCurrentSquare((int x, int y) position);

    }
}