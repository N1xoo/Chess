using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Chesslogik;

namespace ChessUI
{
    public static class Images
    {

        private static readonly Dictionary<PieceType, ImageSource> whiteSources = new()
{
            { PieceType.Bauer, LoadImage("Assets/PawnW.png") },
            { PieceType.Läufer, LoadImage("Assets/BishopW.png") },
            { PieceType. Springer, LoadImage("Assets/Knightw.png") },
            { PieceType.Turm, LoadImage("Assets/Rookw.png") },
            { PieceType.Dame, LoadImage("Assets/QueenW.png") },
            { PieceType.König, LoadImage("Assets/Kingw.png") }
        };

        private static readonly Dictionary<PieceType, ImageSource> blackSources = new()
{

            { PieceType.Bauer, LoadImage("Assets/PawnB.png") },
            { PieceType.Läufer, LoadImage("Assets/BishopB.png") },
            { PieceType.Springer, LoadImage("Assets/KnightB.png") },
            { PieceType.Turm, LoadImage("Assets/RookB.png") },
            { PieceType.Dame, LoadImage("Assets/QueenB.png") },
            { PieceType.König, LoadImage("Assets/KingB.png") } };
        private static ImageSource LoadImage(String filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.Relative));
        }

        public static ImageSource GetImage(Player color, PieceType type)
        {
            return color switch
            {
                Player.White => whiteSources[type],
                Player.Black => blackSources[type],
                _ => null
            };
        }

        public static ImageSource GetImage(Piece piece)
        {
            if (piece == null)
            {
                return null;
            }
            return GetImage(piece.Color, piece.Type);
        }
    }
}
