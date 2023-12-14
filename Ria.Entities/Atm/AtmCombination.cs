namespace Ria.Entities.Atm
{
    internal class AtmCombination
    {
        public List<string> CreateCombinations(int amount, List<Cartridge> cartridges)
        {
            var result = new List<string>();
            CalculateCombinations(amount, cartridges, new List<Cartridge>(), result);
            return result;
        }

        private void CalculateCombinations(int amount, List<Cartridge> cartridges, List<Cartridge> currentCombination, List<string> result)
        {
            if (amount == 0)
            {
                result.Add(BuildCombination(currentCombination));
                return;
            }

            if (amount < 0 || cartridges.Count == 0)
            {
                return;
            }

            CalculateCombinations(amount, cartridges.Skip(1).ToList(), new List<Cartridge>(currentCombination), result);
            CalculateCombinations(amount - cartridges[0].Note, cartridges, new List<Cartridge>(currentCombination.Concat(new[] { cartridges[0] })), result);
        }

        private static string BuildCombination(List<Cartridge> combinations)
        {
            if (combinations.Count == 0)
            {
                return string.Empty;
            }

            var parts = new List<string>();
            foreach (var combination in combinations.Distinct())
            {
                int count = combinations.Count(d => d == combination);
                parts.Add($"{count} x {combination.Note} EUR");
            }

            return string.Join(" + ", parts);
        }
    }
}
