namespace UniformRenamer.Core
{
    using System;
    using System.Collections.Generic;

    class ReplaceRule : IRule
    {
        private string replacement;
        private List<SearchPattern> searchPatterns = new List<SearchPattern>();

        public ReplaceRule(string destinationTag, string replacement, string[] searchPatterns)
        {
            this.destinationTag = destinationTag;
            this.replacement = replacement;
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
                newFormat = newFormat.Insert(newFormat.IndexOf(destinationTag),replacement);
            }
        }
    }
}