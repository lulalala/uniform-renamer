namespace UniformRenamer.Core
{
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    class CopyRule : IRule
    {
        private List<SearchPattern> searchPatterns = new List<SearchPattern>();

        public CopyRule(string name, string[] searchPatterns)
        {
            this.destinationTag = name;
            foreach (string s in searchPatterns)
            {
                this.searchPatterns.Add(new SearchPattern(s));
            }
        }

        public string destinationTag
        {
            get; set;
        }

        public void Apply(ref string oldName, ref string newFormat)
        {
            foreach (SearchPattern s in searchPatterns)
            {
                Match match = s.Match(oldName);
                if (match.Success == true)
                {
                    newFormat = newFormat.Insert(newFormat.IndexOf(destinationTag), match.Groups[1].ToString());
                    if (match.Length > 0)
                    {
                        oldName = oldName.Replace(match.ToString(), string.Empty);
                    }
                    break;
                }
            }
        }
    }
}