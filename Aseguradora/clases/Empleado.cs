using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFApplication.clases
{
    public class Empleado
    {

        #region Propiedades de la clase

        public string Nombre { set; get; }

        public string PrimerApellido { set; get; }

        public string SegundoApellido { set; get; }

        public double HorasLaboradas { set; get; }

        public double SalarioPorHora { set; get; }

        #endregion Propiedades de la clase


        #region Constructores

        /// <summary>
        /// Constructor vacio o por defecto de la clase
        /// </summary>

        public Empleado()
        {

        }


        /// <summary>
        /// Constructor que recibe todas las propiedades
        /// de la clase
        /// </summary>
        /// <param name="pPrimerApellido"></param>
        /// <param name="pSegundoApellido"></param>
        /// <param name="pNombre"></param>
        /// <param name="pHorasLaboradas"></param>
        ///<param name="pSalarioPorHora"></param> 
        ///
        public Empleado(string pPrimerApellido, string pSegundoApellido, string pNombre, double pHorasLaboradas, double pSalarioPorHora)
        {
            this.PrimerApellido = pPrimerApellido;
            this.SegundoApellido = pSegundoApellido;
            this.Nombre = pNombre;
            this.HorasLaboradas = pHorasLaboradas;
            this.SalarioPorHora = pSalarioPorHora;

        }

        #endregion Constructores


        #region Funciones y Metodos

        /// <summary>
        /// Calcula la ganancia del vendedor
        /// Utilizando las propiedades de PrecioCostoFabricacion y PorcentaGnanciaVendedor
        /// </summary>
        /// <returns></returns>
        public double CalculaSalario()
        {
            double resultado = 0;

            resultado = this.HorasLaboradas * this.SalarioPorHora ;

            return resultado;
        }

        /// <summary>
        /// Retorna el nombre completo
        /// usando las propiedades de la clase
        /// </summary>
        /// <returns></returns>

        public string RetornaNombreCompleto()
        {
            return this.PrimerApellido + " " +
                this.SegundoApellido + "   " +
                this.Nombre;
        }


        #endregion Funciones y Metodos
    }
}