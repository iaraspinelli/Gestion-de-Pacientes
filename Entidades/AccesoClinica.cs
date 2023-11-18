using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Numerics;

namespace Entidades
{
    /// <summary>
    /// Clase public permite establecer la conexión con el motor de la base de datos Clinica_db.
    /// Permite realizar consultas SQL a la base de datos.
    /// </summary>
    public class AccesoClinica
    {
        #region Atributos de conexion y consultas SQL
        /// <summary>
        /// Establece la conexión con el motor de la base de datos SQL.
        /// </summary>
        private SqlConnection conexion;
        /// <summary>
        /// Contiene la cadena de conexión a la base de datos SQL. Es estático ya que se utilizará en distintas secciones y debe tener su contructor estático.
        /// </summary>
        private static string cadena_conexion;
        /// <summary>
        /// Representa y permite los comandos SQL que se pueden ejecutar en una conexión con la base de datos SQL.
        /// </summary>
        private SqlCommand comando;
        /// <summary>
        /// Permite la lectura de lo que devuelve las consultas SQL. 
        /// </summary>
        private SqlDataReader lectorSql;
        #endregion


        #region Constructores statico y no statico
        /// <summary>
        /// Constructor estático de la clase AccesoClinica para iniciar el atributo static cadena_conexion aignandole el string de conexión ubicado en los recursos de las propiedades del proyecto. 
        /// </summary>
        static AccesoClinica()
        {
            AccesoClinica.cadena_conexion = Properties.Resources.miConexion;
        }
        /// <summary>
        /// Constructor de la clase AccesoClinica, en el cual se instancia el objeto de tipo SqlConnection, y establece la conexión a la base de datos SQL.
        /// </summary>
        public AccesoClinica()
        {
            this.conexion = new SqlConnection(AccesoClinica.cadena_conexion);
        }
        #endregion


        #region Prueba conexion
        /// <summary>
        /// Realiza una prueba de conexión a la base de datos SQL.
        /// </summary>
        /// <returns>
        /// Devuelve true si la conexión se establece correctamente; de lo contrario, devuelve false.
        /// </returns>
        /// <exception cref="Exception">Se lanza en caso de cualquier error durante la prueba de conexión.</exception>
        public bool PruebaConexion()
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close(); 
                }
            }

            return retorno;
        }
        #endregion


        #region Lector de consultas SQL
        /// <summary>
        /// Ejecuta una sentencia SQL que se le pasa como parámetro.
        /// </summary>
        /// <param name="sentencia">La sentencia SQL a ejecutar.</param>
        /// <returns>
        /// Un objeto SqlDataReader que permite leer los datos devueltos por la sentencia SQL.
        /// </returns>
        private SqlDataReader EjecutarLector(string sentencia)
        {
            this.comando = new SqlCommand();
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = sentencia;

            this.comando.Connection = this.conexion;
            this.conexion.Open();

            return comando.ExecuteReader();
        }
        #endregion


        #region CONSULTA SELECT
        /// <summary>
        /// Recorre el lector de datos y crea instancias de la clase PacienteUrgencia para cada registro obtenido, asignando los valores correspondientes a las propiedades de la clase.
        /// </summary>
        /// <param name="lectorSql">El lector de datos SqlDataReader que contiene los resultados de la consulta.</param>
        /// <returns>
        /// Devuelve una lista de objetos PacienteUrgencia que representan los registros obtenidos del lector de datos.
        /// </returns>
        /// <exception cref="Exception">Se lanza en caso de error durante la lectura de datos desde el lectorSql.
        /// </exception>

        public List<PacienteUrgencia> ObtenerPacienteUrgencia(SqlDataReader lectorSql)
        {
            List<PacienteUrgencia> listaPacienteUrgencia = new List<PacienteUrgencia>();

            try
            {

                while (lectorSql.Read())
                {
                    PacienteUrgencia pacienteUrgencia = new PacienteUrgencia();

                    pacienteUrgencia.Id = (int)lectorSql["id"];
                    pacienteUrgencia.Nombre = lectorSql[1].ToString();
                    pacienteUrgencia.Apellido = lectorSql[2].ToString();
                    pacienteUrgencia.Edad = (int)lectorSql["edad"];
                    pacienteUrgencia.Dni = (int)lectorSql["dni"];
                    pacienteUrgencia.Cobertura = lectorSql[5].ToString();
                    pacienteUrgencia.FechaIngreso = lectorSql.GetDateTime(6);
                    pacienteUrgencia.EspecialidadUrgencia = (EEspecialidadUrgencia)lectorSql.GetInt32(7);

                    listaPacienteUrgencia.Add(pacienteUrgencia);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pacientes en urgencias desde el lectorSql.", ex);
            }

            return listaPacienteUrgencia;
        }

        /// <summary>
        /// Recorre el lector de datos y crea instancias de la clase PacienteConsultorioExterno para cada registro obtenido, asignando los valores correspondientes a las propiedades de la clase.
        /// </summary>
        /// <param name="lectorSql">El lector de datos SqlDataReader que contiene los resultados de la consulta.</param>
        /// <returns>
        /// Devuelve una lista de objetos PacienteConsultorioExterno que representan los registros obtenidos del lector de datos.
        /// </returns>
        /// <exception cref="Exception">Se lanza en caso de error durante la lectura de datos desde el lectorSql.
        /// </exception>
        public List<PacienteConsultorioExterno> ObtenerPacienteConsultorioExterno(SqlDataReader lectorSql)
        {
            List<PacienteConsultorioExterno> listaPacienteConsultorioExterno = new List<PacienteConsultorioExterno>();

            try
            { 
                while (lectorSql.Read())
                {
                    PacienteConsultorioExterno pacienteConsultorioExterno = new PacienteConsultorioExterno();

                    pacienteConsultorioExterno.Id = (int)lectorSql["id"];
                    pacienteConsultorioExterno.Nombre = lectorSql[1].ToString();
                    pacienteConsultorioExterno.Apellido = lectorSql[2].ToString();
                    pacienteConsultorioExterno.Edad = (int)lectorSql["edad"];
                    pacienteConsultorioExterno.Dni = (int)lectorSql["dni"];
                    pacienteConsultorioExterno.Cobertura = lectorSql[5].ToString();
                    pacienteConsultorioExterno.FechaTurno = lectorSql.GetDateTime(6);
                    pacienteConsultorioExterno.Especialidad = (EEspecialidad)lectorSql.GetInt32(7);

                    listaPacienteConsultorioExterno.Add(pacienteConsultorioExterno);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pacientes en consultorios externos desde el lectorSql.", ex);
            }

            return listaPacienteConsultorioExterno;
        }

        /// <summary>
        /// Recorre el lector de datos y crea instancias de la clase PacienteHospitalizado para cada registro obtenido, asignando los valores correspondientes a las propiedades de la clase.
        /// </summary>
        /// <param name="lectorSql">El lector de datos SqlDataReader que contiene los resultados de la consulta.</param>
        /// <returns>
        /// Devuelve una lista de objetos PacienteHospitalizado que representan los registros obtenidos del lector de datos.
        /// </returns>
        /// <exception cref="Exception">Se lanza en caso de error durante la lectura de datos desde el lectorSql.
        /// </exception>
        public List<PacienteHospitalizado> ObtenerPacienteHospitalizado(SqlDataReader lectorSql)
        {
            List<PacienteHospitalizado> listaPacienteHospitalizado = new List<PacienteHospitalizado>();

            try
            {
                while (lectorSql.Read())
                {
                    PacienteHospitalizado pacienteHospitalizado = new PacienteHospitalizado();

                    pacienteHospitalizado.Id = (int)lectorSql["id"];
                    pacienteHospitalizado.Nombre = lectorSql[1].ToString();
                    pacienteHospitalizado.Apellido = lectorSql[2].ToString();
                    pacienteHospitalizado.Edad = (int)lectorSql["edad"];
                    pacienteHospitalizado.Dni = (int)lectorSql["dni"];
                    pacienteHospitalizado.Cobertura = lectorSql[5].ToString();
                    pacienteHospitalizado.FechaInternacion = lectorSql.GetDateTime(6);
                    pacienteHospitalizado.NumeroHabitacion = (int)lectorSql["numeroHabitacion"];

                    listaPacienteHospitalizado.Add(pacienteHospitalizado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pacientes en hospitalización desde el lectorSql.", ex);
            }

            return listaPacienteHospitalizado;
        }

        /// <summary>
        /// Obtiene la lista de pacientes desde la base de datos, a traves del lectorSql para ejecutar una consulta Sql según la tabla especificada, y la agrega a la lista proporcionada.
        /// </summary>
        /// <param name="listaPacientes">La lista de pacientes a la que se agregarán los resultados.</param>
        /// <param name="tablaPaciente">El nombre de la tabla de la base de datos que contiene los pacientes específicos.</param>
        /// <returns>
        /// Devuelve true si se obtuvo y agregó la lista de pacientes correctamente; de lo contrario, devuelve false.
        /// </returns>
        /// <exception cref="Exception">Se lanza en caso de error durante la obtención o agregado de la lista de pacientes.
        /// </exception>

        public bool ObtenerListaPacientes(List<Paciente> listaPacientes, string tablaPaciente)
        {

            bool respuestaLista = false;
            try
            {
                string sentencia = $"SELECT * from {tablaPaciente}";
                this.lectorSql = EjecutarLector(sentencia);

                if (tablaPaciente != null)
                {
                    if (tablaPaciente == "pacienteUrgencia")
                        listaPacientes.AddRange(ObtenerPacienteUrgencia(this.lectorSql));
                    else if (tablaPaciente == "pacienteConsultorioExterno")
                        listaPacientes.AddRange(ObtenerPacienteConsultorioExterno(this.lectorSql));
                    else if (tablaPaciente == "pacienteHospitalizado")
                        listaPacientes.AddRange(ObtenerPacienteHospitalizado(this.lectorSql));

                    respuestaLista = true;
                }

                this.lectorSql.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener lista de pacientes.", ex);
            }

            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return respuestaLista;
        }



        #endregion


        #region INSERT
        
        #endregion

        #region UPDATE

        #endregion

        #region DELETE
        
        #endregion




    }
}
