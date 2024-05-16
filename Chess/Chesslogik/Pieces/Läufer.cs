using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesslogik
{
    public class Läufer : Piece
    {
        public override PieceType Type => PieceType.Läufer;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.NorthEast,
            Direction.SouthWest
        };

        public Läufer(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Läufer copy = new Läufer(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Brett brett)
        {
            return MovePositionInDirs(from, brett, dirs).Select(to => new NormalMove(from, to));

        }
    }
}
