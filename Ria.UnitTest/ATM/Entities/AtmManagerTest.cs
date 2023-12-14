using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;
using FluentAssertions;
using Ria.Entities.Atm;


namespace Ria.UnitTest.ATM.Services
{
    [Trait("RIA", "ATM.Services")]
    public class AtmCombinationServiceTest
    {
        private readonly AtmManager AtmManager;
        public AtmCombinationServiceTest()
        {
            AtmManager = new AtmManager();
        }

        [Fact]

        public async Task create_combination_100()
        {
            //Arrange
            var expected = new List<string>
            {
                "1 x 100 EUR",
                "2 x 50 EUR",
                "5 x 10 EUR + 1 x 50 EUR",
                "10 x 10 EUR"
            };

            //Act
            var combinations = AtmManager.GeneratePayoutCombinations(100);

            //Assert
            combinations.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task create_combination_30()
        {
            //Arrange
            var expected = new List<string>
            {
                "3 x 10 EUR"
            };

            //Act
            var combinations = AtmManager.GeneratePayoutCombinations(30);

            //Assert
            combinations.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task create_combination_50()
        {
            //Arrange
            var expected = new List<string>
            {
                "1 x 50 EUR",
                "5 x 10 EUR"
            };

            //Act
            var combinations = AtmManager.GeneratePayoutCombinations(50);

            //Assert
            combinations.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task create_combination_60()
        {
            //Arrange
            var expected = new List<string>
            {
                "1 x 10 EUR + 1 x 50 EUR",
                "6 x 10 EUR"
            };

            //Act
            var combinations = AtmManager.GeneratePayoutCombinations(amount: 60);

            //Assert
            combinations.Should().BeEquivalentTo(expected);
        }
    }
}
