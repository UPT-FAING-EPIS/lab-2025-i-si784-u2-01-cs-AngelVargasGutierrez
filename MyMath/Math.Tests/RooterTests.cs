using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math.Lib;
using System;

namespace Math.Tests
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para la clase Rooter.
    /// </summary>
    [TestClass]
    public class RooterTests
    {
        /// <summary>
        /// Prueba básica del cálculo de raíz cuadrada.
        /// </summary>
        [TestMethod]
        public void BasicRooterTest()
        {
            Rooter rooter = new Rooter();
            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }

        /// <summary>
        /// Prueba el cálculo de raíz cuadrada para un rango de valores.
        /// </summary>
        [TestMethod]
        public void RooterValueRange()
        {
            Rooter rooter = new Rooter();
            for (double expected = 1e-8; expected < 1e+8; expected *= 3.2)
                RooterOneValue(rooter, expected);
        }

        /// <summary>
        /// Método auxiliar para probar un valor específico de raíz cuadrada.
        /// </summary>
        private void RooterOneValue(Rooter rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
        }

        /// <summary>
        /// Prueba el manejo de números negativos.
        /// </summary>
        [TestMethod]
        public void RooterTestNegativeInputx()
        {
            Rooter rooter = new Rooter();
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rooter.SquareRoot(-10));
            Assert.AreEqual("El valor ingresado es invalido, solo se puede ingresar números positivos", exception.Message);
        }
    }
} 