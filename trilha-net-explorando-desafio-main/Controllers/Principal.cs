using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioProjetoHospedagem.Models;

namespace DesafioProjetoHospedagem.Controllers
{
    public class Principal
    {
        public static void RunPrincipal()
        {
            Boolean novoProcesso = true;
            while(novoProcesso)
            {
                NovaSuite();
                Console.WriteLine("ENCERRAR? (S/N)");
                string respostaNewRun = Console.ReadLine();
                if(respostaNewRun.ToUpper() == "S"){
                    novoProcesso = false;
                }
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("Reservas realizadas:");
            Console.WriteLine("------------------------------");
        }
        public static void NovaSuite()
        {
            Boolean novasuite = true;
            while(novasuite){
                Console.WriteLine("Digite o tipo da suíte:");
                string tipoSuite = Console.ReadLine();
                Console.WriteLine("Digite a capacidade da suíte:");
                int capacidade = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o valor da diária:");
                decimal valorDiaria = decimal.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------");

                Suite s = new(tipoSuite: tipoSuite, capacidade: capacidade, valorDiaria: valorDiaria);

                NovaReserva(s);

                Console.WriteLine("Deseja adicionar mais uma suíte? (S/N)");
                string resposta = Console.ReadLine();
                if(resposta.ToUpper() == "N"){
                    novasuite = false;
                }
            }
        }
        public static void NovaReserva(Suite s)
        {
            List<Pessoa> hospedes = new();
            Boolean novohospede = true;
            while(novohospede){
                Console.WriteLine("Digite o nome completo do hóspede:");
                string nomeHospede = Console.ReadLine();
                Pessoa p = new(nome: nomeHospede);
                hospedes.Add(p);
                Console.WriteLine("------------------------------");

                Console.WriteLine("Deseja adicionar mais um hóspede? (S/N)");
                string respostaHosp = Console.ReadLine();
                if(respostaHosp.ToUpper() == "N"){
                    novohospede = false;

                    Console.WriteLine("Digite a quantidade de dias reservados:");
                    int diasReservados = int.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------");

                    Reserva reserva = new(diasReservados);
                    reserva.CadastrarSuite(s);
                    reserva.CadastrarHospedes(hospedes);

                    // Exibe a quantidade de hóspedes e o valor da diária
                    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                    Console.WriteLine(string.Format("Valor Total Reserva: {0:C}", reserva.CalcularValorDiaria()));
                    if(reserva.ValorDesconto > 0){
                        Console.WriteLine($"Desconto de 10% aplicado!");
                        Console.WriteLine(string.Format("Valor Total Sem Desconto: {0:C}",reserva.ValorPrincipalTotal));
                        Console.WriteLine(string.Format("Valor Total Desconto: {0:C}",reserva.ValorDesconto));
                    }
                    Console.WriteLine("------------------------------");
                }
            }
        }
    }
}