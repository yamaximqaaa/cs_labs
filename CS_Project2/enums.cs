using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CS_Project
{
    #region enum
    enum Status
    {
        CheckIn = 1,
        GateClosed,
        Arrived,
        DepartedAt,
        Unknown,
        Canceled,
        ExpectedAt,
        Delayed,
        InFlight
    }
    enum Airline
    {
        UkraineInternationalAirlines = 1,
        Windrose,
        SkyUpAirlines,
        AzurAirUkraine
    }
    enum Terminal
    {
        A = 1,
        B,
        C,
        D,
    }
    enum Sex
    {
        Male = 1,
        Female
    }
    enum Class
    {
        Econom = 1,
        Business
    }
    #endregion
}