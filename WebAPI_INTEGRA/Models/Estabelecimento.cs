using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Estabelecimento : PessoaJuridica
    {
        [Key]
        public long EstabelecimentoId { get; set; }
     
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        /// <summary>
        /// Status do local [Aberto - AB, Fechado - F, Horário de almoço - HA]
        /// </summary>
        public string StatusEstabelecimento { get; set; }
        public bool Ativa { get; set; }
        public bool Suspenso { get; set; }

        // ****** Foreign Key Features *******
        public long? EnderecoId { get; set; }
        
        public int PlanoId { get; set; }
        public long? DadosContatoId { get; set; }

    }
}
