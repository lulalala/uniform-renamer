namespace UniformRenamer.Core
{
    using System.Text;
    using System.Text.RegularExpressions;
    using System;
    using System.Collections.Generic;

    class ReplaceRule : IRule
    {
        private string nameTag;
        private string replacement;
        private List<SearchPattern> searchPatterns = new List<SearchPattern>();

        public ReplaceRule(string name, string replacement, string[] searchPatterns)
        {
            this.name = name;
            this.nameTag = name;
            this.replacement = replacement;
            foreach (string s in searchPatterns)
            {
                this.searchPatterns.Add(new SearchPattern(s));
            }
        }

        public string name
        {
            get; set;
        }

        public void Apply(ref string oldName, ref string newFormat)
        {
            bool found = false;
            foreach (SearchPattern s in searchPatterns)
            {
                if (s.IsMatch(oldName))
                {
                    found = true;
                    //Removes the string, to avoid multiple rules mapping the same place.
                    oldName = s.Replace(oldName, String.Empty);
                }
            }
            if (found)
            {
                newFormat = newFormat.Replace(nameTag, replacement);
            }
        }
    }
}