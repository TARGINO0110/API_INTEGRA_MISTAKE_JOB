using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        public string NomeFuncionario { get; set; }
        public string FuncaoFunc { get; set; }
        public string CPF { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salario { get; set; }
    }
}
