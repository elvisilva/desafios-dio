using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class DadosEntrada
    {
        public string Placa { get; set; }
        public DateTime EntradaDataHora { get; set; }
        public DadosEntrada(string placa, DateTime entradaDataHora)
        {
            Placa = placa;
            EntradaDataHora = entradaDataHora;
        }
        public bool ValidarPlaca()
        {
            return Regex.IsMatch(Placa, @"^[a-zA-Z]{3}[0-9][A-Za-z0-9][0-9]{2}$");
        }
    }
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<DadosEntrada> veiculos = new List<DadosEntrada>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            DadosEntrada dadosEntrada = new DadosEntrada(placa.ToUpper(), DateTime.Now);
            if(!dadosEntrada.ValidarPlaca())
            {
                Console.WriteLine("Placa inválida.Digite somente letras e números, com 7 caracteres.");
                return;
            }
            veiculos.Add(dadosEntrada);
            Console.WriteLine($"O veículo {placa} foi estacionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placaLoc = string.Empty;
            placaLoc =  Console.ReadLine();
            int horas = 0;
            if (veiculos != null && veiculos.Any())
            {
                var dadosEntrada = veiculos.FirstOrDefault(d => d.Placa == placaLoc.ToUpper());

                if (dadosEntrada != null)
                {
                    horas = (int)(DateTime.Now - dadosEntrada.EntradaDataHora).TotalHours;
                    Console.WriteLine($"Veículo encontrado: {dadosEntrada.Placa}");
                }
                else
                {
                    Console.WriteLine($"Desculpe, esse veículo de placa ({placaLoc}) não está estacionado aqui. Confira se digitou a placa corretamente");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }            
            decimal valorTotal = precoInicial + (precoPorHora * horas);

            Console.WriteLine($"O veículo {placaLoc} foi removido e o preço total foi de: R$ {valorTotal}");
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                Console.WriteLine("  Placa - Hora de entrada");
                for (int i = 0; i < veiculos.Count; i++)
                {
                    DadosEntrada dadosEntrada = veiculos[i];
                    Console.WriteLine($"{dadosEntrada.Placa} - {dadosEntrada.EntradaDataHora}");
                }
                
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
