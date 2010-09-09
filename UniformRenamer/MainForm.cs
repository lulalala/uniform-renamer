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
    using SourceGrid.Cells.Controllers;

    public partial class MainForm : Form
    {
        private EditorBase oneClickEditor;
        private RuleList rules;
        //Column constant
        private const int FileOldNameCol = 0;
        private const int FileNewNameCol = 1;

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
            SetupRuleGrid();
            SetupFileGrid();

            //ruleTextArea.SelectionTabs = new int[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };

            VersionLabel.Text = String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());

            RuleOpenDialog.FileName = Properties.Settings.Default.LastRulePath;
            if (!RuleOpenDialog.FileName.Equals(String.Empty))
            {
                LoadFile(RuleOpenDialog.FileName);
            }
            TargetDialog.SelectedPath = Properties.Settings.Default.LastTargetPath;
            FillFileGrid(Properties.Settings.Default.LastTargetPath);
        }

        private void SetupRuleGrid()
        {
            var eventsController = new CustomEvents();

            eventsController.EditEnded += delegate(object sender, EventArgs e)
            {
                PreviewRename();
            };

            ruleGrid1.Controller.AddController(eventsController);

            //RuleGrid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch;
            //RuleGrid.AutoSizeCells();
            //RuleGrid.PreviewKeyDown += delegate(object eventSender, PreviewKeyDownEventArgs karg)
            //{
            //    if (karg.KeyCode == Keys.A && karg.Modifiers == Keys.Control)
            //    {
            //        RuleGrid.Selection.SelectRange(new Range(new Position(1, 0), new Position(RuleGrid.RowsCount - 1, FileNewNameCol)), true);
            //    }

            //};
            //cellEditor = SourceGrid.Cells.Editors.Factory.Create(typeof(string));
            //cellEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
        }

        private void EditedHandler(object sender, EventArgs e)
        {
            PreviewRename();
        }

        private void SetupFileGrid()
        {
            FileGrid.Rows.Insert(0);
            FileGrid[0, FileOldNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.FileName);
            FileGrid[0, FileNewNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.NewFileName);
            //ListGrid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch;
            FileGrid.AutoSizeCells();
            FileGrid.PreviewKeyDown += delegate(object eventSender, PreviewKeyDownEventArgs karg)
            {
                if (karg.KeyCode == Keys.A && karg.Modifiers == Keys.Control)
                {
                    FileGrid.Selection.SelectRange(new Range(new Position(1, 0), new Position(FileGrid.RowsCount - 1, FileNewNameCol)), true);
                }

            };
            oneClickEditor = SourceGrid.Cells.Editors.Factory.Create(typeof(string));
            oneClickEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            FileGrid.Focus();
            if (MessageBox.Show(Textual.RenameWarning, String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                for (int i = 0; i < FileGrid.Rows.Count; i++)
                {
                    if (FileGrid.Selection.IsSelectedRow(i))
                    {
                        if (!FileGrid[i, FileOldNameCol].ToString().Equals(FileGrid[i, FileNewNameCol].ToString()))
                        {
                            ((FileName)FileGrid[i, FileOldNameCol].Value).Rename(FileGrid[i, FileNewNameCol].Value.ToString());
                        }
                    }
                }
            }
        }

        private void LoadFile(string path)
        {
            string s = File.ReadAllText(path, Encoding.UTF8);//.Replace("¥", "\\");
            //newFormatTextbox.Text = rules.format;
            //ruleTextArea.Text = s;

            rules = RuleFactory.ParseRule(s);
        }
        private void SaveFile(string path)
        {
            //File.WriteAllText(path, ruleTextArea.Text, Encoding.UTF8);
            DisplayError(Textual.FileSaved);
        }
        // TODO should be private
        private void PreviewRename()
        {
            //if (ruleTextArea.Text.Length == 0)
            //{
            //    return;
            //}
            RuleList rules = RuleFactory.ParseRule(newFormatTextBox.Text, ruleGrid1);

            FileName fn = null;
            for (int i = 1; i < FileGrid.RowsCount; i++)
            {
                fn = (FileName)FileGrid[i, FileOldNameCol].Value;
                string s = rules.Convert(fn.GetRenamableNamePart());

                if (s.Length > 0)
                {
                    if (!fn.IsDirectory())
                    {
                        FileGrid[i, FileNewNameCol].Value = s + fn.GetExtension();
                    }
                    else
                    {
                        FileGrid[i, FileNewNameCol].Value = s;
                    }
                }
                else
                {
                    FileGrid[i, FileNewNameCol].Value = String.Empty;
                }
            }
            FileGrid.AutoSizeCells();
        }


        private void ResetRenameButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FileGrid.Rows.Count; i++)
            {
                FileGrid[i, FileNewNameCol].Value = FileGrid[i, FileOldNameCol].ToString();
            }
        }

        private void RuleNewButton_Click(object sender, EventArgs e)
        {
            //if (ruleTextArea.Text.Length != 0)
            //{
                
            //    //ruleTextArea.Clear();
            //    Properties.Settings.Default.LastRulePath = null;
            //}
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

        private void FillFileGrid(string path)
        {
            if (FileGrid.RowsCount != 1)
            {
                FileGrid.Redim(1, 2);
            }
            if (path.Equals(String.Empty))
                return;

            SetRenameButtonsEnabled(true);
            int r = 1;
            foreach (string s in Directory.GetDirectories(path))
            {
                FileName fs = new FileName(s);

                FileGrid.Rows.Insert(r);
                FileGrid[r, FileOldNameCol] = new SourceGrid.Cells.Cell(fs);
                FileGrid[r, FileNewNameCol] = new SourceGrid.Cells.Cell(fs.ToString(), oneClickEditor);
                r++;
            }
            foreach (string s in Directory.GetFiles(path))
            {
                FileName fs = new FileName(s);

                FileGrid.Rows.Insert(r);
                FileGrid[r, FileOldNameCol] = new SourceGrid.Cells.Cell(fs);
                FileGrid[r, FileNewNameCol] = new SourceGrid.Cells.Cell(fs.ToString(), oneClickEditor);
                r++;
            }
            FileGrid.AutoSizeCells();
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
                FillFileGrid(TargetDialog.SelectedPath);
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

        private void addCopyButton_Click(object sender, EventArgs e)
        {
            ruleGrid1.AddRule(RuleGrid.RuleCopy);
            ruleGrid1.AutoSizeCells();
        }

        private void addDeleteButton_Click(object sender, EventArgs e)
        {
            ruleGrid1.AddRule(RuleGrid.RuleDelete);
            ruleGrid1.AutoSizeCells();
        }

        private void addReplaceButton_Click(object sender, EventArgs e)
        {
            ruleGrid1.AddRule(RuleGrid.RuleReplace);
            ruleGrid1.AutoSizeCells();
        }

        private void newFormatTextBox_TextChanged(object sender, EventArgs e)
        {
            PreviewRename();
        }


    }
}