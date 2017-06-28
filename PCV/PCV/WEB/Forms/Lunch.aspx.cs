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
                // Esta parte hacia que se cargaran varias opciones en el grdVentas.
                //List<Producto> lstProductos = new List<Producto>();
                //int NumProd = 4;
                //for (int i = 0; i < NumProd; i++)
                //{
                //    lstProductos.Add(new Producto() { Cantidad = 1 });
                //}
                
                //grdVentas.DataSource = lstProductos;
                //grdVentas.DataBind();
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
            txtSubsXTurno.Text = "" + empleado.CantidadSubsidio;
        }

        public void LoadCatalogosComidas()
        {
            ProcterGambleRepository repo = new ProcterGambleRepository();
            List<comidas> lstComidas = repo.ConsultaCatalogoComidas();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            LoadCodigoComida();

            txtCodigoComida.Text = string.Empty;
        }

        private void LoadCodigoComida()
        {
            ProcterGambleRepository repo = new ProcterGambleRepository();
            IList<Producto> lstProductos = new List<Producto>();

            // Almacenar los valores guardados que ya existian en el grid
            foreach (GridViewRow itemRow in grdVentas.Rows)
            {
                DropDownList ddlCodigosComidas = itemRow.FindControl("ddlCodigosComidas") as DropDownList;
                TextBox txtCantidad = itemRow.FindControl("txtCantidad") as TextBox;

                if (ddlCodigosComidas.SelectedIndex > 0)
                {
                    // Buscar el nombre del producto
                    int com_id = int.Parse(ddlCodigosComidas.SelectedValue);
                    int cantidad = int.Parse(txtCantidad.Text);

                    comidas comida = repo.comidas.Where(m => m.com_id == com_id).First();

                    decimal total = (decimal)comida.pre_precio.Value * cantidad;

                    Producto itemProducto =
                    new Producto()
                    {
                        com_id = com_id,
                        NombreProducto = comida.com_descripcion,
                        Cantidad = cantidad,
                        Precio = (decimal)comida.pre_precio.Value,
                        Total = total
                    };

                    lstProductos.Add(itemProducto);
                }
            }

            /* Obtener el codigo de comida y compararlo con los codigos de comidas */
            string strCodigoComida = txtCodigoComida.Text.Trim();
            IList<comidas> lstComidas = repo.comidas.Where(m => m.com_codigo == strCodigoComida).ToList();
            int Cantidad;

            int.TryParse(txtCantidad.Text.Trim(), out Cantidad);

            foreach (comidas comida in lstComidas)
            {
                decimal dTotal = (decimal)comida.pre_precio.Value * Cantidad;

                Producto itemProducto =
                        new Producto()
                        {
                            com_id = comida.com_id,
                            NombreProducto = comida.com_descripcion,
                            Cantidad = Cantidad,
                            Precio = (decimal)comida.pre_precio.Value,
                            Total = dTotal
                        };

                lstProductos.Add(itemProducto);
            }

            grdVentas.Visible = true;
            grdVentas.DataSource = lstProductos;
            grdVentas.DataBind();
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
                TextBox txtSubtotal = e.Row.FindControl("txtSubtotal") as TextBox;
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
                    ddlCodigosComidas.Enabled = false;
                    txtCantidad.Text = itemProd.Cantidad.ToString();
                    txtCantidad.Enabled = false;
                    txtSubtotal.Text = itemProd.Total.ToString("0.00");
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                RecalcularTotalFooter(e);
            }
        }

        public comidas GetComidaById(int com_id)
        {
            List<comidas> lstComidas = CatalogosComidasCache();
            comidas ComidaResult = lstComidas.Where(m => m.com_id == com_id).FirstOrDefault();
            return ComidaResult;
        }

        protected void ddlCodigosComidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCodigosComidas = sender as DropDownList;
            int com_id = int.Parse(ddlCodigosComidas.SelectedValue); // com_id

            GridViewRow grdVentas = ddlCodigosComidas.NamingContainer as GridViewRow;
            TextBox txtPrecio = grdVentas.FindControl("txtPrecio") as TextBox;
            TextBox txtCantidad = grdVentas.FindControl("txtCantidad") as TextBox;
            TextBox txtSubtotal = grdVentas.FindControl("txtSubtotal") as TextBox;

            comidas ComidaResult = GetComidaById(com_id);
            if (ComidaResult != null)
            {
                txtPrecio.Text = ComidaResult.pre_precio.Value.ToString("0.00");
                int cantidad = 0;
                cantidad = int.Parse(txtCantidad.Text);
                txtSubtotal.Text = "" + cantidad * ComidaResult.pre_precio;
            }
            else
            {
                txtPrecio.Text = "0.00";
                txtCantidad.Text = "0.00";
                txtSubtotal.Text = "0.00";
            }

            // RecalcularTotalFooter();
        }

        public void RecalcularTotalFooter(GridViewRowEventArgs e)
        {
            decimal Total = 0;
            foreach (GridViewRow itemRow in grdVentas.Rows)
            {
                DropDownList ddlCodigosComidas = itemRow.FindControl("ddlCodigosComidas") as DropDownList;
                if (ddlCodigosComidas.SelectedValue != "-1") // Con selección
                {
                    TextBox txtCantidad = itemRow.FindControl("txtCantidad") as TextBox;
                    comidas comidaResult = GetComidaById(int.Parse(ddlCodigosComidas.SelectedValue));

                    if (comidaResult != null)
                    {
                        Total += decimal.Parse(txtCantidad.Text) * (decimal)comidaResult.pre_precio.Value;
                    }
                }
            }

            TextBox txtTotal = e.Row.FindControl("txtTotal") as TextBox;
            if (txtTotal != null)
            {
                txtTotal.Text = ""+ Total;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}