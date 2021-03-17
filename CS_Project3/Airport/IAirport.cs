using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project
{
    public interface IAirport
    {
        void LandPlane(int key, Plane plane);
        void PlaneTookOff(int planeNum_);
        void EmergencyInformationOutput();
        void FindSomePlane();
        void FindNearestPlane();
        void Print();
    }
}
