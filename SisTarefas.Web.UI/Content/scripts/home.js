$(document).ready(() => {
    //Modal de cadastro de contato
    var ModalCadastro = {
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

})