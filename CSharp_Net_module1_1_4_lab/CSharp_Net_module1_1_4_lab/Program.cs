using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_1_4_lab
{
    class Program
    {
        // 1) declare enum ComputerType
        enum typePC
        {
            desktop,
            laptop,
            server
        }

        // 2) declare struct Computer
        struct computer
        {
            public typePC type;
            public int CPUc;
            public double CPUh;
            public int memory;
            public int HDD;

            public computer(typePC type_, 
                     int CPUc_, 
                     double CPUh_, 
                     int memory_, 
                     int HDD_)
            {
                type = type_;
                CPUc = CPUc_;
                CPUh = CPUh_;
                memory = memory_;
                HDD = HDD_;
            }
            


        }

        static void Main(string[] args)
        {
            // 3) declare jagged array of computers size 4 (4 departments)
            computer[][] dep = new computer[4][];


            // 4) set the size of every array in jagged array (number of computers)
            computer desktop = new computer(typePC.desktop, 4, 2.5, 6, 500);
            computer laptop = new computer(typePC.laptop, 2, 1.7, 4, 250);
            computer server = new computer(typePC.server, 8, 3, 16, 2000);
            dep[0] = new computer[5]; //{ desktop, desktop, laptop, laptop, server };
            dep[1] = new computer[3]; //{ laptop, laptop, laptop };
            dep[2] = new computer[5]; //{ desktop, desktop, laptop, laptop, desktop }; 
            dep[3] = new computer[4]; //{ desktop,  laptop, server, server }; 

            // 5) initialize array
            // Note: use loops and if-else statements
            
            //computer desktop = new computer(typePC.desktop, 4, 2.5, 6, 500);
            //computer laptop = new computer(typePC.laptop, 2, 1.7, 4, 250);
            //computer server = new computer(typePC.server, 8, 3, 16, 2000);

            
            int input = 0;
            for (int i = 0; i < dep.GetLength(0); i++)
            {
                Console.WriteLine("Departament {0}.", i+1);
                for (int j = 0; j < dep[i].GetLength(0); j++)
                {
                    Console.WriteLine("What computer you want to add?");
                    Console.WriteLine("1 -> Desktop");
                    Console.WriteLine("2 -> Laptop");
                    Console.WriteLine("3 -> Server");
                    bool check = false;
                    while (!check)
                    {
                        input = int.Parse(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                dep[i][j] = desktop;
                                check = true;
                                Console.WriteLine();
                                break;
                            case 2:
                                dep[i][j] = laptop;
                                check = true;
                                Console.WriteLine();
                                break;
                            case 3:
                                dep[i][j] = server;
                                check = true;
                                Console.WriteLine();
                                break;
                            default:
                                Console.WriteLine("Incorrect input.");
                                check = false;
                                break;
                        }
                    }
                }
                Console.Clear();
            }

            // 6) count total number of every type of computers
            // 7) count total number of all computers
            // Note: use loops and if-else statements
            // Note: use the same loop for 6) and 7)
            int allComp = 0,
                desktopCount = 0,
                laptopCount = 0,
                serverCount = 0;
            
            for (int i = 0; i < dep.GetLength(0); i++)
            {
                for (int j = 0; j < dep[i].GetLength(0); j++)
                {
                    allComp++;
                    if (dep[i][j].type == typePC.desktop)
                        desktopCount++;
                    if (dep[i][j].type == typePC.laptop)
                        laptopCount++;
                    if (dep[i][j].type == typePC.server)
                        serverCount++;
                }
            }
            Console.WriteLine("All computers: {0}", allComp);
            Console.WriteLine("Desktop computers: {0}", desktopCount);
            Console.WriteLine("Laptop computers: {0}", laptopCount);
            Console.WriteLine("Server computers: {0}", serverCount);
            Console.WriteLine();
            // 8) find computer with the largest storage (HDD) - 
            // compare HHD of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            computer largestHDD = dep[0][0];
            int[] ID = new int[2];
            for (int i = 0; i < dep.GetLength(0); i++)
            {
                for (int j = 0; j < dep[i].GetLength(0); j++)
                {
                    if (dep[i][j].HDD >= largestHDD.HDD)
                    {
                        largestHDD = dep[i][j];
                        ID[0] = i;
                        ID[1] = j;
                    }
                }
            }

            Console.WriteLine("Size of largest HDD is: {0}.", largestHDD.HDD);
            Console.WriteLine("ID: [{1}][{2}]", ID[0], ID[1]);
            Console.WriteLine();
            // 9) find computer with the lowest productivity (CPU and memory) - 
            // compare CPU and memory of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            // Note: use logical oerators in statement conditions
            computer slovestComp = dep[0][0];
            for (int i = 0; i < dep.GetLength(0); i++)
            {
                for (int j = 0; j < dep[i].GetLength(0); j++)
                {
                    if (dep[i][j].CPUc <= slovestComp.CPUc &&
                        dep[i][j].CPUh <= slovestComp.CPUh &&
                        dep[i][j].memory <= slovestComp.memory )
                    {
                        slovestComp = dep[i][j];
                        ID[0] = i;
                        ID[1] = j;
                    }
                }
            }
            Console.WriteLine("CPU of lowest productivity PC is: {0} cores, {1} HGz. Memory is {2}GB", slovestComp.CPUc, 
                slovestComp.CPUh, slovestComp.memory);
            Console.WriteLine("ID: [{0}][{1}]", ID[0], ID[1]);
            Console.WriteLine();
            // 10) make desktop upgrade: change memory up to 8
            // change value of memory to 8 for every desktop. Don't do it for other computers
            // Note: use loops and if-else statements

            
            for (int i = 0; i < dep.GetLength(0); i++)
            {
                for (int j = 0; j < dep[i].GetLength(0); j++)
                {
                    if (dep[i][j].type == typePC.desktop)
                    {
                        dep[i][j].memory = 8;
                        Console.WriteLine("Upgrade sucsessful!!!");
                    }
                }
            }
            
        }
 
    }
}
