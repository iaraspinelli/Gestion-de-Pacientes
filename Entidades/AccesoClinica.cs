using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace Entidades
{
    /// <summary>
    /// Clase public permite establecer la conexión con el motor de la base de datos Clinica_db.
    /// Permite realizar consultas SQL a la base de datos.
    /// </summary>
    public class AccesoClinica: IAcceso
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
                throw new ConexionSqlException("Error durante la prueba de conexión.", ex);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
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
        public SqlDataReader EjecutarLector(string sentencia)
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = sentencia;

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                return this.comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el lector SQL.", ex);
            }
            
        }

        #endregion


        #region SELECT
        /// <summary>
        /// Recorre el lector de datos y crea instancias de la clase PacienteUrgencia para cada registro obtenido, asignando los valores correspondientes a las propiedades de la clase.
        /// </summary>
        /// <param name="lectorSql">El lector de datos SqlDataReader que contiene los resultados de la consulta.</param>
        /// <returns>
        /// Devuelve una lista de objetos PacienteUrgencia que representan los registros obtenidos del lector de datos.
        /// </returns>

        public List<PacienteUrgencia> ObtenerPacienteUrgencia(SqlDataReader lectorSql)
        {
            List<PacienteUrgencia> listaPacienteUrgencia = new List<PacienteUrgencia>();

            while (lectorSql.Read())
                {
                    PacienteUrgencia pacienteUrgencia = new PacienteUrgencia();

                    pacienteUrgencia.Id = (int)lectorSql["id"];
                    pacienteUrgencia.Nombre = lectorSql[1].ToString();
                    pacienteUrgencia.Apellido = lectorSql[2].ToString();
                    pacienteUrgencia.Edad = (int)lectorSql["edad"];
                    pacienteUrgencia.Dni = (int)lectorSql["dni"];
                    pacienteUrgencia.Cobertura = lectorSql[5].ToString();
                    pacienteUrgencia.FechaIngreso = (DateTime)lectorSql.GetDateTime(6);
                    pacienteUrgencia.EspecialidadUrgencia = (EEspecialidadUrgencia)lectorSql.GetInt32(7);

                    listaPacienteUrgencia.Add(pacienteUrgencia);
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
        public List<PacienteConsultorioExterno> ObtenerPacienteConsultorioExterno(SqlDataReader lectorSql)
        {
            List<PacienteConsultorioExterno> listaPacienteConsultorioExterno = new List<PacienteConsultorioExterno>();

            while (lectorSql.Read())
            {
                PacienteConsultorioExterno pacienteConsultorioExterno = new PacienteConsultorioExterno();

                pacienteConsultorioExterno.Id = (int)lectorSql["id"];
                pacienteConsultorioExterno.Nombre = lectorSql[1].ToString();
                pacienteConsultorioExterno.Apellido = lectorSql[2].ToString();
                pacienteConsultorioExterno.Edad = (int)lectorSql["edad"];
                pacienteConsultorioExterno.Dni = (int)lectorSql["dni"];
                pacienteConsultorioExterno.Cobertura = lectorSql[5].ToString();
                pacienteConsultorioExterno.FechaTurno = (DateTime)lectorSql.GetDateTime(6);
                pacienteConsultorioExterno.Especialidad = (EEspecialidad)lectorSql.GetInt32(7);

                listaPacienteConsultorioExterno.Add(pacienteConsultorioExterno);
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
        public List<PacienteHospitalizado> ObtenerPacienteHospitalizado(SqlDataReader lectorSql)
        {
            List<PacienteHospitalizado> listaPacienteHospitalizado = new List<PacienteHospitalizado>();

            while (lectorSql.Read())
            {
                PacienteHospitalizado pacienteHospitalizado = new PacienteHospitalizado();

                pacienteHospitalizado.Id = (int)lectorSql["id"];
                pacienteHospitalizado.Nombre = lectorSql[1].ToString();
                pacienteHospitalizado.Apellido = lectorSql[2].ToString();
                pacienteHospitalizado.Edad = (int)lectorSql["edad"];
                pacienteHospitalizado.Dni = (int)lectorSql["dni"];
                pacienteHospitalizado.Cobertura = lectorSql[5].ToString();
                pacienteHospitalizado.FechaInternacion = (DateTime)lectorSql.GetDateTime(6);
                pacienteHospitalizado.NumeroHabitacion = (int)lectorSql["numeroHabitacion"];

                listaPacienteHospitalizado.Add(pacienteHospitalizado);
            }
            this.lectorSql.Close();
            
            return listaPacienteHospitalizado;
        }


        /// <summary>
        /// Obtiene la lista de pacientes desde la base de datos, a traves del lectorSql para ejecutar una consulta Sql según la tabla especificada, y la agrega a la lista proporcionada.
        /// </summary>
        /// <param name = "listaPacientes" > La lista de pacientes a la que se agregarán los resultados.</param>
        /// <param name = "tablaPaciente" > El nombre de la tabla de la base de datos que contiene los pacientes específicos.</param>
        /// <returns>
        /// Devuelve true si se obtuvo y agregó la lista de pacientes correctamente; de lo contrario, devuelve false.
        /// </returns>
        /// <exception cref="ConexionSqlException">
        /// Se lanza en caso de cualquier error durante la obtención de la lista de pacientes.
        /// Las excepciones específicas lanzadas son:
        /// - <see cref="SqlException"/>: Error relacionado con una operación SQL.
        /// - <see cref="InvalidOperationException"/>: Error relacionado cuando ocurre una operación no válida en el estado actual del objeto.
        /// - <see cref="Exception"/>: Error relacionado con otras excepciones no manejadas de manera específica.
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
                    {
                        listaPacientes.AddRange(ObtenerPacienteUrgencia(this.lectorSql));
                    }
                    else if (tablaPaciente == "pacienteConsultorioExterno")
                    {
                        listaPacientes.AddRange(ObtenerPacienteConsultorioExterno(this.lectorSql));
                    }
                    else if (tablaPaciente == "pacienteHospitalizado")
                    {
                        listaPacientes.AddRange(ObtenerPacienteHospitalizado(this.lectorSql));
                    }

                    respuestaLista = true;
                }

                this.lectorSql.Close();

            }
            catch (SqlException sqlEx)
            {
                throw new ConexionSqlException("Error de SQL al obtener lista de pacientes.", sqlEx);
            }
            catch (InvalidOperationException operacionInvalidaEx)
            {
                throw new ConexionSqlException("Operación no válida al obtener lista de pacientes.", operacionInvalidaEx);
            }
            catch (Exception ex)
            {
                throw new ConexionSqlException("Error al obtener lista de pacientes.", ex);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return respuestaLista;
        }

        #endregion


        #region Parametros pacientes
        /// <summary>
        /// Genera los parámetros de un objeto Paciente para su uso en consultas SQL.
        /// </summary>
        /// <param name="paciente">El objeto Paciente del cual se extraerán los parámetros.</param>
        public void GenerarParametrosPaciente(Paciente paciente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
            comando.Parameters.AddWithValue("@apellido", paciente.Apellido);
            comando.Parameters.AddWithValue("@edad", paciente.Edad);
            comando.Parameters.AddWithValue("@dni", paciente.Dni);
            comando.Parameters.AddWithValue("@cobertura", paciente.Cobertura);
        }

        /// <summary>
        /// Genera los parámetros de un objeto PacienteUrgencia para su uso en consultas SQL.
        /// </summary>
        /// <param name="pacienteUrgencia">El objeto PacienteUrgencia del cual se extraerán los parámetros.</param>
        public void GenerarParametrosPacienteUrgencia(PacienteUrgencia pacienteUrgencia, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@fechaIngreso", pacienteUrgencia.FechaIngreso);
            comando.Parameters.AddWithValue("@especialidadUrgencia", (int)pacienteUrgencia.EspecialidadUrgencia);
        }

        /// <summary>
        /// Genera los parámetros de un objeto PacienteConsultorioExterno para su uso en consultas SQL.
        /// </summary>
        /// <param name="pacienteConsultorioExterno">El objeto PacienteConsultorioExterno del cual se extraerán los parámetros.</param>
        public void GenerarParametrosPacienteConsultorioExterno(PacienteConsultorioExterno pacienteConsultorioExterno, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@fechaTurno", pacienteConsultorioExterno.FechaTurno);
            comando.Parameters.AddWithValue("@especialidad", (int)pacienteConsultorioExterno.Especialidad);
        }

        /// <summary>
        /// Genera los parámetros de un objeto PacienteHospitalizado para su uso en consultas SQL.
        /// </summary>
        /// <param name="pacienteHospitalizado">El objeto PacienteHospitalizado del cual se extraerán los parámetros.</param>
        public void GenerarParametrosPacienteHospitalizado(PacienteHospitalizado pacienteHospitalizado, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@fechaInternacion", pacienteHospitalizado.FechaInternacion);
            comando.Parameters.AddWithValue("@numeroHabitacion", pacienteHospitalizado.NumeroHabitacion);
        }

        #endregion


        #region Obtener id

        /// <summary>
        /// Establece el ID del paciente consultando la base de datos según el nombre y la tabla especificados.
        /// </summary>
        /// <param name="paciente">Objeto de tipo Paciente al cual se le establecerá el ID.</param>
        /// <param name="tablaPaciente">Nombre de la tabla de la base de datos donde se realizará la consulta.</param>
        /// <returns>
        /// Devuelve true si se pudo establecer el ID correctamente; de lo contrario, devuelve false.
        /// </returns>
        /// <exception cref="ConexionSqlException">
        /// Se lanza en caso de cualquier error durante la obtención del id del paciente.
        /// Las excepciones específicas lanzadas son:
        /// - <see cref="SqlException"/>: Error relacionado con una operación SQL.
        /// - <see cref="InvalidOperationException"/>: Error relacionado cuando ocurre una operación no válida en el estado actual del objeto.
        /// - <see cref="Exception"/>: Error relacionado con otras excepciones no manejadas de manera específica.
        /// </exception>

        public bool EstablecerId(Paciente paciente, string tablaPaciente)
        {
            bool respuestaId = false;

            try
            {
                string sentencia = $"SELECT id FROM {tablaPaciente} WHERE nombre = '{paciente.Nombre}'";

                using (SqlDataReader lectorSql = EjecutarLector(sentencia))
                {
                    if (lectorSql.Read())
                    {
                        paciente.Id = (int)lectorSql["id"];
                        respuestaId = true;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new ConexionSqlException("Error de SQL al obtener el Id del paciente", sqlEx);
            }
            catch (InvalidOperationException operacionInvalidaEx)
            {
                throw new ConexionSqlException("Operación no válida al obtener el Id del paciente.", operacionInvalidaEx);
            }
            catch (Exception ex)
            {
                throw new ConexionSqlException("Error al obtener el Id del paciente.", ex);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                    this.conexion.Close();
            }

            return respuestaId;
        }
        #endregion


        #region INSERT
        /// <summary>
        /// Agrega un nuevo paciente a la tabla que corresponda en la base de datos, luego de verificar el tipo de paciente que ingresa.
        /// </summary>
        /// <param name="paciente">El objeto Paciente a agregar.</param>
        /// <returns>Devuelve true si el paciente se agregó correctamente; de lo contrario, false.</returns>
        /// <exception cref="ConexionSqlException">
        /// Se lanza en caso de cualquier error durante el agregado de un paciente.
        /// Las excepciones específicas lanzadas son:
        /// - <see cref="SqlException"/>: Error relacionado con una operación SQL.
        /// - <see cref="InvalidOperationException"/>: Error relacionado cuando ocurre una operación no válida en el estado actual del objeto.
        /// - <see cref="Exception"/>: Error relacionado con otras excepciones no manejadas de manera específica.
        /// </exception>
        public bool AgregarPaciente(Paciente paciente)
        {
            bool respuestaAgregado = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Parameters.AddWithValue("@id", paciente.Id);
                GenerarParametrosPaciente(paciente, this.comando);

                if (paciente is PacienteUrgencia)
                {
                    GenerarParametrosPacienteUrgencia((PacienteUrgencia)paciente, this.comando);
                    this.comando.CommandText = $"INSERT INTO pacienteUrgencia (nombre,apellido,edad,dni,cobertura,fechaIngreso,especialidadUrgencia) VALUES (@nombre, @apellido, @edad, @dni, @cobertura, @fechaIngreso, @especialidadUrgencia)";
                }
                else if (paciente is PacienteConsultorioExterno)
                {
                    GenerarParametrosPacienteConsultorioExterno((PacienteConsultorioExterno)paciente, this.comando);
                    this.comando.CommandText = $"INSERT INTO pacienteConsultorioExterno (nombre,apellido,edad,dni,cobertura,fechaTurno,especialidad) VALUES (@nombre, @apellido, @edad, @dni, @cobertura, @fechaTurno, @especialidad)";
                }
                else if (paciente is PacienteHospitalizado)
                {
                    GenerarParametrosPacienteHospitalizado((PacienteHospitalizado)paciente, this.comando);
                    this.comando.CommandText = $"INSERT INTO pacienteHospitalizado (nombre,apellido,edad,dni,cobertura,fechaInternacion,numeroHabitacion) VALUES (@nombre, @apellido, @edad, @dni, @cobertura, @fechaInternacion, @numeroHabitacion)";
                }


                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    respuestaAgregado = true;
                }

            }
            catch (SqlException sqlEx)
            {
                throw new ConexionSqlException("Error de SQL al agregar un paciente a la tabla de la base de datos Sql.", sqlEx);
            }
            catch (InvalidOperationException operacionInvalidaEx)
            {
                throw new ConexionSqlException("Operación no válida al agregar un paciente a la tabla de la base de datos Sql.", operacionInvalidaEx);
            }
            catch (Exception ex)
            {
                throw new ConexionSqlException("Error al agregar un paciente a la tabla de la base de datos Sql.", ex);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return respuestaAgregado;
        }

        #endregion


        #region UPDATE

        /// <summary>
        /// Modifica un paciente de la tabla que corresponda en la base de datos, luego de verificar el tipo de paciente que ingresa.
        /// </summary>
        /// <param name="paciente">El objeto Paciente a modificar.</param>
        /// <returns>Devuelve true si el paciente se modificó correctamente; de lo contrario, false.</returns>
        /// <exception cref="ConexionSqlException">
        /// Se lanza en caso de cualquier error durante la modificación de un paciente.
        /// Las excepciones específicas lanzadas son:
        /// - <see cref="SqlException"/>: Error relacionado con una operación SQL.
        /// - <see cref="InvalidOperationException"/>: Error relacionado cuando ocurre una operación no válida en el estado actual del objeto.
        /// - <see cref="Exception"/>: Error relacionado con otras excepciones no manejadas de manera específica.
        /// </exception>
        public bool ModificarPaciente(Paciente paciente, int id)
        {
            bool respuestaModificar = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Parameters.AddWithValue("@id", id);
                GenerarParametrosPaciente(paciente, this.comando);

                if (paciente is PacienteUrgencia)
                {
                    GenerarParametrosPacienteUrgencia((PacienteUrgencia)paciente, this.comando);
                    this.comando.CommandText = "UPDATE pacienteUrgencia SET nombre = @nombre, apellido = @apellido, edad = @edad, dni = @dni, cobertura = @cobertura, fechaIngreso = @fechaIngreso, especialidadUrgencia = @especialidadUrgencia WHERE id = @id";
                }
                else if (paciente is PacienteConsultorioExterno)
                {
                    GenerarParametrosPacienteConsultorioExterno((PacienteConsultorioExterno)paciente, this.comando);
                    this.comando.CommandText = "UPDATE pacienteConsultorioExterno SET nombre = @nombre, apellido = @apellido, edad = @edad, dni = @dni, cobertura = @cobertura, fechaTurno = @fechaTurno, especialidad = @especialidad WHERE id = @id";
                }
                else if (paciente is PacienteHospitalizado)
                {
                    GenerarParametrosPacienteHospitalizado((PacienteHospitalizado)paciente, this.comando);
                    this.comando.CommandText = "UPDATE pacienteHospitalizado SET nombre = @nombre, apellido = @apellido, edad = @edad, dni = @dni, cobertura = @cobertura, fechaInternacion = @fechaInternacion, numeroHabitacion = @numeroHabitacion WHERE id = @id";
                }

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    respuestaModificar = true;
                }
            }
            catch (SqlException sqlEx)
            {
                throw new ConexionSqlException("Error de SQL al modificar un paciente de la tabla de la base de datos Sql.", sqlEx);
            }
            catch (InvalidOperationException operacionInvalidaEx)
            {
                throw new ConexionSqlException("Operación no válida al modificar un paciente de la tabla de la base de datos Sql.", operacionInvalidaEx);
            }
            catch (Exception ex)
            {
                throw new ConexionSqlException("Error al modificar un paciente de la tabla de la base de datos Sql.", ex);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return respuestaModificar;
        }


        #endregion


        #region DELETE

        /// <summary>
        /// Elimina un paciente de la tabla que corresponda en la base de datos, luego de verificar el tipo de paciente que ingresa.
        /// </summary>
        /// <param name="paciente">El objeto Paciente a eliminar.</param>
        /// <returns>Devuelve true si el paciente se eliminó correctamente; de lo contrario, false.</returns>
        /// <exception cref="ConexionSqlException">
        /// Se lanza en caso de cualquier error durante la eliminación de un paciente.
        /// Las excepciones específicas lanzadas son:
        /// - <see cref="SqlException"/>: Error relacionado con una operación SQL.
        /// - <see cref="InvalidOperationException"/>: Error relacionado cuando ocurre una operación no válida en el estado actual del objeto.
        /// - <see cref="Exception"/>: Error relacionado con otras excepciones no manejadas de manera específica.
        /// </exception>
        public bool EliminarPaciente(Paciente paciente)
        {
            bool respuestaEliminar = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Parameters.AddWithValue("@id", paciente.Id);

                if (paciente is PacienteUrgencia)
                {
                    this.comando.CommandText = $"DELETE FROM pacienteUrgencia WHERE id = @id";
                }
                else if (paciente is PacienteConsultorioExterno)
                {
                    this.comando.CommandText = $"DELETE FROM pacienteConsultorioExterno WHERE id = @id";
                }
                else if (paciente is PacienteHospitalizado)
                {
                    this.comando.CommandText = $"DELETE FROM pacienteHospitalizado WHERE id = @id";
                }

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    respuestaEliminar = true;
                }
            }
            catch (SqlException sqlEx)
            {
                throw new ConexionSqlException("Error de SQL al eliminar un paciente de la tabla de la base de datos Sql.", sqlEx);
            }
            catch (InvalidOperationException operacionInvalidaEx)
            {
                throw new ConexionSqlException("Operación no válida al eliminar un paciente de la tabla de la base de datos Sql.", operacionInvalidaEx);
            }
            catch (Exception ex)
            {
                throw new ConexionSqlException("Error al eliminar un paciente de la tabla de la base de datos Sql.", ex);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return respuestaEliminar;
        }


        #endregion


    }
}
