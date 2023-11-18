using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Collections.Generic;

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
        private SqlDataReader reader;
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
        public List<Paciente> ObtenerListaDatos()
        {
            List<Paciente> lista = new List<Paciente>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "SELECT tipoPaciente,nombre,apellido,edad,dni,cobertura FROM paciente";

                this.comando.Connection = this.conexion;
                this.conexion.Open();
                this.reader = this.comando.ExecuteReader(); 

                while (this.reader.Read())
                {
                    Paciente paciente;
                    paciente.Id = (int)this.reader["id"];
                    //Esto retorna un object, asi que hay que castearlo a int

                    dato.cadena = this.reader[1].ToString();
                    //Es un array de indexado, asi que se le pone la posicion donde se encuentra "cadena" en el select, que seria la posicion 1.
                    //Como devuelve un object, se le agrega el metodo to string

                    //int entero = this.reader.GetInt32(2);
                    dato.entero = (int)this.reader["entero"];

                    dato.flotante = (float)this.reader.GetDouble(3);
                    //Al flotante se le agrega el get double, y se le pasa el numero de la posicion del campo a flotear, segun la posicion en la que esta en la consulta select. Siempre se asume el tipo mas grande de ese tipo.


                    //Dato dato = new Dato(id, cadena, entero, flotante);

                    lista.Add(dato);
                    //Se agrega el dato a la lista de Datos
                }

                this.reader.Close(); //Cerrar el reader, sino queda el recurso abierto
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }
        #endregion

        #region INSERT
        public bool AgregarDato(Dato dato)
        {
            bool result = false;
            try
            {
                this.command = new SqlCommand();
                this.command.Parameters.AddWithValue("@cadena", dato.cadena);
                this.command.Parameters.AddWithValue("@entero", dato.entero);
                this.command.Parameters.AddWithValue("@flotante", dato.flotante);

                this.command.CommandType = System.Data.CommandType.Text;
                this.command.CommandText = $"INSERT INTO dato(cadena,entero,flotante) VALUES(@cadena, @entero, @flotante)";

                this.command.Connection = this.conexion;
                this.conexion.Open();

                //Este metodo Query sirve para insert, update y delete
                int filasAfectadas = this.command.ExecuteNonQuery();
                if (filasAfectadas == 1) //Porque ejecuta de a una fila
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return result;
        }
        #endregion

        #region UPDATE
        public bool ModificarDato(Dato dato)
        {
            bool result = false;
            try
            {
                this.command = new SqlCommand();

                //Este metodo permite pasarle parametros, los parametros para sql server empiezan con @
                this.command.Parameters.AddWithValue("@id", dato.id);
                this.command.Parameters.AddWithValue("@cadena", dato.cadena);
                this.command.Parameters.AddWithValue("@entero", dato.entero);
                this.command.Parameters.AddWithValue("@flotante", dato.flotante);

                this.command.CommandType = System.Data.CommandType.Text;
                this.command.CommandText = $"UPDATE dato SET cadena = @cadena, entero = @entero, flotante = @flotante WHERE id = @id";


                this.command.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.command.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return result;
        }

        #endregion

        #region DELETE
        public bool BorrarDato(Dato dato)
        {
            bool result = false;
            try
            {
                this.command = new SqlCommand();
                this.command.Connection = this.conexion;
                this.command.Parameters.AddWithValue("@id", dato.id);
                this.command.CommandType = System.Data.CommandType.Text;
                this.command.CommandText = $"DELETE FROM dato WHERE id=@id";

                this.conexion.Open();

                int filasAfectadas = this.command.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return result;
        }
        #endregion




    }
}
