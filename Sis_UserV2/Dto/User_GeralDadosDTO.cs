using Sis_UserV2.Models;
using System.Collections.Generic;

namespace Sis_UserV2.Dto
{
    public class User_GeralDadosDTO : Entity
    {
        //USER
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        //-----------------------------------------
        //ENDERECO_USER
        public string Rua       { get; set; }
        public string Bairro    { get; set; }
        public string Quadra    { get; set; }
        public string Lote      { get; set; }
        public string CEP       { get; set; }
        public string Estado    { get; set; }
        public string Cidade    { get; set; }
        //-----------------------------------------
        //FONE_USER
        public string FoneCelular1 { get; set; }
        public string FoneCelular2 { get; set; }
        public string FoneFixo { get; set; }      
        //-----------------------------------------
        //IMAGEM
        public List<byte[]> Imgs { get; set; }

        //-----------------------------------------
        //DOCUMENTO
        public List<byte[]> Docs { get; set; }
    }
}
