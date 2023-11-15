namespace WindowsForm
{
    partial class FormLogin : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblBienvenido = new Label();
            txtCorreo = new TextBox();
            txtClave = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblBienvenido.ForeColor = SystemColors.ButtonHighlight;
            lblBienvenido.Location = new Point(87, 34);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(161, 37);
            lblBienvenido.TabIndex = 0;
            lblBienvenido.Text = "Bienvenido";
            lblBienvenido.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtCorreo.ForeColor = SystemColors.ControlDarkDark;
            txtCorreo.Location = new Point(40, 100);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Correo electrónico";
            txtCorreo.Size = new Size(258, 25);
            txtCorreo.TabIndex = 1;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.ForeColor = SystemColors.ControlDarkDark;
            txtClave.Location = new Point(40, 142);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Contraseña";
            txtClave.Size = new Size(258, 25);
            txtClave.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveCaption;
            btnLogin.FlatAppearance.BorderColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(87, 220);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(161, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(343, 338);
            Controls.Add(btnLogin);
            Controls.Add(txtClave);
            Controls.Add(txtCorreo);
            Controls.Add(lblBienvenido);
            Name = "FormLogin";
            Text = "Usuario Login";
            Load += FormLogin_Load;
            FormClosing += FormLogin_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenido;
        private TextBox txtCorreo;
        private TextBox txtClave;
        private Button btnLogin;
    }
}