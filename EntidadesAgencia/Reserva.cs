using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia
{
    public class Reserva
    {
        
        private decimal montoFinal;
        private string dniPasajero;
        private EPaquetesViaje paqueteSeleccionado;

        public Reserva()
        {
            this.montoFinal = -1;
            this.dniPasajero = string.Empty;
            this.paqueteSeleccionado = EPaquetesViaje.Bronce;
        }
        public Reserva(EPaquetesViaje paqueteSeleccionado, decimal montoFinal, string dniPasajero)
        {
           this.paqueteSeleccionado = paqueteSeleccionado;
           this.montoFinal = montoFinal;
           this.dniPasajero = dniPasajero;
        }


        public string DniPasajero { get { return this.dniPasajero; } set { this.dniPasajero = value; } }
        public decimal MontoFinal { get { return this.montoFinal; } set { this.montoFinal = value; } }
        public EPaquetesViaje PaquetesViaje { get { return this.paqueteSeleccionado; } set { this.paqueteSeleccionado = value; } }

      
        
        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Paquete: {this.paqueteSeleccionado}\t");
            sb.AppendLine($"Monto: {this.montoFinal}\t");
            sb.AppendLine($"DNI: {this.dniPasajero}\t");
            

            return sb.ToString();
        }


        public static bool operator ==(Reserva v1, Reserva v2)
        {
            if(v1 is not null && v2 is not null) 
            {
                if (v1.dniPasajero == v2.dniPasajero && v1.paqueteSeleccionado == v2.paqueteSeleccionado)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Reserva v1, Reserva v2)
        { 
           return !(v1 == v2);
        }


    }
}
