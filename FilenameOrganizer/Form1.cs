using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FilenameOrganizer.Processor;
using System.IO;
using SourceGrid;

namespace FilenameOrganizer
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }

        private void test()
        {
            string filename = "[漫畫][中文][作者名]作品名";

            string format = "<author><language><title>";


            string txt = "language\t[中]\t[中文]\t(中文)";
            string[] txtArray = txt.Split('\t');


            List<ReplaceRule> rules = new List<ReplaceRule>();
            rules.Add(new ReplaceRule(txtArray[0], txtArray[1], new ArraySegment<string>(txtArray, 2, txtArray.Length - 2).Array));


            foreach (ReplaceRule r in rules)
            {
                format = r.Apply(filename, format);
            }
            //Form1.ActiveForm.Text = format;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SourceGrid control
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 3;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("");
            grid1[0, 1] = new SourceGrid.Cells.ColumnHeader("File Name");
            grid1[0, 2] = new SourceGrid.Cells.ColumnHeader("New File Name");
            grid1.AutoSizeCells();

            ruleOpenDialog.FileName = Properties.Settings.Default.LastRulePath;
            //if (!ruleOpenDialog.FileName.Equals(""))
            //{
            //    ruleTextArea.LoadFile(ruleOpenDialog.FileName);
            //}
            //targetDialog.SelectedPath = Properties.Settings.Default.LastTargetPath;
            //targetListBoxFill("D:\\temp\\[Comic] sort");//Properties.Settings.Default.LastTargetPath);
            //ruleTextArea.LoadFile("F:\\Temp\\testrule.txt",RichTextBoxStreamType.PlainText);
        }

        private void ruleOpenButton_Click(object sender, EventArgs e)
        {
            if (ruleOpenDialog.ShowDialog() == DialogResult.OK)
            {
                ruleTextArea.LoadFile(ruleOpenDialog.FileName, RichTextBoxStreamType.PlainText);
            }
            Properties.Settings.Default.LastRulePath = ruleOpenDialog.FileName;
        }

        private void ruleSaveAsButton_Click(object sender, EventArgs e)
        {
            if (ruleSaveAsDialog.ShowDialog() == DialogResult.OK)
            {
                ruleTextArea.SaveFile(ruleSaveAsDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void ruleSaveButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LastRulePath != null)
            {
                ruleTextArea.SaveFile(Properties.Settings.Default.LastRulePath, RichTextBoxStreamType.PlainText);
            } else {
                //refactor later
                if (ruleSaveAsDialog.ShowDialog() == DialogResult.OK)
                {
                    ruleTextArea.SaveFile(ruleSaveAsDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void targetSelectButton_Click(object sender, EventArgs e)
        {
            if (targetDialog.ShowDialog() == DialogResult.OK)
            {
                targetListBoxFill(targetDialog.SelectedPath);
            }
        }

        private void targetListBoxFill(string path)
        {
            if (grid1.RowsCount != 1)
            {
                grid1.Rows.RemoveRange(1, grid1.RowsCount - 1);
            }
            if(path.Equals(""))
                return;

            int r=1;
            foreach (string s in Directory.GetDirectories(path))
            {
                grid1.Rows.Insert(r);
                grid1[r, 0] = new SourceGrid.Cells.CheckBox(null, true);
                grid1[r, 1] = new SourceGrid.Cells.Cell(Path.GetFileName(s));
                grid1[r, 2] = new SourceGrid.Cells.Cell(Path.GetFileName(s), typeof(string));
                //grid1.LinkedControls.Add ( new SourceGrid.LinkedControlValue (new TextBox(), new Position(r,2)));
                //grid1[r, 2].ge = Path.GetFileName(s);
                r++;
            }
            foreach (string s in Directory.GetFiles(path))
            {
                grid1.Rows.Insert(r);
                grid1[r, 0] = new SourceGrid.Cells.CheckBox(null, true);
                grid1[r, 1] = new SourceGrid.Cells.Cell(Path.GetFileName(s));
                grid1[r, 2] = new SourceGrid.Cells.Cell(Path.GetFileName(s), typeof(string));
                r++;
            }
            grid1.AutoSizeCells();
        }

        private void targetPrevewRename_Click(object sender, EventArgs e)
        {

            RuleList rules = parseRule(ruleTextArea.Text);

            for (int i = 1; i < grid1.RowsCount; i++)
            {
                string format = rules.format;
                foreach (IRule r in rules)
                {
                    format = r.Apply((string)grid1[i, 1].Value, format);
                }
                grid1[i, 2].Value = format;
            }
            grid1.AutoSizeCells();
        }

        private RuleList parseRule(string text)
        {
            
            StringReader sr = new StringReader(text);
            RuleList rules = new RuleList(sr.ReadLine());
            string[] tokens;
            while (true)
            {
                string s = sr.ReadLine();
                if (s != null)
                {
                    tokens = s.Split('\t');
                    if (tokens[0].StartsWith("reg_"))
                    {
                        rules.Add(new RegexRule(tokens[0],tokens[1]));
                    }
                    else
                    {
                        rules.Add(new ReplaceRule(tokens[0], tokens[1], new ArraySegment<string>(tokens, 2, tokens.Length - 2).Array));
                    }
                }
                else
                    break;
            }
            return rules;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Copy window location to app settings

            //Properties.Settings.Default.WindowLocation = WindowState.`;

            //// Copy window size to app settings

            //if (this.WindowState == FormWindowState.Normal)
            //{
            //    Properties.Settings.Default.WindowSize = this.Size;
            //}
            //else
            //{
            //    Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
            //}
            Properties.Settings.Default.LastTargetPath = targetDialog.SelectedPath;
            Properties.Settings.Default.Save();
        }


    }
}
