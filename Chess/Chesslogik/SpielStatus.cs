using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesslogik
{
    public class SpielStatus
    {
        public Brett Brett { get; }
        //public Piece Piece { get; }
        //public Position Position { get; }

        public Player CurrentPlayer { get; private set; }

        public SpielStatus(Player player, Brett brett)
        {
            CurrentPlayer = player;
            Brett = brett;


        }

        public IEnumerable<Move> LegalMovesForPiece(Position pos)
        {
            if(Brett.IsEmpty(pos) || Brett[pos].Color != CurrentPlayer)
            {
                return Enumerable.Empty<Move>();
            }

            Piece piece = Brett[pos];
            return piece.GetMoves(pos, Brett);
        }

        public void MakeMove(Move move)
        {
            move.Ausführen(Brett);
            CurrentPlayer = CurrentPlayer.Opponent();
        }
    }
}
