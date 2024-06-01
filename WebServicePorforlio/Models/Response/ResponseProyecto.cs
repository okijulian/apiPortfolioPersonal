namespace WebServicePorforlio.Models.Response
{
    public class ResponseProyecto
    {
        public int Exito { get; set; }

        public string Mensaje { get; set; } 

        public List<Proyecto> Data { get; set; }    

        public ResponseProyecto() {
            this.Exito = 0;
        }  
    }
}
