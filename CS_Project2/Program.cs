﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project
{
    class Program
    {
        static bool menu(Airport airport)
        {
            var i = 0;

            #region Main Menu
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("           Main menu           ");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Add Plane");
            Console.WriteLine("2. Delete plane by plane num");
            Console.WriteLine("3. Print all planes");
            Console.WriteLine("4. Find nearest plane(1 hour)");
            Console.WriteLine("5. Output emergency information");
            Console.WriteLine("6. Find some plane");
            Console.WriteLine("7. Check passengers");
            Console.WriteLine("8. Exit");
            Console.WriteLine("===============================");
            Console.WriteLine();

            Console.Write("Enter your choise: ");
            i = Convert.ToInt32(Console.ReadLine());
            #endregion

            switch (i)
            {
                case 1: // add plane------------------
                    {
                        if (airport.IsFreeSpace())
                        {
                            Plane plane = new Plane();
                            plane.BuildPlane();
                            airport.LandPlane(plane);
                        }
                        return false;
                    }
                case 2: // del plane by plane num-----
                    {
                        Console.Clear();

                        airport.PrintPlanes();


                        Console.WriteLine();
                        Console.WriteLine("You deleting plane...");
                        Console.Write("Enter num of plane: ");
                        var numm = Convert.ToInt32(Console.ReadLine());
                        airport.PlaneTookOff(numm);
                        Console.WriteLine("Plane deleted.");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        return false;
                    }
                case 3: // print all------------------
                    {
                        airport.PrintPlanes();
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        return false;
                    }
                case 4: // find nearest---------------
                    {
                        airport.FindNearestPlane();
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        return false;
                    }
                case 5: // emergency information------
                    {
                        airport.EmergencyInformationOutput();
                        Console.WriteLine();
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        return false;
                    }
                case 6: // Find some plane------------
                    {
                        airport.FindSomePlane();
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        return false;
                    }
                case 7: // Check passangers-----------
                    {
                        airport.CheckPassangers();
                        return false;
                    }
                case 8: // Check passangers-----------
                    {
                        Console.Clear();
                        Console.WriteLine("Press enter for exit...");
                        Console.ReadLine();
                        return true;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Enter num 1 to 8!");
                        Console.ReadLine();
                        return false;
                    }
            }
        }

        static void Main(string[] args)
        {
            Airport airport = new Airport();
            airport.CreateTestPlanes();
            bool isExit = false;
            do
            {
                try
                {
                    isExit = menu(airport);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Enter num 1 to 8!");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Unexpected ERROR!\n(try use program normaly)");
                    Console.ReadLine();
                }
            } while (!isExit);

        }
    }
}
