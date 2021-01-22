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
                            break;
                        }

                }

            } while (i == 1 || i == 2 || i == 3);
        }

        private void SearchByNum(int num)
        {
            for (int i = 0; i < count; i++)
            {
                if (!EndArray(planeBank[i]) && planeBank[i].planeNum == num)
                {
                    PrintPlane(planeBank[i]); break;
                }
            }
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
            Console.WriteLine("4. By second name");
            Console.WriteLine("5. By passport");
            Console.WriteLine("6. By city");
            Console.WriteLine("7. Back");
            Console.WriteLine("===============================");
            Console.WriteLine();

            Console.Write("Enter your choise: ");
            i = Convert.ToInt32(Console.ReadLine());

            switch (i)
            {
                case 1:
                    {
                        Console.WriteLine("1");
                        return false;
                    }
                case 2:
                    {
                        Console.WriteLine("2");
                        return false;
                    }
                case 3:
                    {
                        Console.WriteLine("3");
                        return false;
                    }
                case 4:
                    {
                        Console.WriteLine("4"); 
                        return false;
                    }
                case 5:
                    {
                        Console.WriteLine("5");
                        return false;
                    }
                case 6:
                    {
                        Console.WriteLine("6"); 
                        return false;
                    }
                case 7:
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
            bool isExit = false;
            do
            {
                try
                {
                    isExit = CheckMenu();
                }
                catch(FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Enter num 1 to 7!");
                    Console.ReadLine();
                }

            } while (!isExit);
        }

        #endregion

        #region print palnes

        public void PrintPlanes()
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                if (!EndArray(planeBank[i]))
                {
                    Console.WriteLine("===============================");
                    Console.WriteLine("              {0}                ", i + 1);
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

        public void PrintPassengers(int planeNumber)
        {
            Console.Clear();
            for (int i = 0; i < planeBank[0].count; i++)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("         Passenger {0}         ", i + 1);
                Console.WriteLine("===============================");
                Console.WriteLine("Name            : " + planeBank[0][i].name.ToString());
                Console.WriteLine("Second name     : " + planeBank[0][i].secondName.ToString());
                Console.WriteLine("Nationality     : " + planeBank[0][i].nationality.ToString());
                Console.WriteLine("Passport        : " + planeBank[0][i].passport.ToString());
                Console.WriteLine("Date of birthday: " + planeBank[0][i].dateOfBirthday.ToShortDateString().ToString());
                Console.WriteLine("Sex             : " + planeBank[0][i].sex.ToString());
                Console.WriteLine("Class           : " + planeBank[0][i].classF.ToString());
                Console.WriteLine("Plane number    : " + planeBank[0][i].planeNum.ToString());

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

        private bool EmptyArray()
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

        #endregion
    }
}
