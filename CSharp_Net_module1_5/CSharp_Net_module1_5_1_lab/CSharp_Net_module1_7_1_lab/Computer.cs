using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_7_1_lab
{
    class Computer
    {
        public int Cores { get; set; }
        public double Frequency { get; set; }
        public int Memory { get; set; }
        public int Hdd { get; set; }
        public Computer(int cores, double frequency, int memory, int hdd)
        {
            this.Cores = cores;
            this.Frequency = frequency;
            this.Memory = memory;
            this.Hdd = hdd;
        }
    }
}
