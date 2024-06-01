using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServicePorforlio.Models;
using WebServicePorforlio.Models.Request;
using WebServicePorforlio.Models.Response;

namespace WebServicePorforlio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {

        private readonly PortfolioContext _context;

        public ProyectoController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult verProyectos()
        {
            ResponseProyecto oRespuesta = new ResponseProyecto();
            try
            {
                var todosProyectos = _context.Proyectos.ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Data = todosProyectos;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        //metodo  post para agregar nuevo registro
        [HttpPost]
        public IActionResult AgregarProyecto(ProyectoRequest model)
        {
            ResponseProyecto oRespuesta = new ResponseProyecto();

            try
            {
                Proyecto oProyecto = new Proyecto();
                oProyecto.Nombre = model.Nombre;
                oProyecto.Descripcion = model.Descripcion;
                //oProyecto.Imagen = model.Imagen;

                //agregar a la base de datos
                _context.Proyectos.Add(oProyecto);
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
        public IActionResult ActualizarProyecto(ProyectoRequest model)
        {
            ResponseProyecto oRespuesta = new ResponseProyecto();

            try
            {
                Proyecto oProyecto = _context.Proyectos.Find(model.Id);
                oProyecto.Nombre = model.Nombre;
                oProyecto.Descripcion = model.Descripcion;
                //oProyecto.Imagen = model.Imagen;

                //actualizar a la base de datos
                _context.Entry(oProyecto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarProyecto(int id)
        {
            ResponseProyecto oRespuesta = new ResponseProyecto();

            try
            {
                Proyecto oProyecto = _context.Proyectos.Find(id);
                _context.Remove(oProyecto);
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
