using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase publica que representa un objeto PacienteConsultorioExterno, que podrá ser ingresado a la gestión de pacientes a través de Consultorios Externos.
    /// </summary>
    public class PacienteConsultorioExterno : Paciente
    {
        #region Atributos

        private EEspecialidad especialidad;
        private DateTime fechaTurno;

        #endregion

        #region Propiedades

        public EEspecialidad Especialidad
        {
            get { return this.especialidad; }
            set
            {
                if (value != this.especialidad)
                {
                    this.especialidad = value;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no ha tenido cambios");
                }
            }
        }

        public DateTime FechaTurno
        {
            get
            {
                return this.fechaTurno;
            }
            set
            {
                if (value != this.fechaTurno)
                {
                    this.fechaTurno = value;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no ha tenido cambios");
                }
            }
        }



        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase PacienteConsultorioExterno, necesario para Serializar en XML.
        /// </summary>
        public PacienteConsultorioExterno()
        {
            
        }
        public PacienteConsultorioExterno(string nombre, string apellido, int edad, int dni, string cobertura) : base(nombre, apellido, edad, dni, cobertura)
        {
            base.Nombre = nombre;
            base.Apellido = apellido;
            base.Edad = edad;
            base.Dni = dni;
            base.Cobertura = cobertura;
            this.especialidad = EEspecialidad.Clínica;
            this.fechaTurno = DateTime.Now;
        }

        public PacienteConsultorioExterno(string nombre, string apellido, int edad, int dni, string cobertura, DateTime fechaTurno) : this(nombre, apellido, edad, dni, cobertura)
        {
            this.fechaTurno = fechaTurno;
        }

        /// <summary>
        /// Último constructor sobrecargado de la clase PacienteConsultorioExterno
        /// </summary>
        /// <param name="nombre">Objeto de tipo string referente al nombre del paciente.</param>
        /// <param name="apellido">Objeto de tipo string referente al apellido del paciente.</param>
        /// <param name="edad">Objeto de tipo int referente a la edad del paciente.</param>
        /// <param name="dni">Objeto de tipo int referente al dni del paciente.</param>
        /// <param name="cobertura">Objeto de tipo string referente a la cobertura del paciente.</param>
        /// <param name="fechaTurno">Objeto de tipo DateTime referente a la fecha de turno del paciente.</param>
        /// <param name="especialidad">Objeto de tipo enum referente a la especialidad médica del turno del paciente.</param>
        public PacienteConsultorioExterno(string nombre, string apellido, int edad, int dni, string cobertura, DateTime fechaTurno, EEspecialidad especialidad) : this(nombre, apellido, edad, dni, cobertura, fechaTurno)
        {
            this.especialidad = especialidad;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos del paciente de acuerdo a los datos completados y seleccionados por el usuario en el formPacienteConsultorioExterno. Este método está sobrescrito a partir del mismo método con virtual en la clase base.
        /// </summary>
        /// <returns>Retorna un string con los datos base del pacienteingresado por Consultorios Externos.</returns>
        protected override string MostrarDatosPaciente()
        {
            StringBuilder datosPaciente = new StringBuilder();

            datosPaciente.Append("Paciente Consultorios Externos - ");
            datosPaciente.Append(base.MostrarDatosPaciente());
            

            return datosPaciente.ToString();
        }

        /// <summary>
        /// Sobrescribe el método asbtracto de la clase base, muestra el detalle de todos los datos del paciente ingresado por Consultorio Externo.
        /// </summary>
        /// <returns>Retorna un string con cierto formato, indicando el detalle de la información del paciente.</returns>
        public override string MostrarDetallesPaciente()
        {
            string detallesPaciente = $"Datos detallados del paciente {base.Nombre.ToUpper()} {base.Apellido.ToUpper()}\n" +
                $"Edad: {base.Edad}\n" +
                $"DNI: {base.Dni}\n" +
                $"Cobertura: {base.Cobertura}\n" +
                $"Fecha de Turno: {this.fechaTurno.ToString("yyyy-MM-dd HH:mm")}\n" +
                $"Especialidad de Turno: {this.especialidad}\n";
            return detallesPaciente;
        }

        /// <summary>
        ///  Sobreescribe el ToString(), devuelve una representación en forma de cadena string del objeto actual.
        /// </summary>
        /// <returns>Retorna una cadena que representa los datos del paciente ingresado por Consultorio Externo.</returns>
        public override string ToString()
        {
            return this.MostrarDatosPaciente();
        }

        /// <summary>
        /// Sobreescribe el Equals() para permitir la comparación entre el objeto actual y el objeto indicado de la clase PacienteConsultorioExterno.
        /// </summary>
        /// <param name="obj">Representa un objeto de cualquier tipo que se va a comparar con el objeto actual.</param>
        /// <returns>Retorna true si el objeto es de tipo PacienteConsultorioExterno y si es igual al objeto actual.</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is PacienteConsultorioExterno)
            {
                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Comprueba si dos objetos de la clase PacienteConsultorioExterno son iguales en base a su nombre y DNI, gracias a la sobrecarga del operador ==.
        /// </summary>
        /// <param name="pacienteCons1">Representa el primer objeto PacienteConsultorioExterno a comparar.</param>
        /// <param name="pacienteCons2">Representa el segundo objeto PacienteConsultorioExterno a comparar.</param>
        /// <returns>Retorna true si los objetos PacientePacienteConsultorioExterno son iguales.</returns>
        public static bool operator ==(PacienteConsultorioExterno pacienteCons1, PacienteConsultorioExterno pacienteCons2)
        {
            bool rta = false;

            if (((object)pacienteCons1) == null && ((object)pacienteCons2) == null)
            {
                rta = true;
            }
            else
            {
                if (((object)pacienteCons1) != null && ((object)pacienteCons2) != null)
                {
                    if (pacienteCons1.Id == pacienteCons2.Id && pacienteCons1.Dni == pacienteCons2.Dni)
                    {
                        rta = true;
                    }
                }
            }
            return rta;
        }

        /// <summary>
        /// Comprueba si dos objetos de la clase PacienteConsultorioExterno son distintos en base a su nombre y DNI, gracias a la sobrecarga del operador !=.
        /// </summary>
        /// <param name="pacienteCons1">Representa el primer objeto PacienteConsultorioExterno a comparar.</param>
        /// <param name="pacienteCons2">Representa el segundo objeto PacienteConsultorioExterno a comparar.</param>
        /// <returns>Retorna true si los objetos PacientePacienteConsultorioExterno son distintos.</returns>
        public static bool operator !=(PacienteConsultorioExterno pacienteCons1, PacienteConsultorioExterno pacienteCons2)
        {
            return !(pacienteCons1 == pacienteCons2);
        }

        #endregion

    }
}
