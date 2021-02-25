using SisTarefas.Domain.Base;
using SisTarefas.Repository.Base;
using SisTarefas.Repository.Context;
using SisTarefas.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

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
            dynamic response = new { data = true, message = "Tarefa salva com sucesso!" };
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

        public dynamic AddNotification(Notificacoes notific)
        {
            dynamic response = new { data = true, message = "Contato adicionado com sucesso!" };
            try
            {
                _entity.Notificacoes.Add(notific);
                _entity.SaveChanges();

            }catch(Exception ex)
            {
                response = new { data = false, message = ex };
            }
            return response;
        }
        public dynamic CadastrarContato(Contatos contato)
        {
            dynamic response = new { data = true, message = "Contato adicionado com sucesso!" };
            try
            {
                _entity.Contatos.Add(contato);
                _entity.SaveChanges();

            }
            catch (Exception ex)
            {
                response = new { data = false, message = ex };
            }
            return response;
        }

        public List<string> ListarContatos()
        {
            List<string> response;
            try
            {
                response = _entity.Contatos.Select(x => x.nome).ToList<string>();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                response = new List<string>();
            }
            
            return response;
        }

        public Tarefa BuscarTarefa(int id)
        {
            return _entity.Tarefas.FirstOrDefault(x => x.id == id);
        }

        public dynamic NotificationVerific(string usuario)
        {
            dynamic response;
            try
            {
                response = new
                {
                    data = true,
                    notification = _entity.Notificacoes.Select(x => x).Where(x => x.data <= DateTime.Now && x.nome == usuario)
                };

            }catch(Exception ex)
            {
                response = new
                {
                    data = false,
                    notification = new Notificacoes()
                };
            }
            
            return response;
        }
    }
}
