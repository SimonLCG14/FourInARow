using System;

namespace FourInARow
{
    class Program
    {
        private static readonly bool[,] isBlue = new bool[7, 6];
        private static readonly bool[,] isRed = new bool[7, 6];
        private static readonly int[] columnHeights = new int[7];
        private static readonly char playingSymbol = '#';
        static void Main(string[] args)
        {
            
            int playingCounter = 1;
            int userMove = 0;

            PrintField();

            for (int i = 0; i < 2; i++)
            {
                do
                {
                    PrintInput(playingCounter);
                    userMove = int.Parse(Console.ReadLine());
                } while (isValid(userMove) == false);

                columnHeights[userMove - 1] += 1;

                if (playingCounter % 2 == 0)
                {
                    isBlue[userMove - 1, columnHeights[userMove]] = true;
                }
                else
                {
                    isRed[userMove - 1, columnHeights[userMove]] = true;
                }

                playingCounter++;

                for (int k = 0; k < 50; k++)
                {
                    Console.WriteLine();
                }

                PrintField();
            }

        }
        private static void PrintField()
        {
            PrintLine();
            Console.WriteLine();

            for (int i = 5; i >= 0; i--)
            {    
                for (int j = 0; j < 7; j++)
                {
                    if (j == 0)
                    {
                        if (isBlue[j, i] == true)
                        {
                            Console.Write("|  ");
                            ChangeColor('b');
                            Console.Write(playingSymbol);
                            ChangeColor('d');
                            Console.Write("|");
                        }
                        else if (isRed[j, i] == true)
                        {
                            Console.Write("|  ");
                            ChangeColor('r');
                            Console.Write(playingSymbol);
                            ChangeColor('d');
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write($"|   |");
                        }
                    }
                    else
                    {
                        if (isBlue[j, i] == true)
                        {
                            Console.Write("  ");
                            ChangeColor('b');
                            Console.Write(playingSymbol);
                            ChangeColor('d');
                            Console.Write("|");
                        }
                        else if (isRed[j, i] == true)
                        {
                            Console.Write("  ");
                            ChangeColor('r');
                            Console.Write(playingSymbol);
                            ChangeColor('d');
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write($"   |");
                        }
                    }
                }

                Console.WriteLine();

                PrintLine();

                Console.WriteLine();
            }

            Console.WriteLine();
        }
        private static void PrintLine()
        {
            Console.Write("+");

            for (int i = 0; i < 7; i++)
            {
                Console.Write("---+");
            }
        }
        private static void Reset()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    isBlue[i, j] = false;
                    isRed[i, j] = false;
                }
            }

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }
        }
        private static void PrintInput(int counter)
        {
            Console.Write("Please enter column ");

            if (counter % 2 == 0)
            {
                ChangeColor('d');
                Console.Write("(Blue) ");
                ChangeColor('d');

            }
            else
            {
                ChangeColor('r');
                Console.Write("(Red) ");
                ChangeColor('d');
            }
        }
        private static bool isValid(int move)
        {
            bool isMoveValid = true;
            move--;

            if(columnHeights[move] == 6)
            {
                isMoveValid = false;
            }

            return isMoveValid;
        }
        private static void PrintSpace()
        {
            for(int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }
        }
        private static void ChangeColor(char color)
        {
            switch(color)
            {
                case 'r':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case 'b':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
    }
}
