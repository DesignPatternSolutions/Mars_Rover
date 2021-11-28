using MarsRover.Interfaces;

namespace MarsRover.Models
{
    public class MarsSpaceRover : IRover
    {
        ///<summary>
        /// Direction of Mars Rover.
        ///</summary>
        private CardinalDirection _direction;
        
        ///<summary>
        /// Location of Mars Rover.
        ///</summary>
        private string _location;

        ///<summary>
        /// Co-ordinate of Mars Rover.
        ///</summary>
        private (int x, int y) _currentCoordinate;

        ///<summary>
        /// Max grid co-ordinate of Mars Rover.
        ///</summary>
        private readonly int _maxPosition;

        ///<summary>
        /// Initial grid co-ordinate of Mars Rover.
        ///</summary>
        private readonly int _minPosition;

        public CardinalDirection Direction => _direction;

        public string Location => _location;

        public (int x, int y) CurrentCoordinate => this._currentCoordinate;

        ///<param name="gridMax"> Max co-ordinate in the grid.</param>
        ///<param name="gridMin"> Initial co-ordinate of the Mars Rover in the grid.</param>
        public MarsSpaceRover(int gridMax, int gridMin)
        {
            _maxPosition = gridMax;
            _minPosition = gridMin;
            this._direction = CardinalDirection.south;
            this._currentCoordinate = (gridMin, gridMin);
            string square = this.GetCurrentSquare(this._currentCoordinate).ToString();
            string direction = this.Direction.ToString();
            this._location = square + " " + direction;
        }

        ///<summary>
        /// Check if the Mars Rover's Current Co-ordinate is valid.
        ///</summary>
        ///<returns>Boolean</returns>
        public bool CanMove()
        {
            (int x, int y) position = this._currentCoordinate;
            return position.x < this._maxPosition && position.x >= this._minPosition && position.y < this._maxPosition && position.y >= this._minPosition;
        }

        public int GetCurrentSquare((int x, int y) position)
        {
            return position.x + position.y * _maxPosition + 1;
        }

        public void MoveForward(int distance)
        {
            switch (this.Direction)
            {
                case CardinalDirection.north:
                    this._currentCoordinate.y -= distance;
                    break;
                case CardinalDirection.south:
                    this._currentCoordinate.y += distance;
                    break;
                case CardinalDirection.east:
                    this._currentCoordinate.x += distance;
                    break;
                case CardinalDirection.west:
                    this._currentCoordinate.x -= distance;
                    break;
                default:
                    break;
            }
            this.SetLocation();
        }

        public void RotateLeft()
        {
            switch (this.Direction)
            {
                case CardinalDirection.north:
                    this._direction = CardinalDirection.west;
                    break;
                case CardinalDirection.south:
                    this._direction = CardinalDirection.east;
                    break;
                case CardinalDirection.east:
                    this._direction = CardinalDirection.north;
                    break;
                case CardinalDirection.west:
                    this._direction = CardinalDirection.south;
                    break;
                default:
                    break;
            }
            this.SetLocation();
        }

        public void RotateRight()
        {
            switch (this.Direction)
            {
                case CardinalDirection.north:
                    this._direction = CardinalDirection.east;
                    break;
                case CardinalDirection.south:
                    this._direction = CardinalDirection.west;
                    break;
                case CardinalDirection.east:
                    this._direction = CardinalDirection.south;
                    break;
                case CardinalDirection.west:
                    this._direction = CardinalDirection.north;
                    break;
                default:
                    break;
            }
            this.SetLocation();
        }

        ///<summary>
        /// Set the current location of the rover.
        ///</summary>
        private void SetLocation()
        {
            string square = this.GetCurrentSquare(this._currentCoordinate).ToString();
            string direction = this.Direction.ToString();
            this._location = square + " " + direction;
        }
    }
}