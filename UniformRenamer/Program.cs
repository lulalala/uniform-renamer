namespace UniformRenamer
{
    using System;
    using System.Windows.Forms;

    static class Program
    {
        private static MainForm form;
        public static void FormThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            form.DisplayError(e.Exception.Message);
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
            Application.Run(form = new MainForm());
        }
    }
}