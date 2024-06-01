using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicePorforlio.Models;
using WebServicePorforlio.Models.Request;
using WebServicePorforlio.Models.Response;

namespace WebServicePorforlio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescripcionPersonalController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public DescripcionPersonalController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        //metodo get para  consultar los datos de mi tabla 
        public IActionResult verDescripcion()
        {
            ResponseDescripcionPersonal oRespuesta = new ResponseDescripcionPersonal();

            try
            {
                    var descripcion = _context.DescripcionPersonal.ToList();
                    oRespuesta.Exito = 1;
                   oRespuesta.Data = descripcion;
                
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        //metodo  post para agregar nuevo registro
        [HttpPost]
        public IActionResult AgregarDescripcion(DescripcionPersonalRequest model)
        {
            ResponseDescripcionPersonal oRespuesta = new ResponseDescripcionPersonal();

            try
            {
                DescripcionPersonal oDescripcion = new DescripcionPersonal();
                oDescripcion.Descripcion = model.Descripcion;
                oDescripcion.FechaCreacion = model.FechaCreacion;
                oDescripcion.FechaModificacion = model.FechaModificacion;

                //agregar a la base de datos
                _context.DescripcionPersonal.Add(oDescripcion);
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
        public IActionResult ActualizarDescripcion(DescripcionPersonalRequest model)
        {
            ResponseDescripcionPersonal oRespuesta = new ResponseDescripcionPersonal();

            try
            {
                DescripcionPersonal oDescripcion = _context.DescripcionPersonal.Find(model.id);
                oDescripcion.Descripcion = model.Descripcion;
                oDescripcion.FechaCreacion = model.FechaCreacion;
                oDescripcion.FechaModificacion = model.FechaModificacion;

                //actualizar a la base de datos
                _context.Entry(oDescripcion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        //borrar un elemento de la tabla 
        [HttpDelete("{id}")]
        public IActionResult BorrarDescripcion(int id)
        {
            ResponseDescripcionPersonal oRespuesta = new ResponseDescripcionPersonal();

            try
            {
                DescripcionPersonal oDescripcion = _context.DescripcionPersonal.Find(id);
                _context.Remove(oDescripcion);
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
