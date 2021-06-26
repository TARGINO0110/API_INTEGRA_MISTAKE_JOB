using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class DadosContato
    {
        public long IdDadosContato { get; set; }
        public string Email { get; set; }
        public string NumeroCelular { get; set; }
        public long? RedeSocial { get; set; }
    }
}
