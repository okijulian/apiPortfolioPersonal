namespace WebServicePorforlio.Models.Response
{
    public class ResponseDatosPersona
    {
        public int Exito { get; set; }

        public string Mensaje { get; set; }

        public List<DatosPersona> Data { get; set; }

        public ResponseDatosPersona()
        {
            this.Exito = 0;
        }
    }
}
