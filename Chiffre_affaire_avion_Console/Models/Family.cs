using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffre_affaire_avion_Console.Models
{
    public class Family
    {
        public List<FamilyMember> members = new List<FamilyMember>();

        private int availableSeats = 5;

        public int AvailableSeats => availableSeats;

        public void AddMember(Passenger passenger)
        {
            FamilyMember familyMember = new FamilyMember(passenger.Type, passenger.Price, this);
            members.Add(familyMember);
            availableSeats--;
        }

        public int CalculateTotalPrice()
        {
            return members.Sum(member => member.Price);
        }
    }
}
