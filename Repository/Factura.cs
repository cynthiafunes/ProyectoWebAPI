using System;

namespace Repository
{
    public class Factura
    {
        public int Id { get; set; }
        public int Id_cliente { get; set; }
        public required string Nro_factura { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public decimal Total { get; set; }
        public decimal Total_iva5 { get; set; }
        public decimal Total_iva10 { get; set; }
        public decimal Total_iva { get; set; }
        public required string Total_letras { get; set; }
        public required string Sucursal { get; set; }
    }
}
