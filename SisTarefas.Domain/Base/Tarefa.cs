using System;

namespace SisTarefas.Domain.Base
{
    public class Tarefa
    {
        public int? id { get; set; }
        public DateTime data_prevista { get; set; }
        public DateTime data_conclusao { get; set; }
        public string area { get; set; }
        public string impacto { get; set; }
        public string status { get; set; }
        public string origem { get; set; }
        public string responsavel { get; set; }
        public string descricao { get; set; }
        public string observacoes { get; set; }
        public string contato { get; set; }
        public int notificacoes { get; set; }
    }
}
