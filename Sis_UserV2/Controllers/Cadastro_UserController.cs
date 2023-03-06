using Core.Seguranca;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sis_UserV2.Dto;
using Sis_UserV2.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace Sis_UserV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCorsAttribute("*","*","*")]
    public class Cadastro_UserController: ControllerBase
    {
        private ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private Cryptography _crypto = new Cryptography();
        private readonly DbSet<Auth_User> _dbAuth_User;
        private readonly DbSet<User> _dbUser;
        private readonly DbSet<Fone_User> _dbFone_User;
        private readonly DbSet<Image_User> _dbImage_User;
        private readonly DbSet<Doc_User> _dbDoc_User;
        private readonly DbSet<Endereco_User> _dbEndereco_User;

        public Cadastro_UserController(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            _dbUser = db.Set<User>();
            _dbAuth_User = db.Set<Auth_User>();
            _dbDoc_User = db.Set<Doc_User>();
            _dbImage_User = db.Set<Image_User>();
            _dbFone_User = db.Set<Fone_User>();
            _dbEndereco_User = db.Set<Endereco_User>();
        }


        [HttpPost]
        [Route("insere/User")]
        public async Task<IActionResult> RegistraUser([FromBody] User model)
        {
            var CPFExists = await _dbUser.FirstOrDefaultAsync(x => x.CPF == model.CPF);
            if (CPFExists != null)
            {
                Response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "CPF já existe" });
            }
            User regulariza = new User()
            {
                CPF = model.CPF,
                Email = model.Email,
                RG = model.RG,
                Observacao = model.Observacao,
            };
            try
            {
                await _dbUser.AddRangeAsync(regulariza);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dados do Usuario não adicionados na tabela");
            }
            Response.StatusCode = 200;
            return Ok(new { Status = "Sucess", Message = "Dados do Usuario cadastrado com sucesso na tabela", StatusCode = 200 });
        }

        [HttpPost]
        [Route("insere/FoneUser")]
        public async Task<IActionResult> RegistraFoneUser([FromBody] Fone_User model)
        {
            var CPFExists = await _dbFone_User.FirstOrDefaultAsync(x => x.CPF == model.CPF);
            if (CPFExists != null)
            {
                Response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, "CPF já existe ");
            }
            Fone_User Fone = new Fone_User()
            {
                CPF = model.CPF,
                FoneCelular1 = model.CPF,
                FoneCelular2 = model.CPF,
                FoneFixo = model.CPF,
            };
            try
            {
                await _dbFone_User.AddRangeAsync(Fone);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Fone não adicionados na tabela");
            }
            Response.StatusCode = 200;
            return Ok(new { Status = "Sucess", Message = "Fone do Usuario cadastrado com sucesso na tabela" });
        }

        [HttpPost]
        [Route("insere/EnderecoUser")]
        public async Task<IActionResult> RegistraEnderecoUser([FromBody] Endereco_User model)
        {
            var CPFExists = await _dbEndereco_User.FirstOrDefaultAsync(x => x.CPF == model.CPF);
            if (CPFExists != null)
            {
                Response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, "CPF já existe ");
            }
            Endereco_User Endereco = new Endereco_User()
            {
                CPF = model.CPF,
                Rua = model.Rua,
                Bairro = model.Bairro,
                Lote = model.Lote,
                Quadra = model.Quadra,
                CEP = model.CEP,
                Cidade = model.Cidade,
                Estado = model.Estado,

            };
            try
            {
                await _dbEndereco_User.AddRangeAsync(Endereco);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Endereco não adicionados na tabela");
            }
            Response.StatusCode = 200;
            return Ok(new { Status = "Sucess", Message = "Endereco do Usuario cadastrado com sucesso na tabela" });
        }

        [HttpPost]
        [Route("insere/AuthUser")]
        public async Task<IActionResult> RegisterAuth([FromBody] Auth_User model)
        {
            var senha = _crypto.Criptografar(model.Pass);
            var CPFExists = await _dbAuth_User.FirstOrDefaultAsync(x => x.CPF == model.CPF);
            if (CPFExists != null)
            {
                Response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, "CPF já existe ");
            }
            Auth_User usuario = new Auth_User()
            {
                CPF = model.CPF,
                Pass = senha
            };
            try
            {
                await _dbAuth_User.AddRangeAsync(usuario);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Password não adicionados na tabela");
            }
            Response.StatusCode = 200;
            return Ok(new { Status = "Sucess", Message = "Passwoard cadastrado com sucesso" });
        }

        [HttpPost]
        [Route("insere/DocumentosUser")]
        public async Task<IActionResult> RegistroDoc_User([FromBody] ImgDoc_UserDto model)
        {
            try
            {
                var CPFExists = await _dbUser.FirstOrDefaultAsync(x => x.CPF == model.CPF);
                if (CPFExists != null)
                {
                    var CPFDocExists = await _dbImage_User.FirstOrDefaultAsync(x => x.CPF == model.CPF);
                    if (CPFDocExists != null)
                    {
                        Response.StatusCode = 400;
                        return StatusCode(StatusCodes.Status400BadRequest, "Protocolo já existente ");
                    }
                }
                try
                {
                    foreach (var item in model.Docs)
                    {
                        await _dbDoc_User.AddAsync(new Doc_User
                        {
                            CPF = model.CPF,
                            Doc = Encoding.ASCII.GetBytes(item)
                        });

                    }
                    await _db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Documentos não adicionados na tabela");
                }
                Response.StatusCode = 200;
                return Ok(new { Status = "Sucess", Message = "Documentos cadastrado com sucesso na tabela" });
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return StatusCode(StatusCodes.Status500InternalServerError, "Documentos não adicionados na tabela");
            }
        }

        [HttpPost]
        [Route("insere/ImagemUser")]
        public async Task<IActionResult> RegistroImagem_User([FromBody] ImgDoc_UserDto model)
        {
            try
            {
                var CPFExists = await _dbUser.FirstOrDefaultAsync(x => x.CPF == model.CPF);
                if (CPFExists != null)
                {
                    var CPFDocExists = await _dbImage_User.FirstOrDefaultAsync(x => x.CPF == model.CPF);
                    if (CPFDocExists != null)
                    {
                        Response.StatusCode = 400;
                        return StatusCode(StatusCodes.Status400BadRequest, "Protocolo já existente ");
                    }
                }
                try
                {
                    foreach (var item in model.Docs)
                    {
                        await _dbImage_User.AddAsync(new Image_User
                        {
                            CPF = model.CPF,
                            Img = Encoding.ASCII.GetBytes(item)
                        });
                    }
                    await _db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Documentos não adicionados na tabela");
                }
                Response.StatusCode = 200;
                return Ok(new { Status = "Sucess", Message = "Documentos cadastrado com sucesso na tabela" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Documentos não adicionados na tabela");
            }
        }
        [HttpGet]
        [Route("busca/User")]
        [DisableCors]
        public async Task<JsonResult> UserDdos()
        {
            HttpContext.Response.Headers.Add("Content-type", "application/json; charset=utf-8");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return new JsonResult(_dbUser);
        }


    }
}
