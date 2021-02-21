using System;
using System.Collections.Generic;
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

        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelbuilder.Configurations.Add(new TarefasMapping());
        }
    }
}
