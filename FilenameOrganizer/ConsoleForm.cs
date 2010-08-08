namespace FilenameOrganizer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public sealed partial class ConsoleForm : Form
    {
        private static readonly ConsoleForm instance = new ConsoleForm();

        public ConsoleForm()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(ConsoleForm_Closing);
        }

        public static ConsoleForm GetInstance
        {
            get { return instance; }
        }

        private void ConsoleForm_Closing(object sender, CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}