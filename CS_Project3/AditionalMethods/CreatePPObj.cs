using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Project;

namespace CS_Project.AditionalMethods
{
    public static class CreatePPObj
    {
        #region CreatePlane
        public static KeyValuePair<int, Plane> CreatePlane()
        {
            Plane newPlane = new Plane();
            int key = 0;
            try
            {
                
                Console.Clear();
                Console.WriteLine("Building plane...");
                Console.WriteLine("===================================");

                key = CreatePlaneNumber();

                Console.WriteLine("===================================");
                
                newPlane.timeIn = DateTime.Now;
                newPlane.timeOut = DateTime.Now;
                TimeOut(key, newPlane);
                //this.timeOut = this.timeOut.AddHours(3);

                //  ==================================================

                newPlane.city = CreateCity();
                
                Console.WriteLine("===================================");

                AddAirline(newPlane);

                Console.WriteLine("===================================");

                AddTerminal(newPlane);
                Console.WriteLine("===================================");

                AddStatus(newPlane);
                Console.WriteLine("===================================");

                Console.Write("Enter gate code: ");
                newPlane.gate = Console.ReadLine().Replace(" ", "");
                Console.WriteLine("===================================");

                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("Input correct data!");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                CreatePlane();
            }
            SpawnPassengers(key, newPlane);
            return new KeyValuePair<int, Plane>(key, newPlane);
        }

        public static void SpawnPassengers(int keyPlane, Plane plane)
        {
            switch (plane.airline)
            {
                case Airline.UkraineInternationalAirlines:
                    plane.count = 25;
                    break;
                case Airline.Windrose:
                    plane.count = 20;
                    break;
                case Airline.SkyUpAirlines:
                    plane.count = 35;
                    break;
                case Airline.AzurAirUkraine:
                    plane.count = 30;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            for (int i = 0; i < plane.count; i++)
            {
                plane.Add(CreatePassportNum(i), CreatePassanger(keyPlane, i, plane.airline));
            }
        }

        #region SubsidiaryMethod

        static void TimeOut(int numm, Plane plane)
        {
            Random rnd = new Random(numm);
            var num = rnd.Next(0, 3);
            switch (num)
            {
                case 1:
                    { plane.timeOut = plane.timeOut.AddMinutes(15); break; }
                case 2:
                    { plane.timeOut = plane.timeOut.AddMinutes(30); break; }
                case 3:
                    { plane.timeOut = plane.timeOut.AddMinutes(90); break; }
                default:
                    { plane.timeOut = plane.timeOut.AddMinutes(120); break; }
            }
        }



        static int CreatePlaneNumber()
        {
            int key = 0;
            try
            {
                Console.Write("Enter plane number: ");
                key = Convert.ToInt32(Console.ReadLine().Replace(" ", ""));
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Enter correct plane number!!!");
                Console.WriteLine();
                key = CreatePlaneNumber();
            }
            return key;
        }
        static string CreateCity()
        {
            string str = "Default";
            try
            {
                Console.Write("Enter plane city: ");
                str = Console.ReadLine().Replace(" ", "");
                if (str == "")
                {
                    throw new FormatException();
                }

            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Enter correct city!!!");
                Console.WriteLine();
                str = CreateCity();
            }
            return str;
        }
        static void AddAirline(Plane plane)
        {
            try
            {
                Console.WriteLine("Choose airline:");
                for (int i = 1; i <= Enum.GetNames(typeof(Airline)).Length; i++)                     // how it work: Enum.GetNames(typeof(Airline)).Length?
                {
                    Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Airline), i));
                }
                Console.Write("Enter number of Airline company: ");
                var num = Convert.ToInt32(Console.ReadLine());
                if (num > 4 || num < 1)
                {
                    throw new FormatException();
                }
                switch (num)
                {
                    case (int)Airline.UkraineInternationalAirlines:
                        { plane.airline = Airline.UkraineInternationalAirlines; break; }

                    case (int)Airline.Windrose:
                        { plane.airline = Airline.Windrose; break; }

                    case (int)Airline.SkyUpAirlines:
                        { plane.airline = Airline.SkyUpAirlines; break; }

                    case (int)Airline.AzurAirUkraine:
                        { plane.airline = Airline.AzurAirUkraine; break; }
                    default:
                        { plane.airline = Airline.UkraineInternationalAirlines; break; }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Enter num from 1 to 4!!!");
                Console.WriteLine();
                AddAirline(plane);
            }
            
        }
        static void AddTerminal(Plane plane)
        {
            try
            {
                Console.WriteLine("Choose terminal:");
                for (int i = 1; i <= Enum.GetNames(typeof(Terminal)).Length; i++)                     // how it work: Enum.GetNames(typeof(Airline)).Length?
                {
                    Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Terminal), i));
                }
                Console.Write("Enter number of terminal: ");
                var num = Convert.ToInt32(Console.ReadLine());
                if (num > 4 || num < 1)
                {
                    throw new FormatException();
                }
                switch (num)
                {
                    case (int)Terminal.A:
                        { plane.terminal = Terminal.A; break; }

                    case (int)Terminal.B:
                        { plane.terminal = Terminal.B; break; }

                    case (int)Terminal.C:
                        { plane.terminal = Terminal.C; break; }

                    case (int)Terminal.D:
                        { plane.terminal = Terminal.D; break; }
                    default:
                        { plane.terminal = Terminal.A; break; }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Enter num from 1 to 4!!!");
                Console.WriteLine();
                AddTerminal(plane);
            }
        }
        static void AddStatus(Plane plane)
        {
            try
            {
                Console.WriteLine("Choose plane status:");
                for (int i = 1; i <= Enum.GetNames(typeof(Status)).Length; i++)                     // how it work: Enum.GetNames(typeof(Airline)).Length?
                {
                    Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Status), i));
                }
                Console.Write("Enter number of plane status: ");
                var num = Convert.ToInt32(Console.ReadLine());
                if (num > 9 || num < 1)
                {
                    throw new FormatException();
                }
                switch (num)
                {
                    case (int)Status.CheckIn:
                        { plane.status = Status.CheckIn; break; }

                    case (int)Status.GateClosed:
                        { plane.status = Status.GateClosed; break; }

                    case (int)Status.Arrived:
                        { plane.status = Status.Arrived; break; }

                    case (int)Status.DepartedAt:
                        { plane.status = Status.DepartedAt; break; }

                    case (int)Status.Unknown:
                        { plane.status = Status.Unknown; break; }

                    case (int)Status.Canceled:
                        { plane.status = Status.Canceled; break; }

                    case (int)Status.ExpectedAt:
                        { plane.status = Status.ExpectedAt; break; }

                    case (int)Status.Delayed:
                        { plane.status = Status.Delayed; break; }

                    case (int)Status.InFlight:
                        { plane.status = Status.InFlight; break; }

                    default:
                        { plane.status = Status.Arrived; break; }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Enter num from 1 to 9!!!");
                Console.WriteLine();
                AddStatus(plane);
            }
        }
        static string CreateGate()
        {
            string str = "Default";
            try
            {
                Console.Write("Enter gate code: ");
                str = Console.ReadLine().Replace(" ", "");
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Enter correct gate!!");
                Console.WriteLine();
                str = CreateGate();
            }
            return str;
        }

        #endregion

        #endregion

        #region CreatePassangers

        static Passenger CreatePassanger(int planeNum, int n, Airline airline)
        {
            Passenger newPass = new Passenger();
            newPass.planeNum = planeNum;
            newPass.airline = airline;
            AddPropData(n, newPass);
            return newPass;
        }

        #region SubsidiaryMethod
        static void AddPropData(int n, Passenger passenger)
        {
            AddName(n, passenger);
            AddSecondName(n, passenger);
            AddNationality(n, passenger);
            AddSex(n, passenger);
            AddClassF(n, passenger);
            AddDate(n, passenger);
            AddPrice(passenger);
        }
        static void AddName(int n, Passenger passenger)
        {
            string[] arr = new string[] { "Max", "Jack", "James", "Kobe", "Michel" };
            passenger.name = arr[new Random(n * n).Next(0, arr.Length)];
        }
        static void AddSecondName(int n, Passenger passenger)
        {
            string[] arr = new string[] { "Lukashevich", "Sparrow", "LeBron", "Bryant", "Jordan" };
            passenger.secondName = arr[new Random(n).Next(0, arr.Length)];
        }
        static void AddNationality(int n, Passenger passenger)
        {
            string[] arr = new string[] { "Ukrain", "EU", "Japan", "USA", "Moldova" };
            passenger.nationality = arr[new Random(n).Next(0, arr.Length)];
        }
        static int CreatePassportNum(int n)
        {
            //string[] arr = new string[] { "AA", "AE", "DQ", "GG", "WP" };

            //return arr[new Random(n + 100).Next(0, arr.Length)] +
            //    new Random(n + 111).Next(100, 999) +
            //    arr[new Random(n + 222).Next(0, arr.Length)];

            return new Random(n + 111).Next(1000, 9999);
        }
        static void AddSex(int n, Passenger passenger)
        {
            Sex[] arr = new Sex[] { Sex.Female, Sex.Male };
            passenger.sex = arr[new Random(n).Next(0, arr.Length)];
        }
        static void AddClassF(int n, Passenger passenger)
        {
            Class[] arr = new Class[] { Class.Business, Class.Econom };
            passenger.classF = arr[new Random(n).Next(0, arr.Length)];
        }
        static void AddDate(int n, Passenger passenger)
        {
            int day = new Random(n * 2).Next(1, 29);
            int month = new Random(n * 3).Next(1, 12);
            int year = new Random(n * 4).Next(1940, 2021);
            passenger.dateOfBirthday = new DateTime(year, month, day);
        }
        static void AddPrice(Passenger passenger)
        {
            var price = (int)passenger.classF;
            switch (passenger.airline)
            {
                case Airline.UkraineInternationalAirlines:
                    if (passenger.classF == Class.Business)
                        price += 5000;
                    else
                        price += 1000;
                    break;
                case Airline.Windrose:
                    if (passenger.classF == Class.Business)
                        price += 55;
                    else
                        price += 15;
                    break;
                case Airline.SkyUpAirlines:
                    if (passenger.classF == Class.Business)
                        price += 2555;
                    else
                        price += 1999;
                    break;
                case Airline.AzurAirUkraine:
                    if (passenger.classF == Class.Business)
                        price += 228;
                    else
                        price += 322;
                    break;
                default:
                    price += 1000;
                    break;
            }
            passenger.price = price;
        }
        #endregion

        #endregion
    }
}
