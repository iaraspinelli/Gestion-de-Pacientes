using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase publica que representa un objeto Clinica, que contendrá la colección genérica List<T>, en la cual se podrán agregar todos los pacientes cargados al instanciarla con new Clinica<Paciente>.
    /// </summary>
    public class Clinica<T> where T : Paciente
    {
        #region Atributos

        private List<T> pacientes;
        private int capacidadPacientes;

        #endregion

        #region Propiedades

        public List<T> Pacientes
        {
            get
            {
                return this.pacientes;
            }
            set
            {
                this.pacientes = value;
            }

        }
        public int CantidadPacientes
        {
            get
            {
                return this.capacidadPacientes;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase Clinica, instancia la coleccion generica e inicializa la capacidad de pacientes.
        /// </summary>
        public Clinica()
        {
            this.pacientes = new List<T>();
            this.capacidadPacientes = 10;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobreescribe el Equals() para permitir la comparación entre el objeto actual y el objeto indicado.
        /// </summary>
        /// <param name="obj">Representa un objeto de cualquier tipo que se va a comparar con el objeto actual.</param>
        /// <returns>Retorna true si el objeto es de tipo Paciente y si es igual al objeto actual.</returns>
        public override bool Equals(object? obj)
        {
            return this == (T)obj;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara una instancia de la clase Clinica con un objeto de tipo Paciente para determinar si el paciente está ingresado en la lista, gracias a la sobrecarga del operador ==.
        /// </summary>
        /// <param name="listaPacientes">Representa la instancia de la clase Clinica a comparar.</param>
        /// <param name="paciente">Reresenta el objeto de tipo Paciente que se compara con la lista.</param>
        /// <returns>retorna true si el paciente ya está ingresado en la lista.</returns>
        public static bool operator ==(Clinica<T> listaPacientes, T paciente)
        {
            bool pacienteIngresado = false;

            foreach(T item in listaPacientes.pacientes)
            {
                if(item == paciente)
                {
                    pacienteIngresado = true;
                    break;

                }
            }
            return pacienteIngresado;
        }

        /// <summary>
        /// Compara una instancia de la clase Clinica con un objeto de tipo Paciente para determinar si el paciente no está ingresado en la lista, gracias a la sobrecarga del operador !=.
        /// </summary>
        /// <param name="listaPacientes">Representa la instancia de la clase Clinica a comparar.</param>
        /// <param name="paciente">Representa el objeto de tipo Paciente que se compara con la lista.</param>
        /// <returns>Retorna true si el paciente no está ingresado en la lista.</returns>
        public static bool operator !=(Clinica<T> listaPacientes, T paciente)
        {
            return !(listaPacientes == paciente);
        }

        /// <summary>
        /// Agrega un objeto de tipo Paciente a la lista de pacientes de la instancia de la clase Clinica si no se ha alcanzado la capacidad máxima y si el paciente no está ya ingresado.
        /// </summary>
        /// <param name="listaPacientes">Representa la instancia de la clase Clinica a la que se agrega el paciente.</param>
        /// <param name="paciente">Representa el objeto de tipo Paciente que se agrega a la lista.</param>
        /// <returns>Retorna la instancia de la clase Clinica con el paciente agregado si se cumple con las condiciones; si se cumplen se devuelve la instancia original.</returns>
        public static Clinica<T> operator +(Clinica<T> listaPacientes, T paciente)
        {
            if (listaPacientes.pacientes.Count < listaPacientes.capacidadPacientes)
            {
                if (listaPacientes != paciente)
                {
                    listaPacientes.pacientes.Add(paciente);
                }
                else
                {
                    Console.WriteLine($"Paciente {paciente.Nombre} {paciente.Apellido} con DNI {paciente.Dni} ya se encuentra en la lista.\n");
                }
            }
            else
            {
                Console.WriteLine("Se ha alcanzado la capacidad máxima de pacientes.\n");
            }
            return listaPacientes;
        }

        /// <summary>
        /// Elimina un objeto de tipo Paciente de la lista de pacientes de la instancia de la clase Clinica si el paciente ya está ingresado en la lista.
        /// </summary>
        /// <param name="listaPacientes">Representa la instancia de la clase Clinica de la que se elimina el paciente.</param>
        /// <param name="paciente">Representa el objeto de tipo Paciente que se elimina de la lista.</param>
        /// <returns>Retorna la instancia de la clase Clinica con el paciente eliminado, si el paciente está en la lista; si no está, se devuelve la instancia original.</returns>
        public static Clinica<T> operator -(Clinica<T> listaPacientes, T paciente)
        {
            if (listaPacientes == paciente)
            {
                listaPacientes.pacientes.Remove(paciente);
            }

            return listaPacientes;
        }


        #endregion

        #region Ordenar elementos de la lista

        /// <summary>
        /// Compara dos objetos de tipo Paciente para ordenarlos alfabéticamente por el nombre en orden ascendente.
        /// </summary>
        /// <param name="paciente1">Representa el primer objeto de tipo Paciente a comparar.</param>
        /// <param name="paciente2">Representa el segundo objeto de tipo Paciente a comparar.</param>
        /// <returns>Retorna un valor entero que indica la posición de los objetos en el orden ascendente.</returns>
        public static int OrdenarPorNombreAscendente(T paciente1, T paciente2)
        {
            return string.Compare(paciente1.Nombre, paciente2.Nombre);
        }

        /// <summary>
        /// Compara dos objetos de tipo Paciente para ordenarlos alfabéticamente por el nombre en orden descendente.
        /// </summary>
        /// <param name="paciente1">Representa el primer objeto de tipo Paciente a comparar.</param>
        /// <param name="paciente2">Representa el segundo objeto de tipo Paciente a comparar.</param>
        /// <returns>Retorna un valor entero que indica la posición de los objetos en el orden descendente.</returns>
        public static int OrdenarPorNombreDescendente(T paciente1, T paciente2)
        {
            return string.Compare(paciente2.Nombre, paciente1.Nombre);
        }

        /// <summary>
        /// Compara dos objetos de tipo Paciente para ordenarlos por el número de DNI en orden ascendente.
        /// </summary>
        /// <param name="paciente1">Representa el primer objeto de tipo Paciente a comparar.</param>
        /// <param name="paciente2">Representa el segundo objeto de tipo Paciente a comparar.</param>
        /// <returns>Retorna un valor entero que indica la posición de los objetos en el orden ascendente.</returns>
        public static int OrdenarPorDniAscendente(T paciente1, T paciente2)
        {
            if (paciente1.Dni > paciente2.Dni)
                return 1;
            else if (paciente1.Dni < paciente2.Dni)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Compara dos objetos de tipo Paciente para ordenarlos por el número de DNI en orden descendente.
        /// </summary>
        /// <param name="paciente1">Representa el primer objeto de tipo Paciente a comparar.</param>
        /// <param name="paciente2">Representa el segundo objeto de tipo Paciente a comparar.</param>
        /// <returns>Retorna un valor entero que indica la posición de los objetos en el orden descendente.</returns>
        public static int OrdenarPorDniDescendente(T paciente1, T paciente2)
        {
            if (paciente1.Dni < paciente2.Dni)
                return 1;
            else if (paciente1.Dni > paciente2.Dni)
                return -1;
            else
                return 0;
        }

        #endregion

    }
}
