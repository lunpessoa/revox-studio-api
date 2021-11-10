using Microsoft.EntityFrameworkCore;
//using RevoxStudios.Databases;
using RevoxStudios.Domain.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevoxStudios.Infra
{
    public class Conexão : DbContext
    {
        public Conexão()
        {

        }

        public Conexão(DbContextOptions<Conexão> options) : base(options)
        { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Estabelecimentos> Estabelecimentos { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Controle_de_Acesso> Controle_De_Acesso { get; set; }
        public DbSet<Serviços> Serviços { get; set; }
    }
}
