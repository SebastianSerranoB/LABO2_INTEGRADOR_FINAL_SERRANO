using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia
{
    public class Pasajero
    {
        private string nombre;
        private string apellido;
        private string dni;
        private int edad;
      

        public Pasajero()
        { 
            this.nombre = string.Empty;
            this.apellido = string.Empty;
            this.dni = string.Empty;
            this.edad = -1;
        }
        public Pasajero(string nombre, string apellido, string dni) : this()
        { 
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }
        public Pasajero(string nombre, string apellido, string dni, int edad) : this(nombre, apellido, dni) 
        {
            this.edad = edad;   
        }


        public string Nombre { get {  return this.nombre; } set {  this.nombre = value; } }
        public string Apellido { get {  return this.apellido; } set {  this.apellido = value; } }
        public string Dni { get {  return this.dni; } set {  this.dni = value; } }
       public int Edad { get { return this.edad; } set { this.edad = value; } }


        public static bool operator ==(Pasajero a, Pasajero b)
        {
            if (a is not null && b is not null)
            {
                return a.dni == b.dni;
            }

            return false;
        }

        public static bool operator !=(Pasajero a, Pasajero b)
        {
            return !(a == b);
        }


        public string MostrarDatos()
        { 
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}\t");
            sb.AppendLine($"Apellido: {this.apellido}\t");
            sb.AppendLine($"DNI: {this.dni}\t");
            sb.AppendLine($"Edad: {this.edad}\t");

            return sb.ToString();
        }
        





    }
}
