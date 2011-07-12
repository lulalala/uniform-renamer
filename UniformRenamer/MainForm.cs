namespace UniformRenamer
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    using UniformRenamer.Core;

    using SourceGrid;
    using SourceGrid.Cells.Controllers;

    public partial class MainForm : Form
    {
        private CustomEvents onChangeEventsController;
        private RuleList rules;

        private bool inPreview = false;

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

            //VersionLabel.Text = String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }


        private void SetupRuleGrid()
        {
            onChangeEventsController = new CustomEvents();
            onChangeEventsController.ValueChanged += delegate(object sender, EventArgs e)
            {
                if (inPreview)
                {
                    //need to catch here otherwise SG will catch the exception
                    try
                    {
                        PreviewRename();
                    }
                    catch (Exception ee)
                    {
                        SetStatus(ee.Message);
                    }
                    ruleGrid.AutoSizeCells();
                }
            };
            ruleGrid.AutoStretchColumnsToFitWidth = true;
            ruleGrid.SelectionMode = GridSelectionMode.Row;

            RuleOpenDialog.FileName = Properties.Settings.Default.LastRulePath;
            if (!RuleOpenDialog.FileName.Equals(String.Empty))
            {
                LoadFile(RuleOpenDialog.FileName);
            }

            ruleGrid.Controller.AddController(onChangeEventsController);

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

        private void SetupFileGrid()
        {
            fileGrid.Rows.Insert(0);
            fileGrid[0, FileGrid.FileIconCol] = new SourceGrid.Cells.ColumnHeader();
            fileGrid[0, FileGrid.FileOldNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.FileName);
            fileGrid[0, FileGrid.FileNewNameCol] = new SourceGrid.Cells.ColumnHeader(Textual.NewFileName);

            fileGrid.AutoSizeCells();

            TargetDialog.SelectedPath = Properties.Settings.Default.LastTargetPath;
            FillFileGrid(Properties.Settings.Default.LastTargetPath);
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            fileGrid.Focus();
            fileGrid.Rename();
        }

        private void LoadFile(string path)
        {
            inPreview = false;
            ruleGrid.Controller.RemoveController(onChangeEventsController);

            //Load text to grid
            string s = File.ReadAllText(path, Encoding.UTF8);
            newFormatTextBox.Text = s.Substring(0, s.IndexOf('\n'));
            ruleGrid.Parse(s);

            inPreview = true;
            ruleGrid.Controller.AddController(onChangeEventsController);

            //Load grid to rule
            PreviewRename();

            if (StatusLabel.Text.Length == 0)
            {
                SetStatus(Textual.FileLoaded + ' ' + path);
            }
        }
        private void SaveFile(string path)
        {
            File.WriteAllText(path, newFormatTextBox.Text + '\n' + ruleGrid.ToString(), Encoding.UTF8);
            SetStatus(Textual.FileSaved + ' ' + path);
        }

        // include rules refresh
        private void PreviewRename()
        {
            if (inPreview)
            {
                if (ruleGrid.RowsCount == ruleGrid.FixedRows)
                {
                    return;
                }

                try
                {
                    rules = RuleFactory.ParseRule(newFormatTextBox.Text, ruleGrid);
                }
                catch(Exception e)
                {
                    SetStatus(e.Message);
                }

                PreviewRename(rules);
            }
        }
        private void PreviewRename(RuleList rules)
        {
            fileGrid.PreviewRename(rules);
            SetStatus(String.Empty);
        }


        private void ResetRenameButton_Click(object sender, EventArgs e)
        {
            fileGrid.ResetRename();
        }

        private void RuleNewButton_Click(object sender, EventArgs e)
        {
            ResetRules();
        }

        private void ResetRules()
        {
            //TODO confirmation
            ruleGrid.ClearValues();
            rules = null;
            Properties.Settings.Default.LastRulePath = null;
        }

        private void RuleOpenButton_Click(object sender, EventArgs e)
        {
            if (RuleOpenDialog.ShowDialog() == DialogResult.OK)
            {
                ResetRules();
                LoadFile(RuleOpenDialog.FileName);
                Properties.Settings.Default.LastRulePath = RuleOpenDialog.FileName;
                Properties.Settings.Default.Save();   
            }
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
            if (Properties.Settings.Default.LastRulePath.Length == 0)   //no file path to save yet
            {
                if (RuleSaveAsDialog.ShowDialog() != DialogResult.OK)
                {
                    return; //User cancels save operation
                }
                else
                {
                    Properties.Settings.Default.LastRulePath = RuleSaveAsDialog.FileName;
                    Properties.Settings.Default.Save();
                }
            }
            SaveFile(Properties.Settings.Default.LastRulePath);
        }

        //private void UpdatePreview()
        //{
        //    // TODO: modify rules instead of creating a new one

        //        rules = null;
        //        PreviewRename();
        //}



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

        private void FillFileGrid(string p)
        {
            fileGrid.FillFileGrid(p);
            SetRenameButtonsEnabled(true);
        }

        public void SetStatus(string text)
        {
            StatusLabel.Text = text;
        }

        private void addCopyButton_Click(object sender, EventArgs e)
        {
            ruleGrid.AddRule((int)RuleType.RuleCopy);
            ruleGrid.AutoSizeCells();
        }

        private void addDeleteButton_Click(object sender, EventArgs e)
        {
            ruleGrid.AddRule((int)RuleType.RuleDelete);
            ruleGrid.AutoSizeCells();
        }

        private void addReplaceButton_Click(object sender, EventArgs e)
        {
            ruleGrid.AddRule((int)RuleType.RuleReplace);
            ruleGrid.AutoSizeCells();
        }

        private void newFormatTextBox_TextChanged(object sender, EventArgs e)
        {
            if (rules != null)
            {
                rules.format = ((System.Windows.Forms.TextBox)sender).Text;
                PreviewRename(rules);
            }
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            OptionForm form = new OptionForm();
            form.ShowDialog();
            PreviewRename();
        }
    }
}