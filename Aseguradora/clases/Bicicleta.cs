using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFApplication.clases
{
    public class Bicicleta:Vehiculo
    {
        #region Atributos/variables/propiedades de la clase

        public string Material { set; get; }

        #endregion Atributos/variables/propiedades de la clase

        #region Constructores

        public Bicicleta(
          string pMaterial,
          int pCantidadPasajeros,
          int pCantidadRuedas,
          string pMarca):base(pCantidadPasajeros,pCantidadRuedas,pMarca) //enviar de regreso estos 3 parametros al padre Vehiculo

        {
            this.Material = pMaterial;
        }

        #endregion Constructores

        #region Funciones y métodos
        /// <summary>
        /// Sobreescribir del metodo padre para agregar su especializacion
        /// </summary>
        /// <returns>Retorna el tipo clase Bicicleta</returns>
        public override string Tipo()
        {
            return "Bicicleta";
        }
        /// <summary>
        /// Sobreescribir del metodo padre para agregar su especializacion
        /// </summary>
        /// <returns>Retorna el tipo clase Bicicleta</returns>
        public override string RetornaDatosVehiculo()
        {
            return

               $"{base.RetornaDatosVehiculo()}{saltoLinea} Material{this.Material}";
               
        }

        #endregion Funciones y métodos
    }
}