namespace WindowsForm
{
    partial class FormPacienteUrgencia
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
            lblFechaIngreso = new Label();
            dateTimeFechaIngreso = new DateTimePicker();
            lblEspecialidad = new Label();
            cboEspecialidad = new ComboBox();
            lblIngreso = new Label();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 192, 255);
            // 
            // lblFechaIngreso
            // 
            lblFechaIngreso.AutoSize = true;
            lblFechaIngreso.BackColor = Color.DarkGray;
            lblFechaIngreso.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFechaIngreso.Location = new Point(353, 125);
            lblFechaIngreso.Name = "lblFechaIngreso";
            lblFechaIngreso.Size = new Size(119, 21);
            lblFechaIngreso.TabIndex = 17;
            lblFechaIngreso.Text = "Fecha Ingreso:";
            // 
            // dateTimeFechaIngreso
            // 
            dateTimeFechaIngreso.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeFechaIngreso.Format = DateTimePickerFormat.Custom;
            dateTimeFechaIngreso.Location = new Point(489, 125);
            dateTimeFechaIngreso.Name = "dateTimeFechaIngreso";
            dateTimeFechaIngreso.Size = new Size(222, 25);
            dateTimeFechaIngreso.TabIndex = 18;
            dateTimeFechaIngreso.Value = new DateTime(2023, 10, 16, 19, 1, 23, 0);
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.BackColor = Color.DarkGray;
            lblEspecialidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblEspecialidad.Location = new Point(362, 167);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(110, 21);
            lblEspecialidad.TabIndex = 19;
            lblEspecialidad.Text = "Especialidad:";
            // 
            // cboEspecialidad
            // 
            cboEspecialidad.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboEspecialidad.FormattingEnabled = true;
            cboEspecialidad.Location = new Point(489, 165);
            cboEspecialidad.Name = "cboEspecialidad";
            cboEspecialidad.Size = new Size(222, 25);
            cboEspecialidad.TabIndex = 20;
            // 
            // lblIngreso
            // 
            lblIngreso.AutoSize = true;
            lblIngreso.BackColor = Color.DarkGray;
            lblIngreso.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblIngreso.Location = new Point(441, 80);
            lblIngreso.Name = "lblIngreso";
            lblIngreso.Size = new Size(196, 21);
            lblIngreso.TabIndex = 23;
            lblIngreso.Text = "Ingresado por Urgencias";
            // 
            // FormPacienteUrgencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 441);
            Controls.Add(lblIngreso);
            Controls.Add(cboEspecialidad);
            Controls.Add(lblEspecialidad);
            Controls.Add(dateTimeFechaIngreso);
            Controls.Add(lblFechaIngreso);
            Name = "FormPacienteUrgencia";
            Text = "Paciente Urgencias";
            Load += FormPacienteUrgencia_Load;
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtApellido, 0);
            Controls.SetChildIndex(txtEdad, 0);
            Controls.SetChildIndex(txtDni, 0);
            Controls.SetChildIndex(txtCobertura, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(lblFechaIngreso, 0);
            Controls.SetChildIndex(dateTimeFechaIngreso, 0);
            Controls.SetChildIndex(lblEspecialidad, 0);
            Controls.SetChildIndex(cboEspecialidad, 0);
            Controls.SetChildIndex(lblIngreso, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFechaIngreso;
        private DateTimePicker dateTimeFechaIngreso;
        private Label lblEspecialidad;
        private ComboBox cboEspecialidad;
        private Label lblIngreso;
    }
}