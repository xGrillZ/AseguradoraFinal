using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFApplication.clases
{
    public class Articulo
    {

        #region Atributos/variables/Propiedades de la clase
        /// <summary>
        /// Propiedad del codigo del articulo
        /// </summary>
         public string CodigoArticulo { get; set; }
        /// <summary>
        /// Propiedad del costo de fabricacion
        /// </summary>
        public double PrecioCostoFabricacion { get; set; }
        /// <summary>
        /// Propiedad del porcentaje de ganancia del vendedor
        /// </summary>
        public double PorcentajeGananciaVendedor { get; set; }

        #endregion Atributos/variables/Propiedades de la clase

        #region Constructores

        /// <summary>
        /// Constructor Vacio
        /// </summary>
        public Articulo()
        {

        }

        /// <summary>
        /// Constructor sobrecargado que recibe todas las propiedades de la clase
        /// </summary>
        /// <param name="pCodigoArticulo">Codigo articulo</param>
        /// <param name="pPrecioCostoFabricacion">Costo de fabricarlo</param>
        /// <param name="pPorcentajeGananciaVendedor">Ganancia del Vendedor</param>
        /// 
        public Articulo(string pCodigoArticulo,double pPrecioCostoFabricacion,
            double pPorcentajeGananciaVendedor) //p de parametro antes 
        {
            this.CodigoArticulo = pCodigoArticulo;
            this.PrecioCostoFabricacion = pPrecioCostoFabricacion;
            this.PorcentajeGananciaVendedor = pPorcentajeGananciaVendedor;
        }
        #endregion Constructores

        #region Funciones y metodos
        /// <summary>
        /// Calcula la ganancia del vendedor
        /// Utilizando las propiedades de PrecioCostoFabricacion y PorcentaGnanciaVendedor
        /// </summary>
        /// <returns></returns>
        public double CalculaGananciaVendedor()
        {
            double resultado = 0;

            resultado = this.PrecioCostoFabricacion * (this.PorcentajeGananciaVendedor / 100);

            return resultado;         
        }

        /// <summary>
        /// Calcula Precio Parcial del articulo
        /// sumando la ganacia del vendedor y el valor de la propiedad PrecioCostoFabricacion
        /// </summary>
        /// <returns></returns>
        public double CalculaPrecioParcial()
        {
            //double resultado = 0;

            //resultado = this.PrecioCostoFabricacion + this.CalculaGananciaVendedor();

            //return resultado;

            return this.PrecioCostoFabricacion + this.CalculaGananciaVendedor(); //nos ahorramos la variable

        }
        /// <summary>
        /// Calcula el precio de venta del articulo
        /// sumando un 13% del impuesto
        /// </summary>
        /// <returns></returns>

        public double CalculaPrecioVenta()
        {

            //return this.CalculaPrecioParcial() * 1.13;
            return (this.CalculaPrecioParcial() * 0.13) + this.CalculaPrecioParcial();

        }
        #endregion Funciones y metodos

    }
}