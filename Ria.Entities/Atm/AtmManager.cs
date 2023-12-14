namespace Ria.Entities.Atm
{
    public class AtmManager
    {
        private readonly AtmCombination AtmCombination;

        public AtmManager()
        {
            AtmCombination = new AtmCombination();
        }

        public IEnumerable<string> GeneratePayoutCombinations(int amount)
        {
            var cartridges = new List<Cartridge>
            {
                new(10),
                new(50),
                new(100)
            };

            return AtmCombination.CreateCombinations(amount, cartridges);
        }

    }
}
