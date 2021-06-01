using Abstractions.Enums;
using Abstractions.Passanger;
using Abstractions.Plane;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    class DBPlane : IPlane
    {
        public int planeNumber { get; set; }
        public DateTime timeIn { get ; set; }
        public DateTime timeOut { get; set; }
        public string city { get; set; }
        public Airline airline { get; set; }
        public Terminal terminal { get; set; }
        public Status status { get; set; }
        public string gate { get; set; }
        public bool isPlaneInAirport { get; set; }
        public ICollection<DBPassanger> Passangers { get; set; }
    }
}
