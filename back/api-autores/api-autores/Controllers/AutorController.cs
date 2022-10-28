using api_autores.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_autores.Controllers
{
    //Indicamos que es un controlador
    [ApiController]
    //definir la ruta de acceso al controlador
    [Route("api-autores/autor")]
    // :ControllerBase es una herencia para que sea un controlador
    public class AutorController: ControllerBase
    {
        private readonly ApplicationDBContext context;

        //creamos el metodo constructor
        public AutorController(ApplicationDBContext context)
        {
            this.context = context;
        }

        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Autor>>>findAll()
        {
            return await context.Autor.ToListAsync();
        }

        //cuando queremos obtener solo los habiitaddos
        [HttpGet("custom")]
        public async Task<ActionResult<List<Autor>>> findAllCustom()
        {
            return await context.Autor.Where(x => x.estado == true).ToListAsync();
        }

        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult>add(Autor a)
        {
            context.Add(a);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> findById(int id)
        {
            var autor = await context.Autor
                .FirstOrDefaultAsync(x => x.codigoautor == id);
            return autor;
        }

        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult>update(Autor a, int id)
        {
            if(a.codigoautor!=id)
            {
                return BadRequest("No se encuentra el codigo correspondiente");
            }

            context.Update(a);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos eliminar informacion
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Autor.AnyAsync(x => x.codigoautor == id);
            if (!existe)
            {
                return NotFound();
            }
            var autor = await context.Autor.FirstOrDefaultAsync(x => x.codigoautor == id);
            autor.estado = false;
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
