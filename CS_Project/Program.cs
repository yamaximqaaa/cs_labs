using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project
{

    #region enum
    enum Status
    {
        CheckIn = 1,
        GateClosed,
        Arrived,
        DepartedAt,
        Unknown,
        Canceled,
        ExpectedAt,
        Delayed,
        InFlight
    }
    enum Airline
    {
        UkraineInternationalAirlines = 1,
        Windrose,
        SkyUpAirlines,
        AzurAirUkraine
    }
    enum Terminal
    {
        A = 1,
        B,
        C,
        D,
    }
    #endregion

    struct Plane
    {
        #region plane fields
        public int planeNum;
        public DateTime timeIn;
        public DateTime timeOut;
        public string city;
        public Airline airline;
        public Terminal terminal;
        public Status status;
        public string gate;
        public bool isPlaneInAirport;
        #endregion

        #region build plane
        public void BuildPlane()
        {
            Console.Clear();
            Console.WriteLine("Building plane...");
            Console.WriteLine("===================================");

            Console.Write("Enter plane number: ");
            this.planeNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===================================");

            this.timeIn = DateTime.Now;
            this.timeOut = DateTime.Now;
            TimeOut(planeNum);
            //this.timeOut = this.timeOut.AddHours(3);

            Console.Write("Enter plane city: ");
            this.city = Console.ReadLine();
            Console.WriteLine("===================================");

            AddAirline();
            Console.WriteLine("===================================");

            AddTerminal();
            Console.WriteLine("===================================");

            AddStatus();
            Console.WriteLine("===================================");

            Console.Write("Enter gate code: ");
            this.gate = Console.ReadLine();
            Console.WriteLine("===================================");

            this.isPlaneInAirport = false;

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();

        }
        
        private void TimeOut(int numm)
        {
            Random rnd = new Random(numm);
            var num = rnd.Next(0, 3);
            if (num == 1)
                this.timeOut = this.timeOut.AddMinutes(30);
            else if( num == 2)
                this.timeOut = this.timeOut.AddHours(2);
            else if (num == 3)
                this.timeOut = this.timeOut.AddHours(3);
            else
                this.timeOut = this.timeOut.AddMinutes(21);
        }

        #endregion

        #region private methods
        private void AddAirline()
        {
            Console.WriteLine("Choose airline:");
            for (int i = 1; i <= Enum.GetNames(typeof(Airline)).Length; i++)                     // how it work: Enum.GetNames(typeof(Airline)).Length?
            {
                Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Airline), i));
            }
            Console.Write("Enter number of Airline company: ");
            var num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case (int)Airline.UkraineInternationalAirlines:
                    { this.airline = Airline.UkraineInternationalAirlines; break; }

                case (int)Airline.Windrose:
                    { this.airline = Airline.Windrose; break; }

                case (int)Airline.SkyUpAirlines:
                    { this.airline = Airline.SkyUpAirlines; break; }

                case (int)Airline.AzurAirUkraine:
                    { this.airline = Airline.AzurAirUkraine; break; }
                default:
                    { this.airline = Airline.UkraineInternationalAirlines; break; }
            }
        }
        private void AddTerminal()
        {
            Console.WriteLine("Choose terminal:");
            for (int i = 1; i <= Enum.GetNames(typeof(Terminal)).Length; i++)                     // how it work: Enum.GetNames(typeof(Airline)).Length?
            {
                Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Terminal), i));
            }
            Console.Write("Enter number of terminal: ");
            var num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case (int)Terminal.A:
                    { this.terminal = Terminal.A; break; }

                case (int)Terminal.B:
                    { this.terminal = Terminal.B; break; }

                case (int)Terminal.C:
                    { this.terminal = Terminal.C; break; }

                case (int)Terminal.D:
                    { this.terminal = Terminal.D; break; }
                default:
                    { this.terminal = Terminal.A; break; }
            }

        }
        private void AddStatus()
        {
            Console.WriteLine("Choose plane status:");
            for (int i = 1; i <= Enum.GetNames(typeof(Status)).Length; i++)                     // how it work: Enum.GetNames(typeof(Airline)).Length?
            {
                Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Status), i));
            }
            Console.Write("Enter number of plane status: ");
            var num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case (int)Status.CheckIn:
                    { this.status = Status.CheckIn; break; }

                case (int)Status.GateClosed:
                    { this.status = Status.GateClosed; break; }

                case (int)Status.Arrived:
                    { this.status = Status.Arrived; break; }

                case (int)Status.DepartedAt:
                    { this.status = Status.DepartedAt; break; }

                case (int)Status.Unknown:
                    { this.status = Status.Unknown; break; }

                case (int)Status.Canceled:
                    { this.status = Status.Canceled; break; }

                case (int)Status.ExpectedAt:
                    { this.status = Status.ExpectedAt; break; }

                case (int)Status.Delayed:
                    { this.status = Status.Delayed; break; }

                case (int)Status.InFlight:
                    { this.status = Status.InFlight; break; }

                default:
                    { this.status = Status.Arrived; break; }
            }

        }
        #endregion
    }

    struct Airport
    {
        const int count = 28;
        private int planePtr;                       // show next free space (indx)
        private Plane[] planeBank;
        public Plane this[int i]
        {
            get { return planeBank[i]; }
            set { planeBank[i] = value; }
        }

        #region add-del palne
        public void LandPlane(Plane plane)
        {
            if (planeBank == null)
            {
                plane.isPlaneInAirport = true;
                this.planeBank = new Plane[count];
                this.planeBank[0] = plane;
                this.planePtr = 1;
            }
            else
            {
                plane.isPlaneInAirport = true;
                this.planeBank[planePtr] = plane;
                planePtr++;
            }
        }
        public void PlaneTookOff(int planeNum_)
        {
            for (int i = 0; i < count; i++)
            {
                if (this.planeBank[i].planeNum == planeNum_)
                {
                    this.planeBank[i] = this.planeBank[count - 1];
                    this.planeBank[count - 1].isPlaneInAirport = false;
                }
            }
            planePtr--;
        }
        #endregion

        #region find some plane

        public void FindSomePlane()
        {
            Console.Clear();
            var i = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("          Search menu          ");
                Console.WriteLine("===============================");
                Console.WriteLine("How you want search?");
                Console.WriteLine("===============================");
                Console.WriteLine("1. By number");
                Console.WriteLine("2. By day");
                Console.WriteLine("3. By city");
                Console.WriteLine("4. Back");
                Console.WriteLine("===============================");
                Console.WriteLine();

                Console.Write("Enter your choise: ");
                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Searching plane by number...");
                            Console.WriteLine();
                            Console.Write("Enter plane number: ");
                            var number = Convert.ToInt32(Console.ReadLine());
                            SearchByNum(number);
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Searching plane by day...");
                            Console.WriteLine();
                            Console.Write("Enter day: ");
                            var day = Convert.ToInt32(Console.ReadLine());
                            SearchByTime(day);
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Searching plane by day...");
                            Console.WriteLine();
                            Console.Write("Enter city: ");
                            string city = Console.ReadLine();
                            SearchByCity(city);
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Back to menu >>>");
                            break;
                        }

                }

            } while (i == 1 || i == 2 || i == 3);
        }

        private void SearchByNum(int num)
        {
            for (int i = 0; i < count; i++)
            {
                if (planeBank[i].planeNum == num)
                {
                    PrintPlane(planeBank[i]);
                }
            }
        }

        private void SearchByTime(int date)
        {
            for (int i = 0; i < count; i++)
            {
                if (planeBank[i].timeOut.Day == date)
                {
                    PrintPlane(planeBank[i]);
                }
            }
        }

        private void SearchByCity(string city)
        {
            for (int i = 0; i < count; i++)
            {
                if (planeBank[i].city == city)
                {
                    PrintPlane(planeBank[i]);
                }
            }
        }


        #endregion

        #region find nearest plane

        public void FindNearestPlane()
        {
            Console.Clear();
            Console.WriteLine("Searching plane for nearest hour...");
            Console.WriteLine();

            if (planeBank == null)
            {
                Console.WriteLine("Airport is empty!");
                return;
            }

            DateTime now = DateTime.Now;
            DateTime date1 = new DateTime(2015, 7, 20, 1, 0, 0);

            bool marker = false;

            for (int i = 0; i < count; i++)
            {
                if (date1.Hour >= planeBank[i].timeOut.Subtract(now).Hours && planeBank[i].isPlaneInAirport == true)
                {
                    PrintPlane(planeBank[i]);
                    marker = true;
                }
            }
            if (!marker)
            {
                Console.WriteLine("We can't find such plane :(");
            }

        }

        #endregion

        #region print palnes

        public void PrintPlanes()
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                if (planeBank[i].isPlaneInAirport == true)
                {
                    Console.WriteLine("===============================");
                    Console.WriteLine("Plane num: " + planeBank[i].planeNum.ToString());
                    Console.WriteLine("Time in  : " + planeBank[i].timeIn.ToString());
                    Console.WriteLine("Time out : " + planeBank[i].timeOut.ToString());
                    Console.WriteLine("City     : " + planeBank[i].city.ToString());
                    Console.WriteLine("Airline  : " + planeBank[i].airline.ToString());
                    Console.WriteLine("Terminal : " + planeBank[i].terminal.ToString());
                    Console.WriteLine("Status   : " + planeBank[i].status.ToString());
                    Console.WriteLine("Gate     : " + planeBank[i].gate.ToString());
                }
            }
            Console.WriteLine("===============================");
        }

        private void PrintPlane(Plane plane)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Plane num: " + plane.planeNum.ToString());
            Console.WriteLine("Time in  : " + plane.timeIn.ToString());
            Console.WriteLine("Time out : " + plane.timeOut.ToString());
            Console.WriteLine("City     : " + plane.city.ToString());
            Console.WriteLine("Airline  : " + plane.airline.ToString());
            Console.WriteLine("Terminal : " + plane.terminal.ToString());
            Console.WriteLine("Status   : " + plane.status.ToString());
            Console.WriteLine("Gate     : " + plane.gate.ToString());
            Console.WriteLine("===============================");
        }

        #endregion
    }


    class Program
    {

        static void EmergencyInformationOutput()
        {
            Console.Clear();
            Console.WriteLine("Emergency Information\n");
        }


        static void Main(string[] args)
        {
            Airport airport = new Airport();
            var i = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("           Main menu           ");
                Console.WriteLine("===============================");
                Console.WriteLine("1. Add Plane");
                Console.WriteLine("2. Delete plane by plane num");
                Console.WriteLine("3. Print all planes");
                Console.WriteLine("4. Find nearest plane(1 hour)");
                Console.WriteLine("5. Output emergency information");
                Console.WriteLine("6. Find some plane");
                Console.WriteLine("7. Exit");
                Console.WriteLine("===============================");
                Console.WriteLine();

                Console.Write("Enter your choise: ");
                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        {
                            Plane plane = new Plane();
                            plane.BuildPlane();
                            airport.LandPlane(plane);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.Write("Enter num of plane: ");
                            var numm = Convert.ToInt32(Console.ReadLine());
                            airport.PlaneTookOff(numm);
                            Console.WriteLine("Plane deleted.");
                            Console.WriteLine();
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }
                    case 3:
                        {
                            airport.PrintPlanes();
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            airport.FindNearestPlane();
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            EmergencyInformationOutput();
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            airport.FindSomePlane();
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Select one from 5!");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }

                }

            } while (i != 7);

        }
    }
}
