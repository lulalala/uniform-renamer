namespace UniformRenamer.Core
{
    using System.Text;
    using System.Text.RegularExpressions;

    class CopyRule : IRule
    {
        private Regex regex;

        public CopyRule(string name, string searchText)
        {
            this.name = name;
            if(searchText.StartsWith("* "))
                this.regex = new Regex(searchText.Substring(2, searchText.Length - 2));
            else
                this.regex = new Regex(Regex.Escape(searchText)); // TODO need to change to string.replace()
        }

        public string name
        {
            get; set;
        }

        public void Apply(ref string oldName, ref string newFormat)
        {
            Match match = regex.Match(oldName);
            if (match.Success == true)
            {
                newFormat = newFormat.Replace(name, match.Groups[1].ToString());
                if (match.Groups[1].ToString().Length > 0)
                    oldName = oldName.Replace(match.ToString(), string.Empty);
            }
        }
    }
}