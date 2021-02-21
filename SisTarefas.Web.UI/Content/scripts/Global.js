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
    };


});
