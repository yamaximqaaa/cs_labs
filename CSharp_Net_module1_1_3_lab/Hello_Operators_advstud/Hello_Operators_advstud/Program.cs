using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Operators_advstud
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MyMax = 200;

            Random random = new Random();
            // random.Next(MaxValue) returns a 32-bit signed integer that is greater than or equal to 0 and less than MaxValue
            int Guess_number = random.Next(MyMax) + 1;
            // implement input of number and comparison result message in the while circle with  comparison condition
            bool answer = false;
            string name;
            Console.WriteLine("Guess the number!");
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Try to guess my number");

            while (!answer)
            {
                int tryy = int.Parse(Console.ReadLine());
                if (tryy != Guess_number)
                {
                    Console.WriteLine("Sorry, but you missed.");
                    if (tryy > Guess_number)
                        Console.WriteLine("My number is lower. Try again.");
                    else
                        Console.WriteLine("My number is bigger. Try again.");
                    continue;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Congratulations {0} you guessed my number {1}!!!!!", name, Guess_number);
                    answer = true;
                    break;
                }
            }
        }
    }
}
