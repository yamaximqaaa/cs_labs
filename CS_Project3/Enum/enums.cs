using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CS_Project
{
    #region enum
    public enum Status
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
    public enum Airline
    {
        UkraineInternationalAirlines = 1,
        Windrose,
        SkyUpAirlines,
        AzurAirUkraine
    }
    public enum Terminal
    {
        A = 1,
        B,
        C,
        D,
    }
    
    public enum Sex
    {
        Male = 1,
        Female
    }
    public enum Class
    {
        Econom = 3000,
        Business = 6300
    }
    #endregion
}