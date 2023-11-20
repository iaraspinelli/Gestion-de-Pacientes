namespace WindowsForm
{
    partial class FormPacienteHospitalizado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblIngreso = new Label();
            lblFechaIngreso = new Label();
            lblNumHabitacion = new Label();
            dateTimeFechaIngreso = new DateTimePicker();
            txtNumHabitacion = new TextBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 192, 255);
            // 
            // lblIngreso
            // 
            lblIngreso.AutoSize = true;
            lblIngreso.BackColor = Color.DarkGray;
            lblIngreso.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblIngreso.Location = new Point(441, 80);
            lblIngreso.Name = "lblIngreso";
            lblIngreso.Size = new Size(239, 21);
            lblIngreso.TabIndex = 24;
            lblIngreso.Text = "Ingresado por Hospitalización";
            // 
            // lblFechaIngreso
            // 
            lblFechaIngreso.AutoSize = true;
            lblFechaIngreso.BackColor = Color.DarkGray;
            lblFechaIngreso.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFechaIngreso.Location = new Point(353, 125);
            lblFechaIngreso.Name = "lblFechaIngreso";
            lblFechaIngreso.Size = new Size(119, 21);
            lblFechaIngreso.TabIndex = 25;
            lblFechaIngreso.Text = "Fecha Ingreso:";
            // 
            // lblNumHabitacion
            // 
            lblNumHabitacion.AutoSize = true;
            lblNumHabitacion.BackColor = Color.DarkGray;
            lblNumHabitacion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNumHabitacion.Location = new Point(351, 167);
            lblNumHabitacion.Name = "lblNumHabitacion";
            lblNumHabitacion.Size = new Size(121, 21);
            lblNumHabitacion.TabIndex = 26;
            lblNumHabitacion.Text = "N° Habitación:";
            // 
            // dateTimeFechaIngreso
            // 
            dateTimeFechaIngreso.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeFechaIngreso.Format = DateTimePickerFormat.Custom;
            dateTimeFechaIngreso.Location = new Point(489, 125);
            dateTimeFechaIngreso.Name = "dateTimeFechaIngreso";
            dateTimeFechaIngreso.Size = new Size(222, 25);
            dateTimeFechaIngreso.TabIndex = 27;
            dateTimeFechaIngreso.Value = new DateTime(2023, 10, 16, 19, 1, 23, 0);
            // 
            // txtNumHabitacion
            // 
            txtNumHabitacion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumHabitacion.Location = new Point(489, 165);
            txtNumHabitacion.Name = "txtNumHabitacion";
            txtNumHabitacion.Size = new Size(222, 25);
            txtNumHabitacion.TabIndex = 28;
            // 
            // FormPacienteHospitalizado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtNumHabitacion);
            Controls.Add(dateTimeFechaIngreso);
            Controls.Add(lblNumHabitacion);
            Controls.Add(lblFechaIngreso);
            Controls.Add(lblIngreso);
            Name = "FormPacienteHospitalizado";
            Text = "FormPacienteHospitalizado";
            Load += FormPacienteHospitalizado_Load;
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtApellido, 0);
            Controls.SetChildIndex(txtEdad, 0);
            Controls.SetChildIndex(txtDni, 0);
            Controls.SetChildIndex(txtCobertura, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(lblIngreso, 0);
            Controls.SetChildIndex(lblFechaIngreso, 0);
            Controls.SetChildIndex(lblNumHabitacion, 0);
            Controls.SetChildIndex(dateTimeFechaIngreso, 0);
            Controls.SetChildIndex(txtNumHabitacion, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIngreso;
        private Label lblFechaIngreso;
        private Label lblNumHabitacion;
        private DateTimePicker dateTimeFechaIngreso;
        protected TextBox txtNumHabitacion;
    }
}