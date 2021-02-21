

namespace SisTarefas.Repository.Base
{
    public class Conexao
    {
        private string conexao;
        public Conexao()
        {
            this.conexao = "";
        }

        public string getStringConection()
        {
            return this.conexao;
        }
    }
}
