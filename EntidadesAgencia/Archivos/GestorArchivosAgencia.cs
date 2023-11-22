using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.IO;
using System.Collections;
using EntidadesAgencia.Excepciones;

namespace EntidadesAgencia.Archivos
{
    public static class GestorArchivosAgencia
    {
        public static string RutaPorDefecto;
        static GestorArchivosAgencia() 
        {
            GestorArchivosAgencia.RutaPorDefecto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private static string ObtenerRutaPorDefecto()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaCompleta = Path.Combine(path, "AgenciaViajesRegistros");

            return rutaCompleta;
        }


        public static bool GuardarPasajerosEnArchivo(List<Pasajero> listaDePasajeros, string nombreArchivo)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string directorio = GestorArchivosAgencia.ObtenerRutaPorDefecto();
            string rutaCompleta = Path.Combine(directorio, $"{nombreArchivo}.json");

            try
            {
               
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio); 
                }

                using (StreamWriter sw = new StreamWriter(rutaCompleta))
                {
                    string listaJson = JsonSerializer.Serialize(listaDePasajeros, options);
                    sw.WriteLine(listaJson);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ManejoDeArchivosException(nombreArchivo, ex);
            }

        }



        public static List<Pasajero> LeerArchivoPasajeros(string nombreArchivo)
        {
            List<Pasajero>? listaDePasajeros; 

            try
            {
                string directorio = GestorArchivosAgencia.ObtenerRutaPorDefecto();
                string rutaCompleta = Path.Combine(directorio, $"{nombreArchivo}.json");

                if (!File.Exists(rutaCompleta))
                {
                    return new List<Pasajero>();
                }

                using (StreamReader sr = new StreamReader(rutaCompleta) )
                {
                    string listaJson = sr.ReadToEnd();
                    listaDePasajeros = JsonSerializer.Deserialize<List<Pasajero>>(listaJson);
                }

                return listaDePasajeros;
            }
            catch(Exception ex) 
            {
                throw new ManejoDeArchivosException(nombreArchivo, ex);
            }

            
        }

       

        public static List<Reserva> LeerArchivoReservas(string nombreArchivo)
        {
            List<Reserva>? listaDeReservas;

            try
            {
                string directorio = GestorArchivosAgencia.ObtenerRutaPorDefecto();
                string rutaCompleta = Path.Combine(directorio, $"{nombreArchivo}.json");

                if (!File.Exists(rutaCompleta))
                {
                    return new List<Reserva>();
                }

                using (StreamReader sr = new StreamReader(rutaCompleta))
                {
                    string listaJson = sr.ReadToEnd();
                    listaDeReservas = JsonSerializer.Deserialize<List<Reserva>>(listaJson);
                }

                return listaDeReservas;
            }
            catch (Exception ex)
            {
               throw new ManejoDeArchivosException(nombreArchivo, ex);
            }

            
       
        }

        public static bool GuardarReservasEnArchivo(List<Reserva> listaDeReservas, string nombreArchivo)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;


            try
            {
                string directorio = GestorArchivosAgencia.ObtenerRutaPorDefecto();
                string rutaCompleta = Path.Combine(directorio, $"{nombreArchivo}.json");

              
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }


                using(StreamWriter sw = new StreamWriter(rutaCompleta))
                {
                    string listaJson = JsonSerializer.Serialize(listaDeReservas, options);
                    sw.WriteLine(listaJson);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ManejoDeArchivosException(nombreArchivo, ex);
            }

           
        }

      




    }
}
