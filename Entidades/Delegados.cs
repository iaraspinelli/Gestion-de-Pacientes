namespace Entidades
{
    #region Delegado Form Paciente

    /// <summary>
    /// Delegado utilizado para validar los campos del formulario para pacientes.
    /// </summary>
    /// <param name="mensaje">Representa el mensaje que se mostrará cuando el campo no sea válido.</param>
    public delegate void DelegadoValidarFormulario(string mensaje);

    #endregion

    #region Delegados Form Principal Pacientes

    /// <summary>
    /// Delegado utilizado para las operaciones inválidas en el form principal de pacientes.
    /// </summary>
    /// <param name="mensaje">Representa el mensaje que se mostrará cuando la operación sea inválida.</param>
    public delegate void DelegadoOperacionInvalida(string mensaje);

    /// <summary>
    /// Delegado utilizado para las operaciones válidas en el form principal de pacientes.
    /// </summary>
    /// <param name="mensaje">Representa el mensaje que se mostrará cuando la operación válida.</param>
    public delegate void DelegadoOperacionValida(string mensaje);

    /// <summary>
    /// Delegado utilizado para mostrar la fecha y horario actual en el label del formulario Principal de Pacientes.
    /// </summary>
    /// <param name="fecha">Representa la fecha actual a mostrar.</param>
    public delegate void DelegadoMostrarFechaActual(DateTime fecha);

    #endregion

}