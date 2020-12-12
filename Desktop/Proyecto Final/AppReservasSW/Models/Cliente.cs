using System;

namespace AppReservasSW.Models
{
    public class Cliente
    {
        public int CLIE_CODIGO { get; set; }
        public string CLIE_IDENTIFICACION { get; set; }
        public string CLIE_NOMBRE { get; set; }
        public string CLIE_PASSWORD { get; set; }
        public string CLIE_EMAIL { get; set; }
        public string CLIE_ESTADO { get; set; }
        public DateTime CLIE_FEC_NAC { get; set; }
        public string CLIE_TELEFONO { get; set; }
    }
}