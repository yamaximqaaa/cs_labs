using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project
{
    interface IAirport
    {
        void LandPlane(Plane plane);
        void PlaneTookOff(int planeNum_);
        void EmergencyInformationOutput();
        void FindSomePlane();
        void FindNearestPlane();
        void PrintPlanes();
    }
}
