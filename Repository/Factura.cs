//// CONTIENE LAS CLASES MODELOS

using System;
using System.ComponentModel.DataAnnotations;

namespace Repository
{
    public class Factura
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El número de factura es obligatorio.")]
        public string Nro_factura { get; set; } = "";

        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El campo 'Total' es obligatorio.")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El campo 'Total_iva5' es obligatorio.")]
        public decimal Total_iva5 { get; set; }

        [Required(ErrorMessage = "El campo 'Total_iva10' es obligatorio.")]
        public decimal Total_iva10 { get; set; }

        [Required(ErrorMessage = "El campo 'Total_iva' es obligatorio.")]
        public decimal Total_iva { get; set; }

        [Required(ErrorMessage = "El campo 'Total_letras' es obligatorio.")]
        public string Total_letras { get; set; } = "";

        [Required(ErrorMessage = "El campo 'Sucursal' es obligatorio.")]
        public string Sucursal { get; set; } = "";
    }
}
