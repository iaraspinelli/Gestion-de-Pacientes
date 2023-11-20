using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase publica que representa un objeto PacienteHospitalizado, que podrá ser ingresado a la gestión de pacientes a través de Hospitalización.
    /// </summary>
    public class PacienteHospitalizado : Paciente
    {
        #region Atributos

        private int numeroHabitacion;
        private DateTime fechaInternacion;

        #endregion

        #region Propiedades

        public int NumeroHabitacion
        {
            get { return this.numeroHabitacion; }
            set
            {
                if (value != this.numeroHabitacion)
                {
                    this.numeroHabitacion = value;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no ha tenido cambios");
                }
            }
        }

        public DateTime FechaInternacion
        {
            get
            {
                return this.fechaInternacion;
            }
            set
            {
                if (value != this.fechaInternacion)
                {
                    this.fechaInternacion = value;
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
        /// Constructor por defecto de la clase PacienteHospitalizado, necesario para Serializar en XML.
        /// </summary>
        public PacienteHospitalizado()
        {
            
        }
        public PacienteHospitalizado(string nombre, string apellido, int edad, int dni, string cobertura) : base(nombre, apellido, edad, dni, cobertura)
        {
            base.Nombre = nombre;
            base.Apellido = apellido;
            base.Edad = edad;
            base.Dni = dni;
            base.Cobertura = cobertura;
            this.numeroHabitacion = 0;
            this.fechaInternacion = DateTime.Now;
        }

        public PacienteHospitalizado(string nombre, string apellido, int edad, int dni, string cobertura, DateTime fechaInternacion) : this(nombre, apellido, edad, dni, cobertura)
        {
            this.fechaInternacion = fechaInternacion;
        }

        /// <summary>
        /// Último constructor sobrecargado de la clase PacienteConsultorioExterno
        /// </summary>
        /// <param name="nombre">Objeto de tipo string referente al nombre del paciente.</param>
        /// <param name="apellido">Objeto de tipo string referente al apellido del paciente.</param>
        /// <param name="edad">Objeto de tipo int referente a la edad del paciente.</param>
        /// <param name="dni">Objeto de tipo int referente al dni del paciente.</param>
        /// <param name="cobertura">Objeto de tipo string referente a la cobertura del paciente.</param>
        /// <param name="fechaInternacion">Objeto de tipo DateTime referente a la fecha de internación del paciente.</param>
        /// <param name="numeroHabitacion">Objeto de tipo int referente al número de habitación del paciente.a</param>
        public PacienteHospitalizado(string nombre, string apellido, int edad, int dni, string cobertura, DateTime fechaInternacion, int numeroHabitacion) : this(nombre, apellido, edad, dni, cobertura, fechaInternacion)
        {
            this.numeroHabitacion = numeroHabitacion;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos del paciente de acuerdo a los datos completados y seleccionados por el usuario en el formPacienteHospitalizado. Este método está sobrescrito a partir del mismo método con virtual en la clase base.
        /// </summary>
        /// <returns>Retorna un string con los datos base del pacienteingresado por Hospitalización.</returns>
        protected override string MostrarDatosPaciente()
        {
            StringBuilder datosPaciente = new StringBuilder();

            datosPaciente.Append("Paciente Hospitalizado - ");
            datosPaciente.Append(base.MostrarDatosPaciente());
            

            return datosPaciente.ToString();
        }

        /// <summary>
        /// Sobrescribe el método asbtracto de la clase base, muestra el detalle de todos los datos del paciente ingresado por Hospitalización.
        /// </summary>
        /// <returns>Retorna un string con cierto formato, indicando el detalle de la información del paciente.</returns>
        public override string MostrarDetallesPaciente()
        {
            string detallesPaciente = $"Datos detallados del paciente {base.Nombre.ToUpper()} {base.Apellido.ToUpper()}\n" +
                $"Edad: {base.Edad}\n" +
                $"DNI: {base.Dni}\n" +
                $"Cobertura: {base.Cobertura}\n" +
                $"Fecha de internación: {this.fechaInternacion.ToString("yyyy-MM-dd")}\n" +
                $"Número de habitación: {this.numeroHabitacion}\n";
            return detallesPaciente;
        }
        
        /// <summary>
        ///  Sobreescribe el ToString(), devuelve una representación en forma de cadena string del objeto actual.
        /// </summary>
        /// <returns>Retorna una cadena que representa los datos del paciente ingresado por Hospitalización.</returns>
        public override string ToString()
        {
            return this.MostrarDatosPaciente();
        }

        /// <summary>
        /// Sobreescribe el Equals() para permitir la comparación entre el objeto actual y el objeto indicado de la clase PacienteHospitalizado.
        /// </summary>
        /// <param name="obj">Representa un objeto de cualquier tipo que se va a comparar con el objeto actual.</param>
        /// <returns>Retorna true si el objeto es de tipo PacienteHospitalizado y si es igual al objeto actual.</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is PacienteHospitalizado)
            {
                retorno = true;
            }

            return retorno;
        }



        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Comprueba si dos objetos de la clase PacienteHospitalizado son iguales en base a su nombre y DNI, gracias a la sobrecarga del operador ==.
        /// </summary>
        /// <param name="pacienteHosp1">Representa el primer objeto PacienteHospitalizado a comparar.</param>
        /// <param name="pacienteHosp2">Representa el segundo objeto PacienteHospitalizado a comparar.</param>
        /// <returns>Retorna true si los objetos PacienteHospitalizado son iguales.</returns>
        public static bool operator ==(PacienteHospitalizado pacienteHosp1, PacienteHospitalizado pacienteHosp2)
        {
            bool rta = false;

            if (((object)pacienteHosp1) == null && ((object)pacienteHosp2) == null)
            {
                rta = true;
            }
            else
            {
                if (((object)pacienteHosp1) != null && ((object)pacienteHosp2) != null)
                {
                    if (pacienteHosp1.Id == pacienteHosp2.Id && pacienteHosp2.Dni == pacienteHosp2.Dni)
                    {
                        rta = true;
                    }
                }
            }
            return rta;
        }

        /// <summary>
        /// Comprueba si dos objetos de la clase PacienteHospitalizado son distintos en base a su nombre y DNI, gracias a la sobrecarga del operador !=.
        /// </summary>
        /// <param name="pacienteHosp1">Representa el primer objeto PacienteHospitalizado a comparar.</param>
        /// <param name="pacienteHosp2">Representa el segundo objeto PacienteHospitalizado a comparar.</param>
        /// <returns>Retorna true si los objetos PacienteHospitalizado son distintos.</returns>
        public static bool operator !=(PacienteHospitalizado pacienteHosp1, PacienteHospitalizado pacienteHosp2)
        {
            return !(pacienteHosp1 == pacienteHosp2);
        }

        #endregion

    }
}
