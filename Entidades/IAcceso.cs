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

        bool AgregarPacienteUrgencia(PacienteUrgencia pacienteUrgencia);

        bool AgregarPacienteConsultorioExterno(PacienteConsultorioExterno pacienteConsultorioExterno);

        bool AgregarPacienteHospitalizado(PacienteHospitalizado pacienteHospitalizado);

        bool ModificarPaciente(Paciente paciente);

        bool EliminarPaciente(Paciente paciente);


    }
}
