﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chesslogik;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Image[,] pieceImages = new Image[8, 8];
        private readonly Rectangle[,] highlights = new Rectangle[8, 8];
        private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();

        private SpielStatus spielStatus;
        private Position selectedPos = null;
        public MainWindow()
        {
            InitializeComponent();
            InitializeBrett();

            spielStatus = new SpielStatus(Player.White, Brett.Initial());
            DrawBrett(spielStatus.Brett);
            SetCursor(spielStatus.CurrentPlayer);
        }

        private void InitializeBrett()
        {
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Image image = new Image();
                    pieceImages[i, j] = image;
                    PieceGrid.Children.Add(image);

                    Rectangle highlight = new Rectangle();
                    highlights[i, j] = highlight;
                    HighlightGrid.Children.Add(highlight);
                }
            }
        }

        private void DrawBrett(Brett brett)
        {
            for( int i = 0;i < 8;i++)
            {
                for ( int j = 0;j < 8;j++)
                {
                    Piece piece = brett[i, j];
                    pieceImages[i,j].Source = Images.GetImage(piece);
                }
            }
        }

        private void BrettGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(BrettGrid);
            Position pos = ToSquarePosition(point);

            if (selectedPos == null)
            {
                OnFromPositionSelected(pos);
            }
            else
            {
                OnToPositionSelected(pos);
            }

        }

        private Position ToSquarePosition(Point point)
        {
            double squareSize = BrettGrid.ActualWidth / 8;
            int row = (int)(point.Y / squareSize);
            int col = (int)(point.X / squareSize);
            return new Position(row, col);
        }


        private void OnFromPositionSelected(Position pos)
        {
            IEnumerable<Move> moves = spielStatus.LegalMovesForPiece(pos);
            if(moves.Any())
                {
                selectedPos = pos;
                CacheMoves(moves);
                ShowHighlights();
                }
        }

        private void OnToPositionSelected(Position pos)
        {
            selectedPos = null;
            HideHighlights();

            if(moveCache.TryGetValue(pos, out Move move))
            {
                HandleMove(move);
            }
        }


        private void HandleMove(Move move)
        {
            spielStatus.MakeMove(move);
            DrawBrett(spielStatus.Brett);
            SetCursor(spielStatus.CurrentPlayer);
        }

        private void CacheMoves(IEnumerable<Move> moves)
        {
            moveCache.Clear();
            foreach (Move move in moves)
            {
                moveCache[move.ToPos] = move;
            }
        }

        private void ShowHighlights()
        {
            Color color = Color.FromArgb(150, 120, 250, 120);
            foreach (Position to in moveCache.Keys)
            {
                highlights[to.Row, to.Column].Fill = new SolidColorBrush(color);
            }
        }

        private void HideHighlights()
        {
            foreach (Position to in moveCache.Keys)
            {
                highlights[to.Row, to.Column].Fill = Brushes.Transparent;
            }
        }
        private void SetCursor(Player player)
        {
            if(player == Player.White)
            {
                Cursor = ChessCursor.WhiteCursor;
            }
            else
            {
                  Cursor = ChessCursor.BlackCursor;
            }
        }

    }
}