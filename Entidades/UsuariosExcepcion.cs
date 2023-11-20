using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase de excepción personalizada para errores al manejar arhivos para los usuarios logueados. 
    /// </summary>
    public class UsuariosExcepcion : Exception
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UsuariosExcepcion"/> con un mensaje de error específico.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>

        public UsuariosExcepcion(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UsuariosExcepcion"/> con un mensaje de error específico y la excepción interna.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        /// <param name="innerException">La excepción interna que causó esta excepción.</param>
        public UsuariosExcepcion(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
