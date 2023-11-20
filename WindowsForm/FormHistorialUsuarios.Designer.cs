namespace WindowsForm
{
    partial class FormHistorialUsuarios
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
            txtHistorialUsuarios = new TextBox();
            lblHistorialUsuarios = new Label();
            SuspendLayout();
            // 
            // txtHistorialUsuarios
            // 
            txtHistorialUsuarios.BackColor = SystemColors.ButtonHighlight;
            txtHistorialUsuarios.Location = new Point(24, 68);
            txtHistorialUsuarios.Multiline = true;
            txtHistorialUsuarios.Name = "txtHistorialUsuarios";
            txtHistorialUsuarios.ReadOnly = true;
            txtHistorialUsuarios.ScrollBars = ScrollBars.Vertical;
            txtHistorialUsuarios.Size = new Size(514, 340);
            txtHistorialUsuarios.TabIndex = 0;
            // 
            // lblHistorialUsuarios
            // 
            lblHistorialUsuarios.AutoSize = true;
            lblHistorialUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHistorialUsuarios.Location = new Point(24, 30);
            lblHistorialUsuarios.Name = "lblHistorialUsuarios";
            lblHistorialUsuarios.Size = new Size(255, 21);
            lblHistorialUsuarios.TabIndex = 1;
            lblHistorialUsuarios.Text = "Historial de Usuarios Logueados";
            // 
            // FormHistorialUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(565, 450);
            Controls.Add(lblHistorialUsuarios);
            Controls.Add(txtHistorialUsuarios);
            ForeColor = SystemColors.ControlText;
            IsMdiContainer = true;
            Name = "FormHistorialUsuarios";
            Text = "Historial de Usuarios";
            Load += FormHistorialUsuarios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtHistorialUsuarios;
        private Label lblHistorialUsuarios;
    }
}