namespace WindowsForm
{
    partial class FormPrincipalPacientes
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
            lstPacientes = new ListBox();
            lblOrdenItem = new Label();
            lblOrdenManera = new Label();
            cboOrdenTipo = new ComboBox();
            cboOrdenManera = new ComboBox();
            btnModificar = new Button();
            btnEliminar = new Button();
            lblIngresoPaciente = new Label();
            cboIngresoPaciente = new ComboBox();
            lblUsuario = new Label();
            lblDetalles = new Label();
            lblDatosUsuario = new Label();
            saveFileDialog1 = new SaveFileDialog();
            progressBar = new ProgressBar();
            lblFechaHoraActual = new Label();
            btnAgregar = new Button();
            btnOrdenar = new Button();
            btnGuardarArchivo = new Button();
            SuspendLayout();
            // 
            // lstPacientes
            // 
            lstPacientes.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lstPacientes.FormattingEnabled = true;
            lstPacientes.Location = new Point(130, 72);
            lstPacientes.Name = "lstPacientes";
            lstPacientes.Size = new Size(675, 420);
            lstPacientes.TabIndex = 1;
            // 
            // lblOrdenItem
            // 
            lblOrdenItem.AutoSize = true;
            lblOrdenItem.BackColor = Color.DarkGray;
            lblOrdenItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrdenItem.Location = new Point(816, 201);
            lblOrdenItem.Name = "lblOrdenItem";
            lblOrdenItem.Size = new Size(88, 19);
            lblOrdenItem.TabIndex = 2;
            lblOrdenItem.Text = "Ordenar por:";
            // 
            // lblOrdenManera
            // 
            lblOrdenManera.AutoSize = true;
            lblOrdenManera.BackColor = SystemColors.AppWorkspace;
            lblOrdenManera.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrdenManera.Location = new Point(816, 262);
            lblOrdenManera.Name = "lblOrdenManera";
            lblOrdenManera.Size = new Size(132, 19);
            lblOrdenManera.TabIndex = 3;
            lblOrdenManera.Text = "Ordenar de manera:";
            // 
            // cboOrdenTipo
            // 
            cboOrdenTipo.BackColor = SystemColors.GradientActiveCaption;
            cboOrdenTipo.FlatStyle = FlatStyle.Flat;
            cboOrdenTipo.FormattingEnabled = true;
            cboOrdenTipo.Items.AddRange(new object[] { "Nombre", "DNI" });
            cboOrdenTipo.Location = new Point(816, 223);
            cboOrdenTipo.Name = "cboOrdenTipo";
            cboOrdenTipo.Size = new Size(141, 23);
            cboOrdenTipo.TabIndex = 4;
            // 
            // cboOrdenManera
            // 
            cboOrdenManera.BackColor = SystemColors.GradientActiveCaption;
            cboOrdenManera.FlatStyle = FlatStyle.Flat;
            cboOrdenManera.FormattingEnabled = true;
            cboOrdenManera.Items.AddRange(new object[] { "Ascendente", "Descendente" });
            cboOrdenManera.Location = new Point(816, 284);
            cboOrdenManera.Name = "cboOrdenManera";
            cboOrdenManera.Size = new Size(141, 23);
            cboOrdenManera.TabIndex = 5;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.GradientActiveCaption;
            btnModificar.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnModificar.Location = new Point(22, 182);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(86, 35);
            btnModificar.TabIndex = 8;
            btnModificar.Text = " Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.GradientActiveCaption;
            btnEliminar.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.Location = new Point(22, 242);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 35);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblIngresoPaciente
            // 
            lblIngresoPaciente.AutoSize = true;
            lblIngresoPaciente.BackColor = Color.DarkGray;
            lblIngresoPaciente.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblIngresoPaciente.Location = new Point(22, 27);
            lblIngresoPaciente.Name = "lblIngresoPaciente";
            lblIngresoPaciente.Size = new Size(152, 19);
            lblIngresoPaciente.TabIndex = 13;
            lblIngresoPaciente.Text = "Paciente ingresado por:";
            // 
            // cboIngresoPaciente
            // 
            cboIngresoPaciente.BackColor = SystemColors.GradientActiveCaption;
            cboIngresoPaciente.FlatStyle = FlatStyle.Flat;
            cboIngresoPaciente.FormattingEnabled = true;
            cboIngresoPaciente.Items.AddRange(new object[] { "Urgencias", "Consultorios Externos", "Hospitalización" });
            cboIngresoPaciente.Location = new Point(191, 27);
            cboIngresoPaciente.Name = "cboIngresoPaciente";
            cboIngresoPaciente.Size = new Size(146, 23);
            cboIngresoPaciente.TabIndex = 15;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BorderStyle = BorderStyle.FixedSingle;
            lblUsuario.FlatStyle = FlatStyle.Flat;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.Location = new Point(557, 9);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Padding = new Padding(3);
            lblUsuario.Size = new Size(54, 23);
            lblUsuario.TabIndex = 17;
            lblUsuario.Text = "usuario";
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDetalles.Location = new Point(816, 104);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(115, 15);
            lblDetalles.TabIndex = 19;
            lblDetalles.Text = "Ver Detalles Paciente";
            lblDetalles.Click += lblDetalles_Click;
            lblDetalles.MouseLeave += lblDetalles_MouseLeave;
            lblDetalles.MouseMove += lblDetalles_MouseMove;
            // 
            // lblDatosUsuario
            // 
            lblDatosUsuario.AutoSize = true;
            lblDatosUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatosUsuario.Location = new Point(557, 45);
            lblDatosUsuario.Name = "lblDatosUsuario";
            lblDatosUsuario.Size = new Size(118, 15);
            lblDatosUsuario.TabIndex = 21;
            lblDatosUsuario.Text = "Ver Historial Usuarios";
            lblDatosUsuario.Click += lblDatosUsuario_Click;
            lblDatosUsuario.MouseLeave += lblDatosUsuario_MouseLeave;
            lblDatosUsuario.MouseMove += lblDatosUsuario_MouseMove;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.Black;
            progressBar.ForeColor = SystemColors.GradientActiveCaption;
            progressBar.Location = new Point(418, 217);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(112, 29);
            progressBar.TabIndex = 25;
            // 
            // lblFechaHoraActual
            // 
            lblFechaHoraActual.AutoSize = true;
            lblFechaHoraActual.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaHoraActual.Location = new Point(12, 354);
            lblFechaHoraActual.Name = "lblFechaHoraActual";
            lblFechaHoraActual.Size = new Size(104, 15);
            lblFechaHoraActual.TabIndex = 29;
            lblFechaHoraActual.Text = "Fecha Hora Actual";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.GradientActiveCaption;
            btnAgregar.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAgregar.Location = new Point(22, 118);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 35);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnOrdenar
            // 
            btnOrdenar.BackColor = SystemColors.GradientActiveCaption;
            btnOrdenar.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnOrdenar.FlatStyle = FlatStyle.Flat;
            btnOrdenar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOrdenar.Location = new Point(839, 334);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(86, 35);
            btnOrdenar.TabIndex = 23;
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = false;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // btnGuardarArchivo
            // 
            btnGuardarArchivo.BackColor = SystemColors.GradientActiveCaption;
            btnGuardarArchivo.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnGuardarArchivo.FlatStyle = FlatStyle.Flat;
            btnGuardarArchivo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardarArchivo.Location = new Point(839, 423);
            btnGuardarArchivo.Name = "btnGuardarArchivo";
            btnGuardarArchivo.Size = new Size(88, 24);
            btnGuardarArchivo.TabIndex = 27;
            btnGuardarArchivo.Text = "Guardar Lista";
            btnGuardarArchivo.UseVisualStyleBackColor = false;
            btnGuardarArchivo.Click += btnGuardarArchivo_Click;
            // 
            // FormPrincipalPacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(978, 523);
            Controls.Add(lblFechaHoraActual);
            Controls.Add(btnGuardarArchivo);
            Controls.Add(progressBar);
            Controls.Add(btnOrdenar);
            Controls.Add(lblDatosUsuario);
            Controls.Add(lblDetalles);
            Controls.Add(lblUsuario);
            Controls.Add(cboIngresoPaciente);
            Controls.Add(lblIngresoPaciente);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(cboOrdenManera);
            Controls.Add(cboOrdenTipo);
            Controls.Add(lblOrdenManera);
            Controls.Add(lblOrdenItem);
            Controls.Add(lstPacientes);
            IsMdiContainer = true;
            Name = "FormPrincipalPacientes";
            Text = "Gestión de Pacientes";
            FormClosing += FormPrincipalPacientes_FormClosing;
            Load += FormPrincipalPacientes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstPacientes;
        private Label lblOrdenItem;
        private Label lblOrdenManera;
        private ComboBox cboOrdenTipo;
        private ComboBox cboOrdenManera;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnOrdenar;
        private Button btnGuardarArchivo;
        private Label lblIngresoPaciente;
        private ComboBox cboIngresoPaciente;
        private Label lblUsuario;
        private Label lblDetalles;
        private Label lblDatosUsuario;
        private SaveFileDialog saveFileDialog1;
        private ProgressBar progressBar;
        private Label lblFechaHoraActual;
    }
}