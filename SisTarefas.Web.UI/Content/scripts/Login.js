$(document).ready(() => {
    //Objetos de dados da tela
    let UsuarioLogin = {
        nome: null,
        senha: null
    },
    UsuarioCadastro = {
        nome: null,
        email: null,
        senha: null
    }

    //Troca container para container de cadastro
    $("#cadastrar-login").click(() => {
        $("#login-user").hide(200);
        $("#cadastro-user").show(200);
    });

    //Faz a requisição de login
    $("#login-action").click(() => {
        UsuarioLogin.nome = $("input[name=login-nome]").val();
        UsuarioLogin.senha = $("input[name=login-senha]").val();

        if (Validate.JsonParams(UsuarioLogin, [""])) {
            Load.Show();
            $.ajax({
                method: "Post",
                url: "../Login/Logar",
                data: UsuarioLogin
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
        UsuarioCadastro.nome = $("input[name=cadastro-nome]");
        UsuarioCadastro.email = $("input[name=cadastro-emal]");
        UsuarioCadastro.senha = $("input[name=cadastro-senha]");
        if (Validate.JsonParams(UsuarioCadastro, [""])) {
            Load.Show();
            $.ajax({
                method: "Post",
                url: "../Login/Cadastrar",
                data: UsuarioLogin
            }).fail(() => {
                Load.Hide();
                notific.error("Ops, Ocorreu um erro durante a requisição!");
            });
        } else {
            notific.warning("Por favor preencha todos os campos!");
        }
    });
})
