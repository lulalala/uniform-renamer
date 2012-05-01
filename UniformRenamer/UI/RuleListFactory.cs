using System;
using System.IO;
using UniformRenamer.Core;
using UniformRenamer.Lang;

namespace UniformRenamer.UI
{
    class RuleListFactory
    {
        public static RuleList ParseRule(string newFormat, RuleGrid grid)
        {
            // format string
            RuleList rules = new RuleList(newFormat);

            string[] searchPatterns;
            for (int r = grid.FixedRows; r < grid.RowsCount; r++)
            {
                if (!(bool)grid[r, RuleGrid.ColControl].Value)
                    continue;
                if (!grid.CheckRow(r))
                    continue;

                searchPatterns = ((string)grid[r, RuleGrid.ColPattern].Value).Split('\t');

                if (grid[r, RuleGrid.ColType].Value.Equals("copy"))
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
    }
}
