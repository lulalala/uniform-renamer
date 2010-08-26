namespace UniformRenamer
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using UniformRenamer.Core;

    using SourceGrid;
    using SourceGrid.Cells.Editors;
    using System.Reflection;
    using System.Threading;
    using System.ComponentModel;
    using System.Windows.Threading;

    public partial class MainForm : Form
    {
        private EditorBase cellEditor;
        private RuleList rules;
        //Column constant
        private const int OldFileNameCol = 0;
        private const int NewFileNameCol = 1;

        //private ManualResetEvent delayMSE;
        //private Func<bool> TBDelay;
        //private delegate void ActionToRunWhenUserStopstyping();

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            
            //delayMSE = new ManualResetEvent(false);
            //TBDelay = () => !delayMSE.WaitOne(1500, false);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastTargetPath = TargetDialog.SelectedPath;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SourceGrid control
            ListGrid.Rows.Insert(0);
            ListGrid[0, OldFileNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.FileName);
            ListGrid[0, NewFileNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.NewFileName);
            //ListGrid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch;
            ListGrid.AutoSizeCells();
            ListGrid.PreviewKeyDown += delegate(object eventSender, PreviewKeyDownEventArgs karg)
            {
                if (karg.KeyCode == Keys.A && karg.Modifiers == Keys.Control)
                {
                    ListGrid.Selection.SelectRange(new Range(new Position(1, 0), new Position(ListGrid.RowsCount - 1, NewFileNameCol)), true);
                }

            };
            cellEditor = SourceGrid.Cells.Editors.Factory.Create(typeof(string));
            cellEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;

            ruleTextArea.SelectionTabs = new int[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };

            VersionLabel.Text = String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());

            RuleOpenDialog.FileName = Properties.Settings.Default.LastRulePath;
            if (!RuleOpenDialog.FileName.Equals(String.Empty))
            {
                LoadFile(RuleOpenDialog.FileName);
            }
            TargetDialog.SelectedPath = Properties.Settings.Default.LastTargetPath;
            TargetListBoxFill(Properties.Settings.Default.LastTargetPath);
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            ListGrid.Focus();
            if (MessageBox.Show(Textual.RenameWarning, String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                for (int i = 0; i < ListGrid.Rows.Count; i++)
                {
                    if (ListGrid.Selection.IsSelectedRow(i))
                    {
                        if (!ListGrid[i, OldFileNameCol].ToString().Equals(ListGrid[i, NewFileNameCol].ToString()))
                        {
                            ((FileName)ListGrid[i, OldFileNameCol].Value).Rename(ListGrid[i, NewFileNameCol].Value.ToString());
                        }
                    }
                }
            }
        }

        private void LoadFile(string path)
        {
            string s = File.ReadAllText(path, Encoding.UTF8);//.Replace("¥", "\\");
            //newFormatTextbox.Text = rules.format;
            ruleTextArea.Text = s;

            rules = RuleFactory.ParseRule(s);
        }
        private void SaveFile(string path)
        {
            File.WriteAllText(path, ruleTextArea.Text, Encoding.UTF8);
            DisplayError(Textual.FileSaved);
        }

        private void PreviewRename()
        {
            if (ruleTextArea.Text.Length == 0)
            {
                return;
            }
            RuleList rules = RuleFactory.ParseRule(ruleTextArea.Text);

            FileName fn = null;
            for (int i = 1; i < ListGrid.RowsCount; i++)
            {
                fn = (FileName)ListGrid[i, OldFileNameCol].Value;
                string s = rules.Convert(fn.GetRenamableNamePart());

                if (s.Length > 0)
                {
                    if (!fn.IsDirectory())
                    {
                        ListGrid[i, NewFileNameCol].Value = s + fn.GetExtension();
                    }
                    else
                    {
                        ListGrid[i, NewFileNameCol].Value = s;
                    }
                }
                else
                {
                    ListGrid[i, NewFileNameCol].Value = String.Empty;
                }
            }
            ListGrid.AutoSizeCells();
        }


        private void ResetRenameButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListGrid.Rows.Count; i++)
            {
                ListGrid[i, NewFileNameCol].Value = ListGrid[i, OldFileNameCol].ToString();
            }
        }

        private void RuleNewButton_Click(object sender, EventArgs e)
        {
            if (ruleTextArea.Text.Length != 0)
            {
                
                ruleTextArea.Clear();
                Properties.Settings.Default.LastRulePath = null;
            }
        }

        private void RuleOpenButton_Click(object sender, EventArgs e)
        {
            if (RuleOpenDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFile(RuleOpenDialog.FileName);
            }
            Properties.Settings.Default.LastRulePath = RuleOpenDialog.FileName;
            Properties.Settings.Default.Save();
        }

        private void RuleSaveAsButton_Click(object sender, EventArgs e)
        {
            if (RuleSaveAsDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFile(RuleSaveAsDialog.FileName);
            }
        }

        private void RuleSaveButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LastRulePath.Length == 0)
            {
                if (RuleSaveAsDialog.ShowDialog() != DialogResult.OK)
                {
                    return; //User cancels save operation
                }
                Properties.Settings.Default.LastRulePath = RuleSaveAsDialog.FileName;
            }
            SaveFile(Properties.Settings.Default.LastRulePath);
        }

        private void ruleTextArea_TextChanged(object sender, EventArgs e)
        {
            //delayMSE.Set();

            //// open the ResetEvent gate, to discard these delays    
            //Thread.Sleep(20);
            //// let all pending through the gate    
            //delayMSE.Reset();
            //// close the gate

            //TBDelay.BeginInvoke(res =>
            //{
            //    // callback code        
            //    // check how we exited, via timeout or signal.        
            //    bool timedOut = TBDelay.EndInvoke(res);
            //    if (timedOut)
            //        Dispatcher.CurrentDispatcher.Invoke(
            //            new ActionToRunWhenUserStopstyping(UpdatePreview),
            //            DispatcherPriority.Input);
            //}, null);
            rules = null;
            PreviewRename();
        }

        //private void UpdatePreview()
        //{
        //    // TODO: modify rules instead of creating a new one

        //        rules = null;
        //        PreviewRename();
        //}

        private void TargetListBoxFill(string path)
        {
            if (ListGrid.RowsCount != 1)
            {
                ListGrid.Redim(1, 2);
            }
            if (path.Equals(String.Empty))
                return;

            SetRenameButtonsEnabled(true);
            int r = 1;
            foreach (string s in Directory.GetDirectories(path))
            {
                FileName fs = new FileName(s);

                ListGrid.Rows.Insert(r);
                ListGrid[r, OldFileNameCol] = new SourceGrid.Cells.Cell(fs);
                ListGrid[r, NewFileNameCol] = new SourceGrid.Cells.Cell(fs.ToString(), cellEditor);
                r++;
            }
            foreach (string s in Directory.GetFiles(path))
            {
                FileName fs = new FileName(s);

                ListGrid.Rows.Insert(r);
                ListGrid[r, OldFileNameCol] = new SourceGrid.Cells.Cell(fs);
                ListGrid[r, NewFileNameCol] = new SourceGrid.Cells.Cell(fs.ToString(), cellEditor);
                r++;
            }
            ListGrid.AutoSizeCells();
        }

        private void SetRenameButtonsEnabled(bool b)
        {
            RenamePreviewButton.Enabled = b;
            RenameResetButton.Enabled = b;
            RenameButton.Enabled = b;
        }

        private void TargetPrevewRename_Click(object sender, EventArgs e)
        {
            PreviewRename();
        }

        private void TargetSelectButton_Click(object sender, EventArgs e)
        {
            if (TargetDialog.ShowDialog() == DialogResult.OK)
            {
                TargetListBoxFill(TargetDialog.SelectedPath);
            }
            if (rules != null)
            {
                PreviewRename();
            }
        }

        public void DisplayError(string text)
        {
            ErrorLabel.Text = text;
        }
    }
}