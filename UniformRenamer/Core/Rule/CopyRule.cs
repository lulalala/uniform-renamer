namespace UniformRenamer.Core
{
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class CopyRule : IRule
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
            foreach (SearchPattern pattern in searchPatterns)
            {
                Match match = pattern.Match(oldName);
                if (match.Success)
                {
                    if (newFormat.IndexOf(destinationTag) != -1) // avoid new format not using this copy rule
                    {
                        // if regex () is not used, match.Groups[1].Value will be empty string
                        string match_text = match.Groups[1].Value.Length == 0 ? match.Value : match.Groups[1].Value;
                        newFormat = newFormat.Insert(newFormat.IndexOf(destinationTag), match_text);
                    }
                    if (match.Length > 0)
                    {
                        oldName = oldName.Replace(match.Value, string.Empty);
                    }
                    break;
                }
            }
        }
    }
}