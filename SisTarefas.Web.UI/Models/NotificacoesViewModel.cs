using System;

namespace SisTarefas.Application.Models
{
    public class NotificacoesViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int tarefa { get; set; }
        public DateTime data { get; set; }
        public bool response { get; set; }

    }
}
