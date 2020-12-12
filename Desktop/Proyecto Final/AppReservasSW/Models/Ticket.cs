using System;

namespace AppReservasSW.Models
{
    public class Ticket
    {
        public int TICK_ID { get; set; }
        public DateTime TICK_FECHA { get; set; }
        public int TICK_PRECIO { get; set; }
        public string TICK_DESCRIPCION { get; set; }
        public int COMPA_ID { get; set; }
        public int ITIN_ID { get; set; }
        public int AERO_ID { get; set; }
        public int PAI_ID { get; set; }
        public int SEG_ID { get; set; }
        public int AVI_ID { get; set; }
        public int CLAS_ID { get; set; }
        public int EQUI_ID { get; set; }
        public int CLIE_CODIGO { get; set; }
        public int USU_CODIGO { get; set; }
        public string TICK_MONEDA { get; set; }
    }
}