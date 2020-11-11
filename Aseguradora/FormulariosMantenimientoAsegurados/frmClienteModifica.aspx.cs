using System;
using WFApplication.BL;
using WFApplication.Modelos;


namespace WFApplication.formulariosBaseDatos
{
    public partial class frmClienteModifica : System.Web.UI.Page
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

            if (string.IsNullOrEmpty(parametro))
            {
                Response.Write("<script>alert('Parámetro nulo')</script>");
            }
            else
            {
                int id_Cliente = Convert.ToInt16(parametro);
                BLCliente oCliente = new BLCliente();
                sp_RetornaClienteID_Result datosCliente = new sp_RetornaClienteID_Result();

                ///invocar al procedimiento almacenado
                ///por medio del metodo
                datosCliente = oCliente.RetornaClienteID(id_Cliente);

                ///verificar que el objeto retornado no sea nulo
                if (datosCliente == null)
                {
                    Response.Redirect("frmClienteLista.aspx");
                }
                else
                {
                    ///asignar a cada una de las etiquetas los valores
                    ///obtenidos en la invocacion del procedimiento almacenado
                    ///por medio del metodo
                    this.ddlTipoCliente.SelectedValue = datosCliente.id_TipoCliente.ToString();
                    this.lstPaisProcedencia.SelectedValue = datosCliente.id_PaisProcedencia.ToString();
                    this.txtNombre.Text = datosCliente.nombre;
                    this.txtPrimerApellido.Text = datosCliente.primerApellido;
                    this.txtSegundoApellido.Text = datosCliente.segundoApellido;
                    this.txtTelefono1.Text = datosCliente.telefono1;
                    this.txtTelefono2.Text = datosCliente.telefono2;

                    ///asignar al hidden field
                    ///el valor de la llave primaria
                    this.hdldCliente.Value = datosCliente.id_Cliente.ToString();

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
                    ///obtener los valores seleccionados por el usuario
                    ///se toman de la propiedad datavaluefield
                    ///tanto del dropdownlist como del listbox
                    int id_TipoCliente = Convert.ToInt16(this.ddlTipoCliente.SelectedValue);
                    int id_PaisProcedencia = Convert.ToInt16(this.lstPaisProcedencia.SelectedValue);
                    //obtener el valor del hidden field 
                    int id_Cliente = Convert.ToInt16(this.hdldCliente.Value);

                    ///asignar a la variable el resultado de 
                    ///invocar el procedimiento almacenado
                    resultado = oCliente.ModificaCliente(
                        id_Cliente,
                        id_TipoCliente,
                        this.txtPrimerApellido.Text,
                        this.txtSegundoApellido.Text,
                        this.txtNombre.Text,
                        id_PaisProcedencia,
                        this.txtTelefono1.Text,
                        this.txtTelefono2.Text
                        );

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
                        mensaje += "El registro fue modificado";
                    }
                }
                ///mostrar el mensaje
                Response.Write("<script>alert('" + mensaje + "')</script>");
            }

        }
    }
}