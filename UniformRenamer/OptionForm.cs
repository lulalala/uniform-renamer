using System;
using System.Windows.Forms;

namespace UniformRenamer
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RemoveBrackets = cbRemoveBrackets.Checked;
            Properties.Settings.Default.RemoveMultipleSpace = cbRemoveMultipleSpace.Checked;
            Properties.Settings.Default.RemoveEndSpace = cbRemoveEndSpace.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RemoveBrackets)
            {
                cbRemoveBrackets.Checked = true;
            }
            if (Properties.Settings.Default.RemoveMultipleSpace)
            {
                cbRemoveMultipleSpace.Checked = true;
            }
            if (Properties.Settings.Default.RemoveEndSpace)
            {
                cbRemoveEndSpace.Checked = true;
            }
        }
    }
}
