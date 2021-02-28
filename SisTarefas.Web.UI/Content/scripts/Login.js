$(document).ready(() => {
    //Objetos de dados da tela
    let UsuarioLogin = {
        email: null,
        senha: null
    },
    UsuarioCadastro = {
        nome: null,
        email: null,
        telefone: null,
        senha: null
    }

    //Troca container para container de cadastro
    $("#cadastrar-login").click(() => {
        $("#login-user").hide(200);
        $("#cadastro-user").show(200);
    });

    //Faz a requisição de login
    $("#login-action").click(() => {
        UsuarioLogin.email = $("input[name=login-email]").val();
        UsuarioLogin.senha = $("input[name=login-senha]").val();

        if (Validate.JsonParams(UsuarioLogin, [""])) {
            Load.Show();
            $.ajax({
                method: "Post",
                url: "../Login/Logar",
                data: UsuarioLogin
            }).done((data) => {
                Load.Hide();
                if (data.data) {
                    notific.success(data.message);
                    window.location.href = "/Tarefas/Index";
                    
                } else {
                    notific.error(data.message);
                }
                
            }).fail(() => {
                Load.Hide();
                notific.error("Ops, Ocorreu um erro durante a requisição!");
            });
        } else {
            notific.warning("Por favor preencha todos os campos!");
        }
    });

    //Faz a requisição de cadastro
    $("#cadastrar-action").click(() => {
        UsuarioCadastro.nome = $("input[name=cadastro-nome]").val();
        UsuarioCadastro.email = $("input[name=cadastro-email]").val();
        UsuarioCadastro.telefone = $("input[name=cadastro-telefone]").val();
        UsuarioCadastro.senha = $("input[name=cadastro-senha]").val();

        if (Validate.JsonParams(UsuarioCadastro, ["nenhum"])) {
            Load.Show();
            $.ajax({
                method: "Post",
                url: "../Login/Cadastar",
                data: {
                    Usuario: UsuarioCadastro
                }
            }).done((data) => {
                Load.Hide();
                if (data.data) {
                    notific.success(data.message);
                    window.location.href = "/Tarefas/Index";
                } else {
                    notific.error(data.message);
                }
            }).fail(() => {
                Load.Hide();
                notific.error("Ops, Ocorreu um erro durante a requisição!");
            });
        } else {
            notific.warning("Por favor preencha todos os campos!");
        }
    });

})
