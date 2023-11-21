using System;
using System.Collections.Generic;
using System.Text;

namespace Chiffre_affaire_avion_Console.Models
{
    public class Passenger
    {
        public string Type { get; }
        public int Price { get; }

        public Passenger(string type, int price)
        {
            Type = type;
            Price = price;
        }
    }
}
