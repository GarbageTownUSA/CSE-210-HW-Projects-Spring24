using System;
using System.Text.RegularExpressions;

namespace DnDSpellCaster
{
    public static class DieRoll
    {
        private static Random random = new Random();

        public static int Roll(string dice)
        {
            int total = 0;
            var matches = Regex.Matches(dice, @"(\d+)d(\d+)");
            foreach (Match match in matches)
            {
                int count = int.Parse(match.Groups[1].Value);
                int sides = int.Parse(match.Groups[2].Value);
                for (int i = 0; i < count; i++)
                {
                    total += random.Next(1, sides + 1);
                }
            }
            return total;
        }
    }
}
