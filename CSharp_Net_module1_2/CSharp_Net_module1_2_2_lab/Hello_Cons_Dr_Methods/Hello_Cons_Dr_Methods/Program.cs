using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Implement start position, width and height, symbol, message input
                var height = 10;
                var width = 20;
                var symbol = "-";
                var message = "sdgksngdldfglkf";
                //Create widthBox class instance
                var box = new Box(width, height, symbol, message);
                //Use  Box.Draw() method
                box.Draw();
                Console.WriteLine("Press any key...");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");
            }
            
        }
    }
}
