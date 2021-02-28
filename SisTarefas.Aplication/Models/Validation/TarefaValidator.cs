using FluentValidation;

namespace SisTarefas.Application.Models.Validators
{
    public class TarefaValidator: AbstractValidator<TarefaViewModel>
    {
        public TarefaValidator()
        {
            RuleFor(x => x.area).NotNull().NotEmpty().WithMessage("O atributo Área deve ser especificado");

            RuleFor(x => x.contato).NotNull().NotEmpty().WithMessage("O atributo Contato deve ser especificado");

            RuleFor(x => x.data_conclusao).NotNull().NotEmpty().WithMessage("O atributo Data de Conclusão deve ser especificado");

            RuleFor(x => x.data_prevista).NotNull().NotEmpty().WithMessage("O atributo Data Prevista deve ser especificado");
        }
    }
}