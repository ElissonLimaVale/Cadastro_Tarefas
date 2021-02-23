﻿$(document).ready(() => {
    // Objeto Contato 
    var contato = {
        nome: "",
        email: "",
        telefone: ""
    },
    //Objeto tarefa
    tarefa = {
        data_prevista: "",
        data_conclusao: "",
        area: "",
        impacto: "",
        status: "",
        origem: "",
        responsavel: "",
        descricao: "",
        observacoes: "",
        contato: "",
        notificacao: ""
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

        if (ValidarJson(contato)) {
            $.ajax({
                method: "Post",
                url: "../Tarefas/CadastrarContato",
                data: contato
            }).done((data) => {
                if (data.data) {
                    $("input").val("");
                }
                alert(data.message);
            }).fail(() => {
                alert("Ops, Ocorreu um erro durante a requisição, por favor atualize a página!");
            })
        } else {
            alert("Por favor preencha todos os campos!");
        }
    });

    //Cadastrar Tarefa
    $("#salvar").click(() => {
        tarefa.data_prevista = $("input[name=data_prevista]").val();
        tarefa.data_conclusao = $("input[name=data_conclusao]").val();
        tarefa.area = $("input[name=area]").val();
        tarefa.impacto = $("input[name=impacto]").val();
        tarefa.status = $("input[name=status]").val();
        tarefa.origem = $("input[name=origem]").val();
        tarefa.responsavel = $("input[name=responsavel]").val();
        tarefa.descricao = $("textarea[name=descricao]").val();
        tarefa.observacoes = $("textarea[name=observacoes]").val();
        tarefa.contato = $("input[name=add-contato-value]").val();
        tarefa.notificacao = $("input[name=notificacao]").val();

        if (ValidarJson(tarefa)) {
            $.ajax({
                method: "Post",
                url: "../Tarefas/CadastrarTarefa",
                data: tarefa
            }).done((data) => {
                if (data.data) {
                    $("input").val("");
                    $("textarea").val("");
                }
                alert(data.message);
            }).fail(() => {
                alert("Ops, Ocorreu um erro durante a requisição, por favor atualize a página!");
            })
        } else {
            alert("Por favor preencha todos os campos obrigatorios *!");
        }
    });


    //metodos de interação de dados em tela
    $("#adicionar-contato").click(() => {
        if ($("#select-contato").val() != "Selecionar" && $("#select-contato").val() != "Selecionar Contato")
        {
            $("input[name=add-contato-value]").val($("#select-contato").val());
            $("#select-contato").val("Selecionar Contato");
        }
       
    });

    $("#remover-contato").click(() => {
        $("input[name=add-contato-value]").val("");
    });




    // Valida Atributos de um Json
    function ValidarJson(data) {
        let acceptnull = ["observacoes", "descricao","notificacao"];
        let response = true;

        for (var item in data) {

            if (!acceptnull.includes(item) && data[item] == null || data[item] == "") {
                response = false;
            }
        }

        return response;
    }
})