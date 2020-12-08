namespace CSharp_Net_module1_1_2_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use "Debugging" and "Watch" to study variables and constants

            //1) declare variables of all simple types:
            //bool, char, byte, sbyte, short, ushort, int, uint, long, ulong, decimal, float, double
            // their names should be: 
            //boo, ch, b, sb, sh, ush, i, ui, l, ul, de, fl, d0
            // initialize them with 1, 100, 250.7, 150, 10000, -25, -223, 300, 100000.6, 8, -33.1
            // Check results (types and values). Is possible to do initialization?
            // Fix compilation errors (change values for impossible initialization)
            
            
            bool boo   = true;     // True or False
            char ch    = '1';      // ASCII symbol
            byte b     = 250;      // 0                          -> 255                        No floating-point
            sbyte sb   = 127;      // -128                       -> 127                        No floating-point
            short sh   = 10000;    // -32,768                    -> 32,767                     No floating-point
            ushort ush = 25;       // 0                          -> 65,535                     No floating-point
            int i      = -223;     // -2,147,483,648             -> 2,147,483,647              No floating-point
            uint ui    = 300;      // 0                          -> 4,294,967,295              No floating-point
            long l     = 100000;   // -9,223,372,036,854,775,808 -> 9,223,372,036,854,775,807  No floating-point    
            ulong ul   = 8;        // 0                          -> 18,446,744,073,709,551,615 No floating-point
            decimal de = -33.1m;   // (+ or -)1.0 x 10e-28       -> 7.9 x 10e28  
            float fl   = 1456.34f; // -3.402823e38               -> 3.402823e38 
            double d0  = 228.322;  // -1.79769313486232e308      -> 1.79769313486232e308 


            //2) declare constants of int and double. Try to change their values.

            const int num = 3;
            const double num2 = 4.6;

            //num += 4;
            //num2 += 0.5;


            //3) declare 2 variables with var. Initialize them 20 and 20.5. Check types. 
            // Try to reinitialize by 20.5 and 20 (change values). What results are there?

            var num3 = 20;
            var num4 = 20.5;

            System.Console.WriteLine("num3 type: {0}", num3.GetType());  // System.Int32
            System.Console.WriteLine("num4 type: {0}", num4.GetType());  // System.Double

            //num3 = 20.5;
            num4 = 20;


            // 4) declare variables of System.Int32 and System.Double.
            // Initialize them by values of i and d0. Is it possible?

            //System.Int32 num5 = i;   // No
            //System.Double num6 = d0; // no

            if (true)
            {
                // 5) declare variables of int, char, double 
                // with names i, ch, do
                // is it possible?

                //int i;     // impossible, peremennaya uze obyavlena vishe
                //char ch;   // impossible, peremennaya uze obyavlena vishe
                //double do; // impossible, do zarezervirovano sistemoi

                // 6) change values of variables from 1)

                boo = false;
                ch = 'm';
                b = 12;
                sb = 13;
                sh
                ush
                i
                ui
                l
                ul
                de
                l
                d0
            }

            // 7)check values of variables from 1). Are they changed? Think, why


            // 8) use implicit/ explicit conversion to convert variables from 1). 
            // Is it possible? 

            // Fix compilation errors (in case of impossible conversion commemt that line).
            // int -> char

            // bool -> short

            // double -> long

            // float -> char 

            // int to char

            // decimal -> double

            // byte -> uint

            // ulong -> sbyte

            // 9) and reverse conversion with fixing compilation errors.


            // 10) declare int nullable value. Initialize it with 'null'. 
            // Try to initialize variable i with 'null'. Is it possible?

        }
    }
}
