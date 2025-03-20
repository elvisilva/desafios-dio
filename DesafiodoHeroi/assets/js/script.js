let herois = [];

function determinarNivel(xp) {
    if (xp < 1000) {
        return "Ferro";
    } else if (xp <= 2000) {
        return "Bronze";
    } else if (xp <= 5000) {
        return "Prata";
    } else if (xp <= 7000) {
        return "Ouro";
    } else if (xp <= 8000) {
        return "Platina";
    } else if (xp <= 9000) {
        return "Ascendente";
    } else if (xp <= 10000) {
        return "Imortal";
    } else {
        return "Radiante";
    }
}

function consultarNivel() {

    // Obtém os valores dos campos de entrada
    let nomeHeroi = document.getElementById('username').value;
    let xpHeroi = 0;
    xpHeroi = calcular();

    // Verifica se o XP é um número válido
    if (isNaN(xpHeroi)) {
        alert("Por favor, insira um valor numérico para XP.");
        return;
    }

    // Exibe o elemento 'result' e oculta o elemento 'form
    document.getElementById("result").style.display = "inline-block";
    document.getElementById("form").style.display = "none";

    // Determina o nível do herói
    let nivel = determinarNivel(xpHeroi);

    // Adiciona o herói ao array
    herois.push({ nome: nomeHeroi, xp: xpHeroi });

 
    // Exibe o resultado na tela
    let resultadoDiv = document.getElementById('result');
    resultadoDiv.innerHTML = `O Herói de nome ${nomeHeroi} com XP Total = ${xpHeroi} está no nível de ${nivel}`;

}
function mover(fonte, destino) {
    var selecionados = fonte.querySelectorAll("li input:checked");
    for ( var i = 0 ; i < selecionados.length ; i++ ) {
        var li = selecionados[i].parentNode.parentNode;
        fonte.removeChild(li);
        destino.appendChild(li);
        selecionados[i].checked = false;
    }
}
  
document.querySelector("button.dir").onclick = function() {
    mover(document.querySelector("ul.esq"),
        document.querySelector("ul.dir"));
};

document.querySelector("button.esq").onclick = function() {
    mover(document.querySelector("ul.dir"),
        document.querySelector("ul.esq"));
};

// Drag-and-drop
$( function() {
    $( "#sortable1, #sortable2" ).sortable({
    connectWith: ".connectedSortable"
    }).disableSelection();
} );

function calcular() {
    let soma = 0;
    
    let lista = document.querySelectorAll("#sortable2 li");
    for (let i = 0; i < lista.length; i++) { 
        switch(lista[i].textContent) {
            case "500 pontos":
                soma += 500;
                break;
            case "1000 pontos": 
                soma += 1000;
                break;
            case "2000 pontos":
                soma += 2000;
                break;
            case "3000 pontos":
                soma += 3000;
                break;
            case "4500 pontos":
                soma += 4500;
                break;
            case "6000 pontos":
                soma += 6000;
                break;
            case "7000 pontos":
                soma += 7000;
                break;
        }
    }
    return soma;
}