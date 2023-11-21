using Chiffre_affaire_avion_Console.Business;
using Chiffre_affaire_avion_Console.Data;
using Chiffre_affaire_avion_Console.Models;
using System;
using System.Collections.Generic;

namespace Chiffre_affaire_avion_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Génération des passagers et familles
            var generatePassenger = new GeneratePassenger();
            List<Passenger> passengers = generatePassenger.GeneratePassengers();
            List<Family> families = generatePassenger.GenerateFamilies(passengers);

            // Répartition optimale des passagers et familles
            var servicesAvion = new ServicesAvion();
            List<Seat> optimalSeating = servicesAvion.OptimalSeating(passengers, families);

            // Affichage de la répartition optimale et du chiffre d'affaires total
            Console.WriteLine("Répartition optimale des passagers et familles :");
            foreach (Seat seat in optimalSeating)
            {
                Console.WriteLine(seat);
            }

            int totalRevenue = servicesAvion.CalculateTotalRevenue(optimalSeating);
            Console.WriteLine($"\nChiffre d'affaires total : {totalRevenue} €");
        }
    }
}
