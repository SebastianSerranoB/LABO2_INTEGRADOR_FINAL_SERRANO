using EntidadesAgencia;
using EntidadesAgencia.Archivos;
using EntidadesAgencia.BaseDeDatos;

namespace FrmVista
{
    public partial class FrmMenuPrincipal : Form
    {
        FrmAltaCliente formularioAltaCliente;
        FrmHistorialDeVentas formularioHistorialDeVentas;
        FrmListaClientes formularioListaClientes;
        AgenciaViajes agencia;

        ADOPasajeros adoPasajeros;
        ADOReservas adoReservas;

        public FrmMenuPrincipal()
        {
            InitializeComponent();

            this.agencia = new AgenciaViajes();

            this.formularioAltaCliente = new FrmAltaCliente(agencia, this);
            this.formularioHistorialDeVentas = new FrmHistorialDeVentas(agencia, this);
            this.formularioListaClientes = new FrmListaClientes(agencia, this);

            this.adoPasajeros = new ADOPasajeros();
            this.adoReservas = new ADOReservas();

        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formularioAltaCliente.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formularioHistorialDeVentas.Show();
        }

        private void btnListaClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formularioListaClientes.Show();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this.agencia.Pasajeros = this.adoPasajeros.ObtenerTodosLosElementos();
                this.agencia.Reservas = this.adoReservas.ObtenerTodosLosElementos();

                GestorArchivosAgencia.GuardarPasajerosEnArchivo(this.agencia.Pasajeros, "registroPasajeros");
                GestorArchivosAgencia.GuardarReservasEnArchivo(this.agencia.Reservas, "registroReservas");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer base de datos.", MessageBoxButtons.OK);
                MessageBox.Show("String connection por defecto en clases ADOPasajeros y ADOReservas " +
                                    ":Server=.;Database=INTEGRADOR_AgenciaTurismo_DB;Trusted_Connection=True;", "Por favor modifique el atributo stringConnection", MessageBoxButtons.OK);

            }


        }

        private void btnSalirApp_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show($"¿Desea salir de la aplicacion?" ,"Salir",MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }

                
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorArchivosAgencia.GuardarPasajerosEnArchivo(this.agencia.Pasajeros, "registroPasajeros");
            GestorArchivosAgencia.GuardarReservasEnArchivo(this.agencia.Reservas, "registroReservas");
        }
   
    
    
    
    }
}