using System.Data.SqlClient;

namespace GestionBBDD
{
    public class GestorSqlPasajeros
    {
        private string stringConnection;

        public GestorSqlPasajeros()
        {
            this.stringConnection = "Server=.;Database=INTEGRADOR_AgenciaTurismo_DB;Trusted_Connection=True;";
        }

        public string GetDatosPasajero(string dniPasajero)
        {
            SqlConnection connection = new SqlConnection(this.stringConnection);

            string sentencia = $"SELECT dni_pasajero,nombre,apellido FROM PASAJEROS WHERE dni_pasajero ={dniPasajero}";

            try
            {
                SqlCommand comando = new SqlCommand(sentencia, connection);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    return $"Pasajero con DNI {reader.GetString(0)} =>{reader.GetString(1)},{reader.GetString(2)}";
                    //return reader[1].ToString();
                
                }

                return "No encontre un nombre para el dni recibido"; //no hacer esto, lanzar una excepcion mejor
                    //throw new ...

            }
            catch (Exception ex)
            {
                return ex.Message; // no seria lo correcto
            }
            finally
            { 
                if(connection != null && connection.State == System.Data.ConnectionState.Open) 
                {
                    connection.Close();
                }
                
            }

        }

        public void GetAllPasajeros()
        {
            SqlConnection connection = new SqlConnection(this.stringConnection);

            string sentencia = $"SELECT * FROM PASAJEROS";

            try
            {
                SqlCommand comando = new SqlCommand(sentencia, connection);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                   // return $"Pasajero con DNI {reader.GetString(0)} =>{reader.GetString(1)},{reader.GetString(2)}";
                    //return reader[1].ToString();

                }

               // return "No encontre un nombre para el dni recibido"; //no hacer esto, lanzar una excepcion mejor
                                                                     //throw new ...

            }
            catch (Exception ex)
            {
                //return ex.Message; // no seria lo correcto
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }


        }

       


    }












}