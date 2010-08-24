using System.Text.RegularExpressions;

namespace UniformRenamer.Core
{
    class SearchPattern
    {
        public string pattern { get; set; }
        public bool isRegex { get; set; }
        public SearchPattern(string pattern, bool isRegex)
        {
            this.pattern = pattern;
            this.isRegex = isRegex;
        }
        public SearchPattern(string pattern)
        {
            if (pattern.StartsWith("* "))
            {
                this.pattern = pattern.Substring(2, pattern.Length - 2);
                isRegex = true;
            }
            else
            {
                this.pattern = pattern;
                isRegex = false;
            }
        }
        public string Replace(string input, string replacement)
        {
            if (isRegex)
            {
                return Regex.Replace(input, pattern, replacement);
            }
            else
            {
                return input.Replace(pattern, replacement);
            }
        }
        public bool IsMatch(string input)
        {
            if (isRegex)
            {
                return Regex.IsMatch(input, pattern);
            }
            else
            {
                return input.Contains(pattern);
            }
        }
        public Match Match(string input)
        {
            if (isRegex)
            {
                return Regex.Match(input, pattern);
            }
            else
            {
                return Regex.Match(input, Regex.Escape(pattern));
            }
        }
    }
}
