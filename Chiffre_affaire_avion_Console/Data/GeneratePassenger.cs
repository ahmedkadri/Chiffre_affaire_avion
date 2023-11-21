using Chiffre_affaire_avion_Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffre_affaire_avion_Console.Data
{
    public class GeneratePassenger
    {
        public GeneratePassenger()
        {

        }
        public List<Passenger> GeneratePassengers()
        {
            List<Passenger> passengers = new List<Passenger>();

            // Génération des adultes
            for (int i = 0; i < 200; i++)
            {
                passengers.Add(new Passenger("Adulte", 250));
            }

            // Génération des enfants
            for (int i = 0; i < 50; i++)
            {
                passengers.Add(new Passenger("Enfant", 150));
            }

            // Génération des adultes nécessitant deux places
            for (int i = 0; i < 20; i++)
            {
                passengers.Add(new Passenger("Adulte 2 places", 500));
            }

            return passengers;
        }

        public List<Family> GenerateFamilies(List<Passenger> passengers)
        {
            List<Family> families = new List<Family>();

            // Mélanger la liste des passagers pour créer des familles aléatoires
            Random random = new Random();
            List<Passenger> shuffledPassengers = passengers.OrderBy(x => random.Next()).ToList();

            // Génération des familles en respectant les contraintes
            for (int i = 0; i < shuffledPassengers.Count;)
            {
                Family family = new Family();

                // Ajout des adultes à la famille (maximum 2)
                for (int j = 0; j < 2 && i < shuffledPassengers.Count; j++, i++)
                {
                    family.AddMember(shuffledPassengers[i]);
                }

                // Ajout des enfants à la famille (maximum 3)
                for (int j = 0; j < 3 && i < shuffledPassengers.Count; j++, i++)
                {
                    family.AddMember(shuffledPassengers[i]);
                }

                families.Add(family);
            }

            return families;
        }
    }
}
