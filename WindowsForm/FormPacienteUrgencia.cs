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
    /// Clase public partial que representa un objeto FormPacienteConsultorioUrgencia que hereda del FormPaciente.
    /// </summary>
    public partial class FormPacienteUrgencia : FormPaciente
    {
        #region Atributos
        private PacienteUrgencia pacienteUrgencia;
        #endregion

        #region Propiedades
        public PacienteUrgencia PacienteUrgencia
        {
            get
            {
                return this.pacienteUrgencia;
            }
            set
            {
                this.pacienteUrgencia = value;
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase FormPacienteUrgencia, permite inicializar el componente form y centrarlo en el medio de la pantalla.
        /// </summary>
        public FormPacienteUrgencia()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Constructor que permite inicializar un formulario con un objeto PacienteUrgencia preexistente, que va a permitir modidificar los datos de ese paciente luego.
        /// <param name="pacienteUrgencia">Representa el objeto PacientepacienteUrgencia que se asocia al formulario.</param>
        public FormPacienteUrgencia(PacienteUrgencia pacienteUrgencia) : this()
        {
            base.txtNombre.Text = pacienteUrgencia.Nombre;
            base.txtApellido.Text = pacienteUrgencia.Apellido;
            base.txtEdad.Text = pacienteUrgencia.Edad.ToString();
            base.txtDni.Text = pacienteUrgencia.Dni.ToString();
            base.txtCobertura.Text = pacienteUrgencia.Cobertura;
            this.dateTimeFechaIngreso.Value = pacienteUrgencia.FechaIngreso;
            this.cboEspecialidad.SelectedItem = pacienteUrgencia.EspecialidadUrgencia;
        }
        #endregion

        #region Metodos y eventos

/// <summary>
        /// Maneja el evento de carga del formulario, carga la lista de especialidades disponibles, obteniendo los valores del enum correspondiente. 
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de carga del formulario.</param>
        private void FormPacienteUrgencia_Load(object sender, EventArgs e)
        {
            this.cboEspecialidad.DataSource = Enum.GetValues(typeof(EEspecialidadUrgencia));
        }

        /// <summary>
        ///  Maneja el evento de clic en el botón "Aceptar", creando un objeto PacienteUrgencia si los datos son válidos. 
        /// </summary>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            if (base.CargarFormulario())
            {
                EEspecialidadUrgencia especialidad = (EEspecialidadUrgencia)this.cboEspecialidad.SelectedItem;
                DateTime fechaIngreso = this.dateTimeFechaIngreso.Value;
                this.pacienteUrgencia = new PacienteUrgencia(base.txtNombre.Text, base.txtApellido.Text, int.Parse(base.txtEdad.Text), int.Parse(base.txtDni.Text), base.txtCobertura.Text, fechaIngreso, especialidad)
                    ;
                this.DialogResult = DialogResult.OK;
            }
        }


        #endregion

    }
}
