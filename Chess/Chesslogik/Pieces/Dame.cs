namespace Chesslogik
{
    public class Dame : Piece
    {
        public override PieceType Type => PieceType.Dame;
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
        public Dame(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Dame copy = new Dame(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Brett brett)
        {
            return MovePositionInDirs(from, brett, dirs).Select(to => new NormalMove(from, to));

        }
    }
}
