using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class PessoaJuridica
    {
        public long IdPessoaJuridica { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string TipoPJ { get; set; }
        public string CNPJ { get; set; }
        public int CategoriaPessoaJuridicaId { get; set; }
    }
}
