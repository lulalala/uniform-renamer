using System.Linq;
using SourceGrid;
using SourceGrid.Cells.Editors;
using System.Windows.Forms;
using System;
using System.Drawing;
using SourceGrid.Cells;
using DevAge.Drawing.VisualElements;
using System.Text;
using System.IO;
using DevAge.Drawing;

namespace UniformRenamer.Core
{
    public class RuleGrid:Grid
    {
        public const int ColControl = 0;
        public const int ColType = 1;
        public const int ColDestination = 2;
        public const int ColReplacement = 3;
        public const int ColPattern = 4;

        //public enum Col
        //{
        //    control = 0,
        //    type = 1,
        //    destination = 2,
        //    replacement = 3,
        //    pattern=4
        //}

        private static SourceGrid.Cells.Editors.EditorBase emptyEditor;
        private static SourceGrid.Cells.Editors.EditorBase readOnlyEditor;
        private static SourceGrid.Cells.Editors.TextBox oneClickEditor;
        private static SourceGrid.Cells.Editors.TextBox oneClickTabEditor;
        //private static SourceGrid.Cells.Editors.ComboBox ruleTypeEditor;
        private static PopupMenu popMenu;

        private static SourceGrid.Cells.Views.IView emptyGray;

        public RuleGrid()
        {
            SpecialKeys = GridSpecialKeys.None | GridSpecialKeys.Enter | GridSpecialKeys.Escape | GridSpecialKeys.PageDownUp;
            SelectionMode = SourceGrid.GridSelectionMode.Row;
            BackColor = System.Drawing.SystemColors.Window;
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           
            ColumnsCount = 5;
            RowsCount = 1;
            FixedRows = 1;


            // Initialise custom editors
            oneClickEditor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            oneClickEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick;

            oneClickTabEditor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            oneClickTabEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick;
            oneClickTabEditor.Control.AcceptsReturn = false;
            oneClickTabEditor.Control.AcceptsTab = true;
            oneClickTabEditor.Control.Multiline = true;

            emptyEditor = new EditorBase(typeof(int));
            emptyEditor.EnableEdit = false;

            readOnlyEditor = new EditorBase(typeof(String));
            readOnlyEditor.EnableEdit = false;

            //ruleTypeEditor = new SourceGrid.Cells.Editors.ComboBox(typeof(string));
            //ruleTypeEditor.StandardValues = new string[] { "Delete", "Copy", "Replace" };
            //ruleTypeEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick;
            //ruleTypeEditor.Control.DropDownStyle = ComboBoxStyle.DropDownList;

            emptyGray = new SourceGrid.Cells.Views.Cell();
            emptyGray.BackColor = System.Drawing.SystemColors.ControlDark;

            popMenu = new PopupMenu(this);

            //Header
            this[0, ColControl] = new SourceGrid.Cells.ColumnHeader(Textual.Enabled);
            this[0, ColType] = new SourceGrid.Cells.ColumnHeader(Textual.RuleType);
            this[0, ColDestination] = new SourceGrid.Cells.ColumnHeader(Textual.DestinationTag);
            this[0, ColReplacement] = new SourceGrid.Cells.ColumnHeader(Textual.ReplacementText);
            this[0, ColPattern] = new SourceGrid.Cells.ColumnHeader(Textual.SearchPatterns);

            this.Columns[ColControl].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize;
            this.Columns[ColPattern].AutoSizeMode = SourceGrid.AutoSizeMode.Default;
            this.Columns[ColType].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            //this.Columns[ColPattern].AutoSizeMode = SourceGrid.AutoSizeMode.;

            foreach(int i in new int[]{ColControl, ColType, ColDestination, ColReplacement, ColPattern})
            {
                this[0, i].RemoveController(this[0, i].FindController(typeof(SourceGrid.Cells.Controllers.SortableHeader)));
            }

            AutoSizeCells();
        }

        public bool CheckRow(int row)
        {
            foreach (int i in new int[] { ColType, ColDestination, ColReplacement, ColPattern })
            {
                if (CheckField(row, i) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckField(int row, int column)
        {
            if (this[row, column].Editor != emptyEditor)
            {
                if (((String)this[row, column].Value) == null || ((String)this[row, column].Value).Equals(String.Empty))
                {
                    //throw new Exception("Some fields are incomplete.");
                    return false;
                }
            }
            return true;
        }

        public void AddRule(int rule)
        {
            int r = 0;
            if(!Selection.IsEmpty())
            {
                r = Selection.GetSelectionRegion().GetRowsIndex().Max() + 1;
            }
            if (r == 0)
            {
                r = RowsCount;
            }
            AddRule(rule, r);
        }

        public void AddRule(int rule, int r)
        {
            Rows.Insert(r);
            if (rule == (int)RuleType.RuleDelete)
            {
                //this[r, ColType] = new SourceGrid.Cells.Cell("Delete", ruleTypeEditor);
                this[r, ColType] = createReadOnlyCell("delete");
                this[r, ColDestination] = createEmptyCell();
                this[r, ColReplacement] = createEmptyCell();
            }
            if (rule == (int)RuleType.RuleCopy)
            {
                //this[r, ColType] = new SourceGrid.Cells.Cell("Copy", ruleTypeEditor);
                this[r, ColType] = createReadOnlyCell("copy");
                this[r, ColDestination] = createOneClickCell();
                this[r, ColReplacement] = createEmptyCell();
            }
            if (rule == (int)RuleType.RuleReplace)
            {
                //this[r, ColType] = new SourceGrid.Cells.Cell("Replace", ruleTypeEditor);
                this[r, ColType] = createReadOnlyCell("replace");
                this[r, ColDestination] = createOneClickCell();
                this[r, ColReplacement] = createOneClickCell();
            }
            this[r, ColType].AddController(popMenu);
            //this[r, ColType].View = SourceGrid.Cells.Views.ComboBox.Default;
            this[r, ColControl] = new SourceGrid.Cells.CheckBox(String.Empty, true);
            this[r, ColControl].AddController(popMenu);
            this[r, ColPattern] = createOneClickTabCell();
            //this[r, ColPattern].AddController(new TabKeyEvent());


            AutoSizeCells();
        }

        private Cell createEmptyCell()
        {
            Cell cell = new SourceGrid.Cells.Cell(String.Empty, emptyEditor);
            cell.AddController(popMenu);
            cell.View = emptyGray;
            return cell;
        }

        private Cell createReadOnlyCell(string text)
        {
            Cell cell = new SourceGrid.Cells.Cell(text, readOnlyEditor);
            cell.AddController(popMenu);
            return cell;
        }

        private Cell createOneClickCell()
        {
            Cell cell = new SourceGrid.Cells.Cell(String.Empty, oneClickEditor);
            cell.AddController(popMenu);

            return cell;
        }

        private Cell createOneClickTabCell()
        {
            Cell cell = new SourceGrid.Cells.Cell(String.Empty, oneClickTabEditor);
            cell.AddController(popMenu);

            SourceGrid.Cells.Views.Cell view = cell.View as SourceGrid.Cells.Views.Cell;
            ((TextGDI)view.ElementText).StringFormat.SetTabStops(0.0f, new float[] { 30.0f, 30.0f, 30.0f, 30.0f });

            return cell;
        }

        //bug
        //public RuleGrid()
        //{
        //    FixedRows = 1;
        //    RowsCount = 1;
        //    ColumnsCount = 2;

        //    this[0, 0] = new SourceGrid.Cells.ColumnHeader();
        //    this[0, 1] = new SourceGrid.Cells.ColumnHeader("TEST2");
        //    AutoSizeCells();

        //    Rows.Insert(1);

        //    this[1, 0] = new SourceGrid.Cells.CheckBox();
        //    this[1, 1] = new SourceGrid.Cells.Cell();
        //    //AutoSizeCells();
        //}

        public void RemoveRule(int r)
        {
            this.Rows.Remove(r);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = FixedRows; i < this.RowsCount; i++)
            {
                if (!(bool)this[i, ColControl].Value)
                {
                    sb.Append("//");
                }
                for (int j = 1; j <= ColPattern; j++)
                {
                    if(this[i,j].Value != null)
                    {
                        sb.Append(this[i,j].Value);
                        sb.Append('\t');
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public void Parse(string text)
        {
            ClearValues();

            StringReader sr = new StringReader(text);
            // discard new format string
            sr.ReadLine();

            string[] tokens;
            string s;
            int i = 0;
            while ((s = sr.ReadLine()) != null)
            {
                bool isRuleDisabled = false;
                if (s.StartsWith("//"))
                {
                    s = s.Remove(0, 2);
                    isRuleDisabled = true;
                }

                tokens = s.Split('\t');
                if (tokens[0].Equals("delete"))
                //Delete Rule
                {
                    AddRule((int)RuleType.RuleDelete);
                    i++;
                    this[i, ColPattern].Value = s.Substring(Helper.GetNthIndex(s, '\t', 1) + 1);
                }
                else if (tokens[0].Equals("copy"))
                //Copy Rule
                {
                    AddRule((int)RuleType.RuleCopy);
                    i++;
                    this[i, ColDestination].Value = tokens[1];
                    this[i, ColPattern].Value = s.Substring(Helper.GetNthIndex(s, '\t', 2) + 1);
                }
                else if (tokens[0].Equals("replace"))
                //Replace Rule
                {
                    AddRule((int)RuleType.RuleReplace);
                    i++;
                    this[i, ColDestination].Value = tokens[1];
                    this[i, ColReplacement].Value = tokens[2];
                    this[i, ColPattern].Value = s.Substring(Helper.GetNthIndex(s, '\t', 3) + 1);
                }

                if (isRuleDisabled)
                {
                    this[i, ColControl].Value = false;
                }
            }
        }

        private string CleanPattern(string pattern)
        {
            return pattern.Trim().Replace("\n",String.Empty);
        }

        public void ClearValues()
        {
            if (this.RowsCount > FixedRows)
            {
                this.Rows.RemoveRange(FixedRows, this.RowsCount - FixedRows);
            }
        }
    }

    public class PopupMenu : SourceGrid.Cells.Controllers.ControllerBase
    {
        private RuleGrid grid;
        private ContextMenu menu = new ContextMenu();
        private SourceGrid.CellContext popupContext;

        public PopupMenu(RuleGrid grid)
        {
            menu.MenuItems.Add(Textual.InsertDeleteRule, new EventHandler(Delete_Click));
            menu.MenuItems.Add(Textual.InsertCopyRule, new EventHandler(Copy_Click));
            menu.MenuItems.Add(Textual.InsertReplaceRule, new EventHandler(Replace_Click));
            menu.MenuItems.Add(Textual.RemoveRule, new EventHandler(RemoveRow_Click));
            this.grid = grid;
        }

        public override void OnMouseUp(SourceGrid.CellContext sender, MouseEventArgs e)
        {
            base.OnMouseUp(sender, e);

            if (e.Button == MouseButtons.Right)
            {
                sender.Grid.Selection.ResetSelection(false);
                sender.Grid.Selection.SelectRow(sender.Position.Row, true);
                popupContext = sender;
                menu.Show(sender.Grid, new Point(e.X, e.Y));
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            grid.AddRule((int)RuleType.RuleDelete, popupContext.Position.Row);
        }
        private void Replace_Click(object sender, EventArgs e)
        {
            grid.AddRule((int)RuleType.RuleReplace, popupContext.Position.Row);
        }
        private void Copy_Click(object sender, EventArgs e)
        {
            grid.AddRule((int)RuleType.RuleCopy, popupContext.Position.Row);
        }
        private void RemoveRow_Click(object sender, EventArgs e)
        {
            grid.RemoveRule(popupContext.Position.Row);
        }
        

    }

}
