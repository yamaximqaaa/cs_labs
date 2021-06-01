using Abstractions.Enums;
using System;


namespace Abstractions.Passanger
{
    public interface IPassenger
    {
        #region passanger prop
        int planeNum { get; set; }
        string name { get; set; }
        string secondName { get; set; }
        string nationality { get; set; }
        DateTime dateOfBirthday { get; set; }
        Sex sex { get; set; }
        Class classF { get; set; }
        int price { get; set; }
        #endregion
    }
}
