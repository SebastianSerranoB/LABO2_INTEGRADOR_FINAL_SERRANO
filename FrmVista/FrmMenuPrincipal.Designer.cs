namespace FrmVista
{
    partial class FrmMenuPrincipal
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
            btnAtender = new Button();
            btnVentas = new Button();
            btnListaClientes = new Button();
            btnSalirApp = new Button();
            lblCargaDeRegistros = new Label();
            SuspendLayout();
            // 
            // btnAtender
            // 
            btnAtender.Location = new Point(271, 334);
            btnAtender.Name = "btnAtender";
            btnAtender.Size = new Size(214, 23);
            btnAtender.TabIndex = 0;
            btnAtender.Text = "Atender cliente";
            btnAtender.UseVisualStyleBackColor = true;
            btnAtender.Click += btnAtender_Click;
            // 
            // btnVentas
            // 
            btnVentas.Location = new Point(271, 66);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(214, 23);
            btnVentas.TabIndex = 1;
            btnVentas.Text = "Registro de reservas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnListaClientes
            // 
            btnListaClientes.Location = new Point(271, 95);
            btnListaClientes.Name = "btnListaClientes";
            btnListaClientes.Size = new Size(214, 23);
            btnListaClientes.TabIndex = 2;
            btnListaClientes.Text = "Registro de pasajeros";
            btnListaClientes.UseVisualStyleBackColor = true;
            btnListaClientes.Click += btnListaClientes_Click;
            // 
            // btnSalirApp
            // 
            btnSalirApp.Location = new Point(613, 404);
            btnSalirApp.Name = "btnSalirApp";
            btnSalirApp.Size = new Size(157, 23);
            btnSalirApp.TabIndex = 3;
            btnSalirApp.Text = "Salir";
            btnSalirApp.UseVisualStyleBackColor = true;
            btnSalirApp.Click += btnSalirApp_Click;
            // 
            // lblCargaDeRegistros
            // 
            lblCargaDeRegistros.AutoSize = true;
            lblCargaDeRegistros.ForeColor = SystemColors.InfoText;
            lblCargaDeRegistros.Location = new Point(23, 412);
            lblCargaDeRegistros.Name = "lblCargaDeRegistros";
            lblCargaDeRegistros.Size = new Size(0, 15);
            lblCargaDeRegistros.TabIndex = 4;
            lblCargaDeRegistros.Visible = false;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(lblCargaDeRegistros);
            Controls.Add(btnSalirApp);
            Controls.Add(btnListaClientes);
            Controls.Add(btnVentas);
            Controls.Add(btnAtender);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal";
            FormClosing += FrmMenuPrincipal_FormClosing;
            Load += FrmMenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAtender;
        private Button btnVentas;
        private Button btnListaClientes;
        private Button btnSalirApp;
        private Label lblCargaDeRegistros;
    }
}