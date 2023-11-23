using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesAgencia;
using EntidadesAgencia.Archivos;
using EntidadesAgencia.BaseDeDatos;

namespace FrmVista
{
    public partial class FrmAltaCliente : Form
    {
        AgenciaViajes agencia;
        FrmMenuPrincipal formMenuPrincipal;

        public FrmAltaCliente(AgenciaViajes agencia, FrmMenuPrincipal formMenuPrincipal)
        {
            InitializeComponent();
            this.agencia = agencia;
            this.formMenuPrincipal = formMenuPrincipal;
        }

        /// <summary>
        /// Maneja el evento load del formulario "FrmAltaCliente".
        /// Establece la selección predeterminada del RadioButton y suscribe un método de AgenciaViajes agencia al evento  que muestra la descripcion de paquetes.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FrmAltaCliente_Load(object sender, EventArgs e)
        {
            try
            {
                this.rdbBronce.Checked = true;
                this.agencia.botonMostrarDescripcionPulsado += AgenciaViajes_MostrarDescripcionPaquetes;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message,"Error al cargar formulario de Alta.");
            }
       
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarDatosIngresados())
                {
                    Pasajero pasajeroAux;
                    Reserva reservaAux;

                    pasajeroAux = new Pasajero(this.txtNombreIngresado.Text, this.txtApellidoIngresado.Text, this.txtDniIngresado.Text, (int)numericUpDownEdad.Value);
                    reservaAux = this.GenerarReserva(pasajeroAux);

                    this.DarDeAltaReserva(pasajeroAux, reservaAux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en alta");
            }



        }

        private void DarDeAltaReserva(Pasajero pasajeroAux, Reserva reservaAux)
        {
            if (this.agencia.BuscarPasajeroPorDni(pasajeroAux.Dni) is not null)
            {
                DialogResult respuesta;

                respuesta = MessageBox.Show($"Ya se ha registrado un pasajero con el dni {pasajeroAux.Dni} " +
                                            $"\n{this.agencia.BuscarPasajeroPorDni(pasajeroAux.Dni).MostrarDatos()}" +
                                                  $"\n¿Desea realizar otra reserva a nombre de este pasajero?", "Coincidencia en DNI", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {

                    this.RegistrarReservaEnLista(pasajeroAux, reservaAux, true);
                }
                else
                {
                    MessageBox.Show("No se han echo modificaciones.");
                }

            }
            else
            {
                this.RegistrarReservaEnLista(pasajeroAux, reservaAux, false);
            }
        }

        private Reserva GenerarReserva(Pasajero pasajeroAux)
        {
            Reserva reservaAux;
            if (this.rdbOro.Checked == true)
            {
                reservaAux = new Reserva(EPaquetesViaje.Oro, this.CalcularMontoFinal(EPaquetesViaje.Oro, pasajeroAux.Edad), pasajeroAux.Dni);
            }
            else if (this.rdbPlata.Checked == true)
            {
                reservaAux = new Reserva(EPaquetesViaje.Plata, this.CalcularMontoFinal(EPaquetesViaje.Plata, pasajeroAux.Edad), pasajeroAux.Dni);
            }
            else
            {
                reservaAux = new Reserva(EPaquetesViaje.Bronce, this.CalcularMontoFinal(EPaquetesViaje.Bronce, pasajeroAux.Edad), pasajeroAux.Dni);
            }

            return reservaAux;
        }

        private void RegistrarReservaEnLista(Pasajero pasajeroAux, Reserva reservaAux, bool pasajeroExistente)
        {

            if (pasajeroExistente)
            {
                reservaAux.MontoFinal = this.CalcularMontoFinal(reservaAux.PaquetesViaje, this.agencia.BuscarPasajeroPorDni(pasajeroAux.Dni).Edad);

                ADOReservas adoReservas = new ADOReservas();
                if (this.agencia.RegistrarReserva(reservaAux))
                {

                    if (adoReservas.AgregarNuevoElemento(reservaAux))
                    {
                        GestorArchivosAgencia.GuardarPasajerosEnArchivo(this.agencia.Pasajeros, "registroPasajeros");
                        GestorArchivosAgencia.GuardarReservasEnArchivo(this.agencia.Reservas, "registroReservas");

                        agencia.Reservas = adoReservas.ObtenerTodosLosElementos();

                        MessageBox.Show($"El pasajero{pasajeroAux.Dni} \n {reservaAux.MostrarDatos()}", "Reserva registrada", MessageBoxButtons.OK);

                    }
                    else
                    {
                        MessageBox.Show("No pudo registrarse en la base de datos");
                    }


                }
                else
                {
                    MessageBox.Show($"El pasajero {pasajeroAux.Dni}  ya reservo un paquete de viaje, el maximo es de 3 de reservas posibles" +
                        $" y no puede reservarse el mismo tipo dos veces.", "Ya registrado", MessageBoxButtons.OK);
                }


            }
            else
            {
                if (this.agencia.AgregarPasajero(pasajeroAux) && this.agencia.RegistrarReserva(reservaAux))
                {
                    ADOPasajeros adoPasajeros = new ADOPasajeros();
                    ADOReservas adoReservas = new ADOReservas();

                    if (adoPasajeros.AgregarNuevoElemento(pasajeroAux) && adoReservas.AgregarNuevoElemento(reservaAux))
                    {
                        agencia.Pasajeros = adoPasajeros.ObtenerTodosLosElementos();
                        agencia.Reservas = adoReservas.ObtenerTodosLosElementos();

                        GestorArchivosAgencia.GuardarPasajerosEnArchivo(this.agencia.Pasajeros, "registroPasajeros");
                        GestorArchivosAgencia.GuardarReservasEnArchivo(this.agencia.Reservas, "registroReservas");

                        MessageBox.Show($"Se registro un nuevo pasajero y su correspondiente reserva:\n{pasajeroAux.MostrarDatos()} " +
                            $"\n {reservaAux.MostrarDatos()}", "Reserva registrada", MessageBoxButtons.OK);


                    }
                    else
                    {
                        MessageBox.Show("No pudo registrarse en la base de datos");
                    }


                }


            }



        }






        private decimal CalcularMontoFinal(EPaquetesViaje paqueteSeleccionado, int edad)
        {

            if (edad <= 12)
            {
                return (decimal)paqueteSeleccionado * 90 / 100;
            }
            else if (edad >= 65)
            {
                return (decimal)paqueteSeleccionado * 85 / 100;
            }


            return (decimal)paqueteSeleccionado;
        }


        private bool ValidarDatosIngresados()
        {

            if (String.IsNullOrWhiteSpace(this.txtNombreIngresado.Text) || String.IsNullOrWhiteSpace(this.txtApellidoIngresado.Text) || String.IsNullOrWhiteSpace(this.txtDniIngresado.Text) || !ValidarNombre(this.txtNombreIngresado.Text) || !ValidarNombre(this.txtApellidoIngresado.Text))
            {
                MessageBox.Show("Error! Ingrese un nombre y apellido validos(solo letras), el DNI debe contener 7 u 8 caracteres numericos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(this.txtDniIngresado.Text, out int dni) || dni < 1000000 || this.txtDniIngresado.Text.Length < 7)
            {
                MessageBox.Show("Error! Ingrese un DNI valido, debe ser mayor o igual a 1 millon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return true;
            }

            return false;
        }


        private bool ValidarNombre(string nombre)
        {
            // Expresión regular para validar que el nombre contenga solo letras(minus y mayus) y espacios
            Regex regex = new Regex("^[a-zA-Z ]+$");

            // Verificar si el nombre coincide con la expresión regular
            return regex.IsMatch(nombre);
        }

        private void btn_MenuPrincipalDesdeAltaCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formMenuPrincipal.Show();

        }

        /// <summary>
        /// Maneja el evento de clic en el botón para mostrar la descripción de los paquetes de viaje.
        /// Invoca un método de AgenciaViajes que contiene un delegado encargado de invocar el metodo, para mostrar la descripción de los paquetes, si está disponible.
        /// En caso contrario, muestra un mensaje indicando que no se ha cargado la información.
        private void btnDescripcionPaquetes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.agencia.InvocarMostrarDescripcion(sender, e))
                {
                }
                else
                {
                    MessageBox.Show("No se a cargado informacion que describa los paquetes");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar descripcion", MessageBoxButtons.OK);
            }
            
        }

        /// <summary>
        /// Maneja el evento para mostrar la descripción de los paquetes de viaje.
        /// Muestra la descripción de los paquetes utilizando un mensaje emergente (MessageBox).
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void AgenciaViajes_MostrarDescripcionPaquetes(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(this.agencia.DescripcionPaquetes(), "Descripcion paquetes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }


    }

}
