using System;
namespace CrackThat
{
    public class PrimitveProblems 
    {
        public static long GetClosestNumberByWeight(long num)
        {
            int NUM_ASSIGNED_BITS = 63;
            for (int i = 0; i < NUM_ASSIGNED_BITS; i++)
            {
                if (((num >> i) & 1) != ((num >> (i + 1)) & 1))
                {
                    num ^= (1L << i) | (1L << (i + 1));
                    return num;
                }
            }

            throw new ArgumentException("Number has all 1s or all 0s");
        }
    }
}