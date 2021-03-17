using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project.AditionalMethods
{
    
    class EventHandlers
    {
        public event EventHandler<KeyValuePair<int, Plane>> FlyOut;
        public event EventHandler<KeyValuePair<int, Plane>> FlyIn;

        public void PlaneStatus(KeyValuePair<int, Plane> plane, int i = 1)
        {
            if (i > 0)
            {
                FlyIn?.Invoke(this, plane);
                return;
            }
            if (i < 0)
            {
                FlyOut?.Invoke(this, plane);
                return;
            }
            else
            {
                Console.WriteLine("Nothing happends.");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                return;
            }
        }

    }
}
