using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPiecesPhoneNumber
{
    public class ChessPiece
    {
        //pawn, rock, knight, bishop, queen or king.
        public Piece Name { get; set; }

        //'1' for pawn, '+' for rock, 'L' for knight, 'X' for bishop, '*' for queen and 'o' for king.
        public char Move { get; }

        public int Point { get; }

        public ChessPiece(Piece name)
        {
            Name = name;
            if(name == Piece.PAWN)
            {
                Move = '1';
                Point = 1;
            }
            else if(name == Piece.ROCK)
            {
                Move = '+';
                Point = 5;
            }
            else if (name == Piece.KNIGHT)
            {
                Move = 'L';
                Point = 3;
            }
            else if (name == Piece.BISHOP)
            {
                Move = 'X';
                Point = 3;
            }
            else if (name == Piece.QUEEN)
            {
                Move = '*';
                Point = 9;
            }
            else if (name == Piece.KING)
            {
                Move = 'o';
                Point = 10;
            }
            else
            {
                Move = ' ';
            }
        }
    }
}
