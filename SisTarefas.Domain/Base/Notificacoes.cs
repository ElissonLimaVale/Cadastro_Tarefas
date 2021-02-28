using System;
using System.Collections.Generic;

namespace SisTarefas.Domain.Base
{
    public class Notificacoes
    {
        public int id { get; set; }
        public string nome { get; set; }
        //public string tarefa { get; set; }
        public DateTime data { get; set; }
        public DateTime dataconclusao { get; set; }
        public bool response { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}
