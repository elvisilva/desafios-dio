import { question, questionInt } from 'readline-sync';
import { Heroi } from './Heroi.js';
do {

    let nome = question('Informe do heroi: ');
    let idade = questionInt('Informe a idade do heroi: ');
    let tipo = question('Informe o tipo heroi [mago, guerreiro, monge ou ninja]: ');

    let heroi = new Heroi(nome, idade, tipo.toLowerCase()); // Atribui os valores inseridos pelo usuário
    heroi.atacar(); // Chama o método


    let sair = question('Deseja criar um novo heroi? [s/n] ');

    if(sair.toLowerCase() === 'n')
        break;

} while(true);