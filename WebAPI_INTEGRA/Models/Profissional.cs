using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Profissional
    {
        [Key]
        public int ProfissionalId { get; set; }
        public string CPF { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salario { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorComicao { get; set; }
        public bool Comicao { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public bool Ferias { get; set; }
        public bool Suspenso { get; set; }
        public bool Folga { get; set; }
        public bool Temporario { get; set; }
        /// <summary>
        /// Atendimento do serviço [INTERNO - (I), EXTERNO - (E), INTERNO E EXTERNO - (IE)]
        /// </summary>
        public string AtendeServico { get; set; }

        // ****** Foreign Key Features *******
        public long EstabelecimentoId { get; set; }
        public int EnderecoId { get; set; }
        public int CategoriaServicosId { get; set; }
        public int HorarioTrabalhoId { get; set; }
    }
}
