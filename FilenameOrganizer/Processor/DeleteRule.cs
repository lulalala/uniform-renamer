namespace FilenameOrganizer.Processor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        public void Apply(StringBuilder filename, StringBuilder format)
        {
            foreach (string s in matches)
            {
                filename.Replace(s, "");
            }
        }
    }
}