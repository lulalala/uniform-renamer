namespace FilenameOrganizer.Processor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Globalization;

    static class RuleFactory
    {
        public static RuleList ParseRule(string text)
        {
            StringReader sr = new StringReader(CleanRuleText(text));
            // format string
            RuleList rules = new RuleList(sr.ReadLine()); ;
            
            string[] tokens;
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                // rule
                tokens = s.Split('\t');
                if (tokens[0].StartsWith("reg_"))
                //Regular Expression Rule
                {
                    rules.Add(new RegexRule(tokens[0], tokens[1]));
                }
                else if (tokens[0].Equals("delete"))
                //Delete Rule
                {
                    if (tokens.Length == 1)
                        throw new System.ArgumentException("Delete rule empty");
                    rules.Add(new DeleteRule(new ArraySegment<string>(tokens, 1, tokens.Length - 1).Array));
                }
                else
                //Replace Rule
                {
                    if (tokens.Length < 3)
                        throw new System.ArgumentException("Replace rules need to have at least 3 items delimited by tabs");
                    string[] targets = new string[tokens.Length - 2];
                    Array.Copy(tokens, 2, targets, 0, targets.Length);
                    rules.Add(new ReplaceRule(tokens[0], tokens[1], targets));
                }
            }

            return rules;
        }

        private static string CleanRuleText(string text)
        {
            StringBuilder sb = new StringBuilder("");
            StringReader sr = new StringReader(text);
            string s = null;
            while ((s = sr.ReadLine()) != null)
            {
                s = s.SubstringBefore("//").Trim();
                if (s.Length == 0)
                {
                    continue;
                }
                sb.AppendLine(s);
            }
            return sb.ToString();
        }

        private static string SubstringBefore(this string source, string value)
        {
            //CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            int index = source.IndexOf(value);//compareInfo.IndexOf(source, value, CompareOptions.Ordinal);
            if (index < 0)
            {
                //No such substring
                return source;
            }
            return source.Substring(0, index);
        }

    }
}