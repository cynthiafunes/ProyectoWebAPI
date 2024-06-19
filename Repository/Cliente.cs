namespace Repository
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Id_banco { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; } 
        public required string Documento { get; set; } 
        public required string Direccion { get; set; } 
        public required string Mail { get; set; } 
        public required string Celular { get; set; } 
        public required string Estado { get; set; } 
    }
}
