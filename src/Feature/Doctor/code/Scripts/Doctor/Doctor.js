function login(componentid) {
    var logincontrol = jQuery("#" + componentid);
    var usernameField = logincontrol.find("#popupLoginEmail");
    var passwordField = logincontrol.find("#popupLoginPassword");
    jQuery.ajax(
    {
        url: "/api/Accounts/_Login",
        method: "POST",
        data: {
            email: usernameField.val(),
            password: passwordField.val()
        },
        success: function (data) {
            if (data.RedirectUrl != null && data.RedirectUrl != undefined) {
                window.location.href = window.location.href;
            } else {
                var body = logincontrol.find(".login-body");
                var parent = body.parent();
                body.remove();
                parent.html(data);
            }
        }
    });
}

var getServicePath = "_vti_bin/Reply.Fiat.Cemedi/Search/SearchService.svc/"


function prepareSearch(textstring, flag, tipoVisita) {
    var myJSON = "";

    myJSON = JSON.stringify({ SearchString: textstring, FullText: flag, TipoVisita: tipoVisita });
    return myJSON;
}

function searchAlfa(componentid,letter) {
    var urlsite = "api/Doctor/searchAlfa";
    //var prefixID = jQuery('#HctrlPrefix');
    ////var tipoVisita = jQuery('#HTipoVisita').val();
    //var tipoVisita = jQuery('#' + prefixID.val() + 'HTipoVisita');
    //var jsonReq = prepareSearch(letter, 'false', tipoVisita.val());
    //var path = urlsite + "/" + getServicePath;
    //var searchtype = jQuery('#' + prefixID.val() + 'HTypeSearch');
    var logincontrol = jQuery("#" + componentid);
 
        jQuery.ajax({
            url: path ,
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: jsonReq,
            success: function (data) {
                searchResultMedico(data);

            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    }

function searchFreeText() {

    var urlsite = window.location.protocol + "//" + window.location.host;
    var prefixID = jQuery('#HctrlPrefix');
    var textstring = jQuery('#txtSearch').val();
    //var tipoVisita = jQuery('#HTipoVisita').val();
    var tipoVisita = jQuery('#' + prefixID.val() + 'HTipoVisita');
    var jsonReq = prepareSearch(textstring, 'true', tipoVisita.val());
    var path = urlsite + "/" + getServicePath;
    var searchtype = jQuery('#' + prefixID.val() + 'HTypeSearch');

    if (searchtype.val() == "Medico") {
        jQuery.ajax({
            url: path + 'GetMedico',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: jsonReq,
            success: function (data) {
                searchResultMedico(data);

            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    }
    else if (searchtype.val() == "Visita" || searchtype.val() == "EsameStrumentale") {
        jQuery.ajax({
            url: path + 'GetVisita',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: jsonReq,
            success: function (data) {
                searchResultVisita(data);

            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    }
}

function searchResultMedico(data) {

    var prefixID = jQuery('#HctrlPrefix');
    var resultPage = jQuery('#' + prefixID.val() + 'HResultPage');
    var searchResult = jQuery('#searchResult');

    searchResult.empty();
    var htmlText = "";

    if (data != null) {

        for (var i = 0; i < data.Nome.length; i++) {
            var codmedico = data.CodMedico[i];
            var branca = data.Branca[i];
            var nome = data.Nome[i];
            var cognome = data.Cognome[i];

            htmlText += "<div class='item-list-sub-Sepin'>";
            htmlText += "<a href='" + "/Pages/" + resultPage.val() + "?codMedico=" + codmedico + "' ><strong>" + cognome + " " + nome + "</strong></a><br>";
            htmlText += "<span>" + branca + "<br></span>";
            htmlText += "</div>";

        }
        if (data.Branca.length == 0) {
            htmlText = "Nessun risultato trovato.";
        }

        searchResult.append(htmlText);
    }

    return false;
}

function searchResultVisita(data) {

    var prefixID = jQuery('#HctrlPrefix');
    var resultPage = jQuery('#' + prefixID.val() + 'HResultPage');
    var searchResult = jQuery('#searchResult');

    var codVisiteHidden = jQuery('#' + prefixID.val() + 'HBrancaVisitaVisibilty');
    var codVisiteHiddenValue = codVisiteHidden.val();
    var arrayCodVisitaHidden = null;

    if (codVisiteHidden != null && codVisiteHiddenValue.length > 0) {
        arrayCodVisitaHidden = codVisiteHiddenValue.split(';');
    }



    searchResult.empty();
    var htmlText = "";

    if (data != null) {

        var currbranca = -1;
        var isHidden = false;

        for (var i = 0; i < data.CodBranca.length; i++) {
            var codbranca = data.CodBranca[i];
            var descbranca = data.DescrizioneBranca[i];
            var codvisita = data.CodVisita[i];
            var descvisita = data.DescVisita[i];
            var preparazione = data.Preparazione[i];

            //controllo la branca
            //se è la prima o diversa dalla precedente, allora inserisco titolo branca
            if (currbranca == -1 || currbranca != codbranca) {
                if (i > 0)
                    htmlText += "</div></div></div>";
                htmlText += "<div class=\"wrapper\"><div class=\"block01\"><div class=\"container\">";
                htmlText += "<div class='item-list-sub-Sepin'>";
                htmlText += "<span><strong>" + descbranca + "</strong><br></span>";
                htmlText += "</div>";

                currbranca = data.CodBranca[i];
            }

            htmlText += "<div class='item-list-sub-Sepin block2Visite'>";
            htmlText += "<div>" + descvisita + "</div>";

            //verifico se esistono delle visite il cui link al Dettaglio dev'essere nascosto
            if (arrayCodVisitaHidden != null && arrayCodVisitaHidden.length > 0) {
                // Cerco il codVisita tra quelli nascosti. Se ritorna 0 il codice visita è da nascondere, -1 è da visualizzare.
                isHidden = jQuery.inArray(codvisita, arrayCodVisitaHidden) > -1;
                if (!isHidden) {
                    //la visista non è da nascondere, dunque renderizzo il link di dettaglio
                    htmlText += "<div><a href='" + "/Pages/" + resultPage.val() + "?codVisita=" + codvisita + "' >Dettagli</a></div>";
                }
            } // se non esistono delle visite da nascondere, rederizzo direttamente il link
            else {
                htmlText += "<div><a href='" + "/Pages/" + resultPage.val() + "?codVisita=" + codvisita + "' >Dettagli</a></div>";
            }
            htmlText += "</div>";

        }
        htmlText += "</div></div></div>";

        if (data.CodBranca.length == 0) {
            htmlText = "Nessun risultato trovato.";
        }

        searchResult.append(htmlText);
    }

    return false;
}

function showModalDialog(title, url) {

    //ExecuteOrDelayUntilScriptLoaded(function() {    
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () {

        var options = {
            title: title,
            //args: { Preparazione: preparazione }, // preparazione esame
            showClose: true,
            //width: auto, //leave out and it'll auto-size
            //height: auto, //leave out and it'll auto-size
            url: url  // '/_layouts/Cemedi/Pages/PreparazioneEsame.aspx?tipoEsame=FDW4'	
        };

        SP.UI.ModalDialog.showModalDialog(options);
        jQuery(jQuery('.ms-dlgContent')[0]).css({ position: "fixed" }).animate({ top: "48%" });

    });
}

function Clear(obj) {
    obj.value = "";
}

//function getArgs() {
//    var args = SP.UI.ModalDialog.get_childDialog().get_args();

//    var divHtml = document.getElementById('htmlPreparaz');

//    divHtml.innerHTML(args.preparazione);
//}