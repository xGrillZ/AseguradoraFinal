using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFApplication.clases
{
    public class Circulo:Figura
    {
        #region Atributos/variables/propiedades de la clase
        public double Radio { set; get; }



        #endregion Atributos/variables/propiedades de la clase

        #region Constructores

        public Circulo(
            double pRadio,
            //parametros de la clase padre a continuacion.
            string pColor) : base(pColor) //enviar de regreso estos parametros al padre Figura
        {
            this.Radio = pRadio;            

        }

        #endregion Constructores

        #region Funciones y métodos

        /// <summary>
        /// Sobreescribir del metodo padre para agregar su especializacion
        /// </summary>
        /// <returns>Retorna el tipo clase Circulo</returns>
        public override double Area()
        {
            double resultado = 0;

            resultado =  this.Radio * this.Radio * Pi;

            return resultado;
        }
        /// <summary>
        /// Sobreescribir del metodo padre para agregar su especializacion
        /// </summary>
        /// <returns>Retorna el tipo clase Circulo</returns>
        public override string RetornaDatosFigura()
        {
            return

               $"****Datos de la Figura****{saltoLinea}" +
               $"Color:{this.Color}{saltoLinea}" +
               $"Area:{this.Area()}";
        }
        #endregion Funciones y métodos
    }
}

