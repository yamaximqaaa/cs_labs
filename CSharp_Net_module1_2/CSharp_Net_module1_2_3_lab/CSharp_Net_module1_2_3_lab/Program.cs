using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) declare 2 objects
            Money sum1 = new Money(CurrencyTypes.UAH, 345);
            Money sum2 = new Money(CurrencyTypes.USD, 345);
            Money sum3 = new Money(CurrencyTypes.UAH, 345);
            var suum = sum1 + sum2;
            suum = suum * 3;
            Console.WriteLine((string)suum);
            // 11) do operations
            // add 2 objects of Money

            // add 1st object of Money and double

            // decrease 2nd object of Money by 1 

            // increase 1st object of Money

            // compare 2 objects of Money

            // compare 2nd object of Money and string

            // check CurrencyType of every object

            // convert 1st object of Money to string

        }
    }
}
