
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SisTarefas.Domain.Base;
using SisTarefas.Repository.Mapping;

namespace SisTarefas.Repository.Context
{
    
    public class CadastroTarefasContext: DbContext
    {
        
        public CadastroTarefasContext(): base("CadastroTarefasContext")
        {
            var assegurarDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Contatos> Contatos { get; set; }
        public DbSet<Notificacoes> Notificacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelbuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelbuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelbuilder.Properties().Where(x => x.Name == x.ReflectedType.Name + "Id" || x.Name == "id")
                .Configure(x => x.IsKey());

            modelbuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar"));
            
            modelbuilder.Properties<string>()
                .Configure(x => x.HasMaxLength(1000));


            modelbuilder.Configurations.Add(new TarefasMapping());
            modelbuilder.Configurations.Add(new ContatosMapping());
            modelbuilder.Configurations.Add(new NotificacoesMapping());
        }
    }
}
