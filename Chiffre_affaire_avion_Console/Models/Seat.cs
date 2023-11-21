using System;
using System.Collections.Generic;
using System.Text;

namespace Chiffre_affaire_avion_Console.Models
{
    public class Seat
    {
        public Passenger Passenger { get; }
        public Family Family { get; }

        public Seat(Passenger passenger)
        {
            Passenger = passenger;
        }

        public Seat(Passenger passenger, Family family) : this(passenger)
        {
            Family = family;
        }

        public override string ToString()
        {
            if (Family != null)
            {
                return $"{Passenger.Type} ({Family.CalculateTotalPrice()} €) - Famille";
            }
            else
            {
                return $"{Passenger.Type} ({Passenger.Price} €) - Individuel";
            }
        }
    }
}
