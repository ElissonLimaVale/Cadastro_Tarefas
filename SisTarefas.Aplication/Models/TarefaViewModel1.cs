
using System;
using System.Collections.Generic;

namespace SisTarefas.Application.Models
{
    public class TarefaViewModel
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
        public virtual ICollection<NotificacoesViewModel> Notificacao { get; set; }
        public virtual ICollection<UsuarioViewModel> Usuario { get; set; }

    }
}
