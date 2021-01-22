using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project
{
    class Plane : IPlane
    {
        #region plane propertys
        public int planeNum { get; set; }
        public DateTime timeIn { get; set; }
        public DateTime timeOut { get; set; }
        public string city { get; set; }
        public Airline airline { get; set; }
        public Terminal terminal { get; set; }
        public Status status { get; set; }
        public string gate { get; set; }
        public bool isPlaneInAirport { get; set; }
        Passenger[] passArray;
        public int count { get; set; }
        public Passenger this[int i]
        {
            get { return passArray[i]; }
            set { passArray[i] = value; }
        }
        #endregion

        #region constructor
        public Plane()
        {

        }

        public Plane(int planeNum,
                     string city,
                     Airline airline,
                     Terminal terminal,
                     Status status,
                     string gate)
        {
            this.planeNum = planeNum;
            this.city = city;
            this.airline = airline;
            this.terminal = terminal;
            this.status = status;
            this.gate = gate;
            this.timeIn = DateTime.Now;
            this.timeOut = DateTime.Now;
            TimeOut(planeNum);
        }

        public Plane(int num)
        {
            this.planeNum = num;
            this.city = num.ToString();
            this.airline = Airline.AzurAirUkraine;
            this.terminal = Terminal.A;
            this.status = Status.Delayed;
            this.gate = num.ToString();


            this.timeIn = DateTime.Now;
            this.timeOut = DateTime.Now;
            TimeOut(planeNum);
            SpawnPassengers();
        }
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

            SpawnPassengers();

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();

        }
        private void TimeOut(int numm)
        {
            Random rnd = new Random(numm);
            var num = rnd.Next(0, 3);
            switch (num)
            {
                case 1:
                    { this.timeOut = this.timeOut.AddMinutes(15); break; }
                case 2:
                    { this.timeOut = this.timeOut.AddMinutes(30); break; }
                case 3:
                    { this.timeOut = this.timeOut.AddMinutes(90); break; }
                default:
                    { this.timeOut = this.timeOut.AddMinutes(120); break; }
            }
        }
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

        #region create passengers

        private void SpawnPassengers()
        {
            switch (this.airline)
            {
                case Airline.UkraineInternationalAirlines:
                    this.count = 25;
                    break;
                case Airline.Windrose:
                    this.count = 20;
                    break;
                case Airline.SkyUpAirlines:
                    this.count = 35;
                    break;
                case Airline.AzurAirUkraine:
                    this.count = 30;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            this.passArray = new Passenger[count];

            for (int i = 0; i < count; i++)
            {
                Passenger passenger = new Passenger(this.planeNum, i);
                passArray[i] = passenger;
            }
        }

        #endregion

        
    }
}
