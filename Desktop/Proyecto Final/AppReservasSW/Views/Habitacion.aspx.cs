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
    public partial class Habitacion : System.Web.UI.Page
    {
        IEnumerable<Models.Habitacion> habitaciones = new ObservableCollection<Models.Habitacion>();
        HabitacionManager habitacionManager = new HabitacionManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        private async void InicializarControles()
        {

            habitaciones = await habitacionManager.ObtenerHabitaciones(VG.usuarioActual.CadenaToken);
            grdHabitacion.DataSource = habitaciones.ToList();
            grdHabitacion.DataBind();
        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Habitacion habitacionIngresado = new Models.Habitacion();
                Models.Habitacion habitacion = new Models.Habitacion()
                {
                    HOT_CODIGO = Convert.ToInt32(txtCodigoHotel.Text),
                    HAB_NUMERO = Convert.ToInt32(txtNumero.Text),
                    HAB_CAPACIDAD = Convert.ToInt32(txtCapacidad.Text),
                    HAB_TIPO = txtTipo.Text,
                    HAB_DESCRIPCION = txtDescripcion.Text,
                    HAB_ESTADO = drpEstado.SelectedValue.ToString(),
                    HAB_PRECIO = Convert.ToInt32(txtPrecio.Text)
                };

                habitacionIngresado =
                    await habitacionManager.Ingresar(habitacion, VG.usuarioActual.CadenaToken);

                if (habitacionIngresado != null)
                {
                    lblStatus.Text = "Habitación ingresado correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al ingresar la habitación";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarModificar())
            {
                Models.Habitacion habitacionModificado = new Models.Habitacion();
                Models.Habitacion habitacion = new Models.Habitacion()
                {
                    HOT_CODIGO = Convert.ToInt32(txtCodigoHotel.Text),
                    HAB_NUMERO = Convert.ToInt32(txtNumero.Text),
                    HAB_CAPACIDAD = Convert.ToInt32(txtCapacidad.Text),
                    HAB_TIPO = txtTipo.Text,
                    HAB_DESCRIPCION = txtDescripcion.Text,
                    HAB_ESTADO = drpEstado.SelectedValue.ToString(),
                    HAB_PRECIO = Convert.ToInt32(txtPrecio.Text)
                };

                habitacionModificado =
                    await habitacionManager.Actualizar(habitacion, VG.usuarioActual.CadenaToken);

                if (habitacionModificado != null)
                {
                    lblStatus.Text = "Habitación modificada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al modificar la habitación";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                string codigoHabitacionEliminado = string.Empty;
                string codigoHabitacion = string.Empty;

                codigoHabitacion = txtCodigo.Text;

                codigoHabitacionEliminado =
                    await habitacionManager.Eliminar(codigoHabitacion, VG.usuarioActual.CadenaToken);

                if (!string.IsNullOrEmpty(codigoHabitacionEliminado))
                {
                    lblStatus.Text = "Habitación eliminada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al eliminar la habitación";
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }


        private bool ValidarInsertar()
        {

            if (txtNumero.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el nombre del número de hotel";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtCapacidad.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la capacidad de la habitación";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtTipo.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el tipo de habitación";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción de la habitación";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtPrecio.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el precio de la habitación";
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
                lblStatus.Text = "Debe ingresar el nombre del número de hotel";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtNumero.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el nombre del número de hotel";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtCapacidad.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la capacidad de la habitación";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtTipo.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el tipo de habitación";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtDescripcion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar la descripción de la habitación";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtPrecio.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el precio de la habitación";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            return true;
        }
    }
}
