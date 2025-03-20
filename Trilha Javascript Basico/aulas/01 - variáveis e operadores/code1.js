//Desafios JavaScript na DIO têm funções "gets" e "print" acessíveis globalmente:
//- "gets" : lê UMA linha com dado(s) de entrada (inputs) do usuário;
//- "print": imprime um texto de saída (output), pulando linha.

let numero = parseInt(10); //gets();

let soma = 0;
for (let i = 1; i <= numero; i++) {
  if(parseInt(i % 3) != 0 )
  {
      soma += i
    
  }
}

console.log("Soma dos números de 1 a " + numero + ", exceto os divisíveis por 3: " + soma.toString())