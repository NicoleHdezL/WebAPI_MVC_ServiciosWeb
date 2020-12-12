using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppReservasSW.Models;
using AppReservasSW.Controllers;
using System.Collections.ObjectModel;
using System.Drawing;
using Microsoft.Ajax.Utilities;

namespace AppReservasSW
{
    public partial class Compania : System.Web.UI.Page
    {
        IEnumerable<Models.Compania> companias = new ObservableCollection<Models.Compania>();
        CompaniaManager companiaManager = new CompaniaManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }
        private async void InicializarControles()
        {
            companias = await companiaManager.ObtenerCompanias(VG.usuarioActual.CadenaToken);
            grdCompanias.DataSource = companias.ToList();
            grdCompanias.DataBind();
        }

        async protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Compania companiaIngresado = new Models.Compania();
                Models.Compania compania = new Models.Compania()
                {
                    /*COMPA_NOMBRE = txtNombre.Text,
                    COMPA_DESCRIPCION = txtDescripcion.Text*/
                };

                companiaIngresado =
                    await companiaManager.Ingresar(compania, VG.usuarioActual.CadenaToken);

                if (companiaIngresado != null)
                {
                    lblStatus.Text = "Companía ingresada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al ingresar la compañia";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }
        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarModificar())
            {
                Models.Compania companiaModificado = new Models.Compania();
                Models.Compania compania = new Models.Compania()
                {
                    COMPA_ID = Convert.ToInt32(txtCodigo.Text),
                    COMPA_NOMBRE = txtNombre.Text,
                    COMPA_DESCRIPCION = txtDescripcion.Text
                };

                companiaModificado =
                    await companiaManager.Actualizar(compania, VG.usuarioActual.CadenaToken);

                if (companiaModificado != null)
                {
                    lblStatus.Text = "Compañía modificada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al modificar la Compañía";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                string codigoCompaniaEliminado = string.Empty;
                string codigoCompania = string.Empty;

                codigoCompania = txtCodigo.Text;

                codigoCompaniaEliminado =
                    await companiaManager.Eliminar(codigoCompania, VG.usuarioActual.CadenaToken);

                if (!string.IsNullOrEmpty(codigoCompaniaEliminado))
                {
                    lblStatus.Text = "Compañía eliminada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al eliminar la Compañía";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
            else
            {
                lblStatus.Text = "Debe ingresar el código";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
            }
        }

        private bool ValidarInsertar()
        {

            if (txtNombre.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el nombre de la compañía";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción de la compañía";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            return true;
        }


        private bool ValidarModificar()
        {
            if (txtCodigo.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el código de la compañía";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtNombre.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el nombre de la compañía";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción de la compañía";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            return true;
        }
    }
}