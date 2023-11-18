using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase publica que representa un objeto UsuarioLogin, que permite obtener los datos de los usuarios del archivo de usuarios que se deserializa en el formLogin. 
    /// </summary>
    public class UsuarioLogin
    {
        public string apellido { get; init; }
        public string nombre { get; init; }
        public int legajo { get; init; }
        public string correo { get; init; }
        public string clave { get; init; }
        public string perfil { get; init; }

        /// <summary>
        /// Sobrescribe el ToString(), convierte el objeto UsuarioLogin en una representación de cadena.
        /// </summary>
        /// <returns>Retorna una cadena que representa el usuario con su nombre, apellido y la fecha de ingreso a la aplicación.</returns>
        public override string ToString()
        {
            return $"Usuario: {this.nombre} {this.apellido} - Perfil : {this.perfil} - Fecha login: {DateTime.Now.ToString("dd/MM/yyyy")}";
        }

    }
}
