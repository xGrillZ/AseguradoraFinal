using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFApplication.clases
{
    public class Persona
    {
        #region Propiedades de la clase

        public string nombre  { set; get; }

        public string primerApellido { set; get; }

        public string segundoApellido { set; get; }

        #endregion Propiedades de la clase

        #region Constructores

        /// <summary>
        /// Constructor vacio o por defecto de la clase
        /// </summary>

        public Persona()
        {
                
        }
        /// <summary>
        /// Constructor que recibe solo el nombre
        /// </summary>
        /// <param name="pNombre">Nombre de la persona</param>
        /// 
        public Persona(string pNombre)
        {
            this.nombre = nombre;
        }
        /// <summary>
        /// Constructor que recibe todas las propiedades
        /// de la clase
        /// </summary>
        /// <param name="pPrimerApellido"></param>
        /// <param name="pSegundoApellido"></param>
        /// <param name="pNombre"></param>
        /// 
        public Persona(string pPrimerApellido,
            string pSegundoApellido,
            string pNombre)
        {
            this.primerApellido = pPrimerApellido;
            this.segundoApellido = pSegundoApellido;
            this.nombre = pNombre;
        }

        #endregion Constructores

        #region Funciones y Metodos

        /// <summary>
        /// Retorna el nombre completo
        /// usando las propiedades de la clase
        /// </summary>
        /// <returns></returns>
        
        public string RetornaNombreCompleto ()
        {
            return this.primerApellido + " " +
                this.segundoApellido + "   " +
                this.nombre;
        }

        #endregion Funciones y Metodos
    }
}