using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class PessoaFisica
    {
        public long IdPessoaFisica { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public long? EnderecoId { get; set; }
        public long? DadosContatoId { get; set; }
    }
}
