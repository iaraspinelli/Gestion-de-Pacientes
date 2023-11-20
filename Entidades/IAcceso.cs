using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IAcceso
    {
        bool PruebaConexion();

        SqlDataReader EjecutarLector(string sentencia);

        List<PacienteUrgencia> ObtenerPacienteUrgencia(SqlDataReader lectorSql);

        List<PacienteConsultorioExterno> ObtenerPacienteConsultorioExterno(SqlDataReader lectorSql);

        List<PacienteHospitalizado> ObtenerPacienteHospitalizado(SqlDataReader lectorSql);

        bool ObtenerListaPacientes(List<Paciente> listaPacientes, string tablaPaciente);
        
        void GenerarParametrosPaciente(Paciente paciente, SqlCommand comando);

        void GenerarParametrosPacienteUrgencia(PacienteUrgencia pacienteUrgencia, SqlCommand comando);

        void GenerarParametrosPacienteConsultorioExterno(PacienteConsultorioExterno pacienteConsultorioExterno, SqlCommand comando);

        void GenerarParametrosPacienteHospitalizado(PacienteHospitalizado pacienteHospitalizado, SqlCommand comando);

        bool EstablecerId(Paciente paciente, string tablaPaciente);

        bool AgregarPaciente(Paciente paciente);

        bool ModificarPaciente(Paciente paciente, int idPaciente);

        bool EliminarPaciente(Paciente paciente);


    }
}
