using System;
using System.Security.Cryptography;
using System.Text;


namespace Core.Seguranca
{
    public interface ICryptography
    {
        string ConverterParaHexadecimal(string asciiString);
    }

    public class Cryptography : ICryptography
    {
        string myKey = string.Empty;

        #region Método reponsável por congifigurar a criptografia.
        private ICryptoTransform ConfigurarCriptografia(bool operacao)
        {
            var des = new TripleDESCryptoServiceProvider();
            var hashmd5 = new MD5CryptoServiceProvider();

            des.Key = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            des.Mode = CipherMode.ECB;

            if (operacao)
                return des.CreateEncryptor();

            return des.CreateDecryptor();

        }
        #endregion

        #region Função para cryptografar os informaçoes do sistema
        public string Criptografar(string texto)
        {
            try
            {
                byte[] buff = ASCIIEncoding.ASCII.GetBytes(texto);
                return Convert.ToBase64String(ConfigurarCriptografia(true).TransformFinalBlock(buff, 0, buff.Length));
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region "Método para descriptografia um objeto"
        public string DesCriptografar(string texto)
        {
            try
            {
                byte[] buff = Convert.FromBase64String(texto);
                return ASCIIEncoding.ASCII.GetString(ConfigurarCriptografia(false).TransformFinalBlock(buff, 0, buff.Length));
            }
            catch
            {
                return null;
            }
        }
        #endregion


        /// <summary>
        /// Método para Criptografar e Descritografar.
        /// </summary>
        /// <param name="texto">Informar o texto que será Criptografado ou Descriptografao.</param>
        /// <param name="operacao">Informe o tipo de operação [true]: Criptografa e [false]: Descriptografa.</param>
        /// <param name="chave">Informe o tipo da chave [1]: Chave para o serial e [2]: Chave do sistema.</param>
        /// <returns></returns>

        #region Converter o Numero do Hd para Hexadecimal
        public string ConverterParaHexadecimal(string asciiString)
        {
            //Retorna o número convertido do código do hd para ser gerado o serial.
            string numero = string.Empty;
            foreach (char num in asciiString)
            {
                int tmp = num;
                numero += String.Format("{0:x2}", System.Convert.ToUInt32(tmp.ToString()));
            }
            return numero;
        }
        #endregion
    }
}