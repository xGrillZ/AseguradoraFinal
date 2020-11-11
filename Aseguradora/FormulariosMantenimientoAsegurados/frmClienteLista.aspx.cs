using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WFApplication.BL;
using WFApplication.Modelos;

namespace WFApplication.formulariosBaseDatos
{
    public partial class frmClienteLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMostrarDatos_Click(object sender, EventArgs e)
        {

            this.CargaDatosGrid();

            
        }

         void CargaDatosGrid()
        {
            ///crear la instancia ed la clase que retornara los datos
            BLCliente blCliente = new BLCliente();
            ///crea la variable que contiene los datos
            List<sp_RetornaCliente_Result> fuenteDatos = blCliente.RetornaClientes(
           this.txtPrimerApellido.Text, this.txtNombre.Text);

            //Agregar al grid la fuente de datos
            this.grdListaClientes.DataSource = fuenteDatos;

            //indicarle al grid que se muestre
            this.grdListaClientes.DataBind();
        }

        protected void grdListaClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdListaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}