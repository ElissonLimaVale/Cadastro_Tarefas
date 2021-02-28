
namespace SisTarefas.Domain.Base
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(string nome, string email, string telefone, string senha)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.senha = senha;
        }
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string senha { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}
