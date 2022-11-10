using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems.Medium.OnlineStockSpan;

/// <summary>
/// https://leetcode.com/problems/online-stock-span/
/// </summary>
public class StockSpanner
{
    private readonly List<int> _prices;
    public StockSpanner() {
        _prices = new List<int>();
    }
    
    public int Next(int price)
    {
        var counter = 0;
        _prices.Add(price);
        for (var i = _prices.Count - 1; i >= 0; i--)
        {
            if (price >= _prices[i])
            {
                counter++;
            }
            else
            {
                break;
            }
        }

        return counter;
    }
}