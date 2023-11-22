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
    public class ADOReservas : IAdministradorBaseDeDatos<Reserva>
    {
        private string stringConnection;

        public ADOReservas()
        {
            this.stringConnection = "Server=.;Database=INTEGRADOR_AgenciaTurismo_DB;Trusted_Connection=True;";
        }




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
