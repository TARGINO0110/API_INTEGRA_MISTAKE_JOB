using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Foto
    {
        public long IdFOto { get; set; }
        public byte Imagem { get; set; }
        public string URL { get; set; }
        public long PessoaFisicaId { get; set; }
        public long PessoaJuridica { get; set; }

    }
}
