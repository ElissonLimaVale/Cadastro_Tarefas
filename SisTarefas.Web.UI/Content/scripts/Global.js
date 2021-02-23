$(document).ready(() => {

    function LoadShow() {
    }
    function LoadHide() {

    }
    //notificacão de error e pequenos avisos
    notific = {
        error: (msg) => {
            $("body").append("<div class='notific-error'>"
                + "<span class='icon'></span>"
                + "<span>" + msg + "</span>"
                + "</div>");

            setTimeout(() => {
                $(".notific-error").hide();
            }, 4000);
        },
        success: (msg) => {

            $("body").append("<div class='notific-success'>"
                + "<span class='icon'></span>"
                + "<span>" + msg + "</span>"
                + "</div>");

            setTimeout(() => {
                $(".notific-success").hide();
            }, 4000);
        },
        warning: (msg) => {

            $("body").append("<div class='notific-warning'>"
                + "<span class='icon'></span>"
                + "<span>" + msg + "</span>"
                + "</div>");

            setTimeout(() => {
                $(".notific-warning").hide();
            }, 4000);
        }
    },

    //Notificações de Tarefas
    notification = {
        action: null,

        Start: (temp) => {
            this.action = setInterval(() => {
                $("#notific-tarefa").addClass("notific-true");
                setTimeout(() => {
                    $("#notific-tarefa").removeClass("notific-true");
                }, temp / 2);
            }, temp);
        },
        Stop: () => {
            $("#notific-tarefa").removeClass("notific-true");
            delete this.action;
        }
    };


});
