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

        private static SourceGrid.Cells.Views.IView emptyGray;
        private static SourceGrid.Cells.Views.IView unchangedCellStyle;

        private const int FileOldNameCol = 0;
        private const int FileNewNameCol = 1;

        public FileGrid()
        {
            //SpecialKeys = GridSpecialKeys.None | GridSpecialKeys.Enter | GridSpecialKeys.Escape | GridSpecialKeys.PageDownUp;
            Rows.Insert(0);

            AutoStretchColumnsToFitWidth = true;
            BackColor = System.Drawing.SystemColors.Window;
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ColumnsCount = 2;
            Dock = System.Windows.Forms.DockStyle.Fill;
            EnableSort = false;
            FixedRows = 1;

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

            emptyGray = new SourceGrid.Cells.Views.Cell();
            emptyGray.BackColor = System.Drawing.SystemColors.ControlDark;
            unchangedCellStyle = new SourceGrid.Cells.Views.Cell();
            unchangedCellStyle.ForeColor = System.Drawing.SystemColors.GrayText;

            //Header
            this[0, FileOldNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.FileName);
            this[0, FileNewNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.NewFileName);

            //AutoSizeCells();
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
                            ((FileName)this[i, FileOldNameCol].Value).Rename(this[i, FileNewNameCol].Value.ToString());
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
}
