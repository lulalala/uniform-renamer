namespace FilenameOrganizer.Processor
{
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;

    class RuleList : List<IRule>
    {
        public RuleList(string format)
        {
            this.format = format;
        }

        public string format
        {
            get;set;
        }

        public string Convert(string FileName)
        {
            StringBuilder newName = new StringBuilder(format);
            StringBuilder oldName = new StringBuilder(FileName);
            foreach (IRule r in this)
            {
                r.Apply(oldName, newName);
            }
            return MakeValidFileName(Regex.Replace(newName.ToString().Trim(), "<[^>]+>", string.Empty));
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]", invalidChars);
            return Regex.Replace(name, invalidReStr, "_");
        }
    }
}