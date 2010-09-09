using System.Linq;
using SourceGrid;
using SourceGrid.Cells.Editors;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace UniformRenamer.Core
{
    public class RuleGrid:Grid
    {
        public const int ControlCol = 0;
        public const int TypeCol = 1;
        public const int DestinationCol = 2;
        public const int ReplacementCol = 3;
        public const int PatternCol = 4;

        public const int RuleDelete = 0;
        public const int RuleCopy = 1;
        public const int RuleReplace = 2;

        //private int maxPatternNumber = 1;

        private EditorBase oneClickEditor;
        private PopupMenu popMenu;

        private SourceGrid.Cells.Editors.ComboBox ruleTypeEditor;

        public RuleGrid()
        {
            SelectionMode = SourceGrid.GridSelectionMode.Row;
            //BackColor = System.Drawing.SystemColors.Window;
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           
            ColumnsCount = 5;
            RowsCount = 1;
            FixedRows = 1;

            oneClickEditor = SourceGrid.Cells.Editors.Factory.Create(typeof(string));
            oneClickEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;

            popMenu = new PopupMenu(this);

            this[0, ControlCol] = new SourceGrid.Cells.ColumnHeader();
            this[0, TypeCol] = new SourceGrid.Cells.ColumnHeader("Rule Type");
            this[0, DestinationCol] = new SourceGrid.Cells.ColumnHeader("Destination Nametag");
            this[0, ReplacementCol] = new SourceGrid.Cells.ColumnHeader("Replacement");
            this[0, PatternCol] = new SourceGrid.Cells.ColumnHeader("Target Search Pattern");

            this.Columns[ControlCol].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize;
            this.Columns[PatternCol].AutoSizeMode = SourceGrid.AutoSizeMode.Default;
            //this.Columns[TypeCol].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;
            //this.Columns[PatternCol].AutoSizeMode = SourceGrid.AutoSizeMode.;



            AutoSizeCells();

            ruleTypeEditor = new SourceGrid.Cells.Editors.ComboBox(typeof(string));
            ruleTypeEditor.StandardValues = new string[] { "Delete", "Copy", "Replace" };
            ruleTypeEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick;
            ruleTypeEditor.Control.DropDownStyle = ComboBoxStyle.DropDownList;
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
            if (rule == RuleDelete)
            {
                this[r, TypeCol] = new SourceGrid.Cells.Cell("Delete", ruleTypeEditor);
            }
            if (rule == RuleCopy)
            {
                this[r, TypeCol] = new SourceGrid.Cells.Cell("Copy", ruleTypeEditor);
                this[r, DestinationCol] = new SourceGrid.Cells.Cell(null, oneClickEditor);
                this[r, DestinationCol].AddController(popMenu);
            }
            if (rule == RuleReplace)
            {
                this[r, TypeCol] = new SourceGrid.Cells.Cell("Replace", ruleTypeEditor);
                this[r, ReplacementCol] = new SourceGrid.Cells.Cell(null, oneClickEditor);
                this[r, ReplacementCol].AddController(popMenu);
            }
            this[r, TypeCol].AddController(popMenu);
            this[r, TypeCol].View = SourceGrid.Cells.Views.ComboBox.Default;
            this[r, ControlCol] = new SourceGrid.Cells.CheckBox(null, true);
            this[r, ControlCol].AddController(popMenu);
            this[r, PatternCol] = new SourceGrid.Cells.Cell(null, oneClickEditor);
            this[r, PatternCol].AddController(popMenu);

            AutoSizeCells();
        }

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
            grid.AddRule(RuleGrid.RuleDelete, popupContext.Position.Row);
        }
        private void Replace_Click(object sender, EventArgs e)
        {
            grid.AddRule(RuleGrid.RuleReplace, popupContext.Position.Row);
        }
        private void Copy_Click(object sender, EventArgs e)
        {
            grid.AddRule(RuleGrid.RuleCopy, popupContext.Position.Row);
        }
        private void RemoveRow_Click(object sender, EventArgs e)
        {
            grid.RemoveRule(popupContext.Position.Row);
        }
    }


}
