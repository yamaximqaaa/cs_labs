using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class BaseStaticField<T> where T: new()
    {
        static T field1;
        static T field2;
        protected BaseStaticField()
        {
            Console.WriteLine("BaseStaticField constructor.");
        }
    }
}
