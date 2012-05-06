using System;
using System.IO;
using UniformRenamer.Core;
using UniformRenamer.Lang;
using SourceGrid;
using SourceGrid.Cells;

namespace UniformRenamer.UI
{
    class RuleListFactory
    {
        public static RuleList ParseRules(string newFormat, RuleGrid grid)
        {
            // format string
            RuleList rules = new RuleList(newFormat);

            for (int r = grid.FixedRows; r < grid.RowsCount; r++)
            {
                if (!(bool)grid[r, RuleGrid.ColControl].Value)
                    continue;
                if (!grid.CheckRow(r))
                    continue;

                rules.Add(ParseRule(grid.GetCellsAtRow(r)));
            }

            return rules;
        }

        public static IRule ParseRule(ICellVirtual[] iCellVirtualRow)
        {
            Cell[] row = Array.ConvertAll(iCellVirtualRow, item => (Cell)item);

            string[] searchPatterns = ((string)row[RuleGrid.ColPattern].Value).Split('\t');

            if (row[RuleGrid.ColType].Value.Equals("copy"))
            //Copy Rule
            {
                //if (grid.CheckRow(r))
                return new CopyRule((String)row[RuleGrid.ColDestination].Value, searchPatterns);
            }
            else if (row[RuleGrid.ColType].Value.Equals("delete"))
            //Delete Rule
            {
                return new DeleteRule(searchPatterns);
            }
            else if (row[RuleGrid.ColType].Value.Equals("replace"))
            //Replace Rule
            {
                //if (fieldsNotEmpty(grid, r, new int[]{ RuleGrid.ColDestination, RuleGrid.ColReplacement}))
                return new ReplaceRule((String)row[RuleGrid.ColDestination].Value, (String)row[RuleGrid.ColReplacement].Value, searchPatterns);
            }
            return null;
        }
    }
}
