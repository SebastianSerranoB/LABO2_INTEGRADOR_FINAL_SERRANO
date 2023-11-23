using EntidadesAgencia;
using EntidadesAgencia.MetodosDeExtension;
namespace TestAgenciaViajes
{
    /// <summary>
    /// Clase para pruebas unitarias de la clase AgenciaViajes.
    /// </summary>
    [TestClass]
    public class TestUnitariosAgencia
    {

        /// <summary>
        /// Verifica que el cálculo del promedio de precio por reserva
        /// devuelve el resultado esperado.
        /// </summary>
        [TestMethod]
        public void PromedioDePrecioPorReserva_SeEsperaObtener_ElPromedioCorrespondiente()
        {
            // Arrange 
            AgenciaViajes agenciaViajes = new AgenciaViajes();

            List<Reserva> reservas = new List<Reserva>
            {
                new Reserva { MontoFinal = 100 },
                new Reserva { MontoFinal = 150 },
                new Reserva { MontoFinal = 200 }
            };

            agenciaViajes.Reservas = reservas;

            // Act 
            string resultado = agenciaViajes.PromedioDePrecioPorReserva();

            // Assert 
            string valorEsperado = "El promedio de precio por reserva para 3 reservas fue de: $150,00";
            Assert.AreEqual(valorEsperado, resultado);
        }

        /// <summary>
        /// Verifica que el cálculo del promedio de precio por reserva cuando no existen reservas en lista
        /// devuelva el resultado esperado.
        /// </summary>
        [TestMethod]
        public void PromedioDePrecioPorReserva_CuandoNoExistenReservas_RegresaMensajeSinReservas()
        {
            // Arrange 
            AgenciaViajes agenciaViajes = new AgenciaViajes();

            // Act 
            string resultado = agenciaViajes.PromedioDePrecioPorReserva();

            // Assert 
            string valorEsperado = "No se registraron reservas";
            Assert.AreEqual(valorEsperado, resultado);
        }


        /// <summary>
        /// Verifica que dos objetos Pasajero sean considerados iguales
        /// cuando sus números de DNI coinciden.
        /// </summary>
        [TestMethod]
        public void AlCompararDosPasajeros_CuandoSuDniCoincide_SeEsperaQueRetorneTrue()
        {
            // Arrange 
            Pasajero pasajeroA = new Pasajero { Dni = "11112222" };
            Pasajero pasajeroB = new Pasajero { Dni = "11112222" };

            // Act 
            bool resultado = pasajeroA == pasajeroB;

            // Assert 
            Assert.IsTrue(resultado, "Dos Pasajeros son iguales si tienen el mismo DNI.");
        }


        /// <summary>
        /// Verifica que dos objetos Pasajero sean considerados distintos
        /// cuando sus números de DNI no coinciden.
        /// </summary>
        [TestMethod]
        public void AlCompararDosPasajeros_ConDistintoDni_SeEsperaQueRetorneFalse()
        {
            // Arrange 
            Pasajero pasajeroA = new Pasajero { Dni = "11112222" };
            Pasajero pasajeroB = new Pasajero { Dni = "22221111" };

            // Act 
            bool resultado = pasajeroA == pasajeroB;

            // Assert 
            Assert.IsFalse(resultado, "Dos Pasajeros son distintos si su atributo DNI no coincide");
        }


        /// <summary>
        /// Verifica que dos objetos Pasajero sean no considerados iguales
        /// cuando uno de los operandos es null.
        /// </summary>
        [TestMethod]
        public void AlCompararDosPasajeros_SiAlgunoEsNull_SeEsperaQueRetorneFalse()
        {
            // Arrange 

            Pasajero pasajeroA = new Pasajero { Dni = "11112222" };
            Pasajero pasajeroB = null;

            // Act 
            bool resultado = pasajeroA == pasajeroB;

            // Assert 
            Assert.IsFalse(resultado, "Si uno de los operandos en null debe retornar false");
        }


    }
}