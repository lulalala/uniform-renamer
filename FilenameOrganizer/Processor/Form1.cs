using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FilenameOrganizer.Processor;
using System.IO;

namespace FilenameOrganizer
{
    public partial class Form1 : Form
    {
        private string rulePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filename = "[漫畫][中文][作者名]作品名";

            string format = "<author><language><title>";


            string txt = "language\t[中]\t[中文]\t(中文)";
            string[] txtArray = txt.Split('\t');


            List<ReplaceRule> rules = new List<ReplaceRule>();
            rules.Add(new ReplaceRule(txtArray[0], txtArray[1], new ArraySegment<string>(txtArray,2,txtArray.Length-2).Array));


            foreach(ReplaceRule r in rules){
                format = r.Apply(filename,format);
            }
            //Form1.ActiveForm.Text = format;
        }

        private void ruleOpenButton_Click(object sender, EventArgs e)
        {
            if (ruleOpenDialog.ShowDialog() == DialogResult.OK)
            {
                ruleTextArea.LoadFile(ruleOpenDialog.FileName, RichTextBoxStreamType.PlainText);
            }
            rulePath = ruleOpenDialog.FileName;
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
            ruleTextArea.SaveFile(rulePath, RichTextBoxStreamType.PlainText);
        }

        private void targetSelectButton_Click(object sender, EventArgs e)
        {
            if (targetDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in Directory.GetDirectories(targetDialog.SelectedPath))
                {
                    targetListBox.Items.Add(s);
                }
                
            }

        }

        private void targetPrevewRename_Click(object sender, EventArgs e)
        {
            foreach (string s in targetListBox.Items)
            {
                
            }
        }

    }
}
