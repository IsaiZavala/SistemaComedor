using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;
using Models;
using Models.StoredProceduresClasses;
using PCV.WEB.Objects;

namespace PCV.WEB.Forms
{
    public partial class Lunch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Producto> lstProductos = new List<Producto>();

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

        private void LoadCatalogosComidas()
        {
            ProcterGambleRepository repo = new ProcterGambleRepository();
            List<comidas> lstComidas = repo.ConsultaCatalogoComidas();

            ddlCodigosComidas.DataTextField = "com_descripcion";
            ddlCodigosComidas.DataValueField = "com_id";
            ddlCodigosComidas.DataSource = lstComidas;
            ddlCodigosComidas.DataBind();
            ddlCodigosComidas.Items.Insert(0, new ListItem() { Text = "---------", Value = "-1" });
            ddlCodigosComidas.SelectedIndex = 0;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto nuevoProd = new Producto();
            nuevoProd.NombreProducto = ddlCodigosComidas.SelectedItem.Text;
            nuevoProd.Cantidad = int.Parse(txtCantidad.Text);

            grdVentas.DataSource = nuevoProd;
            grdVentas.DataBind();
        }
    }
}