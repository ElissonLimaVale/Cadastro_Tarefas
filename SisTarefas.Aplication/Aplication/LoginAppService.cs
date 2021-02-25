using SisAtividades.Interface;
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
    }
}
