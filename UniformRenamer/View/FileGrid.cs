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
using System.Text.RegularExpressions;

namespace UniformRenamer.Core
{
    public class FileGrid:Grid
    {
        private static SourceGrid.Cells.Editors.EditorBase oneClickEditor;

        private const int FileOldNameCol = 0;
        private const int FileNewNameCol = 1;

        public FileGrid()
        {
            //SpecialKeys = GridSpecialKeys.None | GridSpecialKeys.Enter | GridSpecialKeys.Escape | GridSpecialKeys.PageDownUp;
            Rows.Insert(0);

            //AutoStretchColumnsToFitWidth = true;
            BackColor = System.Drawing.SystemColors.Window;
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ColumnsCount = 2;
            Dock = System.Windows.Forms.DockStyle.Fill;
            EnableSort = false;
            FixedRows = 1;

            //Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSizeView;

            OptimizeMode = CellOptimizeMode.ForRows;
            SelectionMode = GridSelectionMode.Row;
            TabIndex = 2;
            TabStop = true;

            //Cannot set those!
            //this.Location.X = 0;
            //this.Location.Y = 25;
            //Margin.All = 4;
            //Size.Height = 298;
            //Size.Width = 1038;
            
            // Initialise custom editors
            oneClickEditor = SourceGrid.Cells.Editors.Factory.Create(typeof(string));
            oneClickEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;

            PreviewKeyDown += delegate(object eventSender, PreviewKeyDownEventArgs karg)
            {
                if (karg.KeyCode == Keys.A && karg.Modifiers == Keys.Control)
                {
                    Selection.SelectRange(new Range(new Position(1, 0), new Position(RowsCount - 1, FileNewNameCol)), true);
                }

            };

            //Not sure why it does not work here
            //this[0, FileOldNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.FileName);
            //this[0, FileNewNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.NewFileName);

            //AutoSizeCells();

            Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;
            Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;
            MinimumWidth = 300;
            AutoSizeCells();
            AutoStretchColumnsToFitWidth = true;
            Columns.StretchToFit();
        }

        public void Rename()
        {
            if (MessageBox.Show(Textual.RenameWarning, String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                for (int i = 0; i < Rows.Count; i++)
                {
                    if (Selection.IsSelectedRow(i))
                    {
                        if (!this[i, FileOldNameCol].ToString().Equals(this[i, FileNewNameCol].ToString()))
                        {
                            ICell newNameCell = this[i, FileNewNameCol];
                            ((FileName)this[i, FileOldNameCol].Value).Rename(newNameCell.Value.ToString());
                            newNameCell.Controller.OnValueChanged(new CellContext(this, new Position(i,FileNewNameCol), newNameCell), new EventArgs());
                            this.Refresh();
                        }
                    }
                }
            }
        }

        internal void PreviewRename(RuleList rules)
        {
            FileName fn = null;
            for (int i = 1; i < RowsCount; i++)
            {
                fn = (FileName)this[i, FileOldNameCol].Value;
                string newName = rules.Convert(fn.GetRenamableNamePart());

                if (Properties.Settings.Default.RemoveBrackets)
                {
                    newName = newName.Replace("()", String.Empty).Replace("[]", String.Empty).Replace("{}", String.Empty);
                }

                if (Properties.Settings.Default.RemoveMultipleSpace)
                {
                    newName = Regex.Replace(newName, @"\s+", " ");
                }

                if (Properties.Settings.Default.RemoveEndSpace)
                {
                    newName = newName.Trim();
                }


                if (newName.Length > 0)
                {
                    if (!fn.IsDirectory())
                    {
                        this[i, FileNewNameCol].Value = newName + fn.GetExtension();
                    }
                    else
                    {
                        this[i, FileNewNameCol].Value = newName;
                    }
                }
                else
                {
                    this[i, FileNewNameCol].Value = String.Empty;
                }
            }
            AutoSizeCells();
        }

        public void ResetRename()
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                this[i, FileNewNameCol].Value = this[i, FileOldNameCol].ToString();
            }
        }

        public void FillFileGrid(string path)
        {
            if (RowsCount != 1)
            {
                Redim(1, 2);
            }
            if (path.Equals(String.Empty))
                return;

            //SetRenameButtonsEnabled(true);
            FillFileGridRows(Directory.GetDirectories(path));
            FillFileGridRows(Directory.GetFiles(path));

            AutoSizeCells();
        }

        private void FillFileGridRows(string[] files)
        {
            int r = Rows.Count;
            foreach (string s in files)
            {
                FileName fs = new FileName(s);

                Rows.Insert(r);
                this[r, FileOldNameCol] = new SourceGrid.Cells.Cell(fs);
                this[r, FileNewNameCol] = new SourceGrid.Cells.Cell(fs.ToString(), oneClickEditor);
                this[r, FileNewNameCol].AddController(new ValueChangedEvent());
                this[r, FileNewNameCol].Controller.OnValueChanged(new CellContext(this, new Position(r, FileNewNameCol), this[r, FileNewNameCol]), new EventArgs());
                r++;
            }
        }

        private Cell createOneClickCell()
        {
            Cell cell = new SourceGrid.Cells.Cell(String.Empty, oneClickEditor);

            return cell;
        }











        //public void ClearValues()
        //{
        //    if (this.RowsCount > FixedRows)
        //    {
        //        this.Rows.RemoveRange(FixedRows, this.RowsCount - FixedRows);
        //    }
        //}
 
    }

    public class ValueChangedEvent : SourceGrid.Cells.Controllers.ControllerBase
    {
        bool isCalled = false;
        public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
        {
            if (!isCalled)
            {
                isCalled = true;

                sender.Value = MakeValidFileName(sender.Value.ToString());

                base.OnValueChanged(sender, e);

                if (sender.Value.Equals(sender.Grid.GetCell(sender.Position.Row, 0).ToString()))
                {
                    sender.Cell.View = UnchangedCellStyle.Default;
                }
                else
                {
                    sender.Cell.View = ChangedCellStyle.Default;
                }

                isCalled = false;
            }
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]+", invalidChars);
            return Regex.Replace(name, invalidReStr, " ");
        }
    }

    public class ChangedCellStyle : SourceGrid.Cells.Views.Cell
    {
        public new static readonly ChangedCellStyle Default = new ChangedCellStyle();
    }

    public class UnchangedCellStyle : SourceGrid.Cells.Views.Cell
    {
        public new static readonly UnchangedCellStyle Default = new UnchangedCellStyle();
        public UnchangedCellStyle()
        {
            ForeColor = System.Drawing.SystemColors.GrayText;
        }
    }
}
