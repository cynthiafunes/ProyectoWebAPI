// CONTIENE LAS CLASES MODELOS

using System.ComponentModel.DataAnnotations;

namespace Repository
{
    public class Cliente
    {
        public int Id { get; set; }

        public int IdBanco { get; set; }

        [Required(ErrorMessage = "El campo 'Nombre' es obligatorio.")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El campo 'Apellido' es obligatorio.")]
        public string Apellido { get; set; } = "";

        [Required(ErrorMessage = "El campo 'Documento' es obligatorio.")]
        public string Documento { get; set; } = "";

        [Required(ErrorMessage = "El campo 'Direccion' es obligatorio.")]
        public string Direccion { get; set; } = "";

        [Required(ErrorMessage = "El campo 'Mail' es obligatorio.")]
        public string Mail { get; set; } = "";

        [Required(ErrorMessage = "El campo 'Celular' es obligatorio.")]
        public string Celular { get; set; } = "";

        [Required(ErrorMessage = "El campo 'Estado' es obligatorio.")]
        public string Estado { get; set; } = "";
    }
}
