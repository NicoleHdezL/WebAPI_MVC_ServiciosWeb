using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppReservasSW.Models
{
    public class Aeropuerto
    {
        public int AERO_ID { get; set; }
        public string AERO_CODIGO_AEROPUERTO { get; set; }
        public string AERO_TIPO { get; set; }
        public string AERO_DESCRIPCION { get; set; }
    }
}