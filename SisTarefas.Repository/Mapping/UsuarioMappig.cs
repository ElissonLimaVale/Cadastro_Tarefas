
using SisTarefas.Domain.Base;
using System.Data.Entity.ModelConfiguration;

namespace SisTarefas.Repository.Mapping
{
    public class UsuarioMappig: EntityTypeConfiguration<Usuario>
    {
        public UsuarioMappig()
        {
            ToTable("Usuarios");

            this.HasKey(x => x.id);

            this.Property(x => x.nome).HasColumnType("VARCHAR");
            this.Property(x => x.telefone).HasColumnType("VARCHAR");
            this.Property(x => x.email).HasColumnType("VARCHAR");
            this.Property(x => x.senha).HasColumnType("VARCHAR");
        }
    }
}
