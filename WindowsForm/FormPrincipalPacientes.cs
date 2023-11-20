﻿using Entidades;
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
        private AccesoClinica accesobd;
        private string ingresoSeleccionado;
        private string tipoOrdenSeleccionado;
        private string maneraOrdenSeleccionado;

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor clase FormPrincipalPacientes, permite inicializar el componente form, centrarlo en el medio de la pantalla, instanciar un objeto Clinica, y guardar en un atributo los datos del usuario logueado correctamente a partir del formLogin.
        /// Establece la visibilidad o invisibilidad de los controles, según el perfil del usuario logueado para restringir sus acciones dentro de la app.
        /// </summary>
        public FormPrincipalPacientes(UsuarioLogin usuarioLogueado)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.accesobd = new();
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

        #region Cargar form y listado pacientes
        /// <summary>
        /// Maneja el evento de carga del formulario principal de pacientes, y obtiene la lista de pacientes desde la base de datos. 
        /// Establece el texto del label lblUsuario con la información del usuario logueado.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de carga del formulario.</param>
        private void FormPrincipalPacientes_Load(object sender, EventArgs e)
        {
            this.lblUsuario.Text = this.usuarioLogueado.ToString();
            if (this.accesobd is not null)
            {
                this.accesobd.ObtenerListaPacientes(listaPacientes.Pacientes, "pacienteUrgencia");
                this.accesobd.ObtenerListaPacientes(listaPacientes.Pacientes, "pacienteConsultorioExterno");
                this.accesobd.ObtenerListaPacientes(listaPacientes.Pacientes, "pacienteHospitalizado");
            }
            this.ActualizarListadoPacientes();

        }

        #endregion


        #region Agregar paciente
        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar", abriendo un formulario específico para agregar un paciente, según el tipo de ingreso seleccionado.
        /// Agrega el paciente a la tabla correspondiente en la base de datos, según el tipo de pacientes, y actualiza el visor del listBox, si la operación del formulario es exitosa.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de clic en el botón "Agregar".</param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboIngresoPaciente.SelectedItem != null)
            {
                this.ingresoSeleccionado = (string)this.cboIngresoPaciente.SelectedItem;

                if (this.accesobd is not null)
                {

                    if (this.ingresoSeleccionado == "Urgencias")
                    {
                        FormPacienteUrgencia formPacienteUrgencia = new FormPacienteUrgencia();
                        formPacienteUrgencia.ShowDialog();

                        if (formPacienteUrgencia.DialogResult == DialogResult.OK)
                        {
                            PacienteUrgencia pacienteUrgencia = formPacienteUrgencia.PacienteUrgencia;

                            if (accesobd.AgregarPaciente(pacienteUrgencia))
                            {
                                this.accesobd.EstablecerId(pacienteUrgencia, "pacienteUrgencia");
                                this.listaPacientes += pacienteUrgencia;
                            }
                        }
                    }
                    else if (this.ingresoSeleccionado == "Consultorios Externos")
                    {
                        FormPacienteConsultorioExterno formPacienteConsultorio = new FormPacienteConsultorioExterno();
                        formPacienteConsultorio.ShowDialog();

                        if (formPacienteConsultorio.DialogResult == DialogResult.OK)
                        {
                            PacienteConsultorioExterno pacienteConsultorioExterno = formPacienteConsultorio.PacienteConsultorioExterno;

                            if (accesobd.AgregarPaciente(pacienteConsultorioExterno))
                            {
                                this.accesobd.EstablecerId(pacienteConsultorioExterno, "pacienteConsultorioExterno");
                                this.listaPacientes += pacienteConsultorioExterno;
                            }
                        }
                    }
                    else if (this.ingresoSeleccionado == "Hospitalización")
                    {
                        FormPacienteHospitalizado formPacienteHospitalizado = new FormPacienteHospitalizado();
                        formPacienteHospitalizado.ShowDialog();

                        if (formPacienteHospitalizado.DialogResult == DialogResult.OK)
                        {
                            PacienteHospitalizado pacienteHospitalizado = formPacienteHospitalizado.PacienteHospitalizado;

                            if (accesobd.AgregarPaciente(pacienteHospitalizado))
                            {
                                this.accesobd.EstablecerId(pacienteHospitalizado, "pacienteHospitalizado");
                                this.listaPacientes += pacienteHospitalizado;
                            }
                        }
                    }
                }
                this.ActualizarListadoPacientes();
            }
            else
            {
                MessageBox.Show("Debe indicar el tipo de ingreso del paciente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion


        #region Modificar paciente
        /// <summary>
        /// Maneja el evento de clic en el botón "Modificar", abriendo un formulario específico para modificar un paciente según el Item seleccionado en el listBox.
        /// Actualiza la información del paciente en la tabla correspondiente en la base de datos, y actualiza el visor del listBox, si la operación del formulario es exitosa.
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de clic en el botón "Modificar".</param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indexSeleccionado = this.lstPacientes.SelectedIndex;
            int id = this.listaPacientes.Pacientes[indexSeleccionado].Id;

            if (indexSeleccionado != -1)
            {

                Paciente paciente = this.listaPacientes.Pacientes[indexSeleccionado];
                List<Paciente> lista = new List<Paciente>(this.listaPacientes.Pacientes);
                lista.Remove(paciente);

                if (this.accesobd is not null)
                {
                    if (this.listaPacientes.Pacientes[indexSeleccionado] is PacienteUrgencia)
                    {
                        FormPacienteUrgencia formPacienteUrgencia = new FormPacienteUrgencia((PacienteUrgencia)paciente);
                        formPacienteUrgencia.ShowDialog();

                        if (formPacienteUrgencia.DialogResult == DialogResult.OK)
                        {
                            PacienteUrgencia pacienteUrgencia = formPacienteUrgencia.PacienteUrgencia;
                            pacienteUrgencia.Id = this.listaPacientes.Pacientes[indexSeleccionado].Id;

                            if (lista == pacienteUrgencia)
                            {
                                if (this.accesobd.ModificarPaciente(pacienteUrgencia, id))
                                {
                                    this.listaPacientes.Pacientes[indexSeleccionado] = pacienteUrgencia;
                                    this.listaPacientes.Pacientes[indexSeleccionado].Id = id;
                                }
                            }
                        }
                    }
                    else if (this.listaPacientes.Pacientes[indexSeleccionado] is PacienteConsultorioExterno)
                    {
                        FormPacienteConsultorioExterno formPacienteConsultorioExterno = new FormPacienteConsultorioExterno((PacienteConsultorioExterno)paciente);
                        formPacienteConsultorioExterno.ShowDialog();

                        if (formPacienteConsultorioExterno.DialogResult == DialogResult.OK)
                        {
                            PacienteConsultorioExterno pacienteConsultorioExterno = formPacienteConsultorioExterno.PacienteConsultorioExterno;
                            pacienteConsultorioExterno.Id = this.listaPacientes.Pacientes[indexSeleccionado].Id;

                            if (lista == pacienteConsultorioExterno)
                            {
                                if (this.accesobd.ModificarPaciente(pacienteConsultorioExterno, id))
                                {
                                    this.listaPacientes.Pacientes[indexSeleccionado] = pacienteConsultorioExterno;
                                    this.listaPacientes.Pacientes[indexSeleccionado].Id = id;
                                }
                            }
                        }

                    }
                    else if (this.listaPacientes.Pacientes[indexSeleccionado] is PacienteHospitalizado)
                    {
                        FormPacienteHospitalizado formPacienteHospitalizado = new FormPacienteHospitalizado((PacienteHospitalizado)paciente);
                        formPacienteHospitalizado.ShowDialog();

                        if (formPacienteHospitalizado.DialogResult == DialogResult.OK)
                        {
                            PacienteHospitalizado pacienteHospitalizado = formPacienteHospitalizado.PacienteHospitalizado;
                            pacienteHospitalizado.Id = this.listaPacientes.Pacientes[indexSeleccionado].Id;

                            if (lista == pacienteHospitalizado)
                            {
                                if (this.accesobd.ModificarPaciente(pacienteHospitalizado, id))
                                {
                                    this.listaPacientes.Pacientes[indexSeleccionado] = pacienteHospitalizado;
                                    this.listaPacientes.Pacientes[indexSeleccionado].Id = id;
                                }
                            }
                        }
                    }
                }

                this.ActualizarListadoPacientes();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region Eliminar Paciente
        /// <summary>
        /// Maneja el evento de clic en el botón "Eliminar", pidiendo confirmación para eliminar un paciente y lo elimina de la tabla correspondiente en el base de datos, y actualiza el listado si se confirma.
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
                    if (this.accesobd is not null)
                    {
                        if (this.accesobd.EliminarPaciente(this.listaPacientes.Pacientes[indexSeleccionado]))
                        {
                            this.listaPacientes.Pacientes.RemoveAt(indexSeleccionado);
                            this.ActualizarListadoPacientes();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún paciente para eliminar.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region Ordenar lista
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


        #endregion


        #region Actualizar lista
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

        #endregion


        #region Mostrar detalles de datos de los pacientes
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

        #endregion


        #region Mostrar historial usuarios
        /// <summary>
        /// Maneja el evento de clic en la etiqueta "Datos de Usuario".
        /// Muestra el formulario de historial de usuarios, en donde se puede ver el historial de usuarios logueados junto con sus datos, que son traidos del archivo "usuarios.log".
        /// </summary>
        /// <param name="sender">Representa el objeto que genera el evento.</param>
        /// <param name="e">Representa los argumentos del evento que proporcionan información sobre el evento de clic esta etiqueta.</param>
        private void lblDatosUsuario_Click(object sender, EventArgs e)
        {
            FormHistorialUsuarios formHistorialUsuarios = new FormHistorialUsuarios();
            formHistorialUsuarios.ShowDialog();
        }
        #endregion


        #region Eventos MouseMove y MouseLeave
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

        #endregion


        #region Cerrar form

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
        }

        #endregion

        #endregion

    }
}
