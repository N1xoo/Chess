namespace Chesslogik
{
    public class Springer : Piece
    {
        public override PieceType Type => PieceType.Springer;
        public override Player Color { get; }

        public Springer(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Springer copy = new Springer(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static IEnumerable<Position> PotentionalToPositions(Position from)
        {
            foreach (Direction vDir in new Direction[] { Direction.North, Direction.South })
            {
                foreach (Direction hDir in new Direction[] { Direction.West, Direction.East })
                {
                    yield return from + 2* vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }

        private IEnumerable<Position> MovePositions(Position from, Brett brett)
        {
            return PotentionalToPositions(from).Where(pos => Brett.IsInside(pos)
                && (brett.IsEmpty(pos) || brett[pos].Color != Color ));
        }

        public override IEnumerable<Move> GetMoves(Position from, Brett brett)
        {
            return MovePositions(from, brett).Select(to => new NormalMove(from, to));
        }
    }
}
