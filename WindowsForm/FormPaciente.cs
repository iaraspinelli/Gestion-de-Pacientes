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
    #region Delegados

    public delegate void DelegadoValidarFormulario(string mensaje);

    #endregion

    /// <summary>
    /// Clase public partial que representa un objeto FormPaciente.
    /// </summary>
    public partial class FormPaciente : Form
    {

        #region Atributos
        protected Paciente paciente;
        #endregion


        #region Propiedades
        public Paciente Paciente
        {
            get
            {
                return this.paciente;
            }
            set
            {
                this.paciente = value;
            }
        }
        #endregion


        #region Eventos

        public event DelegadoValidarFormulario CampoInvalido;

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor de la clase FormPaciente, permite inicializar el componente form, centrarlo en el medio de la pantalla.
        /// </summary>
        public FormPaciente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.CampoInvalido += MostrarMensajeCampoInvalido;
        }

        #endregion


        #region Metodos y eventos


        #region Mensaje Evento
        protected void MostrarMensajeCampoInvalido(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion


        #region Cargar formulario
        protected void FormPaciente_Load(object sender, EventArgs e)
        {
            if (this.paciente is not null)
            {
                this.txtNombre.Text = paciente.Nombre;
                this.txtApellido.Text = paciente.Apellido;
                this.txtEdad.Text = paciente.Edad.ToString();
                this.txtDni.Text = paciente.Dni.ToString();
                this.txtCobertura.Text = paciente.Cobertura;
            }
        }

        #endregion


        #region Validaciones de campos
        /// <summary>
        /// Verifica si todos los controles del formulario están completos y si son válidos.
        /// </summary>
        /// <returns>Retorna true si todos los campos están completos y son válidos; sino retorna false.</returns>
        protected bool VerificarCamposFormulario()
        {
            bool camposCompletos = true;
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text == String.Empty)
                    {
                        this.CampoInvalido.Invoke("Debe completar todos los datos correctamente");
                        camposCompletos = false;
                        break;
                    }

                    if (item == this.txtEdad || item == this.txtDni)
                    {
                        if (!(item.Text.All(char.IsDigit)))
                        {
                            this.CampoInvalido.Invoke("Los campos Edad y DNI deben contener solo números.");
                            camposCompletos = false;
                            break;
                        }

                        if (item == this.txtEdad)
                        {
                            int edad = int.Parse(this.txtEdad.Text);
                            if (edad < 0 || edad > 110)
                            {
                                this.CampoInvalido.Invoke("La edad mínima y máxima permitida son 0 y 100 respectivamente.");
                                camposCompletos = false;
                                break;
                            }
                        }

                        if (item == this.txtDni)
                        {
                            int cantidadDigitos = this.txtDni.Text.Length;
                            if (cantidadDigitos < 7 || cantidadDigitos > 8)
                            {
                                this.CampoInvalido.Invoke("Para el DNI sólo se permite ingresar 7 u 8 dígitos.");
                                camposCompletos = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (item.Text.Length > 20)
                        {
                            this.CampoInvalido.Invoke("Para los campos de Nombre, Apellido y Cobertura no se permiten más de 20 caracteres.");
                            camposCompletos = false;
                            break;
                        }
                    }
                }
                if (item is ComboBox && ((ComboBox)item).SelectedItem == null)
                {
                    this.CampoInvalido.Invoke("Debe elegir una especialidad.");
                    camposCompletos = false;
                    break;
                }
            }
            return camposCompletos;
        }

        #endregion


        #region Aceptar
        /// <summary>
        ///  Maneja el evento de clic en el botón "Aceptar", estableciendo el resultado del formulario como "OK".
        /// </summary>
        /// 

        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        #endregion


        #endregion

    }
}
