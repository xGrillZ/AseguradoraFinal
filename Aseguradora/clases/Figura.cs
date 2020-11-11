using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFApplication.clases
{
    public class Figura
    {

        #region Constantes

        public const string saltoLinea = "</br>";
        public const double Pi = 3.1415926535897931;
        
        #endregion Constantes

        #region Atributos/variables/propiedades de la clase

        public string Color { set; get; }
        

        #endregion Atributos/variables/propiedades de la clase


        #region Constructores

        /// <summary>
        /// Constructor que recibe todas las propiedades de la clase
        /// </summary>
        /// <param name="pColor"></param>
             
        public Figura(
            string pColor )
        {
            this.Color = pColor;
                      
        }

        #endregion Constructores

        #region Funciones y métodos

        /// <summary>
        /// Metodo declarado de manera virtual para cada una de
        /// las clases hijas lo pueda sobreescribir
        /// </summary>
        /// <returns>Retorna el area de la Figura</returns>

        public virtual double Area()
        {
            double resultado = 0;

            return resultado;
        }

        public virtual string RetornaDatosFigura()
        {
            return
                $"****Datos de la Figura****{saltoLinea}" +
                $"Color:{this.Color}{saltoLinea}" +
                $"Area:{this.Area()}{saltoLinea}";
        }


        #endregion Funciones y métodos
    }
}