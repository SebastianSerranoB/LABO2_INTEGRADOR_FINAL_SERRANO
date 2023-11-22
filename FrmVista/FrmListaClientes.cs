using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesAgencia;
using EntidadesAgencia.Archivos;
using EntidadesAgencia.BaseDeDatos;
using EntidadesAgencia.Excepciones;

namespace FrmVista
{
    public partial class FrmListaClientes : Form
    {
        AgenciaViajes agencia;
        FrmMenuPrincipal formMenuPrincipal;
        public FrmListaClientes(AgenciaViajes agencia, FrmMenuPrincipal formMenuPrincipal)
        {
            InitializeComponent();
            this.agencia = agencia;
            this.formMenuPrincipal = formMenuPrincipal;
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formMenuPrincipal.Show();
        }

        private void btnMostrarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.agencia.Pasajeros.Count > 0)
                {
                    this.MostrarHistorial();
                }
                else
                {
                    MessageBox.Show("No se registraron pasajeros, atienda un cliente o cargue datos.", "No existen reservas", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar pasajeros");
            }

        }

        private void MostrarHistorial()
        {
            try
            {
                this.lstListaClientes.DataSource = null;
                this.lstListaClientes.DataSource = this.agencia.MostrarListaDePasajeros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al desplegar lista.");
            }


        }

        private void btnModificarPasajero_Click(object sender, EventArgs e)
        {
            ADOPasajeros adoPasajeros = new ADOPasajeros();

            try
            {

                if (!String.IsNullOrWhiteSpace(this.txtModificarNombre.Text) && !String.IsNullOrWhiteSpace(this.txtModificarApellido.Text) && !String.IsNullOrWhiteSpace(this.txtModificarDNI.Text) && ValidarNombre(this.txtModificarNombre.Text) || !ValidarNombre(this.txtModificarApellido.Text))
                {
                    Pasajero pasajeroAux = adoPasajeros.ObtenerElementoPorDNI(this.txtModificarDNI.Text, "Error");
                    if (pasajeroAux is not null)
                    {
                        pasajeroAux.Nombre = this.txtModificarNombre.Text;
                        pasajeroAux.Apellido = this.txtModificarApellido.Text;

                        if (adoPasajeros.ModificarElementoPorDNI(pasajeroAux, this.txtModificarDNI.Text))
                        {

                            this.agencia.Pasajeros = adoPasajeros.ObtenerTodosLosElementos();
                            GestorArchivosAgencia.GuardarPasajerosEnArchivo(this.agencia.Pasajeros, "registroPasajeros");
                            GestorArchivosAgencia.GuardarReservasEnArchivo(this.agencia.Reservas, "registroReservas");
                            //posiblemente deberia registrar los cambios en archivos tambien pero por ahora vamos asi
                            MessageBox.Show("Pasajero modificado con exito, refresce la lista de pasajeros para ver los cambios.", "Modificacion exitosa", MessageBoxButtons.OK);
                        }
                        else
                        {
                            throw new ModificarElementoException("No pudo modificarse el pasajero");

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron coincidencias para el DNI ingresado.", "Pasajero no encontrado", MessageBoxButtons.OK);
                    }


                }
                else
                {
                    MessageBox.Show("Error! Ingrese un nombre y apellido validos(solo letras), el DNI debe ser mayor o igual a 1 millon(1000000)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (ModificarElementoException ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar elemento");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar elemento");

            }




        }


        private bool ValidarNombre(string nombre) //CREAR CLASE VALIDADOR que valide texto, valide nombres y valide dni.
        {
            // Expresión regular para validar que el nombre contenga solo letras(minus y mayus) y espacios
            Regex regex = new Regex("^[a-zA-Z ]+$");

            // Verificar si el nombre coincide con la expresión regular
            return regex.IsMatch(nombre);
        }

        private void btnEliminarPasajero_Click(object sender, EventArgs e)
        {
            ADOPasajeros adoPasajeros = new ADOPasajeros();

            try
            {
                if (!String.IsNullOrWhiteSpace(this.txtModificarDNI.Text))
                {
                    Pasajero pasajeroAux = adoPasajeros.ObtenerElementoPorDNI(this.txtModificarDNI.Text, "Error al obtener elemento");

                    if (pasajeroAux is not null)
                    {
                        if (agencia.CantidadDeReservasRegistradasADNI(this.txtModificarDNI.Text) == 0)
                        {

                            DialogResult respuesta;

                            respuesta = MessageBox.Show($"\n{this.agencia.BuscarPasajeroPorDni(pasajeroAux.Dni).MostrarDatos()}" +
                                                              $"\n¿Desea eliminar este pasajero?", "Coincidencia en DNI", MessageBoxButtons.YesNo);

                            if (respuesta == DialogResult.Yes)
                            {
                                if (adoPasajeros.EliminarElementoPorDNI(this.txtModificarDNI.Text, "Error al eliminar elemento"))
                                {
                                    this.agencia.Pasajeros = adoPasajeros.ObtenerTodosLosElementos();
                                    GestorArchivosAgencia.GuardarPasajerosEnArchivo(this.agencia.Pasajeros, "registroPasajeros");
                                    GestorArchivosAgencia.GuardarReservasEnArchivo(this.agencia.Reservas, "registroReservas");

                                    MessageBox.Show("Se ha eliminado el pasajero", "Pasajero eliminado", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    throw new EliminarPasajeroException("Error al eliminar pasajero");
                                }

                            }
                            else
                            {
                                MessageBox.Show("No se han echo modificaciones.");
                            }



                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar pasajero, elimine primero las reservas a su nombre", "Reservas existentes", MessageBoxButtons.OK);
                        }

                    }
                    else
                    {
                        throw new ElementoNoEncontradoException("No se encontaron pasajeros correspondientes al DNI ingresado");
                    }

                }
            }
            catch (ElementoNoEncontradoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (EliminarPasajeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btnLeerArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(this.txtNombreArchivo.Text))
                {
                    if (GestorArchivosAgencia.LeerArchivoReservas(this.txtNombreArchivo.Text) is not null)
                    {
                        this.agencia.Pasajeros = GestorArchivosAgencia.LeerArchivoPasajeros(this.txtNombreArchivo.Text);
                        this.lstListaClientes.DataSource = null;

                        MessageBox.Show($"El archivo: {this.txtNombreArchivo.Text} se cargo con exito, refresca la lista.");
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer archivo");
            }
        }
    }
}
