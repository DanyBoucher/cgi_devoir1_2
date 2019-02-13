using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir1
{
    class Program
    {
        public static string PrintStar()
        {
            return "*";
        }

        public static string PrintHyphen()
        {
            return "-";
        }

        public static void SquareMethod(string pUserValueSquareShape, string pDimension)
        {
            int pSquareDimension = Int32.Parse(pDimension);
            string stringOutPut = "";

            int myVariable = pSquareDimension - 1;

            for (int i = 0; i < pSquareDimension; i++)
            {
                stringOutPut = "";
                for (int j = 0; j < pSquareDimension; j++)
                {
                    if (i == 0 || i == pSquareDimension - 1)
                    {
                        stringOutPut += PrintStar();
                    }
                    else if (i >= 1 && i <= pSquareDimension - 2)
                    {
                        if (j == 0 || j == pSquareDimension - 1 || (i == j && (pUserValueSquareShape == "2" || pUserValueSquareShape == "3")) || (j == myVariable && pUserValueSquareShape == "3"))
                        {
                            stringOutPut += PrintStar();
                        }
                        else
                        {
                            stringOutPut += PrintHyphen();
                        }
                    }
                }
                myVariable--;
                Console.WriteLine(stringOutPut);
            }
            Console.WriteLine();
        }

        public static void SquareDimensionMenu(int pSquareDimensionMaximum)
        {
            Console.WriteLine("\nSQUARE DIMENSION");
            Console.Write("Please enter a integer square dimension value between 3 and " + pSquareDimensionMaximum + ": ");
        }

        public static bool SquareDimensionValueVerification(int pSquareDimensionMaximum, string pUserValueSquareDimensionString)
        {
            int number;

            bool success = Int32.TryParse(pUserValueSquareDimensionString, out number);
            if (success)
            {
                if (number >= 3 && number <= pSquareDimensionMaximum)
                {
                    return true;
                }
                else
                {
                    WarningDimension(pSquareDimensionMaximum);
                    return false;
                }
            }
            else
            {
                WarningDimension(pSquareDimensionMaximum);
                return false;
            }
        }

        public static void Menu()
        {
            Console.WriteLine("--- MENU ---");
            Console.WriteLine("Method 1:  1");
            Console.WriteLine("Method 2:  2");
            Console.WriteLine("Method 3:  3");
            Console.WriteLine("Dimension: 4");
            Console.WriteLine("LEAVE:     5");
            Console.Write("\nPlease enter a numeric value between 1 and 5: ");
        }

        public static bool MenuValueVerification(string pUserValueSquareDimensionString)
        {
            int number;

            bool success = Int32.TryParse(pUserValueSquareDimensionString, out number);
            if (success)
            {
                if (number >= 1 && number <= 5)
                {
                    return true;
                }
                else
                {
                    WarningMenu();
                    return false;
                }
            }
            else
            {
                WarningMenu();
                return false;
            }
        }

        public static void WarningDimension(int pSquareDimensionMaximum)
        {
            var msg = $"Only integer value between 3 and {pSquareDimensionMaximum} are permetted ";
            DisplayWarning(msg);
        }

        public static void WarningMenu()
        {
            var msg = $" Only integer value between 1 and 5 are permetted ";
            DisplayWarning(msg);
        }

        public static void DisplayWarning(string msg)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("------------------------ WARNING -------------------------");
            Console.WriteLine("---                                                    ---");
            Console.WriteLine($"--- {msg} ---");
            Console.WriteLine("---                                                    ---");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------\n");
        }

        static void Main(string[] args)
        {
            int squareDimensionMaximum = 95;
            string userValueSquareShape;
            string userValueSquareDimension;

            SquareDimensionMenu(squareDimensionMaximum);
            userValueSquareDimension = Console.ReadLine();
            while (!SquareDimensionValueVerification(squareDimensionMaximum, userValueSquareDimension))
            {
                SquareDimensionMenu(squareDimensionMaximum);
                userValueSquareDimension = Console.ReadLine();
            }

            Console.WriteLine();

            while (true)
            {
                Menu();
                userValueSquareShape = Console.ReadLine();
                Console.WriteLine();

                if (MenuValueVerification(userValueSquareShape))
                {
                    if (userValueSquareShape == "1" || userValueSquareShape == "2" || userValueSquareShape == "3")
                    {
                        SquareMethod(userValueSquareShape, userValueSquareDimension);
                    }
                    else if (userValueSquareShape == "4")
                    {
                        SquareDimensionMenu(squareDimensionMaximum);
                        userValueSquareDimension = Console.ReadLine();
                        while (!SquareDimensionValueVerification(squareDimensionMaximum, userValueSquareDimension))
                        {
                            SquareDimensionMenu(squareDimensionMaximum);
                            userValueSquareDimension = Console.ReadLine();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
