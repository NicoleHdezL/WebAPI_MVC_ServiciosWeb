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
    public partial class Clase : System.Web.UI.Page
    {
        IEnumerable<Models.Clase> clases = new ObservableCollection<Models.Clase>();
        ClaseManager claseManager = new ClaseManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }
        private async void InicializarControles()
        {
            clases = await claseManager.ObtenerClases(VG.usuarioActual.CadenaToken);
            grdClases.DataSource = clases.ToList();
            grdClases.DataBind();
        }

        async protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Clase claseIngresado = new Models.Clase();
                Models.Clase clase = new Models.Clase()
                {
                    CLAS_TIPO = txtTipo.Text,
                    CLAS_PRECIO = Convert.ToInt32(txtPrecio.Text),
                    CLAS_DESCRIPCION = txtDescripcion.Text
                };

                claseIngresado =
                    await claseManager.Ingresar(clase, VG.usuarioActual.CadenaToken);

                if (claseIngresado != null)
                {
                    lblStatus.Text = "Clase ingresada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al ingresar la clase";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }
        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarModificar())
            {
                Models.Clase claseModificado = new Models.Clase();
                Models.Clase clase = new Models.Clase()
                {
                    CLAS_ID = Convert.ToInt32(txtCodigo.Text),
                    CLAS_TIPO = txtTipo.Text,
                    CLAS_PRECIO = Convert.ToInt32(txtPrecio.Text),
                    CLAS_DESCRIPCION = txtDescripcion.Text
                };

                claseModificado =
                    await claseManager.Actualizar(clase, VG.usuarioActual.CadenaToken);

                if (claseModificado != null)
                {
                    lblStatus.Text = "Clase modificada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al modificar la Clase";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                string codigoClaseEliminado = string.Empty;
                string codigoClase = string.Empty;

                codigoClase = txtCodigo.Text;

                codigoClaseEliminado =
                    await claseManager.Eliminar(codigoClase, VG.usuarioActual.CadenaToken);

                if (!string.IsNullOrEmpty(codigoClaseEliminado))
                {
                    lblStatus.Text = "Clase eliminada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al eliminar la clase";
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

            if (txtTipo.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el tipo de clase";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtPrecio.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el precio de la clase";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción de la clase";
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
                lblStatus.Text = "Debe ingresar el codigo de la clase";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtTipo.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el tipo de la clase";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtPrecio.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el precio de la clase";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción de la clase";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            return true;
        }
    }
}