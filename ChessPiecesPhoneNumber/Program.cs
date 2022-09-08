using System;
using System.Collections.Generic;
using System.Text;

namespace ChessPiecesPhoneNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Random random = new Random();
            char[,] keypad = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' }, { '*', '0', '#'} };
            var allNumbers = new List<string>();
            var validNumbers = new List<string>();

            int name;
            do
            {
                Console.Write("Please, choose the piece to use: 1 for pawn, 2 for rock, 3 for knight, 4 for bishop, 5 for queen and 6 for king:\n");
            }while( !(int.TryParse(Console.ReadLine(), out name) && (name >= 1 && name <= 6)) );
            

            var chessPiece = new ChessPiece((Piece)name);

            Console.Write("How many number do you want to generate: ");
            var numbers = int.Parse(Console.ReadLine());

            for(int i = 0; i < numbers; i++)
            {                
                int startRow = random.Next(keypad.GetLength(0));
                int startCol = random.Next(keypad.GetLength(1));

                var phoneNumber = DerivePhoneNumber(keypad, chessPiece, startRow, startCol);
                allNumbers.Add(phoneNumber);
                if (IsValidNumber(phoneNumber))
                {
                    validNumbers.Add(phoneNumber);
                }
            }
            Console.WriteLine($"Using {chessPiece.Name} to derive {numbers} phone numbers;");
            Console.WriteLine($"All derived numbers are:\n{string.Join("\n", allNumbers)}");
            Console.WriteLine($"You have {validNumbers.Count} valid numbers:\n{string.Join("\n", validNumbers)}");

        }

        static string DerivePhoneNumber(char[,] keypad, ChessPiece piece, int startRow, int startCol)
        {
            switch (piece.Move)
            {
                case '1':
                    return PawnNumber(keypad, startRow, startCol);

                case '+':
                    return RockNumber(keypad, startRow, startCol);

                case 'L':
                    return KnightNumber(keypad, startRow, startCol);

                case 'X':
                    return BishopNumber(keypad, startRow, startCol);

                case '*':
                    return QueenNumber(keypad, startRow, startCol);

                case 'o':
                    return KingNumber(keypad, startRow, startCol);

                default:
                    return "";
            }                 

        }

        static string PawnNumber(char[,] keypad, int startRow, int startCol)
        {
            Random random = new Random();
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {
                int row;
                int op = random.Next(2);
                if(op == 1)
                {
                    row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                    phoneNumber.Append(keypad[row, startCol].ToString());
                    startRow = row;
                }
                else if(op == 0)
                {
                    row = startRow + 1 <= keypad.GetLength(0) - 1 ? startRow + 1 : startRow - 1;
                    phoneNumber.Append(keypad[row, startCol].ToString());
                    startRow = row;
                }
            }

            return phoneNumber.ToString();
        }

        static string RockNumber(char[,] keypad, int startRow, int startCol)
        {
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());
            
            for (int i = 0; i < 6; i++)
            {

            }

            return phoneNumber.ToString();
        }

        static string KnightNumber(char[,] keypad, int startRow, int startCol)
        {
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {

            }

            return phoneNumber.ToString();
        }

        static string BishopNumber(char[,] keypad, int startRow, int startCol)
        {
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {

            }

            return phoneNumber.ToString();
        }

        static string QueenNumber(char[,] keypad, int startRow, int startCol)
        {
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {

            }

            return phoneNumber.ToString();
        }

        static string KingNumber(char[,] keypad, int startRow, int startCol)
        {
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {

            }

            return phoneNumber.ToString();
        }

        static bool IsValidNumber(string number)
        {
            if ( number.Length != 7 || number.StartsWith('1') || number.StartsWith('0') || number.Contains('*') || number.Contains('#') )
            {
                return false;
            }
            return true;
        }


    }

    
}
