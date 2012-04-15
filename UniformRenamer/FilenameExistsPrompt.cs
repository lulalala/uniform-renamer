using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UniformRenamer
{
    public partial class FilenameExistsPrompt : Form
    {
        public FilenameExistsPrompt(String oldName, String newName)
        {
            InitializeComponent();
            UpdateName(oldName, newName);
        }

        public void UpdateName(String oldName, String newName)
        {
            oldNameLabel.Text = oldName + " ➡";
            newNameLabel.Text = newName + " " + Textual.AlreadyExists;
            newNameTextBox.Text = newName;
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetNewName()
        {
            return newNameTextBox.Text;
        }

        private void skipButton_Click(object sender, EventArgs e)
        {

        }
    }
}
