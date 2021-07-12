namespace LeetCode.Problems.Easy.IsIsomorphic
{
    public class SolutionAnother
    {
        public bool IsIsomorphic(string s, string t)
        {
            var n = t.Length;
            var patternOrder = new int[n];
            var map = new int[256];
        
            var j = 1;
            for (var i = 0; i < n; i++)
            {
                var c = t[i];
                if (map[c] == 0)
                    map[c] = j++;
            
                patternOrder[i] = map[c];
            }
        
            map = new int[256];
            j = 1;
            for (var i = 0; i < n; i++)
            {
                var c = s[i];
                if (map[c] == 0)
                    map[c] = j++;

                if (patternOrder[i] != map[c]) 
                {
                    return false;
                }
            }
            return true;
        }
    }
}