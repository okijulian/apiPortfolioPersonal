using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicePorforlio.Models;
using WebServicePorforlio.Models.Request;
using WebServicePorforlio.Models.Response;

namespace WebServicePorforlio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosPersonaController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public DatosPersonaController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult VerDatosPersona()
        {
            ResponseDatosPersona oRespuesta = new ResponseDatosPersona();
            try
            {
                var persona = _context.DatosPersonas.ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Data = persona;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult AgregarDatosPersona(DatosPersonaRequest model)
        {
            ResponseDatosPersona oRespuesta = new ResponseDatosPersona();

            try
            {
                DatosPersona oPersona = new DatosPersona();
                oPersona.Apellido = model.Apellido;
                oPersona.Nombre = model.Nombre;
                oPersona.Email = model.Email;
                oPersona.Telefono = model.Telefono;

                _context.DatosPersonas.Add(oPersona);
                _context.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }



        [HttpPut]
        public IActionResult ActualizarDatosPersona(DatosPersonaRequest model)
        {
            ResponseDatosPersona oRespuesta = new ResponseDatosPersona();

            try
            {
                DatosPersona oPersona = _context.DatosPersonas.Find(model.Id);
                oPersona.Apellido = model.Apellido;
                oPersona.Nombre = model.Nombre;
                oPersona.Email = model.Email;
                oPersona.Telefono = model.Telefono;

                _context.Entry(oPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult BorrarDatoPersona(int Id)
        {
            ResponseDatosPersona oRespuesta = new ResponseDatosPersona();

            try
            {
                DatosPersona oPersona = _context.DatosPersonas.Find(Id);

                _context.Remove(oPersona);
                _context.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


    }
}
