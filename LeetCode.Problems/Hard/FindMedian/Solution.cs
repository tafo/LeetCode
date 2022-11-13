using System.Collections.Generic;

namespace LeetCode.Problems.Hard.FindMedian;

/// <summary>
/// https://leetcode.com/problems/find-median-from-data-stream/
/// </summary>
public class MedianFinder
{
    private int _left = -1;
    private int _right;
    private bool _flag;
    private readonly List<int> _numbers;

    public MedianFinder()
    {
        _numbers = new List<int>();
    }
    
    public void AddNum(int num)
    {
        var index = _numbers.BinarySearch(num);
        index = index >= 0 ? index : ~index;
        _numbers.Insert(index, num);
        if (_flag)
        {
            _right++;
        }
        else
        {
            _left++;
        }

        _flag = !_flag;
    }
    
    public double FindMedian()
    {
        return (_numbers[_left] + _numbers[_right]) / 2D;
    }
}