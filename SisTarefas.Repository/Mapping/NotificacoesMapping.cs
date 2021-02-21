using SisTarefas.Domain.Base;
using System.Data.Entity.ModelConfiguration;

namespace SisTarefas.Repository.Mapping
{
    public class NotificacoesMapping: EntityTypeConfiguration<Notificacoes>
    {
        public NotificacoesMapping()
        {
            this.ToTable("Notificacoes");

            this.HasKey(x => x.id);

            this.Property(x => x.id).HasColumnType("INT");
            this.Property(x => x.nome).HasColumnType("VARCHAR");
            this.Property(x => x.tarefa).HasColumnType("INT");
            this.Property(x => x.data).HasColumnType("DATETIME");
            this.Property(x => x.response).HasColumnType("BIT");

            //HasRequired(x => x.tarefa)
            //    .WithMany(x => x.n)
            //    .HasForeignKey(x => x.id);
        }
    }
}
