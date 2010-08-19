namespace UniformRenamer.Core
{
    using System.Text;
    using System.Text.RegularExpressions;
    using System;

    class ReplaceRule : IRule
    {
        private string nameTag;
        private string replacement;
        private string[] targets;

        public ReplaceRule(string name, string replacement, string[] targets)
        {
            this.name = name;
            this.nameTag = name;
            this.replacement = replacement;
            this.targets = targets;
        }

        public string name
        {
            get; set;
        }

        public void Apply(ref string oldName, ref string newFormat)
        {
            bool found = false;
            foreach (string t in targets)
            {
                string searchPattern;
                if (t.StartsWith("* "))
                {
                    searchPattern = t.Substring(2,t.Length-2);
                }
                else
                {
                    searchPattern = Regex.Escape(t);
                }

                if (Regex.IsMatch(oldName,searchPattern))
                {
                    found = true;
                    //Removes the string, to avoid multiple rules mapping the same place.
                    oldName = Regex.Replace(oldName, searchPattern, String.Empty);
                }
            }
            if (found)
            {
                newFormat = newFormat.Replace(nameTag, replacement);
            }
            else
            {
                newFormat = newFormat.Replace(nameTag, string.Empty);
            }
        }
    }
}