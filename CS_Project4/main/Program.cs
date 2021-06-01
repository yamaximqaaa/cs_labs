using CS_Project.AditionalMethods;
using System;
using System.Collections.Generic;


namespace CS_Project
{
    class Program
    {
#if DEBUG
        static void AddNewFitches(Airport a)
        {
            

        }

#endif
        static bool menu(Airport airport)
        {
            var i = 0;

            #region Main Menu
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
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
            Console.WriteLine("8. Show price");
            Console.WriteLine("9. Exit");
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.ResetColor();
            Console.Write("Enter your choise: ");
            i = Convert.ToInt32(Console.ReadLine());
            #endregion

            switch (i)
            {
                case 1: // add plane------------------
                    {
                        KeyValuePair<int, Plane> plane = new KeyValuePair<int, Plane>(1111, new Plane());
                        plane.Value.FlyIn += airport.RequestFreespace;
                        
                        if (plane.Value.InOutPlane(true))
                        {
                            plane = CreatePPObj.CreatePlane();
                            airport.LandPlane(plane.Key, plane.Value);
                        }
                        

                        return false;
                    }
                case 2: // del plane by plane num-----
                    {
                        Console.Clear();
                        if (airport.IsEmpty())
                        {
                            Console.Clear();
                            Console.WriteLine("Array is empty!");
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            return false;
                        }
                        try
                        {
                            airport.Print();
                            Console.WriteLine();
                            Console.WriteLine("You deleting plane...");
                            Console.Write("Enter num of plane: ");
                            var numm = Convert.ToInt32(Console.ReadLine().Replace(" ", ""));
                            airport.PlaneTookOff(numm);
                            Console.WriteLine();
                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Enter plane namber!");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        return false;
                    }
                case 3: // print all------------------
                    {
                        airport.Print();
                        Console.WriteLine();
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
                        return false;
                    }
                case 7: // Check passangers-----------
                    {
                        airport.CheckPassangers();
                        return false;
                    }
                case 8: // Show price-----------
                    {
                        Console.Clear();
                        airport.CheckPrise();
                        return false;
                    }
                case 9: // Exit ----------------------
                    {
                        Console.Clear();
                        Console.WriteLine("Press enter for exit...");
                        Console.ReadLine();
                        return true;
                    }
#if DEBUG
                case 1111:
                    {
                        AddNewFitches(airport);
                        
                        Console.ReadLine();

                        return false;
                    }
#endif
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Enter num 1 to 9!");
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
                    Console.WriteLine("Enter num 1 to 9!");
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
