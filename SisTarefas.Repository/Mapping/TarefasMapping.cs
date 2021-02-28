using SisTarefas.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisTarefas.Repository.Mapping
{
    public class TarefasMapping: EntityTypeConfiguration<Tarefa>
    {
        public TarefasMapping()
        {
            this.ToTable("Tarefas");

            this.HasKey(x => x.id);

            this.Property(x => x.id).HasColumnType("INT");
            this.Property(x => x.area).HasColumnType("VARCHAR");
            this.Property(x => x.data_conclusao).HasColumnType("DATETIME");
            this.Property(x => x.data_prevista).HasColumnType("DATETIME");
            this.Property(x => x.impacto).HasColumnType("VARCHAR");
            this.Property(x => x.status).HasColumnType("VARCHAR");
            this.Property(x => x.origem).HasColumnType("VARCHAR");
            this.Property(x => x.responsavel).HasColumnType("VARCHAR");
            this.Property(x => x.descricao).HasColumnType("VARCHAR");
            this.Property(x => x.observacoes).HasColumnType("VARCHAR");
            this.Property(x => x.contato).HasColumnType("VARCHAR");
            //this.Property(x => x.notificacoes).HasColumnType("INT");
            

            //HasKey(x => x.Usuario)
            //    .HasRequired(x => x.Usuario)
            //    .WithRequiredDependent(x => x.id);
        }
        
    }
}
