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
    /// Clase encargada de realizar operaciones CRUD relacionadas con la gestión de pasajeros en la base de datos.
    /// Implementa la interfaz IAdministradorBaseDeDatos que define metodos CRUD basicos.
    /// </summary>
    public class ADOPasajeros : IAdministradorBaseDeDatos<Pasajero>
    {
        private string stringConnection;

        /// <summary>
        /// Inicializa una nueva instancia de la clase ADOPasajeros con la cadena de conexión predeterminada.
        /// </summary>
        public ADOPasajeros()
        {
            this.stringConnection = "Server=.;Database=INTEGRADOR_AgenciaTurismo_DB;Trusted_Connection=True;";
        }

        /// <summary>
        /// Agrega un nuevo pasajero a la base de datos.
        /// </summary>
        /// <param name="elemento">El pasajero a agregar.</param>
        /// <returns>True si se agregó correctamente; de lo contrario, False.</returns>
        public bool AgregarNuevoElemento(Pasajero elemento)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.stringConnection))
                {
                    string query = "INSERT INTO pasajeros (dni_pasajero,nombre,apellido,edad)" +
                     "values (@dni_pasajero,@nombre,@apellido,@edad)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dni_pasajero", elemento.Dni);
                    command.Parameters.AddWithValue("@nombre", elemento.Nombre);
                    command.Parameters.AddWithValue("@apellido", elemento.Apellido);
                    command.Parameters.AddWithValue("@edad", elemento.Edad);

                    connection.Open();

                    command.ExecuteNonQuery();  

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error al agregar un pasajero",ex);
              
            }
        }


        /// <summary>
        /// Elimina un pasajero de la base de datos utilizando su número de documento de identidad (DNI).
        /// </summary>
        /// <param name="dniElemento">Número de documento de identidad del pasajero a eliminar.</param>
        /// <param name="mensaje">Mensaje adicional para identificar el contexto del error, en caso de ocurrir.</param>
        /// <returns>True si se eliminó correctamente; de lo contrario, False.</returns>
        public bool EliminarElementoPorDNI(string dniElemento, string mensaje)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.stringConnection))
                {
                    string query = "DELETE FROM pasajeros WHERE dni_pasajero=@dniElemento";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@dniPasajero", dniElemento);


                    connection.Open();

                    command.ExecuteNonQuery();

                    return true;
                }

            }
            catch (Exception ex)
            {
               
                throw new EliminarPasajeroException($"Error al borrar un pasajero.{mensaje}", ex);
            }
        }



        /// <summary>
        /// Obtiene un pasajero de la base de datos mediante su número de documento de identidad (DNI).
        /// </summary>
        /// <param name="dniElemento">Número de documento de identidad del pasajero a obtener.</param>
        /// <param name="mensaje">Mensaje adicional para identificar el contexto del error, en caso de ocurrir.</param>
        /// <returns>El pasajero correspondiente al DNI proporcionado.</returns>
        public Pasajero ObtenerElementoPorDNI(string dniElemento, string mensaje)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(this.stringConnection)) 
                {
                    string query = $"SELECT * FROM pasajeros WHERE dni_pasajero=@dniElemento";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@dniElemento", dniElemento);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Pasajero pasajero = new Pasajero();
                       
                        pasajero.Dni = reader.GetString(0);
                        pasajero.Nombre = reader.GetString(1);
                        pasajero.Apellido = reader.GetString(2);
                        pasajero.Edad = reader.GetInt32(3);

                        return pasajero;
                    }
                    else
                    {
                        throw new ElementoNoEncontradoException("No se encontro un elemento correspondiente al DNI recibido. ");
                    }

                }

            }
            catch (Exception ex)
            {
                
                throw new ElementoNoEncontradoException($"Error al obtener pasajero por DNI.{mensaje}", ex); 
            }
        }


        /// <summary>
        /// Obtiene todos los pasajeros almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de todos los pasajeros almacenados.</returns>
        public List<Pasajero> ObtenerTodosLosElementos()
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(this.stringConnection)) 
                {
                    List<Pasajero> listaDePasajeros = new List<Pasajero>();
                    string query = $"SELECT * FROM pasajeros";
                    SqlCommand command = new SqlCommand(query, connection);



                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) 
                    {
                        while (reader.Read())
                        {
                            Pasajero pasajero = new Pasajero();
                            
                            pasajero.Dni = reader.GetString(0);
                            pasajero.Nombre = reader.GetString(1);
                            pasajero.Apellido = reader.GetString(2);
                            pasajero.Edad = reader.GetInt32(3);

                            listaDePasajeros.Add(pasajero);
                        }

                        return listaDePasajeros;
                    }
                    else
                    {
                       
                        throw new ElementoNoEncontradoException("Tabla vacia");
                    }

                }

            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error al obtener lista de pasajeros", ex); 
            }
        }



        /// <summary>
        /// Modifica los datos de un pasajero en la base de datos utilizando su número de documento de identidad (DNI).
        /// </summary>
        /// <param name="elemento">Nuevo objeto Pasajero con los datos actualizados.</param>
        /// <param name="dniElemento">Número de documento de identidad del pasajero a modificar.</param>
        /// <returns>True si la modificación se realizó correctamente; de lo contrario, False.</returns>
        public bool ModificarElementoPorDNI(Pasajero elemento, string dniElemento)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.stringConnection))
                {
                    string nombreNuevo = elemento.Nombre;
                    string apellidoNuevo = elemento.Apellido;
                    string query = "UPDATE pasajeros SET nombre=@nombreNuevo, apellido=@apellidoNuevo WHERE dni_pasajero=@dniElemento";

                    SqlCommand command = new SqlCommand(query, connection);
                   
                    command.Parameters.AddWithValue("@dniElemento", dniElemento);
                    command.Parameters.AddWithValue("@nombreNuevo", nombreNuevo);
                    command.Parameters.AddWithValue("@apellidoNuevo", apellidoNuevo);

                    connection.Open();

                    command.ExecuteNonQuery();

                    return true;
                }

            }
            catch (Exception ex)
            {
               
               throw new ModificarElementoException("Error al modificar un pasajero", ex);
            }

        }







    }
}
