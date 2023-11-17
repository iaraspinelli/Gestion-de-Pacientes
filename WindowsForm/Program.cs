namespace WindowsForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            FormLogin frmLogin = new FormLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK )
            {
                FormPrincipalPacientes frmPrincipal = new FormPrincipalPacientes(frmLogin.UsuarioLogin);

                frmPrincipal.FormClosing += (sender, e) =>
                {
                    frmLogin.Close();
                };

                Application.Run(frmPrincipal);
            }
            else
            {
                frmLogin.Close();
            }
        }
    }
}