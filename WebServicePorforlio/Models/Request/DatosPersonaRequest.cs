namespace WebServicePorforlio.Models.Request
{
    public class DatosPersonaRequest
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string? Email { get; set; }

        public long? Telefono { get; set; }
    }
}
