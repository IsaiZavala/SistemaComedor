using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;
using PCV.Models;
using PCV.WEB.Objects;
using PCV.Models.StoredProceduresClasses;
using System.Data;

namespace PCV.WEB.Forms
{
    public partial class Lunch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Producto> lstProductos = new List<Producto>();
                lstProductos.Add(new Producto() { Cantidad = 1 } ); // Se inicializa con la cantidad de uno

                grdVentas.DataSource = lstProductos;
                grdVentas.DataBind();
            }
        }

        protected void lnkValidarCredencial_Click(object sender, EventArgs e)
        {
            ProcterGambleRepository repo = new ProcterGambleRepository();
            ConsultaEmpleados empleado = repo.ConsultaEmpleados( 
                new ConsultaEmpleados()
                {
                    Credencial = txtCredencial.Text.Trim()
                });

            LoadEmpleado(empleado);
            LoadCatalogosComidas();
        }

        private void LoadEmpleado(ConsultaEmpleados empleado)
        {
            txtPlantaDesc.Text = empleado.PlantaDesc;
            txtCredencial.Text = empleado.Credencial;
            txtNombre.Text = empleado.Nombre;
            txtTipoEmpleado.Text = empleado.TipoEmpleado;
            txtHorario.Text = empleado.Horario;
            txtSubsidio.Text = empleado.Subsidio;
        }

        public void LoadCatalogosComidas()
        {
            ProcterGambleRepository repo = new ProcterGambleRepository();
            List<comidas> lstComidas = repo.ConsultaCatalogoComidas();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            List<Producto> lstProductos = new List<Producto>();

            // Almacenar la infomacion que tiene el grdVentas
            foreach (GridViewRow itemRow in grdVentas.Rows)
            {
                DropDownList ddlCodigosComidas = itemRow.FindControl("ddlCodigosComidas") as DropDownList;
                TextBox txtCantidad = itemRow.FindControl("txtCantidad") as TextBox;
                
                if (ddlCodigosComidas.SelectedIndex > 0)
                {
                    // Buscar el nombre del producto
                    int com_id = int.Parse(ddlCodigosComidas.SelectedValue);
                    int cantidad = int.Parse(txtCantidad.Text);

                    ProcterGambleRepository repo = new ProcterGambleRepository();
                    comidas comida = repo.comidas.Where(m => m.com_id == com_id).First();

                    decimal total = (decimal) comida.pre_precio.Value * cantidad;

                    Producto itemProducto =
                    new Producto()
                    {
                        com_id = com_id
                        , NombreProducto = comida.com_descripcion
                        , Cantidad = cantidad
                        , Precio = (decimal)comida.pre_precio.Value
                        , Total = total
                    };

                    lstProductos.Add(itemProducto);
                }
            }

            lstProductos.Add(new Producto() { Cantidad = 1 }); // Inicializar la cantidad con uno
            grdVentas.DataSource = lstProductos;
            grdVentas.DataBind();
        }

        protected void grdVentas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdVentas.EditIndex = e.NewEditIndex;
        }

        protected void grdVentas_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        public List<comidas> lstComidasCache;
        public List<comidas> CatalogosComidasCache()
        {
            if (lstComidasCache == null)
            {
                lstComidasCache = new List<comidas>();
            }

            if (lstComidasCache.Count == 0)
            {
                ProcterGambleRepository repo = new ProcterGambleRepository();
                lstComidasCache = repo.ConsultaCatalogoComidas();
                return lstComidasCache;
            }

            return lstComidasCache;
        }

        protected void grdVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtCantidad = e.Row.FindControl("txtCantidad") as TextBox;
                TextBox txtPrecio = e.Row.FindControl("txtPrecio") as TextBox;
                TextBox txtTotal = e.Row.FindControl("txtTotal") as TextBox;
                DropDownList ddlCodigosComidas = e.Row.FindControl("ddlCodigosComidas") as DropDownList;


                if (ddlCodigosComidas != null)
                {
                    ddlCodigosComidas.DataTextField = "com_descripcion";
                    ddlCodigosComidas.DataValueField = "com_id";
                    ddlCodigosComidas.DataSource = CatalogosComidasCache();
                    ddlCodigosComidas.DataBind();
                    ddlCodigosComidas.Items.Insert(0, new ListItem() { Text = "---------", Value = "-1" });
                    ddlCodigosComidas.SelectedIndex = 0;
                }

                if (e.Row.DataItem != null)
                {
                    Producto itemProd = e.Row.DataItem as Producto;
                    ddlCodigosComidas.SelectedValue = itemProd.com_id.ToString();
                    txtCantidad.Text = itemProd.Cantidad.ToString();
                    txtTotal.Text = itemProd.Total.ToString();
                }
            }
        }

        protected void ddlCodigosComidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCodigosComidas = sender as DropDownList;
            int com_id = int.Parse(ddlCodigosComidas.SelectedValue); // com_id

            GridViewRow grdVentas = ddlCodigosComidas.NamingContainer as GridViewRow;

            ProcterGambleRepository repo = new ProcterGambleRepository();
            comidas ComidaResult = repo.comidas.Where(m => m.com_id == com_id).FirstOrDefault();
            if (ComidaResult != null)
            {
                TextBox txtPrecio = grdVentas.FindControl("txtPrecio") as TextBox;
                if (txtPrecio != null)
                {
                    txtPrecio.Text = ComidaResult.pre_precio.ToString();
                }
            }
        }
    }
}