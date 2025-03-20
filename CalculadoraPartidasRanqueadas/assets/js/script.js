function calcularRank() {
    const victories = parseInt(document.getElementById("victories").value);
    const defeats = parseInt(document.getElementById("defeats").value);
    let victorieBalance = victories - defeats;
    let level = setLevelName(victorieBalance);
    let imgSrc = setLevelImgSrc(level);

    // Exibir o resultado
    const resultDiv = document.getElementById("result");
    resultDiv.innerHTML = `O Herói(a) ou vilão tem de saldo ${victorieBalance} pontos e seu nível é ${level}.<br><img src="${imgSrc}" alt="${level}">`;
}

function setLevelName(victories) {
    let levelName = '';
    if (victories <= 10) {
        levelName = 'Ferro';
    } else if (victories >= 11 && victories <= 20) {
        levelName = 'Bronze';
    } else if (victories >= 21 && victories <= 50) {
        levelName = 'Prata';
    } else if (victories >= 51 && victories <= 80) {
        levelName = 'Ouro';
    } else if (victories >= 81 && victories <= 90) {
        levelName = 'Diamante';
    } else if (victories >= 91 && victories <= 100) {
        levelName = 'Lendário';
    } else if (victories >= 101) {
        levelName = 'Imortal';
    }
    return levelName;
}

function setLevelImgSrc(levelName) {
    let imgSrc = '';
    switch (levelName) {
        case 'Ferro':
            imgSrc = './assets/images/greenArcher.png';
            break;
        case 'Bronze':
            imgSrc = './assets/images/ironman.png';
            break;
        case 'Prata':
            imgSrc = './assets/images/hulk.png';
            break;
        case 'Ouro':
            imgSrc = './assets/images/batman.png';
            break;
        case 'Diamante':
            imgSrc = './assets/images/wonderwoman.png';
            break;
        case 'Lendário':
            imgSrc = './assets/images/superman.png';
            break;
        case 'Imortal':
            imgSrc = './assets/images/bolso.png';
            break;
    }
    return imgSrc;
}