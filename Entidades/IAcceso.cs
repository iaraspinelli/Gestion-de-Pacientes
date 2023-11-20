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

        void GenerarParametrosPaciente(Paciente paciente, SqlCommand comando);

        void GenerarParametrosPacienteUrgencia(PacienteUrgencia pacienteUrgencia, SqlCommand comando);

        void GenerarParametrosPacienteConsultorioExterno(PacienteConsultorioExterno pacienteConsultorioExterno, SqlCommand comando);

        void GenerarParametrosPacienteHospitalizado(PacienteHospitalizado pacienteHospitalizado, SqlCommand comando);

        bool AgregarPaciente(Paciente paciente);

        bool ModificarPaciente(Paciente paciente, int idPaciente);

        bool EliminarPaciente(Paciente paciente);


    }
}
