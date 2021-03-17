using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_CodeFirst
{
    [Table("email")]
    public class Email
    {
        [Key]
        public int EmId { get; set; }
        public string EmValue { get; set; }
        public string IcId { get; set; }
        public virtual Lecturer Lecturer  { get; set; }
    }
}
