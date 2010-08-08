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

    public partial class MainForm : Form
    {
        private EditorBase cellEditor;

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.Show();
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
            ListGrid[0, 0] = new SourceGrid.Cells.ColumnHeader("File Name");
            ListGrid[0, 1] = new SourceGrid.Cells.ColumnHeader("New File Name");
            ListGrid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch;
            ListGrid.AutoSizeCells();
            cellEditor = SourceGrid.Cells.Editors.Factory.Create(typeof(string));
            cellEditor.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;

            ruleTextArea.SelectionTabs = new int[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };

            RuleOpenDialog.FileName = Properties.Settings.Default.LastRulePath;
            if (!RuleOpenDialog.FileName.Equals(""))
            {
                //ruleTextArea.LoadFile(RuleOpenDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
                LoadFile(RuleOpenDialog.FileName);
            }
            TargetDialog.SelectedPath = Properties.Settings.Default.LastTargetPath;
            TargetListBoxFill(Properties.Settings.Default.LastTargetPath);
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            ListGrid.Focus();
            if (MessageBox.Show("Please doublecheck the renaming. Do you wish to continue renaming process?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
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
            string s = File.ReadAllText(path, Encoding.UTF8);
            ruleTextArea.Text = s;
        }
        private void SaveFile(string path)
        {
            File.WriteAllText(path, ruleTextArea.Text, Encoding.UTF8);
        }

        private void RenamePreview()
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
                    ListGrid[i, 1].Value = "";
            }
            //grid1.AutoSizeCells();
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
                //ruleTextArea.LoadFile(RuleOpenDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
                LoadFile(RuleOpenDialog.FileName);
            }
            Properties.Settings.Default.LastRulePath = RuleOpenDialog.FileName;
            Properties.Settings.Default.Save();
        }

        private void RuleSaveAsButton_Click(object sender, EventArgs e)
        {
            if (RuleSaveAsDialog.ShowDialog() == DialogResult.OK)
            {
                //ruleTextArea.SaveFile(RuleSaveAsDialog.FileName, RichTextBoxStreamType.UnicodePlainText);
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
            //ruleTextArea.SaveFile(Properties.Settings.Default.LastRulePath,RichTextBoxStreamType.UnicodePlainText);
            SaveFile(Properties.Settings.Default.LastRulePath);
        }

        private void ruleTextArea_TextChanged(object sender, EventArgs e)
        {
            ////Highlight every found word from keyWords.

            ////Get the last cursor position in the richTextBox1.
            //int selPos = ruleTextArea.SelectionStart;

            ////For each match from the regex, highlight the word.
            //foreach (Match keyWordMatch in keyword.Matches(ruleTextArea.Text))
            //{
            //    ruleTextArea.Select(keyWordMatch.Index, keyWordMatch.Length);
            //    ruleTextArea.SelectionColor = Color.Blue;
            //    ruleTextArea.SelectionStart = selPos;
            //    ruleTextArea.SelectionColor = Color.Black;
            //    ruleTextArea.DeselectAll();
            //}
        }

        private void TargetListBoxFill(string path)
        {
            if (ListGrid.RowsCount != 1)
            {
                ListGrid.Rows.RemoveRange(1, ListGrid.RowsCount - 1);
            }
            if (path.Equals(""))
                return;

            int r = 1;
            foreach (string s in Directory.GetDirectories(path))
            {
                FileName fs = new FileName(s);
                ListGrid.Rows.Insert(r);
                ListGrid[r, 0] = new SourceGrid.Cells.Cell(fs);
                ListGrid[r, 1] = new SourceGrid.Cells.Cell(fs.ToString(), cellEditor);
                r++;
            }
            foreach (string s in Directory.GetFiles(path))
            {
                FileName fs = new FileName(s);
                ListGrid.Rows.Insert(r);
                ListGrid[r, 0] = new SourceGrid.Cells.Cell(fs);
                ListGrid[r, 1] = new SourceGrid.Cells.Cell(fs.ToString(), cellEditor);
                r++;
            }
            //grid1.AutoSizeCells();
        }

        private void TargetPrevewRename_Click(object sender, EventArgs e)
        {
            RenamePreview();
        }

        private void TargetSelectButton_Click(object sender, EventArgs e)
        {
            if (TargetDialog.ShowDialog() == DialogResult.OK)
            {
                TargetListBoxFill(TargetDialog.SelectedPath);
            }
            if (ruleTextArea.TextLength > 10)
            {
                RenamePreview();
            }
        }
    }
}