using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevoxStudios.Domain.Databases
{
    public class Agenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAgenda { get; set; }
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public int idEstab { get; set; }
        public string nomeEstab { get; set; }
        public DateTime horário { get; set; }
        public int idServiço { get; set; }
    }
}
