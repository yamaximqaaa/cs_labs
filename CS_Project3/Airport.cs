using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project
{
    class Airport : IAirport
    {
        #region airport prop
        private const int count = 28;
        private int planeIndx;                       // show next free space (indx)
        private Plane[] planeBank;
        public Plane this[int i]
        {
            get { return planeBank[i]; }
            set { planeBank[i] = value; }
        }
        #endregion

        #region add-del palne
        public void LandPlane(Plane plane)
        {
            if (planeBank == null)
            {
                this.planeBank = new Plane[count];
                this.planeBank[0] = plane;
                this.planeIndx = 1;
            }
            else
            {
                this.planeBank[planeIndx] = plane;
                planeIndx++;
            }
        }
        public void PlaneTookOff(int planeNum_)
        {
            if (EmptyArray())
            {
                Console.Clear();
                Console.WriteLine("Array is empty!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return;
            }
            for (int i = 0; i < count; i++)
            {
                if (this.planeBank[i].planeNum == planeNum_ && this.planeBank[i] != null)
                {
                    this.planeBank[i] = this.planeBank[count - 1];
                    this.planeBank[count - 1] = null;
                    break;
                }
            }
            planeIndx--;
        }
        #endregion

        #region emergency information

        public void EmergencyInformationOutput()
        {
            Console.Clear();
            Console.WriteLine("Emergency Information");
        }

        #endregion

        #region find some plane

        public void FindSomePlane()
        {
            Console.Clear();
            if (EmptyArray())
            {
                Console.Clear();
                Console.WriteLine("Array is empty!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return;
            }

            var tick = false;
            var i = 0;
            do
            {
                try
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
                    if (i > 4 || i < 1)
                    {
                        throw new FormatException();
                    }
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
                                tick = false;
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
                                tick = false;
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
                                tick = false;
                                break;
                            }
                        case 4:
                            {
                                tick = true;
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("Enter num 1 to 3!");
                                Console.ReadLine();
                                tick = false;
                                break;
                            }

                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Enter num 1 to 3!");
                    Console.ReadLine();
                }
            } while (!tick) ;
            

        }

        private Plane SearchByNum(int num)
        {
            bool tick = true;
            for (int i = 0; i < count; i++)
            {
                if (!EndArray(planeBank[i]) && planeBank[i].planeNum == num)
                {
                    PrintPlane(planeBank[i]);
                    tick = true;
                    return planeBank[i];
                }
            }
            if (tick)
            {
                Console.WriteLine();
                Console.WriteLine("No plane with {0} num.", num);
                Console.ReadLine();
            }
            return new Plane();
        }

        private void SearchByTime(int date)
        {
            for (int i = 0; i < count; i++)
            {
                if (!EndArray(planeBank[i]) && planeBank[i].timeOut.Day == date)
                {
                    PrintPlane(planeBank[i]);
                }
            }
        }

        private void SearchByCity(string city)
        {
            for (int i = 0; i < count; i++)
            {
                if (!EndArray(planeBank[i]) && planeBank[i].city == city)
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

            if (EmptyArray())
            {
                Console.WriteLine("Airport is empty!");
                return;
            }

            DateTime now = DateTime.Now;
            DateTime date1 = new DateTime(2015, 7, 20, 1, 0, 0);

            bool marker = false;

            for (int i = 0; i < count; i++)
            {
                if (!EndArray(planeBank[i]) && 1 > planeBank[i].timeOut.Subtract(now).Hours)
                {
                    Console.WriteLine("Time to plane: {0}", planeBank[i].timeOut.Subtract(now));
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

        #region check passangers

        private bool CheckMenu()
        {
            var i = 0;
            Console.Clear();
            Console.WriteLine("          Check menu          ");
            Console.WriteLine("===============================");
            Console.WriteLine("How you want search?");
            Console.WriteLine("===============================");
            Console.WriteLine("1. By flight number");
            Console.WriteLine("2. By price");
            Console.WriteLine("3. By name");
            Console.WriteLine("4. By passport");
            Console.WriteLine("5. By city");
            Console.WriteLine("6. Back");
            Console.WriteLine("===============================");
            Console.WriteLine();

            Console.Write("Enter your choise: ");
            i = Convert.ToInt32(Console.ReadLine());

            switch (i)
            {
                case 1:// By flight num
                    {
                        CheckByFlightNum();
                        return false;
                    }
                case 2:// By price
                    {
                        CheckByPrice();
                        return false;
                    }
                case 3:// By name
                    {
                        CheckByName();
                        return false;
                    }
                case 4:// by passport
                    {
                        CheckByPassport();
                        return false;
                    }
                case 5:// by city
                    {
                        CheckByCity();
                        return false;
                    }
                case 6:// exit
                    {
                        Console.WriteLine("7");
                        return true;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Enter num 1 to 7!");
                        Console.ReadLine();
                        return false;
                    }

            }
        }
        public void CheckPassangers()
        {
            if (EmptyArray())
            {
                Console.Clear();
                Console.WriteLine("Array is empty!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return;
            }
            bool isExit = false;
            do
            {
                try
                {
                    isExit = CheckMenu();
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Enter num 1 to 7!");
                    Console.ReadLine();
                }

            } while (!isExit);
        }

        #region check methods

        private void CheckByFlightNum()
        {
            bool brk = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Checking by plane number...");
                    Console.WriteLine();
                    Console.Write("Enter plane number: ");
                    var number = Convert.ToInt32(Console.ReadLine());
                    if (SearchByNum(number).gate != null)
                    {
                        PrintPassengers(SearchByNum(number));
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    brk = true;
                    break;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Enter flight number!");
                    Console.ReadLine();
                }

            } while (!brk);
        }
        private void CheckByPrice()
        {
            bool brk = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Checking by price...");
                    Console.WriteLine();
                    Console.Write("Enter ticket price: ");
                    var price = Convert.ToInt32(Console.ReadLine());
                    bool tick = true;


                    for (int i = 0; i < count; i++)
                    {
                        if (planeBank[i] != null)
                        {
                            for (int j = 0; j < planeBank[i].count; j++)
                            {
                                if (ComparePrice(planeBank[i][j].price, price))
                                {
                                    PrintPassenger(planeBank[i][j]);
                                    tick = false;
                                }
                            }
                        }

                    }

                    NoSuchPassanger(tick);
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    brk = true;
                    break;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Enter price number!");
                    Console.ReadLine();
                }

            } while (!brk);
        }
        private void CheckByName()
        {
            bool brk = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Checking by name and last name...");
                    Console.WriteLine();
                    bool tick = true;
                    Console.Write("Enter Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Enter Last name: ");
                    var secondName = Console.ReadLine();

                    for (int i = 0; i < count; i++)
                    {
                        if (planeBank[i] != null)
                        {
                            for (int j = 0; j < planeBank[i].count; j++)
                            {
                                if (CompareStrings(planeBank[i][j].name, name))
                                {
                                    if (CompareStrings(planeBank[i][j].secondName, secondName))
                                    {
                                        PrintPassenger(planeBank[i][j]);
                                        tick = false;
                                    }
                                }

                            }
                        }
                    }

                    NoSuchPassanger(tick);
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    brk = true;
                    break;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Enter flight number!");
                    Console.ReadLine();
                }

            } while (!brk);
        }
        private void CheckByCity()
        {
            bool brk = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Checking by city...");
                    Console.WriteLine();
                    bool tick = true;
                    Console.Write("Enter city: ");
                    var city = Console.ReadLine();

                    for (int i = 0; i < count; i++)
                    {
                        if (planeBank[i] != null)
                        {
                            if (CompareStrings(planeBank[i].city, city))
                            {
                                Console.WriteLine("===============================");
                                Console.WriteLine("           Plane{0}            ", planeBank[i].planeNum);
                                Console.WriteLine("===============================");
                                PrintPassengers(planeBank[i]);
                                tick = false;
                                Console.ReadLine();
                            }
                        }
                    }

                    NoSuchPassanger(tick);
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    brk = true;
                    break;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Enter flight number!");
                    Console.ReadLine();
                }

            } while (!brk);
        }
        private void CheckByPassport()
        {
            bool brk = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Checking by passport...");
                    Console.WriteLine();
                    bool tick = true;
                    Console.Write("Enter passport number: ");
                    var passport = Console.ReadLine();

                    for (int i = 0; i < count; i++)
                    {
                        if (planeBank[i] != null)
                        {
                            for (int j = 0; j < planeBank[i].count; j++)
                            {
                                if (CompareStrings(planeBank[i][j].passport, passport))
                                {
                                    PrintPassenger(planeBank[i][j]);
                                    tick = false;
                                }
                            }
                        }
                    }

                    NoSuchPassanger(tick);
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    brk = true;
                    break;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Enter passport number!");
                    Console.ReadLine();
                }

            } while (!brk);
        }

        #region additional methods
        private bool CompareStrings(string name1, string name2)
        {
            if (name1.ToLower().Replace(" ", "") == name2.ToLower().Replace(" ", ""))
                return true;
            else
                return false;
        }
        private bool ComparePrice(int price1, int price2)
        {
            if (price1 == price2)
                return true;
            else
                return false;
        }
        private void NoSuchPassanger(bool tick)
        {
            if (tick)
            {
                Console.WriteLine();
                Console.WriteLine("No such passanger!");
            }
        }

        #endregion

        #endregion

        #endregion

        #region check price

        public void CheckPrise()
        {
            Class price1 = Class.Business;
            Class price2 = Class.Econom;

            for (int i = 1; i < Enum.GetNames(typeof(Airline)).Length + 1; i++)
            {

                switch (i)
                {
                    case 1:
                        Console.WriteLine("Ukraine International Airlines");
                        Console.WriteLine("===============================");
                        Console.WriteLine("Business: {0}", price1 + 5000);
                        Console.WriteLine("Econom:   {0}", price2 + 1000);
                        break;
                    case 2:
                        Console.WriteLine("Windrose");
                        Console.WriteLine("===============================");
                        Console.WriteLine("Business: {0}", price1 + 55);
                        Console.WriteLine("Econom:   {0}", price2 + 15);
                        break;
                    case 3:
                        Console.WriteLine("Sky Up Airlines");
                        Console.WriteLine("===============================");
                        Console.WriteLine("Business: {0}", price1 + 2555);
                        Console.WriteLine("Econom:   {0}", price2 + 1999);
                        break;
                    case 4:
                        Console.WriteLine("Azur Air Ukraine");
                        Console.WriteLine("================================");
                        Console.WriteLine("Business: {0}", price1 + 228);
                        Console.WriteLine("Econom:   {0}", price2 + 322);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("===============================");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        #endregion

        #region print palnes

        public void PrintPlanes()
        {
            if (EmptyArray())
            {
                Console.Clear();
                Console.WriteLine("Array is empty!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return;
            }
            for (int i = 0; i < count; i++)
            {
                if (!EndArray(planeBank[i]))
                {
                    Console.WriteLine("===============================");
                    Console.WriteLine("             #{0}                ", i + 1);
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

        #region print passengers

        public void PrintPassenger(Passenger pas)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Name            : " + pas.name.ToString());
            Console.WriteLine("Second name     : " + pas.secondName.ToString());
            Console.WriteLine("Nationality     : " + pas.nationality.ToString());
            Console.WriteLine("Passport        : " + pas.passport.ToString());
            Console.WriteLine("Date of birthday: " + pas.dateOfBirthday.ToShortDateString().ToString());
            Console.WriteLine("Sex             : " + pas.sex.ToString());
            Console.WriteLine("Class           : " + pas.classF.ToString());
            Console.WriteLine("Price           : " + pas.price.ToString());
            Console.WriteLine("Plane number    : " + pas.planeNum.ToString());
            Console.WriteLine("===============================");
        }

        public void PrintPassengers(Plane pln)
        {
            Console.Clear();
            for (int i = 0; i < pln.count; i++)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("         Passenger {0}         ", i + 1);
                Console.WriteLine("===============================");
                Console.WriteLine("Name            : " + pln[i].name.ToString());
                Console.WriteLine("Second name     : " + pln[i].secondName.ToString());
                Console.WriteLine("Nationality     : " + pln[i].nationality.ToString());
                Console.WriteLine("Passport        : " + pln[i].passport.ToString());
                Console.WriteLine("Date of birthday: " + pln[i].dateOfBirthday.ToShortDateString().ToString());
                Console.WriteLine("Sex             : " + pln[i].sex.ToString());
                Console.WriteLine("Class           : " + pln[i].classF.ToString());
                Console.WriteLine("Price           : " + pln[i].price.ToString());
                Console.WriteLine("Plane number    : " + pln[i].planeNum.ToString());

            }
            Console.WriteLine("===============================");
        }

        #endregion

        #region exeption

        private bool EndArray(Plane obj)
        {
            // mozno zamenit peregruzkoi true-false dla plane
            if (obj == null)
                return true;
            else
                return false;
        }
        public bool EmptyArray()
        {
            if (this.planeBank == null)
                return true;
            else
                return false;
        }
        public bool IsFreeSpace()
        {
            if (count == planeIndx)
            {
                Console.Clear();
                Console.WriteLine("Array is full !!!");
                Console.ReadLine();
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region test data
        public void CreateTestPlanes(int ww = 28)
        {
            for (int j = 0; j < ww; j++)
            {
                Plane plane = new Plane(j + 1);
                LandPlane(plane);
            }
        }
        //private Airline RndAirline(int n)
        //{
        //    for (int i = 1; i <= Enum.GetNames(typeof(Airline)).Length; i++)                     // how it work: Enum.GetNames(typeof(Airline)).Length?
        //    {
        //        ;
        //    }
        //}
        #endregion
    }
}
