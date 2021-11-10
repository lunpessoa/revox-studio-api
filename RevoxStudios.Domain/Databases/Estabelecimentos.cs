using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace RevoxStudios.Domain.Databases
{
    public class Estabelecimentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEstab { get; set; }
        public string nomeEstab { get; set; }
        public string cnpjEstab { get; set; }
        public string telefoneEstab { get; set; }
        public string endereçoEstab { get; set; }
        public string bairroEstab { get; set; }
        public string cepEstab { get; set; }
        public string numeroEstab { get; set; }
        public string donoEstab { get; set; }
        public string cpfDono { get; set; }
        public DateTime dtNascimento { get; set; }
        public string emailDono { get; set; }
        public string telefoneDono { get; set; }
        public string senhaEstab { get; set; }
        public string fotoPerfil { get; set; }
        public string banner { get; set; }
        public string descrição { get; set; }
        public string whatsapp { get; set; }
        public string instagram { get; set; }
        public string facebook { get; set; }
        public string telefoneEstab2 { get; set; }
    }
}
