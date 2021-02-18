using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project
{
    interface IPassenger
    {
        #region passanger prop
        int planeNum { get; set; }
        string name { get; set; }
        string secondName { get; set; }
        string nationality { get; set; }
        string passport { get; set; }
        DateTime dateOfBirthday { get; set; }
        Sex sex { get; set; }
        Class classF { get; set; }
        int price { get; set; }
        #endregion


    }
}
