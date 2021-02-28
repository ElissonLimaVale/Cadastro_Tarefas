

using System.Configuration;

namespace SisTarefas.Repository.Base
{
    public class Conexao
    {
        private string connectionString;
        public Conexao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["CadastroTarefasContext"].ConnectionString;
            //@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\xampp\htdocs\Cadastro_Tarefas\SqlServerTeste.mdf; Integrated Security = True; Connect Timeout = 30";
        }

        public string getStringConection()
        {
            return this.connectionString;
        }
    }
}
