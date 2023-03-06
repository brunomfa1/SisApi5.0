using Core.Seguranca;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sis_UserV2.Dto;
using Sis_UserV2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sis_UserV2.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class Login_UserController: Controller
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
        private readonly DbSet<Keyword_User> _dbKeyword_User;

        public Login_UserController(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            _dbUser = db.Set<User>();
            _dbAuth_User = db.Set<Auth_User>();
            _dbDoc_User = db.Set<Doc_User>();
            _dbImage_User = db.Set<Image_User>();
            _dbFone_User = db.Set<Fone_User>();
            _dbEndereco_User = db.Set<Endereco_User>();
            _dbKeyword_User = db.Set<Keyword_User>();
        }

        [HttpPost]
        [Route("login/LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] Auth_User model)
        {
            var senha = _crypto.Criptografar(model.Pass);
            var CPFExists = await _dbAuth_User.FirstOrDefaultAsync(x => x.CPF == model.CPF && x.Pass == senha);
            if (CPFExists != null)
            {
                Response.StatusCode = 200;
                return Ok(new { Status = "Sucess", Message = "Login realizado com sucesso" });

            }
            Response.StatusCode = 400;
            return StatusCode(StatusCodes.Status400BadRequest, "Senha Incorreta");
        }

        [HttpPost]
        [Route("login/KeywordUser")]
        public async Task<IActionResult> LoginUser([FromBody] Keyword_User model)
        {

            var senha = _crypto.Criptografar(model.KeyWord);
            var WordExists = await _dbKeyword_User.FirstOrDefaultAsync(x => x.CPF == model.CPF && x.KeyWord == senha);
            if (WordExists != null)
            {
                Response.StatusCode = 200;
                return Ok(new { Status = "Sucess", Message = "Autenticação realizada com sucesso" });
            }
            Response.StatusCode = 400;
            return StatusCode(StatusCodes.Status400BadRequest, "Senha Incorreta");
        }

        [HttpPost]
        [Route("login/buscaCadastro")]
        public async Task<IActionResult> buscaCadastro([FromBody] string CPF, string senha)
        {
            var listaResultado = new List<User_GeralDadosDTO>();
            var query = _dbAuth_User.Where(x => x.CPF == CPF && x.Pass == senha);

            var dbBuscaCadastroUser = _dbUser.ToList();
            var dbBuscaCadastroFone_User = _dbFone_User.ToList();
            var dbBuscaCadastroImage_User = _dbImage_User.ToList();
            var dbBuscaCadastroDoc_User = _dbDoc_User.ToList();
            var dbBuscaCadastrEndereco_User = _dbEndereco_User.ToList();
            /*
                ----> Essa Logica deve ser aplicada nesse metodo 
              
                     list<img> lista = new List<img>();
                        foreach(var item in 'SELECT * FROM CPF')    
                            foreach(var item in SELECT * FROM IMG WHERE CPF = CPF.Cpf)
                    {
                        lista.add(item.img);

                    } 

                    dto.img = lista;
            */
            foreach (var BuscaCadastroAuth_User in query)
            {
                var BuscaCadastroUser = dbBuscaCadastroUser.FirstOrDefault(x => x.CPF == BuscaCadastroAuth_User.CPF);
                var BuscaCadastroFone_User = dbBuscaCadastroFone_User.FirstOrDefault(x => x.CPF == BuscaCadastroAuth_User.CPF);
                var BuscaCadastroImage_User = dbBuscaCadastroImage_User.FirstOrDefault(x => x.CPF == BuscaCadastroAuth_User.CPF);
                var BuscaCadastroDoc_User = dbBuscaCadastroDoc_User.FirstOrDefault(x => x.CPF == BuscaCadastroAuth_User.CPF);
                var BuscaCadastrEndereco_User = dbBuscaCadastrEndereco_User.FirstOrDefault(x => x.CPF == BuscaCadastroAuth_User.CPF);
                listaResultado.Add(new User_GeralDadosDTO()
                {
                    //------------------------------------
                    Id = BuscaCadastroAuth_User.Id,
                    CPF = BuscaCadastroAuth_User.CPF,
                    //------------------------------------
                    RG = BuscaCadastroUser.RG,
                    Email = BuscaCadastroUser.Email,
                    Observacao = BuscaCadastroUser.Observacao,
                    //------------------------------------
                    Rua = BuscaCadastrEndereco_User.Rua,
                    Bairro = BuscaCadastrEndereco_User.Bairro,
                    Quadra = BuscaCadastrEndereco_User.Quadra,
                    Lote = BuscaCadastrEndereco_User.Lote,
                    CEP = BuscaCadastrEndereco_User.CEP,
                    Estado = BuscaCadastrEndereco_User.Estado,
                    Cidade = BuscaCadastrEndereco_User.Cidade,
                    //------------------------------------
                    FoneCelular1 = BuscaCadastroFone_User.FoneCelular1,
                    FoneCelular2 = BuscaCadastroFone_User.FoneCelular2,
                    FoneFixo = BuscaCadastroFone_User.FoneFixo,
                    //------------------------------------
                });
            }
            return new JsonResult(listaResultado);
        }
    }
   
}
