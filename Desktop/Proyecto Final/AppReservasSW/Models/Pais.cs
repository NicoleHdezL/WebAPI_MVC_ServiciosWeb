using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppReservasSW.Models
{
    public class Pais
    {
        public int PAI_ID { get; set; }
        public string PAI_CODIGO_PAIS { get; set; }
        public string PAI_TIPO { get; set; }
        public string PAI_DESCRIPCION { get; set; }
    }
}