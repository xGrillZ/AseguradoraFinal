using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WFApplication.BL;

namespace WFApplication.formularios
{
    public partial class frmClienteInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar que sea la primera vez que se carga la pagina
            //o bien que no es una  "recarga" de pagina
            //if(!this.IsPostBack)
            if(this.IsPostBack==false)
            {
                this.cargaListaPaisProcedencia();
                this.cargaListaTipoCliente();
            }
           

        }
        /// <summary>
        /// Carga la lista de tipo cliente
        /// </summary>
        void cargaListaTipoCliente()
        {
            BLTipoCliente oTipoCliente = new BLTipoCliente();
            ///indicarle al dropdownlist la fuente de datos
            this.ddlTipoCliente.DataSource = oTipoCliente.RetornaTipoCliente(null, null);

            ///indicarle al dropdownlist que se muestre
            this.ddlTipoCliente.DataBind();
        }

        /// <summary>
        /// Carga la lista de país de procedencia
        /// </summary>
        void cargaListaPaisProcedencia()
        {
            BLPaisProcedencia oPaisProcedencia = new BLPaisProcedencia();
            ///indicarle al dropdownlist la fuente de datos
            this.lstPaisProcedencia.DataSource = oPaisProcedencia.RetornaPaisProcedencia(null);
            ///indicarle al dropdownlist que se muestre
            this.lstPaisProcedencia.DataBind();
        }

        protected void btAceptar_Click(object sender, EventArgs e)
        {
            this.AlmacenarDatos();
        }
        /// <summary>
        /// Valida que todas las reglas del formulario se hayan cumplido y procede
        /// a insertar el registro utilizando el procedimiento sp_InsertaCliente
        /// </summary>
        void AlmacenarDatos()
        {
            if (this.IsValid)
            {
                string mensaje = "";

                BLCliente oCliente = new BLCliente();

                bool resultado = false;

                try
                {
                    ///obtener los valores seleccionados por el usuario
                    ///se toman de la propiedad datavaluefield
                    ///tanto del dropdwonlist como del listbox
                    int id_TipoCliente = Convert.ToInt16(this.ddlTipoCliente.SelectedValue);
                    int id_PaisProcedencia = Convert.ToInt16(this.lstPaisProcedencia.SelectedValue);
                    ///asignar a la variable el resultado de
                    ///invocar el procedimiento almacenado que se encuentra en el metodo
                    resultado = oCliente.InsertaCliente(
                       id_TipoCliente,
                       this.txtPrimerApellido.Text,
                       this.txtSegundoApellido.Text,
                       this.txtNombre.Text,
                       id_PaisProcedencia,
                       this.txtTelefono1.Text,
                       this.txtTelefono2.Text
                       );
                }
                ///catch se ejecuta en el caso de que haya una excepcion
                ///excepcionCapturada posee los datos de la excepcion
                catch (Exception excepcionCapturada)
                {
                    mensaje += $"Ocurrió un error {excepcionCapturada.Message}";
                }
                /// siempre se ejecuta se atrape o no la excepcion
                finally
                {
                 ///si el resultado de la variable es verdadera implica que
                 ///el proceimiento no retornó errores
                 
                    if (resultado)
                    {
                        mensaje += "El registro fue insertado";
                    }
                ///mostrar el mensaje
                Response.Write("<script>alert('" + mensaje + "')</script>"); ;
            }
        }


    }
}
}
