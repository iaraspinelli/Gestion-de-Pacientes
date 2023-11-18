using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //Para el FileDialog
using System.IO; //Para el Stream
using System.Xml.Serialization; //Para serializar xml
using System.Xml;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace WindowsForm
{
    /// <summary>
    /// Clase public partial que representa un objeto FormPrincipalPacientes, un formulario MDI, que contiene el visor para visualizar la lista de pacientes que se vaya generando. 
    /// </summary>
    public partial class FormPrincipalPacientes : Form
    {
        #region Atributos
        private Clinica<Paciente> listaPacientes;
        private UsuarioLogin usuarioLogueado;
        private string ingresoSeleccionado;
        private string tipoOrdenSeleccionado;
        private string maneraOrdenSeleccionado;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor clase FormPrincipalPacientes, permite inicializar el componente form, centrarlo en el medio de la pantalla, instanciar un objeto Clinica, y guardar en un atributo los datos del usuario logueado correctamente a partir del formLogin.
        /// </summary>
        public FormPrincipalPacientes(UsuarioLogin usuarioLogueado)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.listaPacientes = new Clinica<Paciente>();
            this.usuarioLogueado = usuarioLogueado;

            if (this.usuarioLogueado.perfil == "vendedor")
            {
                this.btnAgregar.Visible = false;
                this.btnModificar.Visible = false;
                this.btnEliminar.Visible = false;
            }
            else if (this.usuarioLogueado.perfil == "supervisor")
            {
                this.btnEliminar.Visible = false;
            }
        }
        #endregion

        #region Metodos y eventos

        /// <summary>
        /// Maneja el evento de carga del formulario principal de pacientes.
        /// Establece el texto del label lblUsuario con la información del usuario logueado.
        /// Muestra un cuadro de diálogo de apertura de archivo (OpenFileDialog) para cargar datos de pacientes solamente desde un archivo XML (patrón de filtro con *.xml).
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de carga del formulario.</param>
        private void FormPrincipalPacientes_Load(object sender, EventArgs e)
        {
            this.lblUsuario.Text = this.usuarioLogueado.ToString();

            /*
            //OpenFileDialog abrirArchivo = new OpenFileDialog();
            //using (abrirArchivo)
            //{
            //    abrirArchivo.Filter = "XML Files (*.xml)|*.xml";
            //    if (abrirArchivo.ShowDialog() == DialogResult.OK)
            //    {
            //        string nombreArchivo = abrirArchivo.FileName;

            //        XmlSerializer srXml = new XmlSerializer(typeof(List<Paciente>));

            //        try
            //        {
            //            using (XmlTextReader lectorXml = new XmlTextReader(nombreArchivo))
            //            {
            //                listaPacientes.Pacientes = (List<Paciente>)srXml.Deserialize(lectorXml);
            //            }
            //            this.ActualizarListadoPacientes();
            //        }
            //        catch (Exception excepcion)
            //        {
            //            MessageBox.Show(excepcion.Message);
            //            this.DialogResult = DialogResult.OK;
            //        }
            //    }
            //    else
            //    {
            //        this.DialogResult = DialogResult.OK;
            //    }
            //}
            */
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar", abriendo un formulario específico para agregar un paciente, según el tipo de ingreso seleccionado.
        /// Agrega el paciente al listado de pacientes y actualiza el visor del listBox, si la operación del formulario es exitosa.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de clic en el botón "Agregar".</param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboIngresoPaciente.SelectedItem != null)
            {
                this.ingresoSeleccionado = (string)this.cboIngresoPaciente.SelectedItem;

                if (this.ingresoSeleccionado == "Urgencias")
                {
                    FormPacienteUrgencia formPacienteUrgencia = new FormPacienteUrgencia();
                    formPacienteUrgencia.ShowDialog();

                    if (formPacienteUrgencia.DialogResult == DialogResult.OK)
                    {
                        this.listaPacientes += formPacienteUrgencia.PacienteUrgencia;
                        this.ActualizarListadoPacientes();
                    }
                }
                else if (this.ingresoSeleccionado == "Consultorios Externos")
                {
                    FormPacienteConsultorioExterno formPacienteConsultorio = new FormPacienteConsultorioExterno();
                    formPacienteConsultorio.ShowDialog();

                    if (formPacienteConsultorio.DialogResult == DialogResult.OK)
                    {
                        this.listaPacientes += formPacienteConsultorio.PacienteConsultorioExterno;
                        this.ActualizarListadoPacientes();
                    }
                }
                else if (this.ingresoSeleccionado == "Hospitalización")
                {
                    FormPacienteHospitalizado formPacienteHospitalizado = new FormPacienteHospitalizado();
                    formPacienteHospitalizado.ShowDialog();

                    if (formPacienteHospitalizado.DialogResult == DialogResult.OK)
                    {
                        this.listaPacientes += formPacienteHospitalizado.PacienteHospitalizado;
                        this.ActualizarListadoPacientes();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe indicar el tipo de ingreso del paciente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Modificar", abriendo un formulario específico para modificar un paciente según el Item seleccionado en el listBox.
        /// Actualiza la información del paciente en el listado si la operación es exitosa.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de clic en el botón "Modificar".</param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indexSeleccionado = this.lstPacientes.SelectedIndex;
            object itemSeleccionado = this.lstPacientes.SelectedItem;

            if (indexSeleccionado != -1)
            {
                if (itemSeleccionado is PacienteUrgencia)
                {
                    PacienteUrgencia pacienteUrgencia = (PacienteUrgencia)this.listaPacientes.Pacientes[lstPacientes.SelectedIndex];

                    FormPacienteUrgencia formPacienteUrgencia = new FormPacienteUrgencia(pacienteUrgencia);
                    formPacienteUrgencia.ShowDialog();

                    if (formPacienteUrgencia.DialogResult == DialogResult.OK)
                    {
                        this.listaPacientes.Pacientes[lstPacientes.SelectedIndex] = formPacienteUrgencia.PacienteUrgencia;
                        this.ActualizarListadoPacientes();
                    }

                }
                else if (itemSeleccionado is PacienteConsultorioExterno)
                {
                    PacienteConsultorioExterno pacienteConsultorioExterno = (PacienteConsultorioExterno)this.listaPacientes.Pacientes[lstPacientes.SelectedIndex];

                    FormPacienteConsultorioExterno formPacienteConsultorioExterno = new FormPacienteConsultorioExterno(pacienteConsultorioExterno);
                    formPacienteConsultorioExterno.ShowDialog();

                    if (formPacienteConsultorioExterno.DialogResult == DialogResult.OK)
                    {
                        this.listaPacientes.Pacientes[lstPacientes.SelectedIndex] = formPacienteConsultorioExterno.PacienteConsultorioExterno;
                        this.ActualizarListadoPacientes();
                    }

                }
                else if (itemSeleccionado is PacienteHospitalizado)
                {
                    PacienteHospitalizado pacienteHospitalizado = (PacienteHospitalizado)this.listaPacientes.Pacientes[lstPacientes.SelectedIndex];

                    FormPacienteHospitalizado formPacienteHospitalizado = new FormPacienteHospitalizado(pacienteHospitalizado);
                    formPacienteHospitalizado.ShowDialog();

                    if (formPacienteHospitalizado.DialogResult == DialogResult.OK)
                    {
                        this.listaPacientes.Pacientes[lstPacientes.SelectedIndex] = formPacienteHospitalizado.PacienteHospitalizado;
                        this.ActualizarListadoPacientes();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Eliminar", pidiendo confirmación para eliminar un paciente y lo elimina del listado si se confirma.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de clic en el botón "Eliminar".</param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indexSeleccionado = this.lstPacientes.SelectedIndex;

            if (indexSeleccionado != -1)
            {
                DialogResult rtaEliminar = MessageBox.Show($"¿Está seguro que desea eliminar el paciente {this.listaPacientes.Pacientes[indexSeleccionado].Nombre.ToUpper()} {this.listaPacientes.Pacientes[indexSeleccionado].Apellido.ToUpper()} con DNI: {this.listaPacientes.Pacientes[indexSeleccionado].Dni}?", "Eliminar", MessageBoxButtons.YesNo);

                if (rtaEliminar == DialogResult.Yes)
                {
                    this.listaPacientes.Pacientes.RemoveAt(indexSeleccionado);
                    this.ActualizarListadoPacientes();
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún paciente para eliminar.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en la etiqueta "Detalles".
        /// Muestra los detalles de un paciente seleccionado si hay un item seleccionado del listBox.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de clic en la etiqueta "Detalles".</param>
        private void lblDetalles_Click(object sender, EventArgs e)
        {
            int indexSeleccionado = this.lstPacientes.SelectedIndex;

            if (indexSeleccionado != -1)
            {
                MessageBox.Show(this.listaPacientes.Pacientes[indexSeleccionado].MostrarDetallesPaciente());
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Ordenar".
        /// Ordena la lista de pacientes según los criterios de orden seleccionados por el usuario en los comboBox correspondientes, a partir de los métodos para el ordenamiento desarrollados en la clase Clinica.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de clic en el botón "Ordenar".</param>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.lstPacientes.Items.Count > 0)
            {
                if (cboOrdenTipo.SelectedItem != null && cboOrdenManera.SelectedItem != null)
                {
                    this.tipoOrdenSeleccionado = (string)this.cboOrdenTipo.SelectedItem;
                    this.maneraOrdenSeleccionado = (string)this.cboOrdenManera.SelectedItem;

                    if (this.tipoOrdenSeleccionado == "Nombre")
                    {
                        if (this.maneraOrdenSeleccionado == "Ascendente")
                        {
                            this.listaPacientes.Pacientes.Sort(Clinica<Paciente>.OrdenarPorNombreAscendente);
                        }
                        else if (this.maneraOrdenSeleccionado == "Descendente")
                        {
                            this.listaPacientes.Pacientes.Sort(Clinica<Paciente>.OrdenarPorNombreDescendente);
                        }
                    }
                    else if (this.tipoOrdenSeleccionado == "DNI")
                    {
                        if (this.maneraOrdenSeleccionado == "Ascendente")
                        {
                            this.listaPacientes.Pacientes.Sort(Clinica<Paciente>.OrdenarPorDniAscendente);
                        }
                        else if (this.maneraOrdenSeleccionado == "Descendente")
                        {
                            this.listaPacientes.Pacientes.Sort(Clinica<Paciente>.OrdenarPorDniDescendente);
                        }
                    }
                    this.ActualizarListadoPacientes();
                }
                else
                {
                    MessageBox.Show("Debe indicar el tipo y la manera de ordenamiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Actualiza el listado de pacientes en el ListBox del formulario.
        /// Limpia la lista actual y agrega cada paciente de la lista de pacientes a la clínica.
        /// </summary>
        private void ActualizarListadoPacientes()
        {
            this.lstPacientes.Items.Clear();
            foreach (Paciente paciente in this.listaPacientes.Pacientes)
            {
                this.lstPacientes.Items.Add(paciente);
            }
        }

        /// <summary>
        /// Maneja el evento de movimiento del mouse sobre la etiqueta "Detalles".
        /// Cambia la fuente y el color del label lblDetalles cuando el mouse se mueve sobre el control.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de movimiento del mouse.</param>
        private void lblDetalles_MouseMove(object sender, MouseEventArgs e)
        {
            this.lblDetalles.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            this.lblDetalles.ForeColor = SystemColors.MenuHighlight;
        }

        /// <summary>
        /// Maneja el evento de salida del mouse de la etiqueta "Detalles".
        /// Restaura la fuente y el color del label lblDetalles cuando el mouse sale del control.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de salida del mouse.</param>
        private void lblDetalles_MouseLeave(object sender, EventArgs e)
        {
            this.lblDetalles.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            this.lblDetalles.ForeColor = SystemColors.ControlText;
        }

        /// <summary>
        /// Maneja el evento de movimiento del mouse sobre la etiqueta "Datos de Usuario".
        /// Cambia la fuente y el color del label lblDatosUsuario cuando el mouse se mueve sobre el control. 
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de movimiento del mouse.</param>
        private void lblDatosUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.lblDatosUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            this.lblDatosUsuario.ForeColor = SystemColors.MenuHighlight;
        }

        /// <summary>
        /// Maneja el evento de movimiento del mouse sobre la etiqueta "Datos de Usuario".
        /// Cambia la fuente y el color del label lblDatosUsuario cuando el mouse sale del control. 
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de salida del mouse.</param>
        private void lblDatosUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.lblDatosUsuario.Font = new Font("Segoe UI", 9F, GraphicsUnit.Point);
            this.lblDatosUsuario.ForeColor = SystemColors.ControlText;
        }

        /// <summary>
        /// Maneja el evento de clic en la etiqueta "Datos de Usuario".
        /// Muestra los datos del usuario logueado correctamente a través del forLogin, en un cuadro de diálogo, si es que encuentra el archivo "usuarios.log".
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de clic esta etiqueta.</param>
        private void lblDatosUsuario_Click(object sender, EventArgs e)
        {
            string pathUsuarioLog = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            pathUsuarioLog += @"\Usuarios";
            Encoding miCodificacion = Encoding.UTF8;

            try
            {
                using (StreamReader lectorUsuario = new StreamReader(pathUsuarioLog + @"\usuarios.log", miCodificacion))
                {
                    MessageBox.Show(lectorUsuario.ReadToEnd());
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message);
            }
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario principal de pacientes, pidiendo confirmación al usuario antes de cerrar la aplicación.
        /// Si se confirma el cierre, permite guardar los datos de la lista de pacientes, solamente en un archivo XML (patrón de filtro con *.xml), a través de la serialización para XML.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de cierre del formulario.</param>
        private void FormPrincipalPacientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rtaCierre = MessageBox.Show("¿Está seguro de que desea cerrar la aplicación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rtaCierre == DialogResult.No)
            {
                e.Cancel = true;
            }
            /*
            //else
            //{
            //    SaveFileDialog guardarArchivo = new SaveFileDialog();
            //    using (guardarArchivo)
            //    {
            //        guardarArchivo.Filter = "XML Files (*.xml)|*.xml";
            //        if (guardarArchivo.ShowDialog() == DialogResult.OK)
            //        {
            //            string nombreArchivo = guardarArchivo.FileName;

            //            XmlSerializer srXml = new XmlSerializer(typeof(List<Paciente>));

            //            using (XmlTextWriter escritorXml = new XmlTextWriter(nombreArchivo, Encoding.UTF8))
            //            {
            //                srXml.Serialize(escritorXml, listaPacientes.Pacientes);
            //            }
            //            this.DialogResult = DialogResult.OK;
            //        }
            //        else
            //        {
            //            e.Cancel = true;
            //        }

            //    }
            //}
            */
        }

        #endregion

    }
}
