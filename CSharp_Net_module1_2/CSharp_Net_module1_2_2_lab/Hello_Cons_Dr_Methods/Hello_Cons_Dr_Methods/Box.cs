using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Box
    {
        //1.  Implement public  auto-implement properties for start position (point position)
        //auto-implement properties for width and height of the box
        //and auto-implement properties for a symbol of a given set of valid characters (*, + ,.) to be used for the border 
        //and a message inside the box
        int sizeW { get; set; }
        int sizeH { get; set; }
        string symbol { get; set; }
        string text { get; set; }
        string[,] box;


        //2.  Implement public Draw() method
        //to define start position, width and height, symbol, message  according to properties
        //Use Math.Min() and Math.Max() methods
        //Use draw() to draw the box with message
        public Box(int sizeW, int sizeH, string symbol, string text)
        {
            this.sizeW = sizeW;
            this.sizeH = sizeH;
            this.symbol = symbol;
            this.text = text;
            box = new string[sizeH, sizeW];
        }
        private void printBorder()
        {
            for (int i = 0; i < sizeH; i++)
            {
                for (int j = 0; j < sizeW; j++)
                {
                    box[i, j] = " ";
                }
            }
            for (int i = 0; i < sizeW; i++)
            {
                box[0, i] = symbol;
                box[sizeH-1, i] = symbol;
            }
            for(int i = 1; i < sizeH-1; i++)
            {
                box[i, 0] = symbol;
                box[i, sizeW-1] = symbol;
            }

        }
        private string[] TextToArr()
        {
            string[] arr = new string[text.Length];
            for(int i = 0; i < text.Length; i++)
            {
                arr[i] = text[i].ToString();
            }
            return arr;
        }
        private void printBody()
        {
            if (sizeW-2 < text.Length)
            {
                Console.WriteLine("Text is too big!");
                return;
            }
            else
            {
                string[] arr = TextToArr();
                var iMid = sizeH / 2;
                var jMid = ((sizeW - text.Length) / 2);
                for (int i = 0; i < sizeH; i++)
                {
                    for (int j = 0; j < sizeW; j++)
                    {
                        if (iMid == i && jMid == j)
                        {
                            for (int t = 0; t < text.Length; t++)
                            {
                                box[i, j] = arr[t];
                                j++;
                            }
                        }
                    }
                }
            }
        }
        public void Draw()
        {
            printBorder();
            printBody();
            TestArray();
        }
        public void TestArray()
        {
            /*
            for (int i = 0; i < sizeH; i++)
            {
                for (int j = 0; j < sizeW; j++)
                {
                    box[i,j] = "";
                }
            }*/
            for (int i = 0; i < sizeH; i++)
            {
                for (int j = 0; j < sizeW; j++)
                {
                    Console.Write(box[i,j]);
                }
                Console.WriteLine();
            }
        }


        //3.  Implement private method draw() with parameters 
        //for start position, width and height, symbol, message
        //Change the message in the method to return the Box square
        //Use Console.SetCursorPosition() method
        //Trim the message if necessary


    }
}
