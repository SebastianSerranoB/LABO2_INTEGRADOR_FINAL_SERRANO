using EntidadesAgencia;
using EntidadesAgencia.Archivos;
using EntidadesAgencia.BaseDeDatos;
using EntidadesAgencia.Excepciones;
using System.Text;
using System.Threading;

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

            try
            {
                this.agencia = new AgenciaViajes();

                this.formularioAltaCliente = new FrmAltaCliente(agencia, this);
                this.formularioHistorialDeVentas = new FrmHistorialDeVentas(agencia, this);
                this.formularioListaClientes = new FrmListaClientes(agencia, this);

                this.adoPasajeros = new ADOPasajeros();
                this.adoReservas = new ADOReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al instanciar formularios", MessageBoxButtons.OK);
            }


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

                this.CargarListaEnSegundoPlano();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer base de datos.", MessageBoxButtons.OK);
                MessageBox.Show("String connection por defecto en clases ADOPasajeros y ADOReservas " +
                                    ":Server=.;Database=INTEGRADOR_AgenciaTurismo_DB;Trusted_Connection=True;", "Por favor modifique el atributo stringConnection", MessageBoxButtons.OK);

            }


        }

        /// <summary>
        /// Inicia una tarea en segundo plano(hilo,thread) para validar los registros de la agencia de viajes.
        /// </summary>
        private void CargarListaEnSegundoPlano()
        {
            Thread tareaSecundaria = new Thread(ValidarRegistrosDeAgenciaViajes);
            tareaSecundaria.Start();
        }

        /// <summary>
        /// Método que valida los registros de pasajeros y reservas de la agencia de viajes en segundo plano.
        /// Muestra un mensaje indicando el proceso y los resultados obtenidos.
        /// </summary>
        private void ValidarRegistrosDeAgenciaViajes()
        {
            StringBuilder sb = new StringBuilder();

            Thread.Sleep(3000);
            MessageBox.Show("Se estan cargando registros de pasajeros en segundo plano...");

            if (this.agencia.Pasajeros is not null && this.agencia.Reservas is not null)
            {
                sb.AppendLine("Registro de pasajeros cargado con exito.");


                sb.AppendLine($"Existen {this.agencia.Pasajeros.Count} pasajeros en lista.");
                sb.AppendLine($"Existen {this.agencia.Reservas.Count} reservas registradas.");
                sb.AppendLine($"Desde el menu principal, puede acceder a Registro de Pasajeros y Registro de Reservas para verlos.");
            }
            else
            {
                sb.AppendLine("No se pudo cargar el registro de pasajeros.");
            }

            Thread.Sleep(5000);

            this.MostrarLabelExito();

            MessageBox.Show(sb.ToString(), "Tarea en segundo plano finalizada.");
        }


        /// <summary>
        /// Muestra un mensaje de éxito en un label de el formulario Menu Principal,cuando se carga el registro de pasajeros.
        /// </summary>
        private void MostrarLabelExito()
        {

            if (this.lblCargaDeRegistros.InvokeRequired)
            {
                Action mostrarExito = () =>
                {
                    this.lblCargaDeRegistros.Visible = true;
                    this.lblCargaDeRegistros.Text = "Registro de pasajeros cargado.";
                };
                this.Invoke(mostrarExito);
            }
            else
            {
                this.lblCargaDeRegistros.Visible = true;
                this.lblCargaDeRegistros.Text = "Registro de pasajeros cargado";
            }

        }



        private void btnSalirApp_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show($"¿Desea salir de la aplicacion?", "Salir", MessageBoxButtons.YesNo);

            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No pudo cerrarse la aplicacion.");
            }



        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                GestorArchivosAgencia.GuardarPasajerosEnArchivo(this.agencia.Pasajeros, "registroPasajeros");
                GestorArchivosAgencia.GuardarReservasEnArchivo(this.agencia.Reservas, "registroReservas");
            }
            catch(Exception ex)
            {
                throw new ManejoDeArchivosException("Error al guardar archivos.",ex);
            }
            
        }




    }
}