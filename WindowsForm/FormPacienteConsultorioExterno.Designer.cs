namespace WindowsForm
{
    partial class FormPacienteConsultorioExterno
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
            lblFechaTurno = new Label();
            dateTimeFechaTurno = new DateTimePicker();
            lblEspecialidad = new Label();
            cboEspecialidad = new ComboBox();
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
            lblIngreso.Location = new Point(416, 80);
            lblIngreso.Name = "lblIngreso";
            lblIngreso.Size = new Size(272, 21);
            lblIngreso.TabIndex = 23;
            lblIngreso.Text = "Ingresado por Consultorio Externo";
            // 
            // lblFechaTurno
            // 
            lblFechaTurno.AutoSize = true;
            lblFechaTurno.BackColor = Color.DarkGray;
            lblFechaTurno.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFechaTurno.Location = new Point(366, 125);
            lblFechaTurno.Name = "lblFechaTurno";
            lblFechaTurno.Size = new Size(106, 21);
            lblFechaTurno.TabIndex = 17;
            lblFechaTurno.Text = "Fecha Turno:";
            // 
            // dateTimeFechaTurno
            // 
            dateTimeFechaTurno.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeFechaTurno.Format = DateTimePickerFormat.Custom;
            dateTimeFechaTurno.Location = new Point(489, 125);
            dateTimeFechaTurno.Name = "dateTimeFechaTurno";
            dateTimeFechaTurno.Size = new Size(222, 25);
            dateTimeFechaTurno.TabIndex = 18;
            dateTimeFechaTurno.Value = new DateTime(2023, 10, 16, 19, 1, 23, 0);
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.BackColor = Color.DarkGray;
            lblEspecialidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblEspecialidad.Location = new Point(362, 167);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(110, 21);
            lblEspecialidad.TabIndex = 24;
            lblEspecialidad.Text = "Especialidad:";
            // 
            // cboEspecialidad
            // 
            cboEspecialidad.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboEspecialidad.FormattingEnabled = true;
            cboEspecialidad.Location = new Point(489, 165);
            cboEspecialidad.Name = "cboEspecialidad";
            cboEspecialidad.Size = new Size(222, 25);
            cboEspecialidad.TabIndex = 25;
            // 
            // FormPacienteConsultorioExterno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboEspecialidad);
            Controls.Add(lblEspecialidad);
            Controls.Add(dateTimeFechaTurno);
            Controls.Add(lblFechaTurno);
            Controls.Add(lblIngreso);
            Name = "FormPacienteConsultorioExterno";
            Text = "Form1";
            Load += FormPacienteConsultorioExterno_Load;
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtApellido, 0);
            Controls.SetChildIndex(txtEdad, 0);
            Controls.SetChildIndex(txtDni, 0);
            Controls.SetChildIndex(txtCobertura, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(lblIngreso, 0);
            Controls.SetChildIndex(lblFechaTurno, 0);
            Controls.SetChildIndex(dateTimeFechaTurno, 0);
            Controls.SetChildIndex(lblEspecialidad, 0);
            Controls.SetChildIndex(cboEspecialidad, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIngreso;
        private Label lblFechaTurno;
        private DateTimePicker dateTimeFechaTurno;
        private Label lblEspecialidad;
        private ComboBox cboEspecialidad;
    }
}