using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    // 1) declare enumeration CurrencyTypes, values UAH, USD, EU
    enum CurrencyTypes
    {
        UAH = 1, 
        USD,
        EU
    }

    class Money
    {
        // 2) declare 2 properties Amount, CurrencyType
        CurrencyTypes type;
        public int amount { get; set; }

        // 3) declare parameter constructor for properties initialization
        public Money(CurrencyTypes type, int amount)
        {
            this.type = type;
            this.amount = amount;
        }

        // 4) declare overloading of operator + to add 2 objects of Money
        public static Money operator +(Money par1, Money par2)
        {
            if (par1.type != par2.type)
            {
                Console.WriteLine("Different currencies!");
                Console.WriteLine("Parameter1 {0}: {1}", par1.type, par1.amount);
                Console.WriteLine("Parameter2 {0}: {1}", par2.type, par2.amount);
                return par1;
            }
            else
            {
                Money par3 = new Money(par1.type, par1.amount + par2.amount);
                return par3;
            }
        }

        // 5) declare overloading of operator -- to decrease object of Money by 1
        public static Money operator --(Money par1)
        {
            par1.amount--;
            return par1;
        }

        // 6) declare overloading of operator * to increase object of Money 3 times
        public static Money operator *(Money par1, int cof)
        {
            par1.amount *= cof;
            return par1;
        }
        // 7) declare overloading of operator > and < to compare 2 objects of Money
        public static bool operator >(Money par1, Money par2)
        {
            if (par1.amount > par2.amount)
                return true;
            else
                return false;
        }
        public static bool operator <(Money par1, Money par2)
        {
            if (par1.amount < par2.amount)
                return true;
            else
                return false;
        }

        // 8) declare overloading of operator true and false to check CurrencyType of object
        public static bool operator true(Money par1)
        {
            if (par1.type == CurrencyTypes.UAH)
                return true;
            else
                return false;
        }
        public static bool operator false(Money par1)
        {
            if (par1.type != CurrencyTypes.UAH)
                return false;
            else
                return true;
        }
        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa
        public static implicit operator double (Money par1)
        { return par1.amount; }
        public static implicit operator string(Money par1)
        { return par1.type.ToString() + ": " + par1.amount.ToString(); }
    }
}
