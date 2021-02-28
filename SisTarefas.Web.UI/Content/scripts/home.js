$(document).ready(() => {
    //$.ajax({
    //    method: "Post",
    //    url: "../Tarefas/NotificationVerific"
    //}).done((data) => {
    //    if (data.data) {
    //        this.Start();
    //        this.AddItem(data.notification.nome, data.notification.id);
    //    }
    //}).fail(() => {
    //    notific.warning("As notificações não serão atualizadas***");
    //    this.Endverify();
    //});

    //Variaveis Gloabais
    var UsersSelected = [];
    // Objeto Contato 
    var contato = [{
        id: null,
        nome: null,
        email: null,
        telefone: null
    }],
        //Objeto tarefa
        tarefa = {
            data_prevista: null,
            data_conclusao: null,
            area: null,
            impacto: null,
            status: null,
            origem: null,
            responsavel: null,
            descricao: null,
            observacoes: null,
            contato: null,
            notificacao: null
        },
        //Modal de cadastro de contato
        ModalCadastro = {
            Open: () => {
                $("#cadastrar_contato").css("top", "0px");
            },
            Close: () => {
                $("#cadastrar_contato").css("top", "-800px");
            }
        };

    // controle de modal de cadastro de contato
    $("#adicionar_contato").click(() => {
        ModalCadastro.Open();
    });

    $("#fechar-cad-contato").click(() => {
        ModalCadastro.Close();
    });

    //métodos de cadastro

    //Cadastrar Contato
    $("#cadastrar").click(() => {
        contato.nome = $("input[name=nome-contato]").val();
        contato.email = $("input[name=email-contato]").val();
        contato.telefone = $("input[name=numero-contato]").val();

        if (Validate.JsonParams(contato, [""])) {
            Load.Show();
            $.ajax({
                method: "Post",
                url: "../Tarefas/CadastrarContato",
                data: contato
            }).done((data) => {
                Load.Hide();
                if (data.data) {
                    $("#select-contato").append("<option value='" + contato.nome + "'>" + contato.nome + "</option>");
                    UsersSelected = [];
                    notific.success(data.message);
                    ModalCadastro.Close();
                    //window.Location.href = "/";
                } else {
                    alert(data.message);
                }
            }).fail(() => {
                Load.Hide();
                alert("Ops, Ocorreu um erro durante a requisição, por favor atualize a página!");
            })
        } else {
            notific.warning("Por favor preencha todos os campos!");
        }
    });

    //Cadastrar Tarefa
    $("#salvar").click(() => {
        contato = [];
        tarefa.data_prevista = $("input[name=data_prevista]").val();
        tarefa.data_conclusao = $("input[name=data_conclusao]").val();
        tarefa.area = $("input[name=area]").val();
        tarefa.impacto = $("input[name=impacto]").val();
        tarefa.status = $("input[name=status]").val();
        tarefa.origem = $("input[name=origem]").val();
        tarefa.responsavel = $("input[name=responsavel]").val();
        tarefa.descricao = $("textarea[name=descricao]").val();
        tarefa.observacoes = $("textarea[name=observacoes]").val();
        tarefa.notificacao = $("input[name=notificacao]").val();
        UsersSelected.forEach((data) => {
            tarefa.contato = data;
            contato.push({ id: null, nome: data, email: null, telefone: null, senha: null });
        });
            
            
        if (Validate.JsonParams(tarefa, ["observacoes", "descricao", "notificacao"])) {
            Load.Show();
            $.ajax({
                method: "Post",
                url: "../Tarefas/CadastrarTarefa",
                data: {
                    tarefa,
                    contato
                }
            }).done((data) => {
                if (data.data) {
                    Load.Hide();
                    notific.success(data.message);
                    $("input").val("");
                    $("textarea").val("");
                } else {
                    alert(data.message);
                }
            }).fail(() => {
                Load.Hide();
                notific.error("Ops, Ocorreu um erro durante a requisição, por favor atualize a página!");
            })
        } else {
            notific.warning("Por favor preencha todos os campos obrigatorios **");
        }
        
    });


    //metodos de interação de dados em tela
    $("#adicionar-contato").on("click", function () {
        let value = $("#select-contato").val();
        
        if (value != "Selecionar" && value != "Selecionar Contato") {
            if (!UsersSelected.includes(value)) {
                $("#items-users").append(
                    "<div class='item-user'>" +
                    "<div class='user-remove btn icone-fechar'></div>" +
                    $("#select-contato").val() +
                    "</div>"
                );
                $("#select-contato").val("Selecionar");
                UsersSelected.push(value);
            }
        } else {
            notific.warning("Selecione o contato para adicionar!");
        }
    });

    $(document).on("click", ".user-remove", function () {
        let item = $(this).parent();
        $(item).hide(200);
        setTimeout(() => {
            $(item).remove();
            UsersSelected.splice(UsersSelected.indexOf($(item).text().trim()));
            console.log($(item).text().trim());
        }, 200);
        
    });

    $(document).on("click", "#remover-contato", function () {
        $(".item-user").hide(200);
        setTimeout(() => {
            $(".item-user").remove();
            UsersSelected = [];
        },200);
    });



});