namespace UniformRenamer.Core
{
    using System;
    using System.IO;
    using System.Text;
    using System.Globalization;
    using SourceGrid;

    static class RuleFactory
    {
        public static RuleList ParseRule(string newFormat, RuleGrid grid)
        {
            
            // format string
            RuleList rules = new RuleList(newFormat); ;

            string[] searchPatterns;
            for(int r=1;r<grid.RowsCount;r++)
            {
                // rule
                searchPatterns = ((string)grid[r,RuleGrid.PatternCol].Value).Split('\t');
                if (grid[r,RuleGrid.TypeCol].Value.Equals("Copy"))
                //Copy Rule
                {
                    rules.Add(new CopyRule((String)grid[r, RuleGrid.DestinationCol].Value, searchPatterns));
                }
                else if (grid[r, RuleGrid.TypeCol].Value.Equals("Delete"))
                //Delete Rule
                {
                    rules.Add(new DeleteRule(searchPatterns));
                }
                else if (grid[r, RuleGrid.TypeCol].Value.Equals("Replace"))
                //Replace Rule
                {
                    rules.Add(new ReplaceRule((String)grid[r, RuleGrid.DestinationCol].Value, (String)grid[r, RuleGrid.ReplacementCol].Value, searchPatterns));
                }
            }

            return rules;
        }
        
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
                if (tokens[0].Equals("copy") || tokens[0].Equals("cpy"))
                //Copy Rule
                {
                    string[] searchPatterns = new string[tokens.Length - 2];
                    Array.Copy(tokens, 2, searchPatterns, 0, searchPatterns.Length);
                    rules.Add(new CopyRule(tokens[1], searchPatterns));
                }
                else if (tokens[0].Equals("delete") || tokens[0].Equals("del"))
                //Delete Rule
                {
                    if (tokens.Length == 1)
                        throw new System.ArgumentException(Textual.ErrorDeleteRule);
                    string[] searchPatterns = new string[tokens.Length - 1];
                    Array.Copy(tokens, 1, searchPatterns, 0, searchPatterns.Length);
                    rules.Add(new DeleteRule(searchPatterns));
                }
                else if (tokens[0].Equals("replace") || tokens[0].Equals("rpl"))
                //Replace Rule
                {
                    if (tokens.Length < 3)
                        throw new System.ArgumentException(Textual.ErrorReplaceRule);
                    string[] searchPatterns = new string[tokens.Length - 2];
                    Array.Copy(tokens, 2, searchPatterns, 0, searchPatterns.Length);
                    rules.Add(new ReplaceRule(tokens[1], tokens[2], searchPatterns));
                }
            }

            return rules;
        }

        private static string CleanRuleText(string text)
        {
            StringBuilder sb = new StringBuilder(String.Empty);
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