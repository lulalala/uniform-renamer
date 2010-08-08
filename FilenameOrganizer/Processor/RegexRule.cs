namespace FilenameOrganizer.Processor
{
    using System.Text;
    using System.Text.RegularExpressions;

    class RegexRule : IRule
    {
        private string nameTag;
        private Regex regex;

        public RegexRule(string name, string regexText)
        {
            this.name = name;
            this.nameTag = "<" + name + ">";
            this.regex = new Regex(regexText);
        }

        public string name
        {
            get; set;
        }

        public void Apply(StringBuilder filename, StringBuilder format)
        {
            Match match = regex.Match(filename.ToString());
            if(match.Success == true)
                format.Replace(nameTag, match.Groups[1].ToString());
            if(match.ToString().Length!=0)
                filename.Replace(match.ToString(),"");
        }
    }
}