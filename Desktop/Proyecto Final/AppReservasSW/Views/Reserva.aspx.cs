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
    public partial class Reserva : System.Web.UI.Page
    {
        IEnumerable<Models.Reserva> reservas= new ObservableCollection<Models.Reserva>();
        ReservaManager reservaManager = new ReservaManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }
        private async void InicializarControles()
        {

            reservas = await reservaManager.ObtenerReservas(VG.usuarioActual.CadenaToken);
            grdReserva.DataSource = reservas.ToList();
            grdReserva.DataBind();
        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Reserva reservaIngresado = new Models.Reserva();
                Models.Reserva reserva = new Models.Reserva()
                {
                    USU_CODIGO = Convert.ToInt32(txtCodigoUsuario.Text),
                    HAB_CODIGO = Convert.ToInt32(txtCodigoHabitacion.Text),
                    RES_FECHA_INGRESO = txtFechaIngreso.Text,
                    RES_FECHA_SALIDA = txtFechaSalida.Text
                };

                reservaIngresado =
                    await reservaManager.Ingresar(reserva, VG.usuarioActual.CadenaToken);

                if (reservaIngresado != null)
                {
                    lblStatus.Text = "Reserva ingresada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al ingresar la reserva";
                    lblStatus.ForeColor = Color.Maroon;
                    lblStatus.Visible = true;
                }
            }
        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            {
                if (ValidarModificar())
                {
                    Models.Reserva reservaModificado = new Models.Reserva();
                    Models.Reserva reserva = new Models.Reserva()
                    {
                        RES_CODIGO = Convert.ToInt32(txtCodigo.Text),
                        USU_CODIGO = Convert.ToInt32(txtCodigoUsuario.Text),
                        HAB_CODIGO = Convert.ToInt32(txtCodigoHabitacion.Text),
                        RES_FECHA_INGRESO = txtFechaIngreso.Text,
                        RES_FECHA_SALIDA = txtFechaSalida.Text
                    };

                    reservaModificado =
                        await reservaManager.Actualizar(reserva, VG.usuarioActual.CadenaToken);

                    if (reservaModificado != null)
                    {
                        lblStatus.Text = "Reserva modificada correctamente";
                        lblStatus.Visible = true;
                        InicializarControles();
                    }
                    else
                    {
                        lblStatus.Text = "Hubo un error al modificar la reserva";
                        lblStatus.ForeColor = Color.Maroon;
                        lblStatus.Visible = true;
                    }
                }
            }

        }

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                string codigoReservaEliminado = string.Empty;
                string codigoReserva = string.Empty;

                codigoReserva = txtCodigo.Text;

                codigoReservaEliminado =
                    await reservaManager.Eliminar(codigoReserva, VG.usuarioActual.CadenaToken);

                if (!string.IsNullOrEmpty(codigoReservaEliminado))
                {
                    lblStatus.Text = "Reserva eliminada correctamente";
                    lblStatus.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblStatus.Text = "Hubo un error al eliminar la reserva";
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

            if (txtCodigoUsuario.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el código del Usuario";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtCodigoHabitacion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el código de la Habitación";
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
                lblStatus.Text = "Debe ingresar el código del Usuario";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtCodigoUsuario.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el código del Usuario";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            if (txtCodigoHabitacion.Text.IsNullOrWhiteSpace())
            {
                lblStatus.Text = "Debe ingresar el código de la Habitación";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.Visible = true;
                return false;
            }

            return true;
        }

    }
}