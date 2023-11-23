using EntidadesAgencia.Excepciones;
using EntidadesAgencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.BaseDeDatos
{

    /// <summary>
    /// Implementación de la interfaz IAdministradorBaseDeDatos para gestionar operaciones lectura/escritura de reservas en la base de datos.
    /// </summary>
    public class ADOReservas : IAdministradorBaseDeDatos<Reserva>
    {
        private string stringConnection;

        /// <summary>
        /// Constructor que inicializa la cadena de conexión a la base de datos.
        /// </summary>
        public ADOReservas()
        {
            this.stringConnection = "Server=.;Database=INTEGRADOR_AgenciaTurismo_DB;Trusted_Connection=True;";
        }



        /// <summary>
        /// Agrega una nueva reserva a la base de datos.
        /// </summary>
        /// <param name="elemento">Reserva a agregar.</param>
        /// <returns>True si la reserva se agregó correctamente; de lo contrario, False.</returns>
        public bool AgregarNuevoElemento(Reserva elemento)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.stringConnection))
                {
                    string query = "INSERT INTO reservas (dni_pasajero,montoFinal,paqueteSeleccionado)" +
                     "values (@dni_pasajero,@montoFinal,@paqueteSeleccionado)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni_pasajero", elemento.DniPasajero);
                    command.Parameters.AddWithValue("@montoFinal", elemento.MontoFinal);
                    command.Parameters.AddWithValue("@paqueteSeleccionado", elemento.PaquetesViaje.ToString());
                    
                    connection.Open();

                    command.ExecuteNonQuery();  

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error al regristrar una reserva", ex);
            }
        }


        /// <summary>
        /// Elimina una reserva de la base de datos utilizando el DNI del pasajero y el nombre del paquete reservado.
        /// </summary>
        /// <param name="dniElemento">DNI del pasajero de la reserva a eliminar.</param>
        /// <param name="paqueteReservado">hace referencia a un tipo de enum EPaquetesViaje.</param>
        /// <returns>True si la reserva se eliminó correctamente; de lo contrario, False.</returns>
        public bool EliminarElementoPorDNI(string dniElemento, string paqueteReservado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.stringConnection))
                {
                    string query = "DELETE FROM reservas WHERE dni_pasajero=@dniElemento AND LOWER(paqueteSeleccionado) = LOWER(@paqueteReservado)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dniElemento", dniElemento);
                    command.Parameters.AddWithValue("@paqueteReservado", paqueteReservado);

                    connection.Open();

                    command.ExecuteNonQuery();

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error al borrar una reserva por DNI", ex);
            }
        }


        /// <summary>
        /// Obtiene una reserva de la base de datos utilizando el DNI del pasajero y el nombre del paquete reservado.
        /// </summary>
        /// <param name="dniElemento">DNI del pasajero de la reserva a obtener.</param>
        /// <param name="paqueteReservado">hace referencia a un tipo de enum EPaquetesViaje.</param>
        /// <returns>La reserva correspondiente al DNI y paquete recibidos.</returns>
        public Reserva ObtenerElementoPorDNI(string dniElemento, string paqueteReservado)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(this.stringConnection)) 
                {
                    
                    string query = $"SELECT * FROM reservas WHERE dni_pasajero=@dniElemento AND LOWER(paqueteSeleccionado) = LOWER(@paqueteReservado)";
                   
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@dniElemento", dniElemento);
                    command.Parameters.AddWithValue("@paqueteReservado", paqueteReservado);

                   

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Reserva reserva = new Reserva();

                        reserva.DniPasajero = reader.GetString(0);
                        reserva.MontoFinal = reader.GetDecimal(1);

                        if (reader.GetString(2).ToLower() == "oro")
                        {
                            reserva.PaquetesViaje = EPaquetesViaje.Oro;
                        }
                        else if (reader.GetString(2).ToLower() == "plata")
                        {
                            reserva.PaquetesViaje = EPaquetesViaje.Plata;
                        }
                        else
                        {
                            reserva.PaquetesViaje = EPaquetesViaje.Bronce;
                        }


                        return reserva;
                    }
                    else
                    {
                        throw new ElementoNoEncontradoException("No se encontro una reserva correspondiente al DNI recibido");
                    }

                }

            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error al obtener reserva por DNI", ex); 
            }
        }


        /// <summary>
        /// Obtiene todas las reservas almacenadas en la base de datos.
        /// </summary>
        /// <returns>Una lista de todas las reservas almacenadas.</returns>
        public List<Reserva> ObtenerTodosLosElementos()
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(this.stringConnection)) 
                {
                    List<Reserva> listaDeReservas = new List<Reserva>();
                    string query = $"SELECT * FROM reservas";
                    SqlCommand command = new SqlCommand(query, connection);


                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) 
                    {
                       
                        while (reader.Read())
                        {
                            Reserva reserva = new Reserva();
                           
                            reserva.DniPasajero = reader.GetString(0);
                            reserva.MontoFinal = reader.GetDecimal(1);

                            if (reader.GetString(2).ToLower() == "oro")
                            {
                                reserva.PaquetesViaje = EPaquetesViaje.Oro;
                            }
                            else if (reader.GetString(2).ToLower() == "plata")
                            {
                                reserva.PaquetesViaje = EPaquetesViaje.Plata;
                            }
                            else
                            {
                                reserva.PaquetesViaje = EPaquetesViaje.Bronce;
                            }
                           
                          
                            listaDeReservas.Add(reserva);
                        }

                        return listaDeReservas;
                    }
                    else
                    {
                        throw new ElementoNoEncontradoException("Tabla vacia");
                    }

                }

            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error al obtener reserva por DNI", ex); 
            }
      
        
        }
    
    
    
    
    


















    
    }
}
