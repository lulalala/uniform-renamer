namespace UniformRenamer.Core
{
    using System;
    using System.IO;
    using UniformRenamer.Lang;

    static class RuleFactory
    {
        public static RuleList ParseRule(string newFormat, RuleGrid grid)
        {
            
            // format string
            RuleList rules = new RuleList(newFormat); ;

            string[] searchPatterns;
            for(int r=grid.FixedRows; r<grid.RowsCount; r++)
            {
                if (!(bool)grid[r, RuleGrid.ColControl].Value)
                    continue;
                if (!grid.CheckRow(r))
                    continue;

                searchPatterns = ((string)grid[r, RuleGrid.ColPattern].Value).Split('\t');

                if (grid[r,RuleGrid.ColType].Value.Equals("copy"))
                //Copy Rule
                {
                    //if (grid.CheckRow(r))
                        rules.Add(new CopyRule((String)grid[r, RuleGrid.ColDestination].Value, searchPatterns));
                }
                else if (grid[r, RuleGrid.ColType].Value.Equals("delete"))
                //Delete Rule
                {
                    rules.Add(new DeleteRule(searchPatterns));
                }
                else if (grid[r, RuleGrid.ColType].Value.Equals("replace"))
                //Replace Rule
                {
                    //if (fieldsNotEmpty(grid, r, new int[]{ RuleGrid.ColDestination, RuleGrid.ColReplacement}))
                        rules.Add(new ReplaceRule((String)grid[r, RuleGrid.ColDestination].Value, (String)grid[r, RuleGrid.ColReplacement].Value, searchPatterns));
                }
            }

            return rules;
        }

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