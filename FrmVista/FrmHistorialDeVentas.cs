using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesAgencia;
using EntidadesAgencia.Archivos;
using EntidadesAgencia.BaseDeDatos;
using EntidadesAgencia.Excepciones;
using EntidadesAgencia.MetodosDeExtension;

namespace FrmVista
{
    public partial class FrmHistorialDeVentas : Form
    {
        AgenciaViajes agencia;
        FrmMenuPrincipal formMenuPrincipal;

        public FrmHistorialDeVentas(AgenciaViajes agencia, FrmMenuPrincipal formMenuPrincipal)
        {
            InitializeComponent();
            this.agencia = agencia;
            this.formMenuPrincipal = formMenuPrincipal;
        }

        private void MostrarHistorial()
        {
            try
            {
                this.lstHistorialVentas.DataSource = null;
                this.lstHistorialVentas.DataSource = this.agencia.MostarListaDeReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar lista");
            }

        }

        private void btn_MostrarHistorialVentas_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.agencia.Reservas.Count > 0)
                {
                    this.MostrarHistorial();
                }
                else
                {
                    MessageBox.Show("No se registraron reservas, atienda un cliente o cargue datos.", "No existen reservas", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar reservas");
            }



        }

        private void btn_VolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formMenuPrincipal.Show();
        }

        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(this.txtEliminarPaquete.Text) && !string.IsNullOrWhiteSpace(this.txtEliminarReservaDNI.Text))
                {
                    ADOReservas adoReservas = new ADOReservas();
                    Reserva auxReserva = new Reserva();

                    if (this.txtEliminarPaquete.Text.ToLower() == "bronce")
                    {
                        auxReserva = adoReservas.ObtenerElementoPorDNI(this.txtEliminarReservaDNI.Text, "bronce");
                    }
                    else if (this.txtEliminarPaquete.Text.ToLower() == "plata")
                    {
                        auxReserva = adoReservas.ObtenerElementoPorDNI(this.txtEliminarReservaDNI.Text, "plata");
                    }
                    else if (this.txtEliminarPaquete.Text.ToLower() == "oro")
                    {
                        auxReserva = adoReservas.ObtenerElementoPorDNI(this.txtEliminarReservaDNI.Text, "oro");
                    }
                    else
                    {
                        MessageBox.Show("Los paquetes disponible son: bronce, plata u oro.");

                    }

                    if (auxReserva is not null && auxReserva.MontoFinal > -1)
                    {
                        DialogResult respuesta;
                        respuesta = MessageBox.Show($"{auxReserva.MostrarDatos()}\n¿Desea eliminar esta reserva?", "Coincidencia en reserva", MessageBoxButtons.YesNo);

                        if (respuesta == DialogResult.Yes)
                        {
                            if (adoReservas.EliminarElementoPorDNI(auxReserva.DniPasajero, auxReserva.PaquetesViaje.ToString()))
                            {
                                this.agencia.Reservas = adoReservas.ObtenerTodosLosElementos();
                                GestorArchivosAgencia.GuardarPasajerosEnArchivo(this.agencia.Pasajeros, "registroPasajeros");
                                GestorArchivosAgencia.GuardarReservasEnArchivo(this.agencia.Reservas, "registroReservas");
                                MessageBox.Show("Se ha eliminado la reserva", "Reserva eliminada", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("No se elimino la reserva");
                            }

                        }
                        else
                        {
                            MessageBox.Show("No se han echo modificaciones.");
                        }


                    }
                    else
                    {
                        MessageBox.Show("No se encontro la reserva. Ingrese nuevamente el dni y el paquete.");
                    }




                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnLeerReservas_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(this.txtNombreArchivo.Text))
                {
                    if (GestorArchivosAgencia.LeerArchivoReservas(this.txtNombreArchivo.Text) is not null)
                    {
                        this.agencia.Reservas = GestorArchivosAgencia.LeerArchivoReservas(this.txtNombreArchivo.Text);
                        this.lstHistorialVentas.DataSource = null;

                        MessageBox.Show($"El archivo: {this.txtNombreArchivo.Text} se cargo con exito, refresca la lista.");
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer archivo");
            }

        }

        private void btnPromedioReservas_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(this.agencia.PromedioDePrecioPorReserva());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"No se pudo calcular");
            
            }
            
        }
    }



}
