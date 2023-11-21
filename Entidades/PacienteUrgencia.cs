using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase publica que representa un objeto PacienteUrgencia, que podrá ser ingresado a la gestión de pacientes a través de Urgencias.
    /// </summary>
    public class PacienteUrgencia : Paciente
    {
        #region Atributos

        private EEspecialidadUrgencia especialidadUrgencia;
        private DateTime fechaIngreso;

        #endregion

        #region Propiedades

        public EEspecialidadUrgencia EspecialidadUrgencia
        {
            get { return this.especialidadUrgencia; }
            set
            {
                if (value != this.especialidadUrgencia)
                {
                    this.especialidadUrgencia = value;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no ha tenido cambios");
                }
            }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return this.fechaIngreso;
            }
            set
            {
                if (value != this.fechaIngreso)
                {
                    this.fechaIngreso = value;
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
        /// Constructor por defecto de la clase PacienteUrgencia, necesario para Serializar en XML.
        /// </summary>
        public PacienteUrgencia()
        {

        }

        public PacienteUrgencia(string nombre, string apellido, int edad, int dni, string cobertura) : base(nombre, apellido, edad, dni, cobertura)
        {
            base.Nombre = nombre;
            base.Apellido = apellido;
            base.Edad = edad;
            base.Dni = dni;
            base.Cobertura = cobertura;
            this.fechaIngreso = DateTime.Now;
            this.especialidadUrgencia = EEspecialidadUrgencia.Clínica;
        }

        public PacienteUrgencia(string nombre, string apellido, int edad, int dni, string cobertura, DateTime fechaIngreso) : this(nombre, apellido, edad, dni, cobertura)
        {
            this.fechaIngreso = fechaIngreso;
        }

        /// <summary>
        /// Último constructor sobrecargado de la clase PacienteConsultorioExterno
        /// </summary>
        /// <param name="nombre">Objeto de tipo string referente al nombre del paciente.</param>
        /// <param name="apellido">Objeto de tipo string referente al apellido del paciente.</param>
        /// <param name="edad">Objeto de tipo int referente a la edad del paciente.</param>
        /// <param name="dni">Objeto de tipo int referente al dni del paciente.</param>
        /// <param name="cobertura">Objeto de tipo string referente a la cobertura del paciente.</param>
        /// <param name="fechaIngreso">Objeto de tipo DateTime referente a la fecha de ingreso a la guardia médica.</param>
        /// <param name="especialidadUrgencia">Objeto de tipo enum referente a la especialidad de guardua médica</param>
        public PacienteUrgencia(string nombre, string apellido, int edad, int dni, string cobertura, DateTime fechaIngreso, EEspecialidadUrgencia especialidadUrgencia) : this(nombre, apellido, edad, dni, cobertura, fechaIngreso)
        {
            this.especialidadUrgencia = especialidadUrgencia;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos del paciente de acuerdo a los datos completados y seleccionados por el usuario en el formPacienteUrgencia. Este método está sobrescrito a partir del mismo método con virtual en la clase base.
        /// </summary>
        /// <returns>Retorna un string con los datos base del pacienteingresado por Urgencias.</returns>
        protected override string MostrarDatosPaciente()
        {
            StringBuilder datosPaciente = new StringBuilder();

            datosPaciente.AppendLine("Paciente Urgencias - ");
            datosPaciente.Append(base.MostrarDatosPaciente());

            return datosPaciente.ToString();
        }

        /// <summary>
        /// Sobrescribe el método asbtracto de la clase base, muestra el detalle de todos los datos del paciente ingresado por Urgencias.
        /// </summary>
        /// <returns>Retorna un string con cierto formato, indicando el detalle de la información del paciente.</returns>
        public override string MostrarDetallesPaciente()
        {
            string detallesPaciente = $"Datos detallados del paciente {base.Nombre.ToUpper()} {base.Apellido.ToUpper()}\n" +
                $"Edad: {base.Edad}\n" +
                $"DNI: {base.Dni}\n" +
                $"Cobertura: {base.Cobertura}\n" +
                $"Fecha de ingreso a la guardia médica: {this.fechaIngreso.ToString("yyyy-MM-dd HH:mm")}\n" +
                $"Especialidad de ingreso por guardia: {this.especialidadUrgencia}\n";
            return detallesPaciente;
        }

        /// <summary>
        ///  Sobreescribe el ToString(), devuelve una representación en forma de cadena string del objeto actual.
        /// </summary>
        /// <returns>Retorna una cadena que representa los datos del paciente ingresado por Urgencias.</returns>
        public override string ToString()
        {
            return this.MostrarDatosPaciente();
        }

        /// <summary>
        /// Sobreescribe el Equals() para permitir la comparación entre el objeto actual y el objeto indicado de la clase PacienteUrgencia.
        /// </summary>
        /// <param name="obj">Representa un objeto de cualquier tipo que se va a comparar con el objeto actual.</param>
        /// <returns>Retorna true si el objeto es de tipo PacienteUrgencia y si es igual al objeto actual.</returns>

        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is PacienteUrgencia)
            {
                retorno = true;
            }

            return retorno;
        }



        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Comprueba si dos objetos de la clase PacienteUrgencia son iguales en base a su nombre y DNI, gracias a la sobrecarga del operador ==.
        /// </summary>
        /// <param name="pacienteUrg1">Representa el primer objeto PacienteUrgencia a comparar.</param>
        /// <param name="pacienteUrg2">Representa el segundo objeto PacienteUrgencia a comparar.</param>
        /// <returns>Retorna true si los objetos PacienteUrgencia son iguales.</returns>
        public static bool operator ==(PacienteUrgencia pacienteUrg1, PacienteUrgencia pacienteUrg2)
        {
            bool rta = false;

            if (((object)pacienteUrg1) == null && ((object)pacienteUrg2) == null)
            {
                rta = true;
            }
            else 
            {
                if (((object)pacienteUrg1) != null && ((object)pacienteUrg2) != null)
                {
                    if (pacienteUrg1.Id == pacienteUrg2.Id)
                    {
                        rta = true;
                    }
                }
            }
            return rta;

        }

        /// <summary>
        /// Comprueba si dos objetos de la clase PacienteUrgencia son distintos en base a su nombre y DNI, gracias a la sobrecarga del operador !=.
        /// </summary>
        /// <param name="pacienteUrg1">Representa el primer objeto PacienteUrgencia a comparar.</param>
        /// <param name="pacienteUrg2">Representa el segundo objeto PacienteUrgencia a comparar.</param>
        /// <returns>Retorna true si los objetos PacienteUrgencia son distintos.</returns>
        public static bool operator !=(PacienteUrgencia pacienteUrg1, PacienteUrgencia pacienteUrg2)
        {
            return !(pacienteUrg1 == pacienteUrg2);
        }

        #endregion

    }
}
