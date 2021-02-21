using SisTarefas.Domain.Base;
using SisTarefas.Repository.Base;
using SisTarefas.Repository.Context;
using SisTarefas.Repository.Interface;
using System;

namespace SisTarefas.Repository
{
    public class TarefaRepository: ITarefaRepository
    {
        private readonly Conexao _conexao;
        private readonly CadastroTarefasContext _entity;
        public TarefaRepository(Conexao conexao, CadastroTarefasContext entity)
        {
            _conexao = conexao;
            _entity = entity;
        }

        public dynamic Cadastrar(Tarefa tarefa)
        {
            dynamic response = new { data = true, message = "Cadastrado com sucesso!" };
            try
            {
                _entity.Tarefas.Add(tarefa);
                _entity.SaveChanges();
            }
            catch (Exception ex)
            {
                response = new { data = false, message = ex };
            }
            return response;
        }
    }
}
