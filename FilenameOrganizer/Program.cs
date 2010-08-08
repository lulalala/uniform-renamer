namespace FilenameOrganizer
{
    using System;
    using System.Windows.Forms;

    static class Program
    {
        private static ConsoleForm consoleForm;

        //static void ExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        //{
        //    try
        //    {
        //        Exception ex = (Exception)e.ExceptionObject;
        //        MessageBox.Show("Whoops! Please contact the developers with the following"
        //              + " information:\n\n" + ex.Message + ex.StackTrace,
        //              "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }
        //    finally
        //    {
        //        Application.Exit();
        //    }
        //}
        public static void FormThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //DialogResult result = DialogResult.Abort;
            try
            {
                //result = MessageBox.Show("Whoops! Please contact the developers with the"
                //  + " following information:\n\n" + e.Exception.Message + e.Exception.StackTrace,
                //  "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                consoleForm = ConsoleForm.GetInstance;
                consoleForm.Show();
                consoleForm.MessageLabel.Text += e.Exception.Message +"\n";
            }
            finally
            {
                //if (result == DialogResult.Abort)
                //{
                //    Application.Exit();
                //}
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(FormThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}