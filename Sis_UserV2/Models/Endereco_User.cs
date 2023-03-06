
namespace Sis_UserV2.Models
{
    public class Endereco_User: Entity
    {
      
        public string CPF { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Quadra { get; set; }
        public string Lote { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

    }
}
