using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Endereco
    {
        public long IdEndereco { get; set; }
        public string RuaAvenidaVia { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string País { get; set; }
        /// <summary>
        /// Tipo do Local [Estabelecimento - E, Casa - CA, Trabalho - T]
        /// </summary>
        public string TipoLocal { get; set; }

    }
}
