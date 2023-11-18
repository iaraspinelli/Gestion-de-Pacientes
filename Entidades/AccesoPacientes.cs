//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace Entidades
{
    public class AccesoPacientes
    {
        #region Atributos de conexion y consultas SQL
        private SqlConnection conexion;
        private static string cadena_conexion;
        private SqlCommand command;
        private SqlDataReader reader;
        #endregion
    }
}
