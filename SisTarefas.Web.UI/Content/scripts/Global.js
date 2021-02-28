$(document).ready(() => {
    
    //notificacão de error e pequenos avisos
    notific = {
        error: (msg) => {
            $("body").append("<div class='notific-error'>"
                + "<span class='icon'></span>"
                + "<span>" + msg + "</span>"
                + "</div>");

            setTimeout(() => {
                $(".notific-error").hide(100);
            }, 4000);
        },
        success: (msg) => {

            $("body").append("<div class='notific-success'>"
                + "<span class='icon'></span>"
                + "<span>" + msg + "</span>"
                + "</div>");

            setTimeout(() => {
                $(".notific-success").hide(100);
            }, 4000);
        },
        warning: (msg) => {

            $("body").append("<div class='notific-warning'>"
                + "<span class='icon'></span>"
                + "<span>" + msg + "</span>"
                + "</div>");

            setTimeout(() => {
                $(".notific-warning").hide(100);
            }, 4000);
        }
    },

    //Notificações de Tarefas
    notification = {
        action: null,
        verification: null,
        items: [],
        IdBoxNotification: "#notification-box-modal-items",
        notificationItems: {},
        Start: (interval) => {
            notification.action = setInterval(() => {
                $("#notific-tarefa").addClass("notific-true");
                setTimeout(() => {
                    $("#notific-tarefa").removeClass("notific-true");
                }, interval / 2);
            }, interval);
        },
        Stop: () => {
            $("#notific-tarefa").removeClass("notific-true");
            clearInterval(notification.action);
        },
        IsOpen: () => {
            return !$("#notification-box").is(":hidden");
        },
        Open: () => {
            $("#notification-box").show(200);
            notification.Stop();
        },
        Close: () => {
            $("#notification-box").hide(200);

        },
        Verify: () => {
            notification.verification = setInterval( function() {
                $.ajax({
                    method: "Post",
                    url: "../Tarefas/NotificationVerific"
                }).done((data) => {
                    if (data.data) {
                        let dados = {};
                        data.notification.forEach((data) => {
                            data.forEach((data) => { dados[data.Key] = data.Value; });
                            if (!notification.items.includes("not-" + dados.id)) {
                                notification.Start(1000);
                                notification.AddItem(dados.descricao, dados.id);
                                notification.AddNotification(dados.id, dados);
                                console.log(dados);
                            }
                        });
                    }
                }).fail(() => {
                    notific.warning("As notificações não serão atualizadas***");
                    this.Endverify();
                });
            }, 5000);
        },
        Endverify: () => {
            clearInterval(this.verification);
        },
        AddItem: (name, id) => {
            $(notification.IdBoxNotification).append(
                "<div id='not-"+id+"' class='item-notification'>"+
                    "<div class='notific-view icon icone-olho'></div>"+
                    "<div class='notific-dell icon icone-deletar'></div>"+
                    "<h4 class='sub-title-top'>" + name + "</h4>"+
                "</div>"
            );
            //console.log(idDiv);
            notification.items.push("not-"+id);
        },
        RemoveItem: (item) => {
            $(item).parent().hide(200);
            $(item).remove();
        },
        View: (name, id) => {
            alert("name: "+name+", id: "+id);
        },
        AddNotification: (nome, notific) => {
            notification.notificationItems[nome] = notific;
        },
        RemoveNotification: (nome) => {
            delete this.notificationItems[nome];
        },
        GetNotification: (nome) => {
            return this.notificationItems[nome];
        }
    },
    //Preload de carregamento
    Load = {
        Show: () => {
            if ($("#load-area").length) {
                $("#load-area").show();
            } else {
                $("body").append("<div id='load-area'><div id='load-loop'></div></div>");
                $("#load-area").show();
            }
        }, 
        Showin: (item) => {
            if ($("#load-area").length) {
                $("#load-area").show();
            } else {
                $(item).append("<div id='load-area'><div id='load-loop'></div></div>");
                $("#load-area").show();
            }
        },
        Hide: () => {
            $("#load-area").hide();
        }
    };

    Validate = {
        JsonParams: (jsonparams, acceptnull) => {

            for (var item in jsonparams) {

                if (!acceptnull.includes(item) && !!!jsonparams[item]) {
                    return false;
                }
            }
            return true;
        }
    }

    //Notification
    $("#notific-tarefa").click(() => {
        if (notification.IsOpen()) {
            notification.Close();
        } else {
            notification.Open();
        }
    });
    $("#notific-exit").click(() => {
        notification.Close();
    });

    //Deletar notificações
    $(document).on("click", ".notific-dell", function() {
        notification.RemoveItem($(this));
    });

    $(document).on("click", ".notific-view", function () {
        let name = $(this).parent().text().trim();
        let id = $(this).parent().attr("id");
        notification.View(name, id);
    });
});
