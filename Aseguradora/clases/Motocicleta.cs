using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFApplication.clases
{
    public class Motocicleta: Vehiculo
    {
        #region Atributos/variables/propiedades de la clase
        public int Cilindraje { set; get; }
        public string TipoMotocicleta { set; get; }
        public string Placa { set; get; }
        public int Anio { set; get; }

        #endregion Atributos/variables/propiedades de la clase

        #region Constructores

        public Motocicleta(
            string pPlaca,
            int pAnio,
            int pCilindraje,
            string pTipoMotocicleta,
            //parametros de la clase padre a continuacion.
            int pCantidadPasajeros,
            int pCantidadRuedas,
            string pMarca) : base(pCantidadPasajeros, pCantidadRuedas, pMarca) //enviar de regreso estos 3 parametros al padre Vehiculo)
        {
            this.Cilindraje = pCilindraje;
            this.TipoMotocicleta = pTipoMotocicleta;
            this.Placa = pPlaca;
            this.Anio = pAnio;
        }

        #endregion Constructores

        #region Funciones y métodos

        /// <summary>
        /// Sobreescribir del metodo padre para agregar su especializacion
        /// </summary>
        /// <returns>Retorna el tipo clase Motocicleta</returns>
        public override string Tipo()
        {
            return "Motocicleta";
        }
        /// <summary>
        /// Sobreescribir del metodo padre para agregar su especializacion
        /// </summary>
        /// <returns>Retorna el tipo clase Motocicleta</returns>
        public override string RetornaDatosVehiculo()
        {
            return

               $"{base.RetornaDatosVehiculo()}{saltoLinea}"+
               $"Tipo Motocicleta:{this.Tipo()}{saltoLinea}" +
               $"Cilindraje:{this.Cilindraje} cc{saltoLinea}" +
               $"Placa:{this.Placa}{saltoLinea}" +
               $"Año:{this.Anio}";
        }
        #endregion Funciones y métodos
    }
}