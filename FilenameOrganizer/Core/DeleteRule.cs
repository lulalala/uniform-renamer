namespace UniformRenamer.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class DeleteRule : IRule
    {
        private string[] matches;

        public DeleteRule(string[] matches)
        {
            this.matches = matches;
        }

        public string name
        {
            get; set;
        }

        public void Apply(ref string oldName, ref string newFormat)
        {
            foreach (string s in matches)
            {
                if (s.StartsWith("* "))
                {
                    oldName = Regex.Replace(oldName, s.Substring(2, s.Length - 2), string.Empty);
                }
                else
                {
                    oldName = oldName.Replace(s, string.Empty);
                }
            }
        }
    }
}