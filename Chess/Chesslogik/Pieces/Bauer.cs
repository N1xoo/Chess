using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesslogik
{
    public class Bauer : Piece
    {
        public override PieceType Type => PieceType.Bauer;
            public override Player Color { get; }

        private  readonly Direction vorwärts;
        

        public Bauer(Player color) 
        {
            Color = color;

            if (color == Player.White)
            {
                vorwärts = Direction.North;
            }
            else if (color== Player.Black)
            {
                vorwärts= Direction.South;
            }
        }
        public override Piece Copy()
        {
            Bauer copy = new Bauer(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private bool CanMoveTo(Position pos, Brett brett)
        {
            return Brett.IsInside(pos) && brett.IsEmpty(pos);
        }

        private bool CanCaptureAt(Position pos, Brett brett)
        {
            if(!Brett.IsInside(pos) || brett.IsEmpty(pos))
            {
                return false;
            }

            return brett[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMoves(Position from, Brett brett)
        {
            Position schritt = from + vorwärts;
            if (CanMoveTo(schritt, brett))
            {
                yield return new NormalMove(from, schritt);

                Position zweiSchritt = schritt + vorwärts;

                if (!HasMoved && CanMoveTo(zweiSchritt, brett))
                {
                    yield return new NormalMove(from, zweiSchritt);
                }
            }
        }


        private IEnumerable<Move> DiagonalMoves(Position from, Brett brett)
        {
            foreach (Direction dir in new Direction[]{Direction.West, Direction.East })
            {
                Position to = from + vorwärts + dir;

                if(CanCaptureAt(to, brett))
                {
                    yield return new NormalMove(from, to);
                }
            }

        }

        public override IEnumerable<Move> GetMoves(Position from, Brett brett)
        {
            return ForwardMoves(from, brett).Concat(DiagonalMoves(from, brett));
        }
    }
}
