namespace FrmVista
{
    partial class FrmListaClientes
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
            lstListaClientes = new ListBox();
            btnMenuPrincipal = new Button();
            btnMostrarClientes = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            txtModificarNombre = new TextBox();
            txtModificarApellido = new TextBox();
            txtModificarDNI = new TextBox();
            lblModificarDNI = new Label();
            lblModificarNombre = new Label();
            lblModificarApellido = new Label();
            btnModificarPasajero = new Button();
            btnEliminarPasajero = new Button();
            btnLeerArchivo = new Button();
            txtNombreArchivo = new TextBox();
            lblNombreArchivo = new Label();
            SuspendLayout();
            // 
            // lstListaClientes
            // 
            lstListaClientes.FormattingEnabled = true;
            lstListaClientes.ItemHeight = 15;
            lstListaClientes.Location = new Point(214, 39);
            lstListaClientes.Name = "lstListaClientes";
            lstListaClientes.Size = new Size(569, 304);
            lstListaClientes.TabIndex = 0;
            // 
            // btnMenuPrincipal
            // 
            btnMenuPrincipal.Location = new Point(30, 402);
            btnMenuPrincipal.Name = "btnMenuPrincipal";
            btnMenuPrincipal.Size = new Size(185, 23);
            btnMenuPrincipal.TabIndex = 1;
            btnMenuPrincipal.Text = "Menu Principal";
            btnMenuPrincipal.UseVisualStyleBackColor = true;
            btnMenuPrincipal.Click += btnMenuPrincipal_Click;
            // 
            // btnMostrarClientes
            // 
            btnMostrarClientes.Location = new Point(408, 402);
            btnMostrarClientes.Name = "btnMostrarClientes";
            btnMostrarClientes.Size = new Size(197, 23);
            btnMostrarClientes.TabIndex = 2;
            btnMostrarClientes.Text = "Mostrar Clientes";
            btnMostrarClientes.UseVisualStyleBackColor = true;
            btnMostrarClientes.Click += btnMostrarClientes_Click;
            // 
            // txtModificarNombre
            // 
            txtModificarNombre.Location = new Point(879, 162);
            txtModificarNombre.MaxLength = 20;
            txtModificarNombre.Name = "txtModificarNombre";
            txtModificarNombre.Size = new Size(188, 23);
            txtModificarNombre.TabIndex = 3;
            // 
            // txtModificarApellido
            // 
            txtModificarApellido.Location = new Point(879, 206);
            txtModificarApellido.MaxLength = 20;
            txtModificarApellido.Name = "txtModificarApellido";
            txtModificarApellido.Size = new Size(188, 23);
            txtModificarApellido.TabIndex = 4;
            // 
            // txtModificarDNI
            // 
            txtModificarDNI.Location = new Point(926, 99);
            txtModificarDNI.MaxLength = 8;
            txtModificarDNI.Name = "txtModificarDNI";
            txtModificarDNI.Size = new Size(100, 23);
            txtModificarDNI.TabIndex = 6;
            // 
            // lblModificarDNI
            // 
            lblModificarDNI.AutoSize = true;
            lblModificarDNI.Location = new Point(937, 81);
            lblModificarDNI.Name = "lblModificarDNI";
            lblModificarDNI.Size = new Size(74, 15);
            lblModificarDNI.TabIndex = 7;
            lblModificarDNI.Text = "DNI pasajero";
            // 
            // lblModificarNombre
            // 
            lblModificarNombre.AutoSize = true;
            lblModificarNombre.Location = new Point(902, 144);
            lblModificarNombre.Name = "lblModificarNombre";
            lblModificarNombre.Size = new Size(87, 15);
            lblModificarNombre.TabIndex = 8;
            lblModificarNombre.Text = "Nuevo nombre";
            // 
            // lblModificarApellido
            // 
            lblModificarApellido.AutoSize = true;
            lblModificarApellido.Location = new Point(902, 188);
            lblModificarApellido.Name = "lblModificarApellido";
            lblModificarApellido.Size = new Size(87, 15);
            lblModificarApellido.TabIndex = 9;
            lblModificarApellido.Text = "Nuevo apellido";
            // 
            // btnModificarPasajero
            // 
            btnModificarPasajero.Location = new Point(879, 232);
            btnModificarPasajero.Name = "btnModificarPasajero";
            btnModificarPasajero.Size = new Size(188, 23);
            btnModificarPasajero.TabIndex = 10;
            btnModificarPasajero.Text = "Modificar";
            btnModificarPasajero.UseVisualStyleBackColor = true;
            btnModificarPasajero.Click += btnModificarPasajero_Click;
            // 
            // btnEliminarPasajero
            // 
            btnEliminarPasajero.Location = new Point(879, 287);
            btnEliminarPasajero.Name = "btnEliminarPasajero";
            btnEliminarPasajero.Size = new Size(188, 23);
            btnEliminarPasajero.TabIndex = 11;
            btnEliminarPasajero.Text = "Eliminar";
            btnEliminarPasajero.UseVisualStyleBackColor = true;
            btnEliminarPasajero.Click += btnEliminarPasajero_Click;
            // 
            // btnLeerArchivo
            // 
            btnLeerArchivo.Location = new Point(30, 119);
            btnLeerArchivo.Name = "btnLeerArchivo";
            btnLeerArchivo.Size = new Size(140, 23);
            btnLeerArchivo.TabIndex = 12;
            btnLeerArchivo.Text = "Cargar archivo";
            btnLeerArchivo.UseVisualStyleBackColor = true;
            btnLeerArchivo.Click += btnLeerArchivo_Click;
            // 
            // txtNombreArchivo
            // 
            txtNombreArchivo.Location = new Point(30, 90);
            txtNombreArchivo.MaxLength = 50;
            txtNombreArchivo.Name = "txtNombreArchivo";
            txtNombreArchivo.Size = new Size(140, 23);
            txtNombreArchivo.TabIndex = 13;
            txtNombreArchivo.Text = "registroPasajeros";
            // 
            // lblNombreArchivo
            // 
            lblNombreArchivo.AutoSize = true;
            lblNombreArchivo.Location = new Point(30, 67);
            lblNombreArchivo.Name = "lblNombreArchivo";
            lblNombreArchivo.Size = new Size(93, 15);
            lblNombreArchivo.TabIndex = 14;
            lblNombreArchivo.Text = "Nombre archivo";
            // 
            // FrmListaClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 450);
            ControlBox = false;
            Controls.Add(lblNombreArchivo);
            Controls.Add(txtNombreArchivo);
            Controls.Add(btnLeerArchivo);
            Controls.Add(btnEliminarPasajero);
            Controls.Add(btnModificarPasajero);
            Controls.Add(lblModificarApellido);
            Controls.Add(lblModificarNombre);
            Controls.Add(lblModificarDNI);
            Controls.Add(txtModificarDNI);
            Controls.Add(txtModificarApellido);
            Controls.Add(txtModificarNombre);
            Controls.Add(btnMostrarClientes);
            Controls.Add(btnMenuPrincipal);
            Controls.Add(lstListaClientes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmListaClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de pasajeros";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstListaClientes;
        private Button btnMenuPrincipal;
        private Button btnMostrarClientes;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox txtModificarNombre;
        private TextBox txtModificarApellido;
        private TextBox txtModificarDNI;
        private Label lblModificarDNI;
        private Label lblModificarNombre;
        private Label lblModificarApellido;
        private Button btnModificarPasajero;
        private Button btnEliminarPasajero;
        private Button btnLeerArchivo;
        private TextBox txtNombreArchivo;
        private Label lblNombreArchivo;
    }
}