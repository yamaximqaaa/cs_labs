using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            long a;
            Console.WriteLine(@"Please,  type the number:
            1. Farmer, wolf, goat and cabbage puzzle
            2. Console calculator
            3. Factirial calculation
            ");
            
            a = long.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Farmer_puzzle();
                    Console.WriteLine("Farmer, wolf, goat and cabbage puzzle");
                    break;
                case 2:
                    Calculator();
                    Console.WriteLine("Console calculator");
                    break;
                case 3:
                    Console.WriteLine("Factirial calculation");
                    Factorial_calculation();
                    break;
                default:
                    Console.WriteLine("Exit");
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
        #region farmer
        static void Farmer_puzzle()
        {
            //Key sequence: 3817283 or 3827183
            // Declare 7 int variables for the input numbers and other variables
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"From one bank to another should carry a wolf, goat and cabbage. 
At the same time can neither carry nor leave together on the banks of a wolf and a goat, 
a goat and cabbage. You can only carry a wolf with cabbage or as each passenger separately. 
You can do whatever how many flights. How to transport the wolf, goat and cabbage that all went well?");
            Console.WriteLine("There: farmer and wolf - 1");
            Console.WriteLine("There: farmer and cabbage - 2");
            Console.WriteLine("There: farmer and goat - 3");
            Console.WriteLine("There: farmer  - 4");
            Console.WriteLine("Back: farmer and wolf - 5");
            Console.WriteLine("Back: farmer and cabbage - 6");
            Console.WriteLine("Back: farmer and goat - 7");
            Console.WriteLine("Back: farmer  - 8");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please,  type numbers by step ");
            // Implement input and checking of the 7 numbers in the nested if-else blocks with the  Console.ForegroundColor changing
            bool answer = false;
            int operand = 1000000;
            int key1 = 3817283;
            int key2 = 3827183;
            int counter = 0;
            while (!answer)
            {
                if (counter < 7)
                {
                    int numCase = int.Parse(Console.ReadLine());
                    
                    if (numCase == (key1/operand) || numCase == (key2 / operand))
                    {
                        key1 = key1 - operand * numCase;
                        key2 = key2 - operand * numCase;
                        operand /=10;
                        
                        Console.WriteLine("Correctly. Enter next num: ");
                        counter++;
                        continue;
                    }
                    else 
                    {
                        Console.WriteLine("Wrong. Try again: ");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("I congratulate You completely guessed the sequence!!!");
                    answer = true;
                    break;
                }
                
            }
        }
        #endregion

        #region calculator
        static void Calculator()
        {
            // Set Console.ForegroundColor  value
            Console.WriteLine(@"Select the arithmetic operation:
1. Multiplication 
2. Divide 
3. Addition 
4. Subtraction
5. Exponentiation ");

            // Implement option input (1,2,3,4,5)
            //     and input of  two or one numbers
            //  Perform calculations and output the result 
            int variant = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter first num: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter second num: ");
            double num2 = double.Parse(Console.ReadLine());
            switch (variant)
            {
                case 1: // Multiplication (umnojenie)
                    Console.WriteLine("Multiplication: ");
                    umnojenie(num1, num2);
                    break;
                case 2: // Divide (Delenie) 
                    Console.WriteLine("Divide: ");
                    delenie(num1, num2);
                    break;
                case 3: // Addition (slojenie)
                    Console.WriteLine("Addition: ");
                    slojenie(num1, num2);
                    break;
                case 4: // Subtraction (vicitanie) 
                    Console.WriteLine("Subtraction: ");
                    vicitanie(num1, num2);
                    break;
                case 5: // Exponentiation (pow) 
                    Console.WriteLine("Exponentiation: ");
                    pow(num1, num2);
                    break;
                default:
                    Console.WriteLine("Exit");
                    break;
            }
        }
        static void umnojenie(double a, double b)
        {
            a *= b;
            Console.WriteLine("Result: {0}", a);
        }
        static void delenie(double a, double b)
        {
            a /= b;
            Console.WriteLine("Result: {0}", a);
        }
        static void slojenie(double a, double b)
        {
            a += b;
            Console.WriteLine("Result: {0}", a);
        }
        static void vicitanie(double a, double b)
        {
            a -= b;
            Console.WriteLine("Result: {0}", a);
        }
        static void pow(double a, double b)
        {
            Console.WriteLine("Result: {0}", Math.Pow(a, b));
        }
        #endregion

        #region Factorial
        static void Factorial_calculation()
        {
            Console.WriteLine("Enter factorial num: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Result: {0}.", factt(num));
        }
        static int factt(int num)
        {
            int res = 0;
            if (num == 1)
                return 1;
            else
                return num * factt(num - 1);
            Console.WriteLine("Result: {0}.", res);
        }
        #endregion
    }
}
