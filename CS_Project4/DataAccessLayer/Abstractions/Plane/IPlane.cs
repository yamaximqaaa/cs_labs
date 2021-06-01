using Abstractions.Enums;
using System;


namespace Abstractions.Plane
{
    public interface IPlane
    {
        #region plane prop
        DateTime timeIn { get; set; }
        DateTime timeOut { get; set; }
        string city { get; set; }
        Airline airline { get; set; }
        Terminal terminal { get; set; }
        Status status { get; set; }
        string gate { get; set; }
        bool isPlaneInAirport { get; set; } // try to del
        #endregion
    }
}
