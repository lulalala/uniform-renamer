namespace FilenameOrganizer
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using FilenameOrganizer.Processor;

    using SourceGrid;
    using SourceGrid.Cells.Editors;
    using System.Reflection;

    public partial class MainForm : Form
    {
        private EditorBase cellEditor;
        private RuleList rules;

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastTargetPath = TargetDialog.SelectedPath;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int col = 0;
            //SourceGrid control
            ListGrid.Rows.Insert(0);
            //ListGrid[0, col++] = new SourceGrid.Cells.ColumnHeader(String.Empty);
            ListGrid[0, col++] = new SourceGrid.Cells.ColumnHeader(Textual.FileName);
            //ListGrid[0, col++] = new SourceGrid.Cells.ColumnHeader(String.Empty);
            ListGrid[0, col++] = new SourceGrid.Cells.ColumnHeader(Textual.NewFileName);
            //ListGrid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch;
            ListGrid.AutoSizeCells();
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
                        ((FileName)ListGrid[i, 0].Value).Rename(ListGrid[i, 1].Value.ToString());
                    }
                }
            }
        }

        private void LoadFile(string path)
        {
            string s = File.ReadAllText(path, Encoding.UTF8).Replace("¥", "\\");
            rules = RuleFactory.ParseRule(s);

            //newFormatTextbox.Text = rules.format;
            ruleTextArea.Text = s;
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
                fn = (FileName)ListGrid[i, 0].Value;
                string s = rules.Convert(fn.GetFileNameWithoutExtension());

                if (s.Length > 0)
                    ListGrid[i, 1].Value = s + fn.GetExtension();
                else
                    ListGrid[i, 1].Value = String.Empty;
            }
            ListGrid.AutoSizeCells();
        }


        private void ResetRenameButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListGrid.Rows.Count; i++)
            {
                ListGrid[i, 1].Value = ListGrid[i, 0].ToString();
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
            if (Properties.Settings.Default.LastRulePath == null)
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
            // TODO: modify rules instead of creating a new one
            rules = null;
            rules = RuleFactory.ParseRule(ruleTextArea.Text);
        }

        private void TargetListBoxFill(string path)
        {
            if (ListGrid.RowsCount != 1)
            {
                ListGrid.Rows.RemoveRange(1, ListGrid.RowsCount - 1);
            }
            if (path.Equals(String.Empty))
                return;

            SetRenameButtonsEnabled(true);
            int r = 1;
            foreach (string s in Directory.GetDirectories(path))
            {
                FileName fs = new FileName(s);
                int col = 0;

                ListGrid.Rows.Insert(r);
                ListGrid[r, col++] = new SourceGrid.Cells.Cell(fs);
                ListGrid[r, col++] = new SourceGrid.Cells.Cell(fs.ToString(), cellEditor);
                r++;
            }
            foreach (string s in Directory.GetFiles(path))
            {
                FileName fs = new FileName(s);
                int col = 0;

                ListGrid.Rows.Insert(r);
                ListGrid[r, col++] = new SourceGrid.Cells.Cell(fs);
                ListGrid[r, col++] = new SourceGrid.Cells.Cell(fs.ToString(), cellEditor);
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