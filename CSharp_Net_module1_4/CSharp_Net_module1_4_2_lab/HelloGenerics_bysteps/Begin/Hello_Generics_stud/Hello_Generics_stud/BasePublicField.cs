using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class BasePublicField<T> where T : new()
    {
        private T instanse;
        public T Instanse
        {
            get
            {
                Console.WriteLine("Public field");
                this.instanse = new T();
                return this.instanse;
            }
        }

    }
}
