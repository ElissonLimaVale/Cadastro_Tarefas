﻿using Dapper;
using SisTarefas.Domain.Base;
using SisTarefas.Repository.Base;
using SisTarefas.Repository.Context;
using SisTarefas.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SisTarefas.Repository
{
    public class TarefaRepository: ITarefaRepository
    {
        private readonly Conexao _conexao;
        private readonly CadastroTarefasContext _entity;
        private SqlConnection _dapper;
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

        public dynamic NotificationVerific(int usuario)
        {
            dynamic response;
            _dapper = new SqlConnection(_conexao.getStringConection());
            _dapper.Open();
            try
            {
                var notification = _dapper.Query("TAREFAS_NOTIFICATION_VERIFY",
                    new
                    {
                        @Usuario = usuario,
                        @Data = DateTime.Now

                    }, commandType: System.Data.CommandType.StoredProcedure).ToList();

                bool data = notification.Count < 1 ? false : true;
                response = new
                {
                    data = data,
                    notification = notification
                };

            }catch(Exception ex)
            {
                response = new
                {
                    data = false,
                    notification = new Notificacoes()
                };
            }finally
            {
                _dapper.Close();
            }
            
            return response;
        }

        public Notificacoes BuscarNotification(string nome)
        {
            return  _entity.Notificacoes.FirstOrDefault(x => x.nome == nome);
        }

        public Tarefa BuscarTarefa(Tarefa tarefa)
        {
            return _entity.Tarefas.FirstOrDefault(x => x.impacto == tarefa.impacto && x.responsavel == tarefa.responsavel && x.contato == tarefa.contato);
        }
    }
}
