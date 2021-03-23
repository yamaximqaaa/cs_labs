using System;
using System.Threading;

namespace CSharp_Net_module1_6_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //use Console.ForegroundColor = ConsoleColor.Gray for output
            Console.ForegroundColor = ConsoleColor.Gray;
            //create ThreadManipulator object
            ThreadManipulator threadManipulator = new ThreadManipulator();
            
            //create first thread for AddingOne method
            Thread firstTrhreead = new Thread(new ParameterizedThreadStart(threadManipulator.AddingOne));
            
            //create second thread for AddingOne method
            Thread secondTrhreead = new Thread(new ParameterizedThreadStart(threadManipulator.AddingOne));
            
            //create thread for AddingCustomValue method
            Thread thirdTrhreead = new Thread(new ParameterizedThreadStart(threadManipulator.AddingCustomValue));
            
            //create Background thread for Stop method
            Thread myThreadBackground = new Thread(new ThreadStart(threadManipulator.Stop));
            myThreadBackground.IsBackground = true;
            //start Background thread for Stop method
            myThreadBackground.Start();

            //start first thread for AddingOne method with argument = 10
            firstTrhreead.Start(10);
            //start second thread for AddingOne method with argument = 20
            secondTrhreead.Start(20);
            //start thread for AddingCustomValue method with argument new[] { 5, 15 }
            thirdTrhreead.Start(new[] { 5, 15 });
            //join threads

            Console.ReadLine();
            
        }
    }
}
