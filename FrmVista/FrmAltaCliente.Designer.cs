namespace FrmVista
{
    partial class FrmAltaCliente
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
            lblDni = new Label();
            txtNombreIngresado = new TextBox();
            txtApellidoIngresado = new TextBox();
            txtDniIngresado = new TextBox();
            grpPaquetes = new GroupBox();
            rdbOro = new RadioButton();
            rdbPlata = new RadioButton();
            rdbBronce = new RadioButton();
            btnAceptar = new Button();
            btn_MenuPrincipalDesdeAltaCliente = new Button();
            numericUpDownEdad = new NumericUpDown();
            lblEdad = new Label();
            btnDescripcionPaquetes = new Button();
            grpPaquetes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEdad).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(101, 122);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(271, 122);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(448, 122);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(27, 15);
            lblDni.TabIndex = 2;
            lblDni.Text = "DNI";
            // 
            // txtNombreIngresado
            // 
            txtNombreIngresado.Location = new Point(101, 163);
            txtNombreIngresado.MaxLength = 20;
            txtNombreIngresado.Name = "txtNombreIngresado";
            txtNombreIngresado.Size = new Size(133, 23);
            txtNombreIngresado.TabIndex = 3;
            // 
            // txtApellidoIngresado
            // 
            txtApellidoIngresado.Location = new Point(269, 163);
            txtApellidoIngresado.MaxLength = 20;
            txtApellidoIngresado.Name = "txtApellidoIngresado";
            txtApellidoIngresado.Size = new Size(133, 23);
            txtApellidoIngresado.TabIndex = 4;
            // 
            // txtDniIngresado
            // 
            txtDniIngresado.Location = new Point(448, 163);
            txtDniIngresado.MaxLength = 8;
            txtDniIngresado.Name = "txtDniIngresado";
            txtDniIngresado.Size = new Size(84, 23);
            txtDniIngresado.TabIndex = 5;
            // 
            // grpPaquetes
            // 
            grpPaquetes.Controls.Add(rdbOro);
            grpPaquetes.Controls.Add(rdbPlata);
            grpPaquetes.Controls.Add(rdbBronce);
            grpPaquetes.Location = new Point(271, 232);
            grpPaquetes.Name = "grpPaquetes";
            grpPaquetes.Size = new Size(200, 156);
            grpPaquetes.TabIndex = 6;
            grpPaquetes.TabStop = false;
            grpPaquetes.Text = "Paquetes";
            // 
            // rdbOro
            // 
            rdbOro.AutoSize = true;
            rdbOro.Location = new Point(25, 106);
            rdbOro.Name = "rdbOro";
            rdbOro.Size = new Size(45, 19);
            rdbOro.TabIndex = 2;
            rdbOro.TabStop = true;
            rdbOro.Text = "Oro";
            rdbOro.UseVisualStyleBackColor = true;
            // 
            // rdbPlata
            // 
            rdbPlata.AutoSize = true;
            rdbPlata.Location = new Point(25, 69);
            rdbPlata.Name = "rdbPlata";
            rdbPlata.Size = new Size(51, 19);
            rdbPlata.TabIndex = 1;
            rdbPlata.TabStop = true;
            rdbPlata.Text = "Plata";
            rdbPlata.UseVisualStyleBackColor = true;
            // 
            // rdbBronce
            // 
            rdbBronce.AutoSize = true;
            rdbBronce.Location = new Point(25, 30);
            rdbBronce.Name = "rdbBronce";
            rdbBronce.Size = new Size(62, 19);
            rdbBronce.TabIndex = 0;
            rdbBronce.TabStop = true;
            rdbBronce.Text = "Bronce";
            rdbBronce.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(559, 351);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(171, 23);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btn_MenuPrincipalDesdeAltaCliente
            // 
            btn_MenuPrincipalDesdeAltaCliente.Location = new Point(45, 351);
            btn_MenuPrincipalDesdeAltaCliente.Name = "btn_MenuPrincipalDesdeAltaCliente";
            btn_MenuPrincipalDesdeAltaCliente.Size = new Size(165, 23);
            btn_MenuPrincipalDesdeAltaCliente.TabIndex = 8;
            btn_MenuPrincipalDesdeAltaCliente.Text = "Menu Principal";
            btn_MenuPrincipalDesdeAltaCliente.UseVisualStyleBackColor = true;
            btn_MenuPrincipalDesdeAltaCliente.Click += btn_MenuPrincipalDesdeAltaCliente_Click;
            // 
            // numericUpDownEdad
            // 
            numericUpDownEdad.Location = new Point(583, 162);
            numericUpDownEdad.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownEdad.Name = "numericUpDownEdad";
            numericUpDownEdad.Size = new Size(55, 23);
            numericUpDownEdad.TabIndex = 9;
            numericUpDownEdad.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(583, 122);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(33, 15);
            lblEdad.TabIndex = 10;
            lblEdad.Text = "Edad";
            // 
            // btnDescripcionPaquetes
            // 
            btnDescripcionPaquetes.Location = new Point(285, 394);
            btnDescripcionPaquetes.Name = "btnDescripcionPaquetes";
            btnDescripcionPaquetes.Size = new Size(186, 23);
            btnDescripcionPaquetes.TabIndex = 11;
            btnDescripcionPaquetes.Text = "Descripcion de paquetes";
            btnDescripcionPaquetes.UseVisualStyleBackColor = true;
            btnDescripcionPaquetes.Click += btnDescripcionPaquetes_Click;
            // 
            // FrmAltaCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btnDescripcionPaquetes);
            Controls.Add(lblEdad);
            Controls.Add(numericUpDownEdad);
            Controls.Add(btn_MenuPrincipalDesdeAltaCliente);
            Controls.Add(btnAceptar);
            Controls.Add(grpPaquetes);
            Controls.Add(txtDniIngresado);
            Controls.Add(txtApellidoIngresado);
            Controls.Add(txtNombreIngresado);
            Controls.Add(lblDni);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAltaCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alta Pasajero";
            Load += FrmAltaCliente_Load;
            grpPaquetes.ResumeLayout(false);
            grpPaquetes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEdad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private TextBox txtNombreIngresado;
        private TextBox txtApellidoIngresado;
        private TextBox txtDniIngresado;
        private GroupBox grpPaquetes;
        private RadioButton rdbOro;
        private RadioButton rdbPlata;
        private RadioButton rdbBronce;
        private Button btnAceptar;
        private Button btn_MenuPrincipalDesdeAltaCliente;
        private NumericUpDown numericUpDownEdad;
        private Label lblEdad;
        private Button btnDescripcionPaquetes;
    }
}