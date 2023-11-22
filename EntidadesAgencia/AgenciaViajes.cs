using System.Collections.Specialized;
using System.Text;

namespace EntidadesAgencia
{
    public class AgenciaViajes
    {
        private List<Pasajero> listaDePasajeros;
        private List<Reserva> historialDeReservas;

        public AgenciaViajes()
        {
           this.listaDePasajeros = new List<Pasajero>();
           this.historialDeReservas = new List<Reserva>();
        }


       public List<Pasajero> Pasajeros { get { return this.listaDePasajeros; } set { this.listaDePasajeros = value; } }
       public List<Reserva> Reservas { get { return this.historialDeReservas; } set { this.historialDeReservas = value; } }


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