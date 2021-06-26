using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Avaliacao
    {
        public long IdAvaliacao { get; set; }
        public string DescAvaliacao { get; set; }
        public decimal PontosAvaliacao { get; set; }
        public long ClienteId { get; set; }
        public long ProfissionalId { get; set; }
        public long ServicosId { get; set; }
        public DateTime DataAtualizado { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
