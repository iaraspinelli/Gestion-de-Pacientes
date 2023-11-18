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
                FormPrincipalPacientes formPrincipal = new FormPrincipalPacientes(frmLogin.UsuarioLogin);
                formPrincipal.Show();
                Application.Run(formPrincipal);
            }
            else
            {
                Application.Exit();
            }
        }
    }
}