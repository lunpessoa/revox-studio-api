using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevoxStudios.Domain.Databases
{
    public class Clientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public string cpfCliente { get; set; }
        public DateTime dtNascimento { get; set; }
        public string telefoneCliente { get; set; }
        public string emailCliente { get; set; }
        public string senhaCliente { get; set; }
        public string fotoPerfil { get; set; }
        public string telefoneCliente2 { get; set; }
    }
}
