namespace FilenameOrganizer.Processor
{
    using System.Text;

    class ReplaceRule : IRule
    {
        private string nameTag;
        private string replacement;
        private string[] targets;

        public ReplaceRule(string name, string replacement, string[] targets)
        {
            this.name = name;
            this.nameTag = "<" + name + ">";
            this.replacement = replacement;
            this.targets = targets;
        }

        public string name
        {
            get; set;
        }

        public void Apply(StringBuilder filename, StringBuilder format)
        {
            string fn = filename.ToString();
            bool found = false;
            foreach (string t in targets)
            {
                if (fn.Contains(t))
                {
                    found = true;
                    //Removes the string, to avoid multiple rules mapping the same place.
                    filename.Replace(t,"");
                }
            }
            if (found)
            {
                format.Replace(nameTag, replacement);
            }
            else
            {
                format.Replace(nameTag, "");
            }
        }
    }
}