using Chiffre_affaire_avion_Console.Business;
using Chiffre_affaire_avion_Console.Data;
using Chiffre_affaire_avion_Console.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Chiffre_affaire_test
{
    [TestClass]
    public class ChiffreAffaireTest
    {
        [TestMethod]
        public void GenerateFamilies_ShouldGenerateValidFamilies()
        {
            var generatePassenger = new GeneratePassenger();

            List<Passenger> passengers = generatePassenger.GeneratePassengers();

            // Act
            List<Family> families = generatePassenger.GenerateFamilies(passengers);

            // Assert
            Assert.IsNotNull(families);
            foreach (var family in families)
            {
                Assert.IsTrue(family.members.Count > 0 && family.members.Count <= 5);
                foreach (var member in family.members)
                {
                    Assert.IsNotNull(member);
                }
            }
        }

        [TestMethod]
        public void OptimalSeating_ShouldGenerateOptimalSeating()
        {
            var generatePassenger = new GeneratePassenger();
            // Arrange
            List<Passenger> passengers = generatePassenger.GeneratePassengers();

            List<Family> families = generatePassenger.GenerateFamilies(passengers);

            var servicesAvion = new ServicesAvion();

            // Act
            List<Seat> optimalSeating = servicesAvion.OptimalSeating(passengers, families);

            // Assert
            Assert.IsNotNull(optimalSeating);
        }


        [TestMethod]
        public void CalculateTotalRevenue_ShouldReturnCorrectTotalRevenue()
        {
            var generatePassenger = new GeneratePassenger();

            List<Passenger> passengers = generatePassenger.GeneratePassengers();

            List<Family> families = generatePassenger.GenerateFamilies(passengers);

            var servicesAvion = new ServicesAvion();
            List<Seat> seats = servicesAvion.OptimalSeating(passengers, families);

            int totalRevenue = servicesAvion.CalculateTotalRevenue(seats);

            Assert.AreEqual(55000, totalRevenue);
        }
    }
}
