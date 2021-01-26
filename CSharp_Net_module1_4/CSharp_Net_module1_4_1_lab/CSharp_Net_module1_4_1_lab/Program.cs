using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_4_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 9) declare object of OnlineShop 
            OnlineShop os1 = new OnlineShop();
            // 10) declare several objects of Customer
            Customer cus1 = new Customer("Cus1");
            Customer cus2 = new Customer("Cus2");
            Customer cus3 = new Customer("Cus3");
            // 11) subscribe method GotNewGoods() of every Customer instance 
            // to event NewGoodsInfo of object of OnlineShop
            os1.MyEvent += cus1.GotNewGoods;
            os1.MyEvent += cus2.GotNewGoods;
            os1.MyEvent += cus3.GotNewGoods;
            // 12) invoke method NewGoods() of object of OnlineShop
            // discuss results
            os1.NewGoods("new book");
        }
    }
}
