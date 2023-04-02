namespace SuccessfulPairsSpellsPotions
{
    internal class Program
    {
        public class SuccessfulPairsSpellsPotions
        {
            private int LowerBound(int[] potions, int spellPotion)
            {
                int leftIdx = 0;
                int rightIdx = potions.Length;
                while (leftIdx < rightIdx)
                {
                    int middleIdx = leftIdx + (rightIdx - leftIdx) / 2;
                    if (potions[middleIdx] < spellPotion)
                    {
                        leftIdx = middleIdx + 1;
                    }
                    else
                    {
                        rightIdx = middleIdx;
                    }
                }
                return leftIdx;
            }

            public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
            {
                int n = potions.Length;
                int[] successfulPairs = new int[spells.Length];
                Array.Sort(potions);
                for (int i = 0; i < spells.Length; ++i)
                {
                    long spellPotions = (long)Math.Ceiling((1.0 * success) / spells[i]);
                    if (spellPotions > potions[n - 1])
                    {
                        successfulPairs[i] = 0;
                        continue;
                    }
                    int lowerBound = LowerBound(potions, (int)spellPotions);
                    successfulPairs[i] = n - lowerBound;
                }
                return successfulPairs;
            }
        }

        static void Main(string[] args)
        {
            SuccessfulPairsSpellsPotions successfulPairsSpellsPotions = new();
            Console.WriteLine(string.Join(", ", successfulPairsSpellsPotions.SuccessfulPairs(new int[] { 5, 1, 3 }, new int[] { 1, 2, 3, 4, 5 }, 7)));
            Console.WriteLine(string.Join(", ", successfulPairsSpellsPotions.SuccessfulPairs(new int[] { 3, 1, 2 }, new int[] { 8, 5, 8 }, 16)));
        }
    }
}