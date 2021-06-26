using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_INTEGRA.Models
{
    public class HorarioTrabalho
    {
        public long IdHorarioTrabalho { get; set; }
        /// <summary>
        /// Referência dia da semana [ DOM - 1, SEG - 2, TER - 3, QUA - 4, QUI - 5, SEX - 6, SAB - 7,]
        /// </summary>
        public int NumDiaSemana { get; set; }
        public string DescDiaSemana { get => SetDescDia(); }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public DateTime HorarioIntervalo { get; set; }
        public string[] HorarioRemove { get; set; }
        /// <summary>
        /// Status do 
        /// </summary>
        public string StatusHorarioTrabalho { get; set; }

        string SetDescDia()
        {
            switch (NumDiaSemana)
            {
                case 1:
                    return "DOMINGO";
                case 2:
                    return "SEGUNDA-FEIRA";
                case 3:
                    return "TERÇA-FEIRA";
                case 4:
                    return "QUARTA-FEIRA";
                case 5:
                    return "QUINTA-FEIRA";
                case 6:
                    return "SEXTA-FEIRA";
                case 7:
                    return "SÁBADO";
                default:
                    return "INDISPONÍVEL";
            }
        }
    }

}
