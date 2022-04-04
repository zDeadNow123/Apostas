﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apostassystem {
    internal class Program {
        static void Main(string[] args) {

            apostas();

            Console.ReadKey();
        }

        public static void apostas() {
            // Sistema de apostas

            // Usuário solicita o numero de cartões desejados
            Console.WriteLine("Digite o número de cartões desejados:");
            int numCartoes = int.Parse(Console.ReadLine());

            // Criar cartões para apostas com base no numero de cartões solicitados, cada cartão com 10 numeros aleatorios de 1 a 60, divididos em 5 grupos por "-", e cada grupo com 2 numeros aleatorios
            string[] cartoes = new string[numCartoes];

            for (int i = 0; i < numCartoes; i++) {

                string card = ""; // string que armazena o cartao
                Random rnd = new Random();

                // Categorias dentro do cartao (5 grupos) de dois numeros cada (de acordo com o rnd.Next [x, xx])
                int[] Groups = new int[5];

                for (int j = 0; j < 5; j++) {

                    Groups[j] = rnd.Next(1, 61);
                    card = string.Join("-", Groups);
                }

                cartoes[i] = card;
                Console.WriteLine("Cartão " + (i + 1) + ": " + cartoes[i]);
            }

            // Perguntar ao usuário se ele deseja gerar outro valor aleatorio para um cartão especifico
            Console.WriteLine("Deseja gerar um novo valor para um cartão especifico? (S/N)");
            string resposta = Console.ReadLine();

            // Se o usuário digitar "S", o programa pede para o usuário digitar o numero do cartão

            // Limpar tela
            Console.Clear();

            // Perguntar ao usuário se deseja voltar ao inicio do programa
            Console.WriteLine("Deseja voltar ao inicio do programa? (S/N)");
            string resposta2 = Console.ReadLine();
        }
    }
}