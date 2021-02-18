using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public sealed class DerivedStaticField: BaseStaticField<DerivedStaticField>
    {
        public DerivedStaticField()
        {
            Console.WriteLine("DerivedStaticField constructor.");
        }
    }
}
