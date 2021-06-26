using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Cliente : PessoaFisica
    {
        public int IdCliente { get; set; }
        public bool Ativo { get; set; }
        public long PessoaFisicaId { get; set; }
    }
}
