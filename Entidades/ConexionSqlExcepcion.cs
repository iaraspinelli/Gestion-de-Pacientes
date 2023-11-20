using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase de excepción personalizada para errores durante la conexión y la realización de consultas Sql.
    /// </summary>
    public class ConexionSqlException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConexionSqlException"/> con un mensaje de error específico.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        public ConexionSqlException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConexionSqlException"/> con un mensaje de error específico y la excepción interna.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        /// <param name="innerException">La excepción interna que causó esta excepción.</param>
        public ConexionSqlException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
