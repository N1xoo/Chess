using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesslogik
{
    public class NormalMove : Move
    {
        public override MoveType Type => MoveType.Normal;
        public override Position FromPos { get; }
        public override Position ToPos { get; }
        public NormalMove(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
        }

        public override void Ausführen(Brett brett)
        {
            Piece piece = brett[FromPos];
            brett[ToPos] = piece;
            brett[FromPos] = null;
            piece.HasMoved = true;

        }
    }
}
