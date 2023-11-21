using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    /// <summary>
    /// Clase public partial que representa un objeto FormPacienteHospitalizado que hereda del FormPaciente.
    /// </summary>
    public partial class FormPacienteHospitalizado : FormPaciente
    {
        #region Atributos
        private PacienteHospitalizado pacienteHospitalizado;
        #endregion

        #region Propiedades
        public PacienteHospitalizado PacienteHospitalizado
        {
            get
            {
                return this.pacienteHospitalizado;
            }
            set
            {
                this.pacienteHospitalizado = value;
            }
        }
        #endregion


        #region Constructores

        /// <summary>
        /// Constructor de la clase FormPacienteHospitalizado, permite inicializar el componente form y centrarlo en el medio de la pantalla.
        /// </summary>
        public FormPacienteHospitalizado()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.CampoInvalido += MostrarMensajeCampoInvalido;
        }

        /// <summary>
        /// Constructor que permite inicializar un formulario con un objeto PacienteHospitalizado preexistente, que va a permitir modidificar los datos de ese paciente luego.
        /// <param name="pacienteHospitalizado">Representa el objeto PacientepacienteHospitalizado que se asocia al formulario.</param>
        public FormPacienteHospitalizado(PacienteHospitalizado pacienteHospitalizado) : this()
        {
            this.pacienteHospitalizado = pacienteHospitalizado;
            base.paciente = this.pacienteHospitalizado;
        }

        #endregion


        #region Metodos

        #region Cargar Formulario

        /// <summary>
        /// Maneja el evento de carga del formulario, carga la lista de especialidades disponibles y los datos del pacienteHospitalizado en caso de que no sea null.
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de carga del formulario.</param>
        private void FormPacienteHospitalizado_Load(object sender, EventArgs e)
        {
            if (this.pacienteHospitalizado is not null)
            {
                this.dateTimeFechaIngreso.Value = pacienteHospitalizado.FechaInternacion;
                this.txtNumHabitacion.Text = pacienteHospitalizado.NumeroHabitacion.ToString();
            }

        }

        #endregion


        #region Aceptar
        /// <summary>
        ///  Maneja el evento de clic en el botón "Aceptar", creando un objeto PacienteHospitalizado si los datos son válidos.
        /// </summary>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            if (base.VerificarCamposFormulario())
            {
                int numHab;
                if (int.TryParse(this.txtNumHabitacion.Text, out numHab) && (numHab > 0 && numHab < 11))
                {
                    DateTime fechaIngreso = this.dateTimeFechaIngreso.Value;
                    this.pacienteHospitalizado = new PacienteHospitalizado(base.txtNombre.Text, base.txtApellido.Text, int.Parse(base.txtEdad.Text), int.Parse(base.txtDni.Text), base.txtCobertura.Text, fechaIngreso, int.Parse(this.txtNumHabitacion.Text))
                        ;

                    paciente = this.pacienteHospitalizado;

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MostrarMensajeCampoInvalido("El campo Número Habitación debe contener sólo números entre 1 y 10.");
                }
            }
        }
        #endregion
        
        #endregion

    }
}
