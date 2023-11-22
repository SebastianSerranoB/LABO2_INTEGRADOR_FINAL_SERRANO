namespace FrmVista
{
    partial class FrmHistorialDeVentas
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
            components = new System.ComponentModel.Container();
            lstHistorialVentas = new ListBox();
            btn_VolverMenuPrincipal = new Button();
            btn_MostrarHistorialVentas = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtEliminarReservaDNI = new TextBox();
            lblDniReserva = new Label();
            btnEliminarReserva = new Button();
            txtEliminarPaquete = new TextBox();
            lblTipoPaquete = new Label();
            btnLeerReservas = new Button();
            txtNombreArchivo = new TextBox();
            lblNombreArchivo = new Label();
            SuspendLayout();
            // 
            // lstHistorialVentas
            // 
            lstHistorialVentas.FormattingEnabled = true;
            lstHistorialVentas.ItemHeight = 15;
            lstHistorialVentas.Location = new Point(125, 40);
            lstHistorialVentas.Name = "lstHistorialVentas";
            lstHistorialVentas.Size = new Size(569, 319);
            lstHistorialVentas.TabIndex = 0;
            // 
            // btn_VolverMenuPrincipal
            // 
            btn_VolverMenuPrincipal.Location = new Point(32, 393);
            btn_VolverMenuPrincipal.Name = "btn_VolverMenuPrincipal";
            btn_VolverMenuPrincipal.Size = new Size(176, 23);
            btn_VolverMenuPrincipal.TabIndex = 1;
            btn_VolverMenuPrincipal.Text = "MenuPrincipal";
            btn_VolverMenuPrincipal.UseVisualStyleBackColor = true;
            btn_VolverMenuPrincipal.Click += btn_VolverMenuPrincipal_Click;
            // 
            // btn_MostrarHistorialVentas
            // 
            btn_MostrarHistorialVentas.Location = new Point(307, 393);
            btn_MostrarHistorialVentas.Name = "btn_MostrarHistorialVentas";
            btn_MostrarHistorialVentas.Size = new Size(179, 23);
            btn_MostrarHistorialVentas.TabIndex = 2;
            btn_MostrarHistorialVentas.Text = "Mostrar Historial";
            btn_MostrarHistorialVentas.UseVisualStyleBackColor = true;
            btn_MostrarHistorialVentas.Click += btn_MostrarHistorialVentas_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtEliminarReservaDNI
            // 
            txtEliminarReservaDNI.Location = new Point(858, 297);
            txtEliminarReservaDNI.MaxLength = 8;
            txtEliminarReservaDNI.Name = "txtEliminarReservaDNI";
            txtEliminarReservaDNI.Size = new Size(100, 23);
            txtEliminarReservaDNI.TabIndex = 7;
            // 
            // lblDniReserva
            // 
            lblDniReserva.AutoSize = true;
            lblDniReserva.Location = new Point(822, 300);
            lblDniReserva.Name = "lblDniReserva";
            lblDniReserva.Size = new Size(27, 15);
            lblDniReserva.TabIndex = 8;
            lblDniReserva.Text = "DNI";
            // 
            // btnEliminarReserva
            // 
            btnEliminarReserva.Location = new Point(822, 393);
            btnEliminarReserva.Name = "btnEliminarReserva";
            btnEliminarReserva.Size = new Size(177, 23);
            btnEliminarReserva.TabIndex = 9;
            btnEliminarReserva.Text = "Eliminar reserva";
            btnEliminarReserva.UseVisualStyleBackColor = true;
            btnEliminarReserva.Click += btnEliminarReserva_Click;
            // 
            // txtEliminarPaquete
            // 
            txtEliminarPaquete.Location = new Point(856, 364);
            txtEliminarPaquete.Name = "txtEliminarPaquete";
            txtEliminarPaquete.Size = new Size(102, 23);
            txtEliminarPaquete.TabIndex = 7;
            // 
            // lblTipoPaquete
            // 
            lblTipoPaquete.AutoSize = true;
            lblTipoPaquete.Location = new Point(822, 346);
            lblTipoPaquete.Name = "lblTipoPaquete";
            lblTipoPaquete.Size = new Size(193, 15);
            lblTipoPaquete.TabIndex = 11;
            lblTipoPaquete.Text = "Reserva de tipo: bronce, plata u oro";
            // 
            // btnLeerReservas
            // 
            btnLeerReservas.Location = new Point(822, 127);
            btnLeerReservas.Name = "btnLeerReservas";
            btnLeerReservas.Size = new Size(161, 23);
            btnLeerReservas.TabIndex = 12;
            btnLeerReservas.Text = "Cargar archivo";
            btnLeerReservas.UseVisualStyleBackColor = true;
            btnLeerReservas.Click += btnLeerReservas_Click;
            // 
            // txtNombreArchivo
            // 
            txtNombreArchivo.Location = new Point(822, 100);
            txtNombreArchivo.MaxLength = 50;
            txtNombreArchivo.Name = "txtNombreArchivo";
            txtNombreArchivo.Size = new Size(161, 23);
            txtNombreArchivo.TabIndex = 13;
            txtNombreArchivo.Text = "registroReservas";
            // 
            // lblNombreArchivo
            // 
            lblNombreArchivo.AutoSize = true;
            lblNombreArchivo.Location = new Point(826, 79);
            lblNombreArchivo.Name = "lblNombreArchivo";
            lblNombreArchivo.Size = new Size(93, 15);
            lblNombreArchivo.TabIndex = 14;
            lblNombreArchivo.Text = "Nombre archivo";
            // 
            // FrmHistorialDeVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 450);
            ControlBox = false;
            Controls.Add(lblNombreArchivo);
            Controls.Add(txtNombreArchivo);
            Controls.Add(btnLeerReservas);
            Controls.Add(lblTipoPaquete);
            Controls.Add(txtEliminarPaquete);
            Controls.Add(btnEliminarReserva);
            Controls.Add(lblDniReserva);
            Controls.Add(txtEliminarReservaDNI);
            Controls.Add(btn_MostrarHistorialVentas);
            Controls.Add(btn_VolverMenuPrincipal);
            Controls.Add(lstHistorialVentas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmHistorialDeVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reservas registradas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstHistorialVentas;
        private Button btn_VolverMenuPrincipal;
        private Button btn_MostrarHistorialVentas;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtEliminarReservaDNI;
        private Label lblDniReserva;
        private Button btnEliminarReserva;
        private TextBox txtEliminarPaquete;
        private Label lblTipoPaquete;
        private Button btnLeerReservas;
        private TextBox txtNombreArchivo;
        private Label lblNombreArchivo;
    }
}