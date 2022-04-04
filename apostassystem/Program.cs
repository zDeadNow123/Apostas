using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apostassystem {
    internal class Program {

        // Definição de variáveis globais
        string[] cartoes;

        public static void Main(string[] args) {

            Program p = new Program(); // A função Main não deixa chamar funções não estáticas dentro dela, teve que ser desse jeito mesmo
            p.apostas();
        }

        public void apostas() {
            // Sistema de apostas

            // Usuário solicita o numero de cartões desejados
            Console.WriteLine("Digite o número de cartões desejados:");
            int numCartoes = int.Parse(Console.ReadLine());
            
            Console.Clear();

            // Criar cartões para apostas com base no numero de cartões solicitados, cada cartão com 10 numeros aleatorios de 1 a 60, divididos em 5 grupos por "-", e cada grupo com 2 numeros aleatorios
            cartoes = new string[numCartoes];

            for (int i = 0; i < numCartoes; i++) {

                string card = ""; // string que armazena o cartao

                // Categorias dentro do cartao (5 grupos) de dois numeros cada (de acordo com o JRandom.Range [x, xx])
                int[] Groups = new int[5];

                for (int j = 0; j < 5; j++) {

                    Groups[j] = JRandom.Range(1, 61);

                    // Verificar se o numero aleatorio gerado ja existe no cartao (se existir ele gera novamente)
                    while (card.Contains(Groups[j].ToString())) {
                        Groups[j] = JRandom.Range(1, 61);
                    }

                    card = string.Join("-", Groups);
                }

                cartoes[i] = card;

                //System.IO.File.WriteAllLines(@"C:\Users\Julio\Desktop\cartoes.txt", cartoes);
                Console.WriteLine("Cartão " + (i + 1) + ": " + cartoes[i]);
            }


            changeCard: // (Não é boa prática) :D

            Console.WriteLine(""); // Escreve uma linha em branco pra coisa não ficar muito colada

            Console.WriteLine("Deseja gerar um numero aleatorio para um cartão especifico? (s/n)");
            string resposta = Console.ReadLine();

            if (resposta == "S" || resposta == "s") {

                Console.WriteLine("Digite o numero do cartao desejado:");
                int cartao = int.Parse(Console.ReadLine());

                changeCard(cartao, numCartoes);
                goto changeCard; // Depois que o método encerra ele torna a perguntar ao usuário se ele deseja gerar um numero aleatorio para um cartão especifico
            }

            Console.WriteLine("Deseja voltar ao inicio do programa? (S/N)");
            string resposta2 = Console.ReadLine();

            if (resposta2 == "S" || resposta2 == "s") {

                Console.Clear();
                apostas();
            }

            else if (resposta2 == "N" || resposta2 == "n") {

                return;
            }

        }

        public void changeCard(int cartao, int numerocartoes) {

                Console.Clear(); // Limpa o console
                
                string card = "";

                int[] Groups = new int[5];

                for (int j = 0; j < 5; j++) {

                    Groups[j] = JRandom.Range(1, 61);

                    // Verificar se o numero aleatorio gerado ja existe no cartao
                    while (card.Contains(Groups[j].ToString())) {
                        Groups[j] = JRandom.Range(1, 61);
                    }

                    card = string.Join("-", Groups);
                }
                
                for (int i = 0; i < numerocartoes; i++) {

                    cartoes[cartao - 1] = card;

                    Console.WriteLine("Cartão " + (i + 1) + ": " + cartoes[i]);
                }
               
        }

    }
}
