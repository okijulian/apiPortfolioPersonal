namespace WebServicePorforlio.Models.Response
{
    public class ResponseDescripcionPersonal
    {
        public int Exito { get; set; }

        public string Mensaje { get; set; }

        public List<DescripcionPersonal> Data { get; set; }

        public ResponseDescripcionPersonal()
        {
            this.Exito = 0;
        }
}
}
