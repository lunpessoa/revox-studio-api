using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RevoxStudios.Domain.Databases
{
    public class Serviços
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idServiço { get; set; }
        public int idEstab { get; set; }
        public string nomeEstab { get; set; }
        public string Serviço { get; set; }
        public decimal Preço { get; set; }
    }
}
