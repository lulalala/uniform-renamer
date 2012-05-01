namespace UniformRenamer.Core
{
    using System;
    using System.IO;
    using UniformRenamer.Lang;

    static class RuleFactory
    {
        //private static bool fieldsNotEmpty(RuleGrid grid, int row, int[] columns)
        //{
        //    foreach (int i in columns)
        //    {
        //        if (((String)grid[row, i].Value) == null)
        //        {
        //            //throw new Exception("Some fields are incomplete.");
        //            return false;
        //        }
        //        if (((String)grid[row, i].Value).Equals(String.Empty))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        
        public static RuleList ParseRule(string text)
        {
            StringReader sr = new StringReader(Helper.CleanRuleText(text));
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
    }
}