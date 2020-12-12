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
    public partial class Seguro : System.Web.UI.Page
    {
        IEnumerable<Models.Seguro> seguros = new ObservableCollection<Models.Seguro>();
        SeguroManager seguroManager = new SeguroManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        private async void InicializarControles()
        {
            seguros = await seguroManager.ObtenerSeguros(VG.usuarioActual.CadenaToken);
            grdSeguros.DataSource = seguros.ToList();
            grdSeguros.DataBind();
        }

       async protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Seguro seguroIngresado = new Models.Seguro();
                Models.Seguro seguro = new Models.Seguro()
                {
                    SEG_TIPO = txtTipo.Text,
                    SEG_PRECIO = Convert.ToInt32(txtPrecio.Text),
                    SEG_DESCRIPCION = txtDescripcion.Text
                };

                seguroIngresado =
                    await seguroManager.Ingresar(seguro, VG.usuarioActual.CadenaToken);

                if (seguroIngresado != null)
                {
                    lblStatus.Text = "Seguro ingresado correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al ingresar el seguro";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }

       async protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarModificar())
            {
                Models.Seguro seguroModificado = new Models.Seguro();
                Models.Seguro seguro = new Models.Seguro()
                {
                    SEG_ID = Convert.ToInt32(txtCodigo.Text),
                    SEG_TIPO = txtTipo.Text,
                    SEG_PRECIO = Convert.ToInt32(txtPrecio.Text),
                    SEG_DESCRIPCION = txtDescripcion.Text
                };

                seguroModificado =
                    await seguroManager.Actualizar(seguro, VG.usuarioActual.CadenaToken);

                if (seguroModificado != null)
                {
                    lblStatus.Text = "Seguro modificado correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al modificar el seguro";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                string codigoSeguroEliminado = string.Empty;
                string codigoSeguro = string.Empty;

                codigoSeguro = txtCodigo.Text;

                codigoSeguroEliminado =
                    await seguroManager.Eliminar(codigoSeguro, VG.usuarioActual.CadenaToken);

                if (!string.IsNullOrEmpty(codigoSeguroEliminado))
                {
                    lblStatus.Text = "Seguro eliminado correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al eliminar el seguro";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
            else
            {
                lblStatus.Text = "Debe ingresar el codigo";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
            }
        }


        private bool ValidarInsertar()
        {

            if (txtTipo.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el tipo del seguro";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtPrecio.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el precio del seguro";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción del seguro";
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
                lblStatus.Text = "Debe ingresar el codigo del seguro";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtTipo.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el tipo del seguro";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtPrecio.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el precio del seguro";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción del seguro";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            return true;
        }
    }
}