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
                sh = -234;
                ush = 234;
                i = -3554;
                ui = 3554;
                l = -23452;
                ul = 23445;
                de = 2.3523523m;
                fl = 2.235f;
                d0 = 3.2352;
            }

            // 7)check values of variables from 1). Are they changed? Think, why

            System.Console.WriteLine("boo: {0}", boo);
            System.Console.WriteLine("ch: {0}", ch);
            System.Console.WriteLine("b: {0}", b);
            System.Console.WriteLine("sb: {0}", sb);
            System.Console.WriteLine("sh: {0}", sh);
            System.Console.WriteLine("ush: {0}", ush);
            System.Console.WriteLine("i: {0}", i);
            System.Console.WriteLine("ui: {0}", ui);
            System.Console.WriteLine("l: {0}", l);
            System.Console.WriteLine("ul: {0}", ul);
            System.Console.WriteLine("de: {0}", de);
            System.Console.WriteLine("fl: {0}", fl);
            System.Console.WriteLine("d0: {0}", d0);

            // 8) use implicit(neyavnii)/ explicit(yavnii) conversion to convert variables from 1). 
            // Is it possible? 

            // Fix compilation errors (in case of impossible conversion commemt that line).
            // int -> char
            char v1 = (char)i;      //explicit
            //char v2 = i;          //implicit ne rabotaet
            System.Console.WriteLine("Int->Char: {0}", v1);
            // bool -> short
            //short v3 = (short)boo;    //explicit ne rabotaet (a mojno li kakto 1 i 0?)
            //short v4 = boo;          //implicit ne rabotaet

            // double -> long
            long v5 = (long)d0;       //explicit
            //long v6 = d0;           //implicit   ne rabotaet

            // float -> char 
            char v7 = (char)fl;    //explicit
            //char v8 = fl;        //implicit ne rabotaet
            System.Console.WriteLine("float -> char: {0}", v7);
            
            // decimal -> double
            double v9 = (double)de;      //explicit
            //double v10 = de;           //implicit ne rabotaet
                                      
            // byte -> uint
            uint v11 = (uint)b;    //explicit
            uint v12 = b;          //implicit

            // ulong -> sbyte
            sbyte v13 = (sbyte)ul;   //explicit
            //sbyte v14 = ul;        //implicitne rabotaet

            // 9) and reverse conversion with fixing compilation errors.
            
            // int <- char
            int vv1 = (int)ch;      //explicit
            int vv2 = ch;           //implicit 
            System.Console.WriteLine("Int<-Char: {0}, {1}", vv1, vv2);

            // bool <- short
            //bool vv3 = (bool)sh;    //explicit ne rabotaet (a mojno li kakto 1 i 0?)
            //bool vv4 = sh;          //implicit ne rabotaet

            // double <- long
            double vv5 = (double)l;     //explicit
            double vv6 = l;             //implicit   //??????

            // float <- char 
            float vv7 = (float)ch;     //explicit
            float vv8 = ch;            //implicit ne rabotaet
            System.Console.WriteLine("float <- char: {0}, {1}", vv7, vv8);

            // decimal <- double
            decimal vv9 = (decimal)d0;    //explicit
            //decimal vv10 = d0;          //implicit ne rabotaet    //???????????        

            // byte <- uint
            byte vv11 = (byte)ui;      //explicit
            //byte vv12 = ui;          //implicit ne rabotaet

            // ulong <- sbyte
            ulong vv13 = (ulong)sb;     //explicit
            //ulong vv14 = sb;          //implicitne rabotaet

            // 10) declare int nullable value. Initialize it with 'null'. 
            // Try to initialize variable i with 'null'. Is it possible?

            int? nnuull = null;
            //i = null;
        }
    }
}
