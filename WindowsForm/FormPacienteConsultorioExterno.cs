﻿using Entidades;
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
    /// Clase public partial que representa un objeto FormPacienteConsultorioExterno que hereda del FormPaciente.
    /// </summary>
    public partial class FormPacienteConsultorioExterno : FormPaciente
    {
        #region Atributos
        private PacienteConsultorioExterno pacienteConsultorioExterno;
        #endregion

        #region Propiedades

        public PacienteConsultorioExterno PacienteConsultorioExterno
        {
            get
            {
                return this.pacienteConsultorioExterno;
            }
            set
            {
                this.pacienteConsultorioExterno = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase FormPacienteConsultorioExterno, permite inicializar el componente form y centrarlo en el medio de la pantalla.
        /// </summary>
        public FormPacienteConsultorioExterno()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Constructor que permite inicializar un formulario con un objeto PacienteConsultorioExterno preexistente, que va a permitir modidificar los datos de ese paciente luego.
        /// <param name="pacienteConsultorioExterno">Representa el objeto PacientepacienteConsultorioExterno que se asocia al formulario.</param>
        public FormPacienteConsultorioExterno(PacienteConsultorioExterno pacienteConsultorioExterno) : this()
        {
            base.txtNombre.Text = pacienteConsultorioExterno.Nombre;
            base.txtApellido.Text = pacienteConsultorioExterno.Apellido;
            base.txtEdad.Text = pacienteConsultorioExterno.Edad.ToString();
            base.txtDni.Text = pacienteConsultorioExterno.Dni.ToString();
            base.txtCobertura.Text = pacienteConsultorioExterno.Cobertura;
            this.dateTimeFechaTurno.Value = pacienteConsultorioExterno.FechaTurno;
            this.cboEspecialidad.SelectedItem = pacienteConsultorioExterno.Especialidad;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Maneja el evento de carga del formulario, carga la lista de especialidades disponibles, obteniendo los valores del enum correspondiente. 
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de carga del formulario.</param>
        private void FormPacienteConsultorioExterno_Load(object sender, EventArgs e)
        {
            this.cboEspecialidad.DataSource = Enum.GetValues(typeof(EEspecialidad));

        }

        /// <summary>
        ///  Maneja el evento de clic en el botón "Aceptar", creando un objeto PacienteConsultorioExterno si los datos son válidos. 
        /// </summary>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {

            if (base.CargarFormulario())
            {
                EEspecialidad especialidad = (EEspecialidad)this.cboEspecialidad.SelectedItem;
                DateTime fechaTurno = this.dateTimeFechaTurno.Value;
                this.pacienteConsultorioExterno = new PacienteConsultorioExterno(base.txtNombre.Text, base.txtApellido.Text, int.Parse(base.txtEdad.Text), int.Parse(base.txtDni.Text), base.txtCobertura.Text, fechaTurno, especialidad)
                    ;
                this.DialogResult = DialogResult.OK;
            }
        }


        #endregion
    }
}
