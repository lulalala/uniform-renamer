using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SourceGrid;
using SourceGrid.Cells;

namespace UniformRenamer.Core
{
    public class FileGrid:Grid
    {
        private IconFetcher fileFetcher;
        private static SourceGrid.Cells.Editors.EditorBase oneClickEditor;

        public const int FileIconCol = 0;
        public const int FileOldNameCol = 1;
        public const int FileNewNameCol = 2;

        public FileGrid()
        {
            //SpecialKeys = GridSpecialKeys.None | GridSpecialKeys.Enter | GridSpecialKeys.Escape | GridSpecialKeys.PageDownUp;
            Rows.Insert(0);

            //AutoStretchColumnsToFitWidth = true;
            BackColor = System.Drawing.SystemColors.Window;
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ColumnsCount = 3;
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
            this[0, FileIconCol] = new SourceGrid.Cells.ColumnHeader();
            this[0, FileOldNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.FileName);
            this[0, FileNewNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.NewFileName);

            //AutoSizeCells();

            Columns[FileIconCol].AutoSizeMode = SourceGrid.AutoSizeMode.None;
            Columns[FileIconCol].Width = 28;
            Columns[FileOldNameCol].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;
            Columns[FileNewNameCol].AutoSizeMode = SourceGrid.AutoSizeMode.MinimumSize | SourceGrid.AutoSizeMode.Default;

            MinimumWidth = 350;
            AutoSizeCells();
            AutoStretchColumnsToFitWidth = true;
            Columns.StretchToFit();

            fileFetcher = new IconFetcher();
        }

        public void Rename()
        {
            if (MessageBox.Show(Textual.RenameWarning, String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                //for (int i = 0; i < Rows.Count; i++)
                //{
                //    if (Selection.IsSelectedRow(i))
                //    {
                //        if (!this[i, FileOldNameCol].ToString().Equals(this[i, FileNewNameCol].ToString()))
                //        {
                //            ICell newNameCell = this[i, FileNewNameCol];
                //            ((FileName)this[i, FileOldNameCol].Value).Rename(newNameCell.Value.ToString());
                //            newNameCell.Controller.OnValueChanged(new CellContext(this, new Position(i,FileNewNameCol), newNameCell), new EventArgs());
                //            this.Refresh();
                //        }
                //    }
                //}
                int[] indexes = Selection.GetSelectionRegion().GetRowsIndex();
/*
                String duplicate_name = null;
                HashSet<String> names = new HashSet<String>();
                foreach (int i in indexes)
                {
                    String name = this[i, FileNewNameCol].ToString();
                    if (!names.Add(name))
                    {
                        duplicate_name = name;
                        break;
                    }
                }

                if (duplicate_name != null)
                {
                    MessageBox.Show( Textual.ErrorDuplicateNewName + "\n" + duplicate_name );
                    throw new Exception( Textual.ErrorDuplicateNewName + " " + duplicate_name );
                }
*/
                FilenameExistsPrompt prompt = null;
                foreach (int i in indexes)
                {
                    if (!this[i, FileOldNameCol].ToString().Equals(this[i, FileNewNameCol].ToString()))
                    {
                        ICell newNameCell = this[i, FileNewNameCol];

                        Boolean is_done = false;
                        while (!is_done)
                        {
                            try
                            {
                                ((FileName)this[i, FileOldNameCol].Value).Rename(newNameCell.Value.ToString());
                                is_done = true;
                            }
                            catch (FileExistsException)
                            {
                                if (prompt == null)
                                {
                                    prompt = new FilenameExistsPrompt(this[i, FileOldNameCol].Value.ToString(), newNameCell.Value.ToString());
                                } else {
                                    prompt.UpdateName(this[i, FileOldNameCol].Value.ToString(), newNameCell.Value.ToString());
                                }

                                switch (prompt.ShowDialog())
                                {
                                    case DialogResult.Cancel:
                                    case DialogResult.Ignore:
                                        is_done = true;
                                        break;
                                    case DialogResult.Retry:
                                        newNameCell.Value = prompt.GetNewName();
                                        break;
                                }
                            }
                        }
                        newNameCell.Controller.OnValueChanged(new CellContext(this, new Position(i, FileNewNameCol), newNameCell), new EventArgs());
                        this.Refresh();
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
                Redim(1, 3);
            }
            if (path.Equals(String.Empty))
                return;

            //SetRenameButtonsEnabled(true);
            FillFileGridRows(Directory.GetDirectories(path), true);
            FillFileGridRows(Directory.GetFiles(path), false);

            AutoSizeCells();
        }

        private void FillFileGridRows(string[] files, bool isDir)
        {
            int r = Rows.Count;
            foreach (string s in files)
            {
                FileName fs = new FileName(s);

                Rows.Insert(r);
                this[r, FileIconCol] = new SourceGrid.Cells.Cell();
                //ORIGINAL: this[r, FileIconCol].Image = System.Drawing.Icon.ExtractAssociatedIcon(fs.GetFilePath()).ToBitmap().GetThumbnailImage(16, 16, null, new IntPtr());
                this[r, FileIconCol].Image = fileFetcher.GetIcon(fs);
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

                sender.Value = FileName.MakeValidFileName(sender.Value.ToString());

                base.OnValueChanged(sender, e);

                if (sender.Value.Equals(sender.Grid.GetCell(sender.Position.Row, FileGrid.FileOldNameCol).ToString()))
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

    public class IconFetcher
    {
        Dictionary<string, System.Drawing.Image> iconList;

        public IconFetcher (){
            iconList = new Dictionary<string, System.Drawing.Image>();
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1;    // 'Small icon

            [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern IntPtr SHGetFileInfoW(string pszPath,
                                        uint dwFileAttributes,
                                        ref SHFILEINFO psfi,
                                        uint cbSizeFileInfo,
                                        uint uFlags);
        }
        //TODO Cache icons
        public System.Drawing.Image GetIcon(FileName filePath)
        {
            String extension;
            if (filePath.IsDirectory())
                extension = "/f"; // Key for folder icon
            else
                extension = Path.GetExtension(filePath.GetFilePath());

            IntPtr hImgSmall;
            SHFILEINFO shinfo = new SHFILEINFO();
            //Use this to get the small Icon
            hImgSmall = Win32.SHGetFileInfoW(filePath.GetFilePath(), 0, ref shinfo,
                                           (uint)Marshal.SizeOf(shinfo),
                                            Win32.SHGFI_ICON |
                                            Win32.SHGFI_SMALLICON);
            
            if(iconList.ContainsKey(extension)){
                return iconList[extension];
            } else {
                System.Drawing.Image icon = System.Drawing.Icon.FromHandle(shinfo.hIcon).ToBitmap().GetThumbnailImage(24, 24, null, new IntPtr());
                iconList.Add(extension, icon);
                return icon;
            }
        }
    }
}
