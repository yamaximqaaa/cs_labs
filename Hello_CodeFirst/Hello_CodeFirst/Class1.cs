using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_CodeFirst
{
    public class TextCodeFirstContext : DbContext
    {
        public TextCodeFirstContext():base("Default")
        {

        }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Email> Emails { get; set; }
    }
}
