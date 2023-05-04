using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagemHabilidadesController(DataContext context)
        {
            _context = context;
        } 

        [HttpPost]

        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade)
        {
            try
            {//codigo aqui

                Personagem personagem = await _context.Personagens
                    .Include(p => p.Arma)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                    .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if (personagem == null)
                    throw new System.Exception("Personagem nao emcontrado para o Id informado");

                Habilidade habilidade = await _context.Habilidades
                                    .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if (habilidade == null)
                    throw new System.Exception("Habilidade nao emcontrada.");

                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.PersonagemHabilidades.AddAsync(ph);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
        [HttpGet("{personagemId}")]
        public async Task<IActionResult> GetHabilidadesPersonagem(int personagemId)
        {
            try
            {
                List<PersonagemHabilidade> phLista = new List<PersonagemHabilidade>();
                phLista = await _context.PersonagemHabilidades
                .Include(p => p.Personagem)
                .Include(p => p.Habilidade)
                .Where(p => p.Personagem.Id == personagemId).ToListAsync();
                return Ok(phLista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetHabilidades")]
        public async Task<IActionResult> GetHabilidade()
        {
            try
            {
                List<Habilidade> Habilidades = new List<Habilidade>();
                Habilidades = await _context.Habilidades.ToListAsync();
                return Ok(Habilidades);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}