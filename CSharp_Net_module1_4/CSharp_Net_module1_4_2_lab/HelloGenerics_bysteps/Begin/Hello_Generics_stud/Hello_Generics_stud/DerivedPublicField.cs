﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class DerivedPublicField : BasePublicField<DerivedPublicField>
    {
        public DerivedPublicField()
        {
            Console.WriteLine("In DerivedPublicField constructor.");
        }

    }
}
