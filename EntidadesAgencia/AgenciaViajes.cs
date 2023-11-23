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

        public bool AgregarPasajero(Pasajero pasajero)
        {
           if (this != pasajero)
            {
                this.listaDePasajeros.Add(pasajero);
                return true;
            }
           
            return false;
        }

        public bool RegistrarReserva(Reserva reserva)
        {
            if (this != reserva)
            {
                this.historialDeReservas.Add(reserva);
                return true;
            }

            return false;
        }

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

        //posible metodo de extension
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

        public static bool operator !=(AgenciaViajes agencia, Reserva reserva)
        { 
            return !(agencia == reserva);
        }





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

        public static bool operator !=(AgenciaViajes agencia, Pasajero pasajero)
        {
            return !(agencia == pasajero);
        }




      








    }
}