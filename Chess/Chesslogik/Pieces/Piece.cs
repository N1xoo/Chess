namespace Chesslogik
{
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }
        public bool HasMoved { get; set; } = false;

        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves(Position from, Brett brett);

        protected IEnumerable<Position> MovePositionInDir(Position from, Brett brett, Direction dir)
        {
            for(Position pos = from + dir; Brett.IsInside(pos); pos += dir )
            {
                if (brett.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = brett[pos];

                if (piece.Color != Color)
                {
                    yield return pos;
                }

                
                    yield break;
            }
        }

        protected IEnumerable<Position> MovePositionInDirs(Position from, Brett brett, Direction[] dirs)
        {
            return dirs.SelectMany(dir => MovePositionInDir(from, brett, dir));
        }
    }
}
