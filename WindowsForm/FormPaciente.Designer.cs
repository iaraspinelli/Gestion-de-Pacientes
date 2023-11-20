namespace WindowsForm
{
    partial class FormPaciente
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
            lblNombre = new Label();
            lblApellido = new Label();
            lblEdad = new Label();
            lblDni = new Label();
            lblCobertura = new Label();
            txtNombre = new TextBox();
            txtCobertura = new TextBox();
            txtDni = new TextBox();
            txtEdad = new TextBox();
            txtApellido = new TextBox();
            lblDatosPaciente = new Label();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.DarkGray;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.Location = new Point(50, 84);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(77, 21);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.BackColor = Color.DarkGray;
            lblApellido.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblApellido.Location = new Point(48, 125);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(79, 21);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.BackColor = Color.DarkGray;
            lblEdad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblEdad.Location = new Point(75, 167);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(52, 21);
            lblEdad.TabIndex = 2;
            lblEdad.Text = "Edad:";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.BackColor = Color.DarkGray;
            lblDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDni.Location = new Point(83, 208);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(44, 21);
            lblDni.TabIndex = 3;
            lblDni.Text = "DNI:";
            // 
            // lblCobertura
            // 
            lblCobertura.AutoSize = true;
            lblCobertura.BackColor = Color.DarkGray;
            lblCobertura.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCobertura.Location = new Point(37, 250);
            lblCobertura.Name = "lblCobertura";
            lblCobertura.Size = new Size(90, 21);
            lblCobertura.TabIndex = 4;
            lblCobertura.Text = "Cobertura:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(142, 80);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(197, 25);
            txtNombre.TabIndex = 5;
            // 
            // txtCobertura
            // 
            txtCobertura.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtCobertura.Location = new Point(142, 246);
            txtCobertura.Name = "txtCobertura";
            txtCobertura.Size = new Size(197, 25);
            txtCobertura.TabIndex = 9;
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDni.Location = new Point(142, 204);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(197, 25);
            txtDni.TabIndex = 8;
            // 
            // txtEdad
            // 
            txtEdad.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtEdad.Location = new Point(142, 163);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(197, 25);
            txtEdad.TabIndex = 7;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.Location = new Point(142, 121);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(197, 25);
            txtApellido.TabIndex = 6;
            // 
            // lblDatosPaciente
            // 
            lblDatosPaciente.AutoSize = true;
            lblDatosPaciente.BackColor = Color.DarkGray;
            lblDatosPaciente.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblDatosPaciente.Location = new Point(290, 23);
            lblDatosPaciente.Name = "lblDatosPaciente";
            lblDatosPaciente.Size = new Size(143, 25);
            lblDatosPaciente.TabIndex = 10;
            lblDatosPaciente.Text = "Datos Paciente";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.GradientActiveCaption;
            btnAceptar.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 192, 255);
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptar.Location = new Point(322, 318);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(111, 37);
            btnAceptar.TabIndex = 13;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FormPaciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(773, 441);
            Controls.Add(btnAceptar);
            Controls.Add(lblDatosPaciente);
            Controls.Add(txtCobertura);
            Controls.Add(txtDni);
            Controls.Add(txtEdad);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblCobertura);
            Controls.Add(lblDni);
            Controls.Add(lblEdad);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            IsMdiContainer = true;
            Name = "FormPaciente";
            Text = "Paciente";
            Load += FormPaciente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDatosPaciente;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblEdad;
        private Label lblDni;
        private Label lblCobertura;
        protected TextBox txtNombre;
        protected TextBox txtCobertura;
        protected TextBox txtDni;
        protected TextBox txtEdad;
        protected TextBox txtApellido;
        protected Button btnAceptar;
    }
}