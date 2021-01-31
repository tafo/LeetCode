using System.Collections.Generic;

namespace LeetCode.Problems.Hard.SubstringWithConcatOfAllWords
{
    public class Solution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var output = new List<int>();
            var wordLength = words[0].Length;
            var windowLength = wordLength * words.Length;
            var wordCounterMap = new Dictionary<string, int>();
            var wordFoundMap = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordCounterMap.ContainsKey(word)) wordCounterMap[word]++;
                else wordCounterMap[word] = 1;
            }

            for (var i = 0; i <= s.Length - windowLength; i++)
            {
                wordFoundMap.Clear();
                CheckWindow(i);
            }

            return output;

            void CheckWindow(int i)
            {
                for (var j = 0; j < words.Length; j++)
                {
                    var start = i + j * wordLength;
                    var word = s.Substring(start, wordLength);

                    if (!wordCounterMap.ContainsKey(word)) return;

                    if (wordFoundMap.ContainsKey(word)) wordFoundMap[word]++;
                    else wordFoundMap[word] = 1;

                    if (wordFoundMap[word] > wordCounterMap[word]) return;
                }
                output.Add(i);
            }
        }
    }
}