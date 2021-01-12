using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_fact_advstud
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define parameters to calculate the factorial of
            //Call fact() method to calculate
            var num = 6;
            Console.WriteLine("Fact result: " + factt(num)); 
        }

        //Create fact() method  with parameter to calculate factorial
        //Use ternary operator
        static int factt(int num)
        {
            int res = 0;
            if (num == 1)
                return 1;
            else
                return num * factt(num - 1);

        }
    }

    

}
