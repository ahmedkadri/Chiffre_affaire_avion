using System;
using System.Collections.Generic;
using System.Text;

namespace Chiffre_affaire_avion_Console.Models
{
    public class FamilyMember : Passenger
    {
        public Family Family { get; }

        public FamilyMember(string type, int price, Family family) : base(type, price)
        {
            Family = family;
        }
    }
}
