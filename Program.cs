namespace SuccessfulPairsSpellsPotions
{
    internal class Program
    {
        public class SuccessfulPairsSpellsPotions
        {

            private int LowerBound(int[] potions, int key)
            {
                int leftIdx = 0;
                int rightIdx = potions.Length;
                while(leftIdx < rightIdx)
                {
                    int middleIdx = leftIdx + (rightIdx - leftIdx) / 2;
                    if (potions[middleIdx] < key)
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
                for(int i = 0; i < spells.Length; ++i)
                {
                    long spellPotion = (long)Math.Ceiling((1.0 * success) / spells[i]);
                    if (spellPotion > potions[n - 1])
                    {
                        successfulPairs[i] = 0;
                        continue;
                    }
                    int minSpellPotionBound = LowerBound(potions, (int)spellPotion);
                    successfulPairs[i] = n - minSpellPotionBound;
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