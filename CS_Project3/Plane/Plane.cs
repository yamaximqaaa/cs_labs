using CS_Project.AditionalMethods;
using CS_Project.Collection;
using CS_Project.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project
{
    public delegate bool PlaneDelegate();
    public class Plane : IPlane, IAirportObj, IEnumerable<KeyValuePair<int, Passenger>>
    {
        #region plane propertys
        //public int planeNum { get; set; }  // now key in collection
        public DateTime timeIn { get; set; }
        public DateTime timeOut { get; set; }
        public string city { get; set; }
        public Airline airline { get; set; }
        public Terminal terminal { get; set; }
        public Status status { get; set; }
        public string gate { get; set; }
        public int count { get; set; }
        public bool isPlaneInAirport { get; set; }

        private DictionaryCollection<Passenger> collectionPassangers = new DictionaryCollection<Passenger>();
        public Passenger this[int key]
        {
            get { return collectionPassangers[key]; }
            set { collectionPassangers[key] = value; }
        }

        
        public event PlaneDelegate FlyIn;
        public event PlaneDelegate FlyOut;

        #endregion

        #region AddDelPassangers

        public void Add(int key, Passenger passenger)
        {
            collectionPassangers.Add(key, passenger);
        }
        public void Del(int key)
        {
            collectionPassangers.Del(key);
        }

        #endregion

        #region EventMethod

        public bool InOutPlane(bool status = true)
        {
            try // TODO
            {

            }
            catch (Exception)
            {

                throw;
            }
            if (status == true)
            {
                return (bool)FlyIn?.Invoke();
            }
            else
            {
                return (bool)FlyOut?.Invoke();
            }
        }

        #endregion

        #region constructor
        public Plane()
        {

        }

        public Plane(int key,
                     string city,
                     Airline airline,
                     Terminal terminal,
                     Status status,
                     string gate)
        {
            this.city = city;
            this.airline = airline;
            this.terminal = terminal;
            this.status = status;
            this.gate = gate;
            this.timeIn = DateTime.Now;
            this.timeOut = DateTime.Now;
            TimeOut(key);

        }

        public Plane(int key)
        {
            this.city = key.ToString();
            this.airline = Airline.AzurAirUkraine;
            this.terminal = Terminal.A;
            this.status = Status.Delayed;
            this.gate = key.ToString();


            this.timeIn = DateTime.Now;
            this.timeOut = DateTime.Now;
            TimeOut(key);
            
        }
        #endregion

        #region build plane
        public void BuildPlane(int key)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Building plane...");
                Console.WriteLine("===================================");

                //Console.Write("Enter plane number: ");
                //this.planeNum = Convert.ToInt32(Console.ReadLine().Replace(" ", ""));
                //Console.WriteLine("===================================");

                this.timeIn = DateTime.Now;
                this.timeOut = DateTime.Now;
                TimeOut(key);
                //this.timeOut = this.timeOut.AddHours(3);

                Console.Write("Enter plane city: ");
                this.city = Console.ReadLine().Replace(" ", "");
                if (this.city == "")
                {
                    throw new FormatException();
                }
                Console.WriteLine("===================================");

                AddAirline();
                Console.WriteLine("===================================");

                AddTerminal();
                Console.WriteLine("===================================");

                AddStatus();
                Console.WriteLine("===================================");

                Console.Write("Enter gate code: ");
                this.gate = Console.ReadLine().Replace(" ", "");
                Console.WriteLine("===================================");

                //SpawnPassengers();

                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Input correct data!");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                BuildPlane(key);
            }

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
            if (num > 4 || num < 1)
            {
                throw new FormatException();
            }
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
            if (num > 4 || num < 1)
            {
                throw new FormatException();
            }
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
            if (num > 9 || num < 1)
            {
                throw new FormatException();
            }
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

        //private void SpawnPassengers()
        //{
        //    switch (this.airline)
        //    {
        //        case Airline.UkraineInternationalAirlines:
        //            this.count = 25;
        //            break;
        //        case Airline.Windrose:
        //            this.count = 20;
        //            break;
        //        case Airline.SkyUpAirlines:
        //            this.count = 35;
        //            break;
        //        case Airline.AzurAirUkraine:
        //            this.count = 30;
        //            break;
        //        default:
        //            Console.WriteLine("Error");
        //            break;
        //    }

        //    this.passArray = new Passenger[count];

        //    for (int i = 0; i < count; i++)
        //    {
        //        Passenger passenger = new Passenger(this.planeNum, i, this.airline);
        //        passArray[i] = passenger;
        //    }
        //}

        #endregion

        #region print

        public void Print(int key)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Plane num: " + key.ToString());
            Console.WriteLine("Time in  : " + this.timeIn.ToString());
            Console.WriteLine("Time out : " + this.timeOut.ToString());
            Console.WriteLine("City     : " + this.city.ToString());
            Console.WriteLine("Airline  : " + this.airline.ToString());
            Console.WriteLine("Terminal : " + this.terminal.ToString());
            Console.WriteLine("Status   : " + this.status.ToString());
            Console.WriteLine("Gate     : " + this.gate.ToString());
            Console.WriteLine("===============================");
        }
        public void PrintPas()
        {
            collectionPassangers.PrintAll();
        }
        #endregion

        #region IfContains

        public bool ContainsKey(int key)
        {
            return collectionPassangers.ContainsKey(key);
        }

        #endregion

        #region IEnumerable

        public IEnumerator<KeyValuePair<int, Passenger>> GetEnumerator()
        {
            return collectionPassangers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
