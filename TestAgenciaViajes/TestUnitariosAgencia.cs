using EntidadesAgencia;
using EntidadesAgencia.MetodosDeExtension;
namespace TestAgenciaViajes
{
    [TestClass]
    public class TestUnitariosAgencia
    {
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