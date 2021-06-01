using System;
using Abstractions.Enums;
using Abstractions.Passanger;

namespace DataAccessLayer.Entities
{
    class DBPassanger : IPassenger
    {
        public int planeNum { get; set; }
        public int passportNumber { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string nationality { get; set; }
        public DateTime dateOfBirthday { get; set; }
        public Sex sex { get; set; }
        public Class classF { get; set; }
        public int price { get; set; }
    }
}
