using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project.Collection
{
    class CollectionError: Exception
    {
        public CollectionError(string message)
            :base(message)
        {

        }
        public CollectionError()
            : base("Error in collection!")
        {

        }
    }
}
