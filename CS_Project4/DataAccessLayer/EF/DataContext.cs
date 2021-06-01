using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EF
{
    public class DataContext: DbContext
    {
        public DbSet<DBPassanger> Passangers { get; set; }
        public DbSet<DBPlane> Planes { get; set; }

        static DataContext()
        {
            Database.SetInitializer<DataContext>(new AirportDbInitializer());
        }
        public  DataContext(string connectionString)
            :base(connectionString)
        {

        }
    }
    public class AirportDbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Planes.Add(new DBPlane
            {
                planeNumber = 3502,
                city = "Kyiv",
                airline = Abstractions.Enums.Airline.SkyUpAirlines,
                terminal = Abstractions.Enums.Terminal.C,
                status = Abstractions.Enums.Status.Arrived,
                timeIn = DateTime.Now,
                timeOut = new DateTime().AddHours(1),
                gate = "AA32b12"
            });
            context.Planes.Add(new DBPlane
            {
                planeNumber = 2435,
                city = "London",
                airline = Abstractions.Enums.Airline.Windrose,
                terminal = Abstractions.Enums.Terminal.A,
                status = Abstractions.Enums.Status.Delayed,
                timeIn = DateTime.Now,
                timeOut = new DateTime().AddMinutes(30),
                gate = "CD01F22"
            });
            context.SaveChanges();
        }
    }
}
