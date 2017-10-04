using System;
using System.Collections;
namespace CrackThat
{
    public class ArrayProblems
    {
        public ArrayProblems()
        {
        }

        public static int computeMaxProfit(int[] stockPrices)
        {
            int maxProfit = 0;
            int minPrice = Int32.MaxValue;

            for (int i = 0; i < stockPrices.Length; i++)
            {
                maxProfit = Math.Max(stockPrices[i] - minPrice, maxProfit);
                minPrice = Math.Min(stockPrices[i], minPrice);
            }

            return maxProfit;

        }

        public static int computeMaxProfitForTwoStockSell(int [] stockPrices)
        {
            int maxProfit = 0;
            int minPrice = Int32.MaxValue;

            ArrayList maxProfits = new ArrayList();


			for (int i = 0; i < stockPrices.Length; i++)
			{
				maxProfit = Math.Max(stockPrices[i] - minPrice, maxProfit);
				minPrice = Math.Min(stockPrices[i], minPrice);
                maxProfits.Add(maxProfit);
			}


            int maxPrice = Int32.MinValue;
            for (int j = stockPrices.Length - 1; j > 0; j--)
            {
                maxPrice = Math.Max(maxPrice, stockPrices[j]);
                int tempProfit = maxPrice - stockPrices[j];
                maxProfit = Math.Max(maxProfit, tempProfit + (int)maxProfits[j - 1]);
            }

            return maxProfit;
		}
    }
}
