using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RevoxStudios.Domain.Databases
{
    public class Controle_de_Acesso
    {
        [Key]
        public string Login { get; set; }
        public string Senha { get; set; }
        public int idStatus { get; set; }
    }
}
