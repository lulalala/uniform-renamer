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

        private static SourceGrid.Cells.Editors.EditorBase emptyEditor;
        private static SourceGrid.Cells.Editors.EditorBase readOnlyEditor;
        private static SourceGrid.Cells.Editors.TextBox oneClickEditor;
        private static SourceGrid.Cells.Editors.TextBox oneClickTabEditor;
        //private static SourceGrid.Cells.Editors.ComboBox ruleTypeEditor;
        private static PopupMenu popMenu;

        private static SourceGrid.Cells.Views.IView emptyGray;

        public RuleGrid()
        {
            SelectionMode = SourceGrid.GridSelectionMode.Row;
            BackColor = System.Drawing.SystemColors.Window;
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           
            ColumnsCount = 5;
            RowsCount = 1;
            FixedRows = 2;


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
            this[0, ColControl] = new SourceGrid.Cells.ColumnHeader(String.Empty);
            this[0, ColType] = new SourceGrid.Cells.ColumnHeader("Rule Type");
            this[0, ColDestination] = new SourceGrid.Cells.ColumnHeader("Destination name tag");
            this[0, ColReplacement] = new SourceGrid.Cells.ColumnHeader("Replacement text");
            this[0, ColPattern] = new SourceGrid.Cells.ColumnHeader("Target search pattern (seperated by tab) ('* ' denotes a regular expression)");

            this.Columns[ColControl].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize;
            this.Columns[ColPattern].AutoSizeMode = SourceGrid.AutoSizeMode.Default;
            this.Columns[ColType].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            //this.Columns[ColPattern].AutoSizeMode = SourceGrid.AutoSizeMode.;

            //((SourceGrid.Cells.ColumnHeader)this[0, ColControl]).SortStyle = HeaderSortStyle.None;
            //((SourceGrid.Cells.ColumnHeader)this[0, ColType]).SortStyle = HeaderSortStyle.None;
            //((SourceGrid.Cells.ColumnHeader)this[0, ColDestination]).SortStyle = HeaderSortStyle.None;
            //((SourceGrid.Cells.ColumnHeader)this[0, ColReplacement]).SortStyle = HeaderSortStyle.None;
            //((SourceGrid.Cells.ColumnHeader)this[0, ColPattern]).SortStyle = HeaderSortStyle.None;

            //this.EnableSort = false;

            foreach(int i in new int[]{ColControl, ColType, ColDestination, ColReplacement, ColPattern})
            {
                this[0, i].RemoveController(this[0, i].FindController(typeof(SourceGrid.Cells.Controllers.SortableHeader)));
            }

            AutoSizeCells();
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
            if (rule == Constants.RuleDelete)
            {
                //this[r, ColType] = new SourceGrid.Cells.Cell("Delete", ruleTypeEditor);
                this[r, ColType] = createReadOnlyCell("delete");
                this[r, ColDestination] = createEmptyCell();
                this[r, ColReplacement] = createEmptyCell();
            }
            if (rule == Constants.RuleCopy)
            {
                //this[r, ColType] = new SourceGrid.Cells.Cell("Copy", ruleTypeEditor);
                this[r, ColType] = createReadOnlyCell("copy");
                this[r, ColDestination] = createOneClickCell();
                this[r, ColReplacement] = createEmptyCell();
            }
            if (rule == Constants.RuleReplace)
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

            SourceGrid.GridSpecialKeys specialKeys = SourceGrid.GridSpecialKeys.None;
            //specialKeys = specialKeys | SourceGrid.GridSpecialKeys.Tab;
            this.SpecialKeys = specialKeys;

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
            for (int i = 1; i < this.RowsCount; i++)
            {
                for (int j = 1; j <= ColPattern; j++)
                {
                    if(this[i,j].Value != null)
                    {
                        sb.Append(this[i,j].Value);
                        sb.Append('\t');
                    }
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public void Parse(string text)
        {
            try
            {
                this.Rows.RemoveRange(1, this.RowsCount - 1);
            }
            catch { }

            StringReader sr = new StringReader(text);
            // discard format string
            sr.ReadLine();

            string[] tokens;
            string s;
            int i = 0;
            while ((s = sr.ReadLine()) != null)
            {
                // rule
                tokens = s.Split('\t');
                if (tokens[0].Equals("copy") || tokens[0].Equals("cpy"))
                //Copy Rule
                {
                    AddRule(Constants.RuleCopy);
                    i++;
                    this[i, ColDestination].Value = tokens[1];
                    this[i, ColPattern].Value = s.Substring(Helper.GetNthIndex(s, '\t', 2) + 1);
                }
                else if (tokens[0].Equals("delete") || tokens[0].Equals("del"))
                //Delete Rule
                {
                    AddRule(Constants.RuleDelete);
                    i++;
                    this[i, ColPattern].Value = s.Substring(Helper.GetNthIndex(s, '\t', 1) + 1);
                }
                else if (tokens[0].Equals("replace") || tokens[0].Equals("rpl"))
                //Replace Rule
                {
                    AddRule(Constants.RuleReplace);
                    i++;
                    this[i, ColDestination].Value = tokens[1];
                    this[i, ColReplacement].Value = tokens[2];
                    this[i, ColPattern].Value = s.Substring(Helper.GetNthIndex(s, '\t', 3) + 1);
                }
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
            menu.MenuItems.Add("Insert Delete Rule", new EventHandler(Delete_Click));
            menu.MenuItems.Add("Insert Replace Rule", new EventHandler(Replace_Click));
            menu.MenuItems.Add("Insert Copy Rule", new EventHandler(Copy_Click));
            menu.MenuItems.Add("Remove Rule", new EventHandler(RemoveRow_Click));
            this.grid = grid;
        }

        public override void OnMouseUp(SourceGrid.CellContext sender, MouseEventArgs e)
        {
            base.OnMouseUp(sender, e);

            if (e.Button == MouseButtons.Right)
            {
                popupContext = sender;
                menu.Show(sender.Grid, new Point(e.X, e.Y));
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            grid.AddRule(Constants.RuleDelete, popupContext.Position.Row);
        }
        private void Replace_Click(object sender, EventArgs e)
        {
            grid.AddRule(Constants.RuleReplace, popupContext.Position.Row);
        }
        private void Copy_Click(object sender, EventArgs e)
        {
            grid.AddRule(Constants.RuleCopy, popupContext.Position.Row);
        }
        private void RemoveRow_Click(object sender, EventArgs e)
        {
            grid.RemoveRule(popupContext.Position.Row);
        }
        

    }

}
