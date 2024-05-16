using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chesslogik
{
    public class Brett
    {
        private readonly Piece[,] pieces = new Piece[8, 8];

        public Piece this[int row, int col]
            {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value;}
            }

        public Piece this[Position pos]
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }

        }

        public static Brett Initial() 
        {
            Brett brett = new Brett();
            brett.AddStartPieces();
            return brett;
        }

        private void AddStartPieces()
        {
            this[0, 0] = new Turm(Player.Black);
            this[0, 1] = new Springer(Player.Black);
            this[0, 2] = new Läufer(Player.Black);
            this[0, 3] = new Dame(Player.Black);
            this[0, 4] = new König(Player.Black);
            this[0, 5] = new Läufer(Player.Black);
            this[0, 6] = new Springer(Player.Black);
            this[0, 7] = new Turm(Player.Black);

            this[7, 0] = new Turm(Player.White);
            this[7, 1] = new Springer(Player.White);
            this[7, 2] = new Läufer(Player.White);
            this[7, 3] = new Dame(Player.White);
            this[7, 4] = new König(Player.White);
            this[7, 5] = new Läufer(Player.White);
            this[7, 6] = new Springer(Player.White);
            this[7, 7] = new Turm(Player.White);

            for (int i = 0; i < 8; i++)
            {
                this[1, i] = new Bauer(Player.Black);
                this[6, i] = new Bauer(Player.White);
            }
        }

        public static bool IsInside(Position pos)
        {
            return pos.Row >=0 && pos.Row < 8 && pos.Column >= 0 && pos.Column < 8;
        }

        public bool IsEmpty(Position pos) 
        { 
            return this[pos] == null;
        }
    }
}
