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

namespace AppReservasSW.Views
{
    public partial class Equipaje : System.Web.UI.Page
    {
        IEnumerable<Models.Equipaje> equipajes = new ObservableCollection<Models.Equipaje>();
        EquipajeManager equipajeManager = new EquipajeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        private async void InicializarControles()
        {
            equipajes = await equipajeManager.ObtenerEquipajes(VG.usuarioActual.CadenaToken);
            grdEquipajes.DataSource = equipajes.ToList();
            grdEquipajes.DataBind();
        }

        async protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Equipaje equipajeIngresado = new Models.Equipaje();
                Models.Equipaje equipaje = new Models.Equipaje()
                {
                    EQUI_TIPO = txtTipo.Text,
                    EQUI_PRECIO = Convert.ToInt32(txtPrecio.Text),
                    EQUI_DESCRIPCION = txtDescripcion.Text
                };

                equipajeIngresado =
                    await equipajeManager.Ingresar(equipaje, VG.usuarioActual.CadenaToken);

                if (equipajeIngresado != null)
                {
                    lblStatus.Text = "Equipaje ingresado correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al ingresar el equipaje";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }
        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarModificar())
            {
                Models.Equipaje equipajeModificado = new Models.Equipaje();
                Models.Equipaje equipaje = new Models.Equipaje()
                {
                    EQUI_ID = Convert.ToInt32(txtCodigo.Text),
                    EQUI_TIPO = txtTipo.Text,
                    EQUI_PRECIO = Convert.ToInt32(txtPrecio.Text),
                    EQUI_DESCRIPCION = txtDescripcion.Text
                };

                equipajeModificado =
                    await equipajeManager.Actualizar(equipaje, VG.usuarioActual.CadenaToken);

                if (equipajeModificado != null)
                {
                    lblStatus.Text = "Equipaje modificado correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al modificar el Equipaje";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                string codigoEquipajeEliminado = string.Empty;
                string codigoEquipaje = string.Empty;

                codigoEquipaje = txtCodigo.Text;

                codigoEquipajeEliminado =
                    await equipajeManager.Eliminar(codigoEquipaje, VG.usuarioActual.CadenaToken);

                if (!string.IsNullOrEmpty(codigoEquipajeEliminado))
                {
                    lblStatus.Text = "Equipaje eliminado correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al eliminar el Equipaje";
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

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

        }

        private bool ValidarInsertar()
        {

            if (txtTipo.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el tipo del equipaje";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtPrecio.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el precio del equipaje";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción del equipaje";
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
                lblStatus.Text = "Debe ingresar el codigo del Equipaje";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtTipo.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el tipo del equipaje";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtPrecio.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el precio del equipaje";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción del equipaje";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            return true;
        }

    }
}