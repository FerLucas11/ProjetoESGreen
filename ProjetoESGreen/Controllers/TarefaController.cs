using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoESGreen.Data;
using ProjetoESGreen.Models;

namespace ProjetoESGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarefaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> Get()
        {
            return await _context.Tarefas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> Get(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ConcludeTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            if(tarefa.Status == Models.TaskStatus.Concluido)
            {
                return NoContent();
            }

            tarefa.Status = Models.TaskStatus.Concluido;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaExiste(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
        
    }
}
