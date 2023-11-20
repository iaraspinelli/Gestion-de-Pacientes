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

        #region Constructores

        /// <summary>
        /// Constructor de la clase FormPaciente, permite inicializar el componente form, centrarlo en el medio de la pantalla.
        /// </summary>
        public FormPaciente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Constructor que permite inicializar un formulario con un objeto Paciente preexistente.
        /// Verificar que se haya cargado el formulario con los campos completos antes de proceder.
        /// </summary>
        /// <param name="paciente">Representa el objeto Paciente que se asocia al formulario.</param>
        //public FormPaciente(Paciente paciente) : this()
        //{
        //    if (this.VerificarCamposFormulario())
        //    {
        //        this.paciente = paciente;
        //        this.txtNombre.Text = paciente.Nombre;
        //        this.txtApellido.Text = paciente.Apellido;
        //        this.txtEdad.Text = paciente.Edad.ToString();
        //        this.txtDni.Text = paciente.Dni.ToString();
        //        this.txtCobertura.Text = paciente.Cobertura;
        //    }
        //}

        #endregion

        #region Metodos y eventos

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
                        MessageBox.Show("Debe completar todos los datos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        camposCompletos = false;
                        break;
                    }

                    if (item == this.txtEdad || item == this.txtDni)
                    {
                        if (!(item.Text.All(char.IsDigit)))
                        {
                            MessageBox.Show($"Los campos Edad y DNI deben contener solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            camposCompletos = false;
                            break;
                        }

                        if (item == this.txtEdad)
                        {
                            int edad = int.Parse(this.txtEdad.Text);
                            if (edad < 0 || edad > 110)
                            {
                                MessageBox.Show("La edad mínima y máxima permitida son 0 y 100 respectivamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                camposCompletos = false;
                                break;
                            }
                        }

                        if (item == this.txtDni)
                        {
                            int cantidadDigitos = this.txtDni.Text.Length;
                            if (cantidadDigitos < 7 || cantidadDigitos > 8)
                            {
                                MessageBox.Show("Para el DNI sólo se permite ingresar 7 u 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                camposCompletos = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (item.Text.Length > 20)
                        {
                            MessageBox.Show("Para los campos de Nombre, Apellido y Cobertura no se permiten más de 20 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            camposCompletos = false;
                            break;
                        }
                    }
                }
                if (item is ComboBox && ((ComboBox)item).SelectedItem == null)
                {
                    MessageBox.Show("Debe elegir una especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    camposCompletos = false;
                    break;
                }
            }
            return camposCompletos;
        }

        #endregion


        #region Cargar formulario
        protected void FormPaciente_Load(object sender, EventArgs e)
        {
            if (this.paciente is not null)
            {
                //this.paciente = paciente;
                this.txtNombre.Text = paciente.Nombre;
                this.txtApellido.Text = paciente.Apellido;
                this.txtEdad.Text = paciente.Edad.ToString();
                this.txtDni.Text = paciente.Dni.ToString();
                this.txtCobertura.Text = paciente.Cobertura;
            }
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
