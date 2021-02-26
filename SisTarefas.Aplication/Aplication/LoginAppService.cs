using AutoMapper;
using SisAtividades.Interface;
using SisAtividades.Models;
using SisTarefas.Domain.Base;
using SisTarefas.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAtividades.Aplication
{
    public class LoginAppService: ILoginAppService
    {
        private readonly ILoginRepository _repository;
        public LoginAppService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public dynamic Atualizar(UsuarioViewModel user)
        {
            return _repository.Atualizar(Mapper.Map<UsuarioViewModel, Usuario>(user));
        }

        public UsuarioViewModel Cadastrar(UsuarioViewModel user)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_repository.Cadastrar(Mapper.Map<UsuarioViewModel,Usuario>(user)));
        }

        public dynamic Deletar(UsuarioViewModel user)
        {
            return _repository.Deletar(Mapper.Map<UsuarioViewModel, Usuario>(user));
        }

        public UsuarioViewModel Logar(UsuarioViewModel user)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_repository.Logar(Mapper.Map<UsuarioViewModel, Usuario>(user))); ;
        }
    }
}
