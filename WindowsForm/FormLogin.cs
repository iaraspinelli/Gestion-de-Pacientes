using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades;
using System.Text.Json;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace WindowsForm
{

    /// <summary>
    /// Clase public partial que representa un objeto FormLogin, un formulario de inicio de sesión. Al ser partial permite separar el código autogenerado por el designer del Form de la lógica del FormLogin.  
    /// </summary>
    public partial class FormLogin : Form
    {
        #region Atributos
        private UsuarioLogin usuarioLogin;
        private List<UsuarioLogin> listaUsuariosLogin;
        #endregion

        #region Propiedades
        public UsuarioLogin UsuarioLogin
        {
            get { return this.usuarioLogin; }
        }
        #endregion


        #region Constructores

        /// <summary>
        /// Constructor clase FormLogin, permite inicializar el componente form y centrarlo en el medio de la pantalla.
        /// </summary>
        public FormLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.lblBienvenido.Focus();
        }

        #endregion

        #region Metodos y eventos

        /// <summary>
        /// Maneja el evento de carga del formulario de inicio de sesión, que se dispara al cargar este formulario y se encarga de deserializar los datos de los usuarios desde un archivo JSON.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de carga del formulario.</param>
        private void FormLogin_Load(object sender, EventArgs e)
        {
            string pathUsuarios = @"..\..\..\usuariosLogin.json";

            if (File.Exists(pathUsuarios))
            {
                using (StreamReader lectorJson = new StreamReader(pathUsuarios))
                {
                    string json_strUsuarios = lectorJson.ReadToEnd();
                    this.listaUsuariosLogin = JsonSerializer.Deserialize<List<UsuarioLogin>>(json_strUsuarios);
                }
            }
            else
            {
                MessageBox.Show("No se encontro el path del archivo");
                Application.Exit();
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón btnLogin (botón de inicio de sesión), que se dispara cuando el usuario hace clic sobre este botón.
        /// Verifica que el correo y la clave ingresados sean los correctos, para poder ingresar a la aplicación.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioLogin? rtaUsuario = null;
            string correoIngresado = txtCorreo.Text;
            string claveIngresada = txtClave.Text;

            foreach (UsuarioLogin usuarioLogueado in this.listaUsuariosLogin)
            {
                if (usuarioLogueado.correo == correoIngresado && usuarioLogueado.clave == claveIngresada)
                {
                    MessageBox.Show("Los datos de login ingresados son correctos.");
                    this.usuarioLogin = usuarioLogueado;
                    rtaUsuario = usuarioLogueado;
                    bool usuarioVerificado = true;
                    this.GuardarUsuarioLogueado(usuarioVerificado, usuarioLogueado);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                }
            }
            if (rtaUsuario == null)
            {
                MessageBox.Show("Los datos ingresados son incorrectos.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCorreo.Text = string.Empty;
                this.txtClave.Text = string.Empty;

            }
        }

        /// <summary>
        /// Guarda la información del usuario logueado, excepto la clave, en un archivo de registro en el escritorio, solamente si el usuario ha sido verificado previamente.
        /// </summary>
        /// <param name="usuarioVerificado">Representa un bool que indica true si el usuario ha sido verificado con éxito en el evento btnLogin_Click.</param>
        /// <param name="usuarioLogueado">Representa el objeto referente al usuario logueado.</param>
        private void GuardarUsuarioLogueado(bool usuarioVerificado, UsuarioLogin usuarioLogueado)
        {
            if (usuarioVerificado == true)
            {
                Encoding miCodificacion = Encoding.UTF8;
                string pathUsuarioLog = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); 
                pathUsuarioLog += @"\Usuarios";
                StringBuilder datosUsuarioLogueado = new StringBuilder();

                datosUsuarioLogueado.AppendLine($"Apellido: {usuarioLogueado.apellido}");
                datosUsuarioLogueado.AppendLine($"Nombre: {usuarioLogueado.nombre}");
                datosUsuarioLogueado.AppendLine($"Legajo: {usuarioLogueado.legajo}");
                datosUsuarioLogueado.AppendLine($"Correo: {usuarioLogueado.correo}");
                datosUsuarioLogueado.AppendLine($"Perfil: {usuarioLogueado.perfil}");
                datosUsuarioLogueado.AppendLine($"Fecha de login: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                datosUsuarioLogueado.ToString();


                try
                {
                    if (!Directory.Exists(pathUsuarioLog))
                        Directory.CreateDirectory(pathUsuarioLog);

                    using (StreamWriter escritorLogin = new StreamWriter(pathUsuarioLog + @"\usuarios.log", true, miCodificacion))
                    {
                        escritorLogin.WriteLine(datosUsuarioLogueado.ToString());
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        
        #endregion

    }
}
