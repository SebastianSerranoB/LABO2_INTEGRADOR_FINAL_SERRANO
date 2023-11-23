using System.Collections.Specialized;
using System.Text;

namespace EntidadesAgencia
{
    // <summary>
    /// Delegado utilizado para mostrar la descripción de paquetes de viaje.
    /// </summary>
    /// <param name="sender">El objeto que activa el evento.</param>
    /// <param name="e">Argumentos del evento.</param>
    public delegate void MostrarDescripcionPaquetes(object sender, EventArgs e);

    /// <summary>
    /// Clase encargada de gestionar las listas de Pasajeros y la lista de sus correspondientes Reservas.
    ///Contiene distintas funcionalidades para interactuar con estas listas.
    /// </summary>
    public class AgenciaViajes
    {
        private List<Pasajero> listaDePasajeros;
        private List<Reserva> historialDeReservas;

        // Evento que se dispara al pulsar el botón para mostrar la descripción de paquetes.
        public event MostrarDescripcionPaquetes? botonMostrarDescripcionPulsado;


        /// <summary>
        /// Constructor de la clase AgenciaViajes, instancia las listas.
        /// </summary>
        public AgenciaViajes()
        {
           this.listaDePasajeros = new List<Pasajero>();
           this.historialDeReservas = new List<Reserva>();
        }

        /// <summary>
        /// Obtiene o establece la lista de pasajeros registrados en la agencia.
        /// </summary>
        public List<Pasajero> Pasajeros { get { return this.listaDePasajeros; } set { this.listaDePasajeros = value; } }

        /// <summary>
        /// Obtiene o establece la lista de reservas registradas en la agencia.
        /// </summary>
        public List<Reserva> Reservas { get { return this.historialDeReservas; } set { this.historialDeReservas = value; } }


        /// <summary>
        /// Invoca el evento de mostrar descripción de paquetes.
        /// </summary>
        /// <param name="sender">El objeto que invoca el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        /// <returns>True si el evento fue invocado con éxito; de lo contrario, False.</returns>
        public bool InvocarMostrarDescripcion(object sender, EventArgs e) 
       {
            if (this.botonMostrarDescripcionPulsado is not null)
            {
                this.botonMostrarDescripcionPulsado(sender, e);
                return true;
            }

            return false;    
       }


        /// <summary>
        /// Devuelve una cadena que describe los paquetes de turismo disponibles, incluyendo detalles y valores, así como descuentos para diferentes grupos de edad.
        /// </summary>
        /// <returns>Cadena de texto con la descripción detallada de los paquetes de turismo.</returns>
        public string DescripcionPaquetes()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" -----  PAQUETES DE TURISMO  ----- ");
            sb.AppendLine("\n  Bronce: Viaje hacia Marte, con escala en la Luna. Consumiciones en barra.\tVALOR: 1000");
            sb.AppendLine("\n  Plata:  Una emocianante aventura por los anillos de saturno hasta pluton, en la poderosa nave, Estrella de la muerte.\tVALOR: 3000");
            sb.AppendLine("\n  Oro: El Crucero del Capitan Beto, viaje deluxe hacia galaxias poco visitadas, spa, canchas de futbol, bandas de musica y mas\tVALOR: 10000");
            sb.AppendLine("\n Descuento de el 10% para menores de 13 y del 15% para mayores de 64 años.");
           

            return sb.ToString(); 
        }


        /// <summary>
        /// Agrega un pasajero a la lista de pasajeros de la agencia si no está ya incluido.
        /// </summary>
        /// <param name="pasajero">Objeto de tipo Pasajero a agregar.</param>
        /// <returns>Booleano indicando si se pudo agregar el pasajero o no.</returns>
        public bool AgregarPasajero(Pasajero pasajero)
        {
           if (this != pasajero)
            {
                this.listaDePasajeros.Add(pasajero);
                return true;
            }
           
            return false;
        }


        /// <summary>
        /// Registra una reserva en el historial de reservas de la agencia si no está ya incluida.
        /// </summary>
        /// <param name="reserva">Objeto de tipo Reserva a registrar.</param>
        /// <returns>Booleano indicando si se pudo registrar la reserva o no.</returns>
        public bool RegistrarReserva(Reserva reserva)
        {
            if (this != reserva)
            {
                this.historialDeReservas.Add(reserva);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Obtiene una lista de strings que representan información detallada de las reservas registradas.
        /// </summary>
        /// <returns>Lista de strings con información de las reservas o un mensaje de "No se registraron reservas".</returns>
        public List<string> MostarListaDeReservas()
        {
            List<string> listaDeReservas = new List<string>();

            if (this.historialDeReservas.Count > 0)
            {
                foreach (Reserva item in this.historialDeReservas)
                {
                   listaDeReservas.Add(item.MostrarDatos());
                }
            }
            else
            {
                listaDeReservas.Add("No se registraron reservas.");
            }


            return listaDeReservas;
        }


        /// <summary>
        /// Obtiene una lista de strings que representan información detallada de los pasajeros registrados.
        /// </summary>
        /// <returns>Lista de strings con información de los pasajeros o un mensaje de "No se registraron pasajeros".</returns>
        public List<string> MostrarListaDePasajeros()
        {
            List<string> listaDePasajeros = new List<string>();

            if (this.listaDePasajeros.Count > 0)
            {
                foreach (Pasajero item in this.listaDePasajeros)
                {
                    listaDePasajeros.Add(item.MostrarDatos());
                }
            }
            else
            {
                listaDePasajeros.Add("No se registraron pasajeros.");
            }

            return listaDePasajeros;
        }


        /// <summary>
        /// Busca un pasajero por su número de documento en la lista de pasajeros.
        /// </summary>
        /// <param name="dni">DNI del pasajero a buscar.</param>
        /// <returns>Objeto Pasajero si se encuentra, de lo contrario retorna null.</returns>
        public Pasajero BuscarPasajeroPorDni(string dni)
        { 
            if(this.listaDePasajeros.Count > 0)
            {
                foreach (Pasajero item in this.listaDePasajeros)
                {
                    if (item.Dni == dni)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Obtiene la cantidad de reservas registradas asociadas a un número de documento (DNI) específico.
        /// </summary>
        /// <param name="dni">DNI del pasajero a buscar.</param>
        /// <returns>Número entero que representa la cantidad de reservas asociadas al DNI proporcionado.</returns>
        public int CantidadDeReservasRegistradasADNI(string dni)
        {
            int retorno = 0;

            if (this.historialDeReservas.Count > 0)
            {
                foreach (var item in this.historialDeReservas)
                {
                    if (item.DniPasajero == dni)
                    { 
                        retorno++;
                    }
                }
            }
           

            return retorno;
        }



        /// <summary>
        /// Sobrecarga de operador '==' para comprobar si una reserva está contenida en la agencia.
        /// </summary>
        /// <param name="agencia">AgenciaViajes donde se busca la reserva.</param>
        /// <param name="reserva">Reserva a buscar en la agencia.</param>
        /// <returns>Booleano indicando si la reserva está presente en la agencia.</returns>
        public static bool operator ==(AgenciaViajes agencia, Reserva reserva)
        {
            if (agencia is not null && reserva is not null  && agencia.Reservas.Count > 0)
            {
                foreach (Reserva item in agencia.Reservas)
                {
                    if (item == reserva)
                    {
                        return true;
                    }
                }
               
            }

            return false;
        }

        /// <summary>
        /// Sobrecarga de operador '!=' para comprobar si una reserva no está contenida en la agencia.
        /// </summary>
        /// <param name="agencia">AgenciaViajes donde se busca la reserva.</param>
        /// <param name="reserva">Reserva a buscar en la agencia.</param>
        /// <returns>Booleano indicando si la reserva no está presente en la agencia.</returns>
        public static bool operator !=(AgenciaViajes agencia, Reserva reserva)
        { 
            return !(agencia == reserva);
        }




        /// <summary>
        /// Sobrecarga de operador '==' para comprobar si un pasajero está contenido en la agencia.
        /// </summary>
        /// <param name="agencia">AgenciaViajes donde se busca el pasajero.</param>
        /// <param name="pasajero">Pasajero a buscar en la agencia.</param>
        /// <returns>Booleano indicando si el pasajero está presente en la agencia.</returns>
        public static bool operator ==(AgenciaViajes agencia, Pasajero pasajero)
        {
            if (agencia is not null && pasajero is not null && agencia.Pasajeros.Count > 0)
            {
                foreach (Pasajero item in agencia.Pasajeros)
                {
                    if (item == pasajero)
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }

        /// <summary>
        /// Sobrecarga de operador '!=' para comprobar si un pasajero no está contenido en la agencia.
        /// </summary>
        /// <param name="agencia">AgenciaViajes donde se busca el pasajero.</param>
        /// <param name="pasajero">Pasajero a buscar en la agencia.</param>
        /// <returns>Booleano indicando si el pasajero no está presente en la agencia.</returns>
        public static bool operator !=(AgenciaViajes agencia, Pasajero pasajero)
        {
            return !(agencia == pasajero);
        }




      








    }
}