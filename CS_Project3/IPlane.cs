using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project
{
    interface IPlane
    {
        #region plane prop
        int planeNum { get; set; }
        DateTime timeIn { get; set; }
        DateTime timeOut { get; set; }
        string city { get; set; }
        Airline airline { get; set; }
        Terminal terminal { get; set; }
        Status status { get; set; }
        string gate { get; set; }
        bool isPlaneInAirport { get; set; } // try to del
        #endregion
        
        
        void BuildPlane();
    }
}
