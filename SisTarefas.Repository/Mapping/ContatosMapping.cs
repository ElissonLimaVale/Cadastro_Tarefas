using SisTarefas.Domain.Base;
using System.Data.Entity.ModelConfiguration;

namespace SisTarefas.Repository.Mapping
{
    public class ContatosMapping: EntityTypeConfiguration<Contatos>
    {
        public ContatosMapping()
        {
            this.ToTable("Contatos");

            this.HasKey(x => x.id);

            this.Property(x => x.id).HasColumnType("INT");
            this.Property(x => x.nome).HasColumnType("VARCHAR");
            this.Property(x => x.email).HasColumnType("VARCHAR");
            this.Property(x => x.telefone).HasColumnType("VARCHAR");
            
        }
    }
}
