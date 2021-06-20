using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class Estabelecimento
    {
        [Key]
        public long EstabelecimentoId { get; set; }
       
        public string TipoPJ { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public bool Ativa { get; set; }
        public bool Suspenso { get; set; }


        // ****** Foreign Key Features *******
        public int EnderecoId { get; set; }
        public int CategoriaEmpresaId { get; set; }
        public int DadosEmpresarial { get; set; }
        public int PlanoSistema { get; set; }

    }
}
