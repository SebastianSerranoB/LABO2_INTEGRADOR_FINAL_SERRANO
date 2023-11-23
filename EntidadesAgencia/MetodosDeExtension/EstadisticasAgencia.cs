using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.MetodosDeExtension
{

    /// <summary>
    /// Clase static con metodos de Extension  que contiene métodos para calcular estadísticas relacionadas a AgenciaViajes.
    /// </summary>
    public static class EstadisticasAgencia
    {

        // <summary>
        /// Calcula el promedio de precio por reserva para una AgenciaViajes dada.
        /// </summary>
        /// <param name="agenciaDeViaje">Instancia de la Agencia de Viajes.</param>
        /// <returns>El promedio de precio por reserva o un mensaje indicando la ausencia de reservas.</returns>
        public static string PromedioDePrecioPorReserva(this AgenciaViajes agenciaDeViaje)
        {
            string retorno = string.Empty;

            if (agenciaDeViaje.Reservas.Count > 0)
            {
                decimal acumuladorMontos = 0;
                foreach (Reserva item in agenciaDeViaje.Reservas)
                {
                    acumuladorMontos += item.MontoFinal;
                }

                if (acumuladorMontos > 0)
                {
                    decimal promedioDePrecio;
                    promedioDePrecio = acumuladorMontos / agenciaDeViaje.Reservas.Count;

                    retorno = $"El promedio de precio por reserva para {agenciaDeViaje.Reservas.Count} reservas fue de: ${promedioDePrecio.ToString("0.00")}";
                }

            }
            else
            {
                retorno = "No se registraron reservas";
            }

            return retorno;
        }

        public static string PasajeroYCorrespondientesReservas(this AgenciaViajes agenciaDeViaje, Pasajero pasajero)
        {
            StringBuilder sb = new StringBuilder();

            if (pasajero is not null && agenciaDeViaje.Reservas.Count > 0)
            {
                int cantidadDeReservas;
                cantidadDeReservas = 0;

                sb.AppendLine(pasajero.MostrarDatos());

                foreach (Reserva item in agenciaDeViaje.Reservas)
                {
                    
                    if (item.DniPasajero == pasajero.Dni)
                    {
                        sb.AppendLine("--------------");
                        sb.AppendLine(item.MontoFinal.ToString("0.00"));
                        sb.AppendLine(item.PaquetesViaje.ToString());
                        cantidadDeReservas++;
                    }

                    if (cantidadDeReservas > 0)
                    {
                        sb.AppendLine($"\nCantidad de reservas:{cantidadDeReservas}");
                    }
                    else
                    {
                        sb.AppendLine("No se registraron reservas de este pasajero");
                    }
                }
            }
            else
            {
                sb.AppendLine("No se registraron pasajeros.");
            }


            return sb.ToString();
        }

    }
}
