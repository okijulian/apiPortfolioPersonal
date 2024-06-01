namespace WebServicePorforlio.Models.Request
{
    public class DescripcionPersonalRequest
    {
        public int id { get; set; }
        public string Descripcion {  get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }


    }
}
