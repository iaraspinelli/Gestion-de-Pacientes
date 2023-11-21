using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public delegate void Action(int e);
    /// <summary>
    /// Atributos de serializacion XML que permiten incluir el tipo de Paciente indicado como un tipo válido para la serializacion xml.
    /// </summary>
    [XmlInclude(typeof(PacienteUrgencia))]
    [XmlInclude(typeof(PacienteHospitalizado))]
    [XmlInclude(typeof(PacienteConsultorioExterno))]

    /// <summary>
    /// Clase abstracta que representa un objeto Paciente, que podrá ser ingresado a la gestión de pacientes a través de Urgencias, Hospitalización o Consultorios Externos.
    /// </summary>
    public abstract class Paciente : Object
    {
        #region Atributos

        protected int id;
        protected string nombre;
        protected string apellido;
        protected int edad;
        protected int dni;
        protected string cobertura;

        #endregion

        public event Action NumeroInvalido;

        #region Propiedades

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (value != this.nombre)
                {
                    this.nombre = value;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no ha tenido cambios");
                }
            }
        }

        public string Apellido
        {
            get { return this.apellido
                    ; }
            set
            {
                if (value != this.apellido)
                {
                    this.apellido = value;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no ha tenido cambios");
                }
            }
        }

        public int Edad
        {
            get { return this.edad; }
            set
            {
                if (value != this.edad)
                {
                    this.edad = value;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no ha tenido cambios");
                }
            }
        }

        public int Dni
        {
            get { return this.dni; }
            set
            {
                if (value != this.dni)
                {
                    this.dni = value;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no ha tenido cambios");
                }
            }
        }

        public string Cobertura
        {
            get { return this.cobertura; }
            set
            {
                if (value != this.cobertura)
                {
                    this.cobertura = value;
                }
                else
                {
                    Console.WriteLine("El dato ingresado no ha tenido cambios");
                }
            }
        }

        #endregion

        #region Constructores
        public Paciente()
        {
            this.nombre = "";
            this.apellido = "";
            this.edad = 0;
            this.dni = 00_000_000;
            this.cobertura = "";
        }

        public Paciente(string nombre, string apellido, int edad) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        /// <summary>
        /// Último constructor sobrecargado de la clase Paciente
        /// </summary>
        /// <param name="nombre">Objeto de tipo string referente al nombre del paciente.</param>
        /// <param name="apellido">Objeto de tipo string referente al apellido del paciente.</param>
        /// <param name="edad">Objeto de tipo int referente a la edad del paciente.</param>
        /// <param name="dni">Objeto de tipo int referente al dni del paciente.</param>
        /// <param name="cobertura">Objeto de tipo string referente a la cobertura del paciente.</param>
        public Paciente(string nombre, string apellido, int edad, int dni, string cobertura) : this(nombre, apellido, edad)
        {
            this.dni = dni;
            this.cobertura = cobertura;
        }

        #endregion

        #region Métodos 

        /// <summary>
        /// Muestra los datos del paciente de acuerdo a los datos completados y seleccionados por el usuario en el form del tipo de la jerarqupia de clase que corresponda. Este método se sobreescribe en las clases derivadas.
        /// </summary>
        /// <returns>Retorna un string con los datos base del paciente.</returns>
        protected virtual string MostrarDatosPaciente()
        {
            StringBuilder datosPaciente = new StringBuilder();

            datosPaciente.AppendLine($"Nombre y apellido: {this.nombre.ToUpper()} {this.apellido.ToUpper()} - ");
            datosPaciente.AppendLine($"Edad: {this.edad} - ");
            datosPaciente.AppendLine($"DNI: {this.dni} - ");
            datosPaciente.AppendLine($"Cobertura: {this.cobertura.ToUpper()}");

            return datosPaciente.ToString();
        }

        /// <summary>
        /// Este metodo es abstracto por lo que no puede implementarse, sino que su implementación se hará en las clases derivadas.
        /// </summary>
        public abstract string MostrarDetallesPaciente();

        /// <summary>
        /// Sobreescribe el ToString(), devuelve una representación en forma de cadena string del objeto actual.
        /// </summary>
        /// <returns>Retorna una cadena que representa los datos del paciente.</returns>
        public override string ToString()
        {
            return this.MostrarDatosPaciente();
        }

        /// <summary>
        /// Sobreescribe el Equals() para permitir la comparación entre el objeto actual y el objeto indicado.
        /// </summary>
        /// <param name="obj">Representa un objeto de cualquier tipo que se va a comparar con el objeto actual.</param>
        /// <returns>Retorna true si el objeto es de tipo Paciente y si es igual al objeto actual.</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is Paciente)
            {
                retorno = this == (Paciente)obj;
            }

            return retorno;
        }
        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Comprueba si dos objetos Paciente son iguales en base a su nombre y DNI, gracias a la sobrecarga del operador ==.
        /// </summary>
        /// <param name="paciente1">Representa el primer objeto Paciente a comparar.</param>
        /// <param name="paciente2">Representa el segundo objeto Paciente a comparar.</param>
        /// <returns>Retorna true si los objetos Paciente son iguales.</returns>
        public static bool operator ==(Paciente paciente1, Paciente paciente2)
        {
            bool rta = false;

            if (((object)paciente1) == null && ((object)paciente2) == null)
            {
                rta = true;
            }
            else 
            {
                if (((object)paciente1) != null && ((object)paciente2) != null)
                {
                    if (paciente1.nombre.ToUpper() == paciente2.nombre.ToUpper() && paciente1.dni == paciente2.dni)
                    {
                        rta = true;
                    }
                }
            }
            return rta;
        }

        /// <summary>
        /// Comprueba si dos objetos Paciente son distintos en base a su nombre y DNI, gracias a la sobrecarga del operador !=.
        /// </summary>
        /// <param name="paciente1">Representa el primer objeto Paciente a comparar.</param>
        /// <param name="paciente2">Representa el segundo objeto Paciente a comparar.</param>
        /// <returns>Retorna true si los objetos Paciente son distintos.</returns>
        public static bool operator !=(Paciente paciente1, Paciente paciente2)
        {
            return !(paciente1 == paciente2);
        }

        /// <summary>
        /// Realiza una conversión implícita de un objeto Paciente a una cadena de texto.
        /// </summary>
        /// <param name="paciente">Representa el objeto Paciente a convertir en una cadena de texto.</param>
        /// <returns>Retorna la representación en forma de cadena del nombre del paciente. </returns>
        public static implicit operator string(Paciente paciente)
        {
            return paciente.nombre;
        }

        public static bool operator ==(List<Paciente> listaPacientes, Paciente paciente)
        {
            return listaPacientes.Contains(paciente);
        }

        public static bool operator !=(List<Paciente> listaPacientes, Paciente paciente)
        {
            return !(listaPacientes == paciente);
        }


        #endregion

    }
}