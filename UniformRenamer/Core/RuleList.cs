namespace UniformRenamer.Core
{
    using System.Collections.Generic;
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

        public string Convert(string oldName)
        {
            string newFormat = format.ToString();
            foreach (IRule r in this)
            {
                r.Apply(ref oldName, ref newFormat);
            }
            return MakeValidFileName(Regex.Replace(newFormat.Trim(), "<[^>]+>", string.Empty));
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]", invalidChars);
            return Regex.Replace(name, invalidReStr, "_");
        }
    }
}