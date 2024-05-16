using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesslogik
{
    public class König : Piece
    {
        public override PieceType Type => PieceType.König;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.East,
            Direction.South,
            Direction.West,
            Direction.North,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.NorthEast,
            Direction.SouthWest
        };
        public König(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            König copy = new König(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePosition(Position from, Brett brett)
        {
            foreach(Direction dir in dirs)
            {
                Position to = from + dir;

                if (!Brett.IsInside(to))
                {
                    continue;
                }

                if (brett.IsEmpty(to) || brett[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Brett brett)
        {
            foreach(Position to in MovePosition(from, brett))
            {
                yield return new NormalMove(from, to);
            }
        }
    }
}
