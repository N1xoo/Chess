using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesslogik
{
    public class Turm : Piece
    {
        public override PieceType Type => PieceType.Turm;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.East,
            Direction.South,
            Direction.West,
            Direction.North,

        };
        public Turm(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Turm copy = new Turm(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Brett brett)
        {
            return MovePositionInDirs(from, brett, dirs).Select(to => new NormalMove(from, to));

        }
    }
}
