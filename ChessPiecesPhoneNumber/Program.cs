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
            Random random = new Random();
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {
                int row;
                int col;
                int op = random.Next(4);
                if (op == 0)
                {
                    row = startRow > 0 ? random.Next(0, startRow) : random.Next(1, keypad.GetLength(0));
                    phoneNumber.Append(keypad[row, startCol].ToString());
                    startRow = row;
                }
                else if (op == 1)
                {
                    row = startRow < keypad.GetLength(0)-1 ? random.Next(startRow+1, keypad.GetLength(0)) : random.Next(0, keypad.GetLength(0)-1);
                    phoneNumber.Append(keypad[row, startCol].ToString());
                    startRow = row;
                }
                else if (op == 2)
                {
                    col = startCol > 0 ? random.Next(0, startCol) : random.Next(1, keypad.GetLength(1));
                    phoneNumber.Append(keypad[startRow, col].ToString());
                    startCol = col;
                }
                else if (op == 3)
                {
                    col = startCol < keypad.GetLength(1) - 1 ? random.Next(startCol + 1, keypad.GetLength(1)) : random.Next(0, keypad.GetLength(1) - 1);
                    phoneNumber.Append(keypad[startRow, col].ToString());
                    startCol = col;
                }

            }

            return phoneNumber.ToString();
        }

        static string KnightNumber(char[,] keypad, int startRow, int startCol)
        {
            Random random = new Random();
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {
                int row;
                int col;
                int op = random.Next(4);
                if (op == 0)
                {
                    if (startRow - 2 >= 0)
                    {
                        row = startRow - 2;
                        col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;
                    }
                    else if(startRow + 2 < keypad.GetLength(0))
                    {
                        row = startRow + 2;
                        col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;
                    }
                    else if (startCol - 2 >= 0)
                    {
                        col = startCol - 2;
                        row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;
                    }
                    else if (startCol + 2 < keypad.GetLength(1))
                    {
                        col = startCol + 2;
                        row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;

                    }
                }
                else if (op == 1)
                {
                    if (startRow + 2 < keypad.GetLength(0))
                    {
                        row = startRow + 2;
                        col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;

                    }
                    else if (startRow - 2 >= 0)
                    {
                        row = startRow - 2;
                        col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;
                    }
                    else if (startCol - 2 >= 0)
                    {
                        col = startCol - 2;
                        row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;
                    }
                    else if (startCol + 2 < keypad.GetLength(1))
                    {
                        col = startCol + 2;
                        row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;

                    }
                }
                else if (op == 2)
                {
                    if (startCol - 2 >= 0)
                    {
                        col = startCol - 2;
                        row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;
                    }
                    else if (startCol + 2 < keypad.GetLength(1))
                    {
                        col = startCol + 2;
                        row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;

                    }
                    else if (startRow + 2 < keypad.GetLength(0))
                    {
                        row = startRow + 2;
                        col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;

                    }
                    else if (startRow - 2 >= 0)
                    {
                        row = startRow - 2;
                        col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;
                    }
                }
                else if (op == 3)
                {
                    if (startCol + 2 < keypad.GetLength(1))
                    {
                        col = startCol + 2;
                        row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;

                    }
                    else if (startCol - 2 >= 0)
                    {
                        col = startCol - 2;
                        row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;
                    }
                    else if (startRow + 2 < keypad.GetLength(0))
                    {
                        row = startRow + 2;
                        col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;

                    }
                    else if (startRow - 2 >= 0)
                    {
                        row = startRow - 2;
                        col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                        phoneNumber.Append(keypad[row, col].ToString());
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            return phoneNumber.ToString();
        }

        static string BishopNumber(char[,] keypad, int startRow, int startCol)
        {
            Random random = new Random();
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {
                int row;
                int col;
                int op = random.Next(4);
                if (op == 0)
                {
                    
                }
                else if (op == 1)
                {
                    
                }
                else if (op == 2)
                {
                    
                }
                else if (op == 3)
                {
                   
                }

            }

            return phoneNumber.ToString();
        }

        static string QueenNumber(char[,] keypad, int startRow, int startCol)
        {
            Random random = new Random();
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {
                int row;
                int col;
                int op = random.Next(8);
                //Rock Moves...
                if (op == 0)
                {
                    row = startRow > 0 ? random.Next(0, startRow) : random.Next(1, keypad.GetLength(0));
                    phoneNumber.Append(keypad[row, startCol].ToString());
                    startRow = row;
                }
                else if (op == 1)
                {
                    row = startRow < keypad.GetLength(0) - 1 ? random.Next(startRow + 1, keypad.GetLength(0)) : random.Next(0, keypad.GetLength(0) - 1);
                    phoneNumber.Append(keypad[row, startCol].ToString());
                    startRow = row;
                }
                else if (op == 2)
                {
                    col = startCol > 0 ? random.Next(0, startCol) : random.Next(1, keypad.GetLength(1));
                    phoneNumber.Append(keypad[startRow, col].ToString());
                    startCol = col;
                }
                else if (op == 3)
                {
                    col = startCol < keypad.GetLength(1) - 1 ? random.Next(startCol + 1, keypad.GetLength(1)) : random.Next(0, keypad.GetLength(1) - 1);
                    phoneNumber.Append(keypad[startRow, col].ToString());
                    startCol = col;
                }
                //Bishop moves...
                else if (op == 4)
                {
                    
                }
                else if (op == 5)
                {
                    
                }
                else if (op == 6)
                {
                    
                }
                else if (op == 7)
                {
                    
                }

            }

            return phoneNumber.ToString();
        }

        static string KingNumber(char[,] keypad, int startRow, int startCol)
        {
            Random random = new Random();
            var phoneNumber = new StringBuilder(keypad[startRow, startCol].ToString());

            for (int i = 0; i < 6; i++)
            {
                int row;
                int col;
                int op = random.Next(8);
                if (op == 0)
                {
                    row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                    phoneNumber.Append(keypad[row, startCol].ToString());
                    startRow = row;
                }
                else if (op == 1)
                {
                    row = startRow + 1 <= keypad.GetLength(0) - 1 ? startRow + 1 : startRow - 1;
                    phoneNumber.Append(keypad[row, startCol].ToString());
                    startRow = row;
                }
                else if (op == 2)
                {
                    col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                    phoneNumber.Append(keypad[startRow, col].ToString());
                    startCol = col;
                }
                else if (op == 3)
                {
                    col = startCol + 1 <= keypad.GetLength(1) - 1 ? startCol + 1 : startCol - 1;
                    phoneNumber.Append(keypad[startRow, col].ToString());
                    startCol = col;
                }
                else if (op == 4)
                {
                    row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                    col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                    phoneNumber.Append(keypad[row, col].ToString());
                    startRow = row;
                    startCol = col;
                }
                else if (op == 5)
                {
                    row = startRow - 1 >= 0 ? startRow - 1 : startRow + 1;
                    col = startCol + 1 <= keypad.GetLength(1) - 1 ? startCol + 1 : startCol - 1;
                    phoneNumber.Append(keypad[row, col].ToString());
                    startRow = row;
                    startCol = col;
                }
                else if (op == 6)
                {
                    row = startRow + 1 <= keypad.GetLength(0) - 1 ? startRow + 1 : startRow - 1;
                    col = startCol - 1 >= 0 ? startCol - 1 : startCol + 1;
                    phoneNumber.Append(keypad[row, col].ToString());
                    startRow = row;
                    startCol = col;
                }
                else if (op == 7)
                {
                    row = startRow + 1 <= keypad.GetLength(0) - 1 ? startRow + 1 : startRow - 1;
                    col = startCol + 1 <= keypad.GetLength(1) - 1 ? startCol + 1 : startCol - 1;
                    phoneNumber.Append(keypad[row, col].ToString());
                    startRow = row;
                    startCol = col;
                }

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
