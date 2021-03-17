using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Birthday { get; set; }
        public long Id { get; set; }
    }
    class TestClass
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.FirstName = "Andy";
            person.LastName = "Sharp";
            person.Birthday = new DateTime(1913, 02, 10);
            Console.WriteLine("Std info:\n" + person.FirstName + " " + person.LastName + ", dr: " + person.Birthday.ToString() );
        }
    }
}
