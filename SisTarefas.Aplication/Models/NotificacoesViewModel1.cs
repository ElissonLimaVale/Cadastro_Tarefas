
using System;

namespace SisTarefas.Application.Models
{
    public class NotificacoesViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        //public string tarefa { get; set; }
        public DateTime data { get; set; }
        public DateTime dataconclusao { get; set; }
        public bool response { get; set; }
        public virtual TarefaViewModel Tarefa { get; set; }

    }
}
