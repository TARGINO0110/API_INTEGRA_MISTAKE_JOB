using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Credenciais
    {
        [Key]
        public int IdCredenciais { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
    }
}
