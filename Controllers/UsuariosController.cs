using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpPost("Registrar")]

        public async Task<IActionResult> RegistrarUsuario(Usuario User)
        {
            try
            {
                if (await UsuarioExistente(User.Username))
                throw new System.Exception("Nome de Usuario ja Existe");

                Criptografia.CriarPasswordHash(User.PasswordString, out byte[] hash, out byte[] salt);
                User.PasswordString = string.Empty;
                User.PasswordHash = hash;
                User.PasswordSalt = salt;
                await _context.Usuarios.AddAsync(User);
                await _context.SaveChangesAsync();

                return Ok(User.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                   .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    usuario.DataAcesso = System.DateTime.Now;
                    _context.Usuarios.Update(usuario);
                    await _context.SaveChangesAsync(); //Confirma a alteração no banco
                    
                    
                    return Ok(usuario.Id);
                    
                }
            }
            catch (System.Exception ex)
            { 
                return BadRequest(ex.Message); 
            }
        }

        
        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenhaUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                    if(usuario == null)
                        throw new System.Exception("usuario nao encomtrado");

                    Criptografia.CriarPasswordHash(credenciais.PasswordString, out byte[] hash, out byte[] salt);
                    usuario.PasswordHash = hash;
                    usuario.PasswordSalt = salt;

                    _context.Usuarios.Update(usuario);
                    int linhasAfetadas = await _context.SaveChangesAsync();
                    return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

    }

}
