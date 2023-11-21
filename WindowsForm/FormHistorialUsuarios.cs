using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    /// <summary>
    /// Clase parcial que representa el formulario "FormHistorialUsuarios".
    /// Este formulario muestra el historial de usuarios cargado desde el archivo "usuarios.log".
    /// </summary>

    public partial class FormHistorialUsuarios : Form
    {
        public FormHistorialUsuarios()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Cargar formulario con el historial de usuarios
        /// <summary>
        /// Evento que se ejecuta al cargar el formulario "FormHistorialUsuarios".
        /// Carga el historial de usuarios desde el archivo "usuarios.log" y lo muestra en un cuadro de texto, con barras verticales de desplazamiento.
        /// </summary>
        /// <param name="sender">Representa el objeto que generó el evento.</param>
        /// <param name="e">Representa los argumentos del evento.</param>
        /// <exception cref="UsuariosExcepcion">
        /// Se lanza en caso de cualquier error específico relacionado con la carga del historial de usuarios.
        /// Las excepciones específicas que se pueden lanzar son:
        /// - <see cref="DirectoryNotFoundException"/>: El directorio especificado no se encuentra.
        /// - <see cref="Exception"/>: Otras excepciones no manejadas de manera específica.
        /// </exception>
        private void FormHistorialUsuarios_Load(object sender, EventArgs e)
        {

            string pathUsuarioLog = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            pathUsuarioLog += @"\Usuarios";
            Encoding miCodificacion = Encoding.UTF8;
            try
            {
                using (StreamReader lectorUsuario = new StreamReader(pathUsuarioLog + @"\usuarios.log", miCodificacion))
                {
                    this.txtHistorialUsuarios.Text = lectorUsuario.ReadToEnd();
                }
            }
            catch (DirectoryNotFoundException dirNoEncontradoEx)
            {
                throw new UsuariosExcepcion($"Error de directorio no encontrado: {dirNoEncontradoEx.Message}", dirNoEncontradoEx);
            }
            catch (Exception ex)
            {
                throw new UsuariosExcepcion($"Error desconocido: {ex.Message}", ex);
            }
        }
        #endregion
    }
}
