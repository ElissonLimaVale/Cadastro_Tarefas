using FluentValidation;
using SisTarefas.Application.Models;

namespace SisTarefas.Web.UI.Models.Validation
{
    public class Notificacao: AbstractValidator<NotificacoesViewModel>
    {
        public Notificacao()
        {
            RuleFor(x => x.nome).NotNull().NotEmpty().WithMessage("O atributo Nome deve ser especificados!");
            RuleFor(x => x.data).NotNull().NotEmpty().WithMessage("O atributo Data deve ser especificados!");
        }
    }
}