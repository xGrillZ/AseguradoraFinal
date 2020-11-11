using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFApplication.clases
{
    public class Vehiculo
    {
        #region Constantes

        public const string saltoLinea = "</br>";

        #endregion Constantes

        #region Atributos/variables/propiedades de la clase

        public int CantidadPasajeros { set; get; }
        public int CantidadRuedas { set; get; }
        public string Marca { set; get; }

        #endregion Atributos/variables/propiedades de la clase

        #region Constructores

        /// <summary>
        /// Constructor que recibe todas las propiedades de la clase
        /// </summary>
        /// <param name="pCantidadPasajeros"></param>
        /// <param name="pCantidadRuedas"></param>
        /// <param name="pMarca"></param>
        public Vehiculo(
            int pCantidadPasajeros,
            int pCantidadRuedas,
            string pMarca)
        {
            this.CantidadPasajeros = pCantidadPasajeros;
            this.CantidadRuedas = pCantidadRuedas;
            this.Marca = pMarca;
        }

        #endregion Constructores

        #region Funciones y métodos

        /// <summary>
        /// Metodo declarado de manera virtual para cada una de
        /// las clases hijas lo pueda sobreescribir
        /// </summary>
        /// <returns>Retorna el tipo del vehiculo</returns>

        public virtual string Tipo()
        {
            return "Vehiculo";
        }

        public virtual string RetornaDatosVehiculo()
        {
            return
                $"****Datos del Vehiculo****{saltoLinea}" +
                $"Tipo:{this.Tipo()}{saltoLinea}" +
                $"Marca:{this.Marca}{saltoLinea}" +
                $"Cantidad ruedas:{this.CantidadRuedas}{saltoLinea}" +
                $"Cantidad de pasajeros:{this.CantidadPasajeros}";
        }


        #endregion Funciones y métodos
    }
}
