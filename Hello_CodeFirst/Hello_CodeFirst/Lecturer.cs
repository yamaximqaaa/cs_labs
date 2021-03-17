using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_CodeFirst
{
    public class Lecturer
    {
        [Key]
        public string LcId { get; set; }
        public string LcFname { get; set; }
        public string LcIName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}
