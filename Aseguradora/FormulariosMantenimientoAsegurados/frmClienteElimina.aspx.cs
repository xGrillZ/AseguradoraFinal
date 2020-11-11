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
    public partial class frmClienteElimina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.cargaListaPaisProcedencia();
                this.cargaListaTipoCliente();
                this.cargaDatosRegistro();
            }
        }

        /// <summary>
        /// Carga la lista de tipo cliente
        /// </summary>
        void cargaListaTipoCliente()
        {
            BLTipoCliente oTipoCliente = new BLTipoCliente();
            ///indicarle al dropdownlist la fuente de datos
            this.ddlTipoCliente.DataSource = oTipoCliente.RetornaTipoCliente();
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
            this.lstPaisProcedencia.DataSource = oPaisProcedencia.RetornaPaisProcedencia();
            ///indicarle al dropdownlist que se muestre
            this.lstPaisProcedencia.DataBind();
        }

        void cargaDatosRegistro()
        {

            ///obtener el parámetro envíado desde el grid
            ///es CASESENSITIVE
            string parametro =
                this.Request.QueryString["id_Cliente"];

            //validar si el parametro es correcto
            if (String.IsNullOrEmpty(parametro))
            {
                Response.Write("<script>alert('Parámetro nulo')</script>");
            }
            else
            {
                int id_Cliente = Convert.ToInt16(parametro);
                BLCliente oCliente = new BLCliente();
                sp_RetornaClienteID_Result datosCliente = new sp_RetornaClienteID_Result();
                ///invocar al procedimiento
                datosCliente =
                    oCliente.RetornaClienteID(id_Cliente);
                if (datosCliente == null)
                {
                    Response.Redirect("frmClienteLista.aspx");
                }
                else
                {
                    this.ddlTipoCliente.SelectedValue = datosCliente.id_TipoCliente.ToString();
                    this.lstPaisProcedencia.SelectedValue = datosCliente.id_PaisProcedencia.ToString();
                    this.txtNombre.Text = datosCliente.nombre;
                    this.txtPrimerApellido.Text = datosCliente.primerApellido;
                    this.txtSegundoApellido.Text = datosCliente.segundoApellido;
                    this.txtTelefono1.Text = datosCliente.telefono1;
                    this.txtTelefono2.Text = datosCliente.telefono2;
                    this.hdIdCliente.Value = datosCliente.id_Cliente.ToString();
                }
            }
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
                BLCliente oCliente = new BLCliente();
                bool resultado = false;
                string mensaje = "";
                try
                {
                    ///Obtener el id del registro eliminar
                    int id_Cliente = Convert.ToInt16(this.hdIdCliente.Value);
                    ///Asignar a la variable el resultado de
                    ///invocar el PA
                    resultado = oCliente.EliminaCliente(id_Cliente);

                }
                ///catch: se ejecuta en el caso de que haya una excepcion
                ///excepcionCapturada: posee los datos de la excepción
                catch (Exception excepcionCapturada)
                {
                    mensaje += $"Ocurrió un error: {excepcionCapturada.Message}";
                }
                ///finally: siempre se ejecuta (se atrape o no la excepción)
                finally
                {
                    ///si el resultado de la variable es verdadera implica que
                    ///el procedimiento no retornó errores
                    if (resultado)
                    {
                        mensaje += "El registro fue eliminado";
                    }
                }
                ///mostrar el mensaje
                Response.Write("<script>alert('" + mensaje + "')</script>"); ;
            }
        }
    }
}