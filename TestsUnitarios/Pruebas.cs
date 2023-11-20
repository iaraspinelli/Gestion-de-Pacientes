using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace TestsUnitarios
{
    /// <summary>
    /// Clase de pruebas unitarias para verificar la funcionalidad de la aplicación.
    /// </summary>
    [TestClass]
    public class Pruebas
    {
        /// <summary>
        /// Método de prueba para verificar la igualdad entre diferentes tipos de pacientes.
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadPacientes_Ok()
        {
            //Arrange
            //PacienteUrgencia 
            Paciente paciente1 = new PacienteUrgencia("iara","spinelli",26,40677296,"osde");
            Paciente paciente2 = new PacienteHospitalizado("iara","spinelli",26, 40677296, "osde");
            Paciente paciente3 = new PacienteConsultorioExterno("iara", "spinelli", 26, 40677296, "osde");

            //Act
            bool rta = paciente1 == paciente2 && paciente1 == paciente3 && paciente2 == paciente3;

            //Assert
            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Método de prueba para verificar la desigualdad entre diferentes tipos de pacientes.
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadPacientes_Falla()
        {
            //Arrange
            Paciente paciente1 = new PacienteUrgencia("iara", "spinelli", 26, 40677296, "osde");
            Paciente paciente2 = new PacienteHospitalizado("patricio", "espindola", 29, 38454884, "osseg");
            Paciente paciente3 = new PacienteConsultorioExterno("miriam", "guardia", 54, 22456782, "osseg integral");

            //Act
            bool rta = paciente1 == paciente2 && paciente1 == paciente3 && paciente2 == paciente3;

            //Assert
            Assert.IsFalse(rta);
        }

        /// <summary>
        /// Método de prueba para verificar la igualdad entre pacientes nulos.
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadPacientesNulos()
        {
            //Arrange
            Paciente paciente1 = null;
            Paciente paciente2 = null;

            //Act
            bool rta = paciente1 == paciente2;

            //Assert
            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Método de prueba para verificar que la lista de pacientes en una clínica no sea nula.
        /// </summary>
        [TestMethod]
        public void ClinicaVerificarNoNulo()
        {
            //Arrange
            Clinica<Paciente> clinica = new Clinica<Paciente>();

            //Act
            List<Paciente> pacientes = clinica.Pacientes;

            //Assert
            Assert.IsNotNull(pacientes);
        }

        /// <summary>
        /// Método de prueba para verificar la adición de pacientes a una clínica.
        /// </summary>
        [TestMethod]
        public void AgregarPacientes_Ok()
        {
            //Arrange
            Clinica<Paciente> clinica = new Clinica<Paciente>();
            Paciente paciente1 = new PacienteUrgencia("iara", "spinelli", 26, 40677296, "osde");
            Paciente paciente2 = new PacienteHospitalizado("patricio", "espindola", 29, 38454884, "osseg");
            Paciente paciente3 = new PacienteConsultorioExterno("miriam", "guardia", 54, 22456782, "osseg integral");
            int espacioLibreEsperado = 7;
            int espacioLibre = 0;

            //Act
            clinica += paciente1;
            clinica += paciente2;
            clinica += paciente3;

            espacioLibre = clinica.CantidadPacientes - clinica.Pacientes.Count;

            //Assert
            Assert.AreEqual(espacioLibre, espacioLibreEsperado);
        }

        /// <summary>
        /// Método de prueba para verificar la adición de pacientes a una clínica cuando está llena.
        /// </summary>
        [TestMethod]
        public void AgregarPacientes_Llena()
        {
            //Arrange
            Clinica<Paciente> clinica = new Clinica<Paciente>();
            Paciente paciente1 = new PacienteUrgencia("iara", "spinelli", 26, 40677296, "osde");
            Paciente paciente2 = new PacienteHospitalizado("patricio", "espindola", 29, 38454884, "osseg");
            Paciente paciente3 = new PacienteConsultorioExterno("miriam", "guardia", 54, 22456782, "osseg integral");
            Paciente paciente4 = new PacienteUrgencia("sebastian", "spinell", 27, 40677297, "osd");
            Paciente paciente5 = new PacienteHospitalizado("patric", "espindol", 30, 38454852, "osse");
            Paciente paciente6 = new PacienteConsultorioExterno("miriam", "guardi", 54, 22456784, "osseg integra");
            Paciente paciente7 = new PacienteUrgencia("iara magali", "spinelli", 26, 40677291, "swiss");
            Paciente paciente8 = new PacienteHospitalizado("patricio", "espindola", 29, 38454882, "swiss");
            Paciente paciente9 = new PacienteConsultorioExterno("miriam guardia", "guard", 54, 22456792, "osseg 1");
            Paciente paciente10 = new PacienteHospitalizado("pato", "espindolita", 29, 38455884, "osseg 2");
            Paciente paciente11 = new PacienteConsultorioExterno("mirian", "guardiola", 54, 23456782, "osseg 3");

            //Act
            clinica += paciente1;
            clinica += paciente2;
            clinica += paciente3;
            clinica += paciente4;
            clinica += paciente5;
            clinica += paciente6;
            clinica += paciente7;
            clinica += paciente8;
            clinica += paciente9;
            clinica += paciente10;
            clinica += paciente11;

            bool rta = clinica.Pacientes.Count > clinica.CantidadPacientes;

            //Assert
            Assert.IsFalse(rta);

        }
    }

}