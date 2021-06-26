using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Profissional : PessoaFisica
    {
        [Key]
        public int ProfissionalId { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salario { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorComicao { get; set; }
        public bool Comicao { get; set; }
        /// <summary>
        /// Status do profissional (Em serviço - ES, Indisponível - I, Disponível - D)
        /// </summary>
        public string StatusProfissional { get; set; }
        public bool Ativo { get; set; }
        public bool Ferias { get; set; }
        public bool Suspenso { get; set; }
        public bool Folga { get; set; }
        public bool Temporario { get; set; }
        public DateTime DataInicioAtivo { get; set; }
        public DateTime? DataFinalAtivo { get; set; }
        /// <summary>
        /// Atendimento do serviço [INTERNO - (I), EXTERNO - (E), INTERNO E EXTERNO - (IE)]
        /// </summary>
        public string AtendeServico { get; set; }

        // ****** Foreign Key *******
        public long PessoaFisicaId { get; set; }
        public long? ServicosId { get; set; }
        public long? EstabelecimentoId { get; set; }
        public int? CategoriaServicosId { get; set; }
        public int? HorarioTrabalhoId { get; set; }
        public long? VoucherProfissional { get; set; }
        public int PlanoId { get; set; }
    }
}
