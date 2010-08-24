namespace UniformRenamer.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class DeleteRule : IRule
    {
        private List<SearchPattern> searchPatterns = new List<SearchPattern>();

        public DeleteRule(string[] searchPatterns)
        {
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
            foreach (SearchPattern s in searchPatterns)
            {
                oldName = s.Replace(oldName, String.Empty);
            }
        }
    }
}