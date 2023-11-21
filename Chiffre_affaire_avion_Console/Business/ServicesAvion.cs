using Chiffre_affaire_avion_Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffre_affaire_avion_Console.Business
{
    public class ServicesAvion
    {
        public ServicesAvion()
        {

        }
        public List<Seat> OptimalSeating(List<Passenger> passengers, List<Family> families)
        {
            // Sélection des 200 passagers les plus rentables
            List<Passenger> selectedPassengers = passengers.OrderByDescending(p => p.Price).Take(200).ToList();



            // Affectation des passagers individuels
            List<Seat> seating = new List<Seat>();
            foreach (Passenger passenger in selectedPassengers)
            {
                if (passenger is FamilyMember)
                {
                    Family family = ((FamilyMember)passenger).Family;
                    // Vérifier si la famille a suffisamment de places disponibles
                    if (family.AvailableSeats > 0)
                    {
                        Seat seat = new Seat(passenger, family);
                        seating.Add(seat);
                    }
                }
                else
                {
                    // Affecter les passagers individuels à des sièges non occupés
                    Seat seat = new Seat(passenger);
                    seating.Add(seat);
                }
            }

            return seating;
        }

        public int CalculateTotalRevenue(List<Seat> seating)
        {
            return seating.Sum(seat => seat.Passenger.Price);
        }

        public void DisplaySeating(List<Seat> seating)
        {
            foreach (Seat seat in seating)
            {
                Console.WriteLine(seat);
            }
        }


    }
}
