using SisTarefas.Repository.Base;
using SisTarefas.Repository.Context;
using SisTarefas.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisTarefas.Repository.Repository
{
    public class LoginRepository: ILoginRepository
    {
        private readonly Conexao _conexao;
        private readonly CadastroTarefasContext _entity;
        public LoginRepository(Conexao conexao,
                               CadastroTarefasContext entity
            )
        {
            _conexao = conexao;
            _entity = entity;
        }
    }
}
