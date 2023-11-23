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
    {/// <summary>
    /// Clase  que gestiona operaciones de lectura y escritura de archivos relacionados con la agencia de viajes.
    /// </summary>
    public static class GestorArchivosAgencia
    {
        public static string RutaPorDefecto;

        /// <summary>
        /// Inicializa la ruta por defecto utilizando la carpeta de escritorio del usuario.
        /// </summary>
        static GestorArchivosAgencia() 
        {
            GestorArchivosAgencia.RutaPorDefecto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
       
        /// <summary>
        /// Obtiene la ruta por defecto para guardar archivos.
        /// </summary>
        /// <returns>La ruta por defecto para guardar archivos.</returns>
        private static string ObtenerRutaPorDefecto()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaCompleta = Path.Combine(path, "AgenciaViajesRegistros");

            return rutaCompleta;
        }

        /// <summary>
        /// Guarda la lista de pasajeros en un archivo con formato JSON en la ruta especificada.
        /// </summary>
        /// <param name="listaDePasajeros">Lista de pasajeros a guardar.</param>
        /// <param name="nombreArchivo">Nombre del archivo de salida.</param>
        /// <returns>True si la operación de guardado fue exitosa; de lo contrario, False.</returns>
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


        /// <summary>
        /// Lee un archivo con la lista de pasajeros en formato JSON desde la ruta especificada.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo a leer.</param>
        /// <returns>La lista de pasajeros leída desde el archivo. Si el archivo no existe, devuelve una lista vacía.</returns>
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


        /// <summary>
        /// Lee un archivo con la lista de reservas en formato JSON desde la ruta especificada.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo a leer.</param>
        /// <returns>La lista de reservas leída desde el archivo. Si el archivo no existe, devuelve una lista vacía.</returns>
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

        /// <summary>
        /// Guarda la lista de reservas en un archivo con formato JSON en la ruta especificada.
        /// </summary>
        /// <param name="listaDePasajeros">Lista de reservas a guardar.</param>
        /// <param name="nombreArchivo">Nombre del archivo de salida.</param>
        /// <returns>True si la operación de guardado fue exitosa; de lo contrario, False.</returns>
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
