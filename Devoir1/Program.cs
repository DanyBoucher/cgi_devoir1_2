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

        public static bool ValueVerification(int pSquareDimensionMinimum, int pSquareDimensionMaximum, string pUserValueSquareDimensionString, string pWarningMessage)
        {
            int number;

            bool success = Int32.TryParse(pUserValueSquareDimensionString, out number);
            if (success && number >= pSquareDimensionMinimum && number <= pSquareDimensionMaximum)
            {
                return true;
            }
            else
            {
                DisplayWarning(pWarningMessage);
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
            int squareDimensionMinimum = 3;
            int squareDimensionMaximum = 95;
            string squareWarningDimensionMessage = $"Only integer value between 3 and {squareDimensionMaximum} are permetted ";
            
            int menuNumberMinimum = 1;
            int menuNumberMaximum = 5;
            string menuWarningMessage = $" Only integer value between {menuNumberMinimum} and {menuNumberMaximum} are permetted ";

            string userValueSquareShapeString;
            string userValueSquareDimensionString;

            SquareDimensionMenu(squareDimensionMaximum);
            userValueSquareDimensionString = Console.ReadLine();
            while (!ValueVerification(squareDimensionMinimum, squareDimensionMaximum, userValueSquareDimensionString, squareWarningDimensionMessage))
            {
                SquareDimensionMenu(squareDimensionMaximum);
                userValueSquareDimensionString = Console.ReadLine();
            }

            Console.WriteLine();

            while (true)
            {
                Menu();
                userValueSquareShapeString = Console.ReadLine();
                Console.WriteLine();

                if (ValueVerification(menuNumberMinimum, menuNumberMaximum, userValueSquareShapeString, menuWarningMessage))
                {
                    if (userValueSquareShapeString == "1" || userValueSquareShapeString == "2" || userValueSquareShapeString == "3")
                    {
                        SquareMethod(userValueSquareShapeString, userValueSquareDimensionString);
                    }
                    else if (userValueSquareShapeString == "4")
                    {
                        SquareDimensionMenu(squareDimensionMaximum);
                        userValueSquareDimensionString = Console.ReadLine();
                        while (!ValueVerification(squareDimensionMinimum, squareDimensionMaximum, userValueSquareDimensionString, squareWarningDimensionMessage))
                        {
                            SquareDimensionMenu(squareDimensionMaximum);
                            userValueSquareDimensionString = Console.ReadLine();
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
