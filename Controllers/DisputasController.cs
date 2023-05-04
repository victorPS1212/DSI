using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using System.Text;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;

        public DisputasController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync(Disputa d)
        {
            try
            {
                //aqui
                Personagem atacante = await _context.Personagens
                .Include(p => p.Arma)
                .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);


                Personagem oponente = await _context.Personagens
                .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                int Dano = atacante.Arma.Dano + (new Random().Next(atacante.Forca));

                Dano = Dano - new Random().Next(oponente.Defesa);

                if(Dano > 0)
                oponente.PontosVida = oponente.PontosVida - (int)Dano;
                if(oponente.PontosVida <= 0)
                d.Narracao = $"{oponente.Nome} foi derrotado!!!";

                _context.Personagens.Update(oponente);
                await _context.SaveChangesAsync();

                StringBuilder dados = new StringBuilder();
                dados.AppendFormat("Atacante: {0}.", atacante.Nome);
                dados.AppendFormat("Oponente: {0}.", oponente.Nome);
                dados.AppendFormat("Pontos de vida do Atacante: {0}.", atacante.PontosVida);
                dados.AppendFormat("Pontos de vida do oponente: {0}.", oponente.PontosVida);
                dados.AppendFormat("Arma Utilizada: {0}.", atacante.Arma.Nome);
                dados.AppendFormat("Dano: {0}.", Dano);

                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;
                _context.Disputas.Add(d);
                _context.SaveChanges();

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Habilidade")]
        public async Task<IActionResult> AtaqueComHabilidadeAsync(Disputa d)
        {
            try
            {
                //aqui
                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}