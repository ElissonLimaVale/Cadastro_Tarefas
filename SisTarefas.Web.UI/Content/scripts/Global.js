$(document).ready(() => {

    
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

        Start: (interval) => {
            this.action = setInterval(() => {
                $("#notific-tarefa").addClass("notific-true");
                setTimeout(() => {
                    $("#notific-tarefa").removeClass("notific-true");
                }, interval / 2);
            }, interval);
        },
        Stop: () => {
            $("#notific-tarefa").removeClass("notific-true");
            clearInterval(this.action);
        },
        IsOpen: () => {
            return !$("#notification-box").is(":hidden");
        },
        Open: () => {
            $("#notification-box").show(200);
        },
        Close: () => {
            $("#notification-box").hide(200);
        }
    },
    //Preload de carregamento
    Load = {
        Show: () => {
            if ($("#load-area").leght) {
                $("#load-area").show();
            } else {
                $("body").append("<div id='load-area'><div id='load-loop'></div></div>");
                $("#load-area").show();
            }
        }, 
        Hide: () => {
            $("#load-area").hide();
        }
    };


});
