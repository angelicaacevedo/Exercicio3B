using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio3B
{
    public class program
    {
        public static void Main(String[] args)
        {
            ConjuntosDeInteiros conjunto1 = new ConjuntosDeInteiros();

            while(true)
            {
                Console.WriteLine("\n\n-----MENU DE OPÇÕES-----");
                Console.WriteLine("Escolha um número para realizar a atividade desejada: ");
                Console.WriteLine("Opção 1: Validar conjunto de numeros");
                Console.WriteLine("Opção 2: Inserir um novo elemento no conjunto");
                Console.WriteLine("Opção 3: Remover um elemento do conjunto");
                Console.WriteLine("Opção 4: Mostrar os numeros do conjunto");
                Console.WriteLine("Opção 5: Comparar dois conjuntos");
                Console.WriteLine("Opção 6: Verificar se um conjunto está contido em outro");
                Console.WriteLine("Opção 7: Sair do programa...");

                int numeroEscolhido = Convert.ToInt32(Console.ReadLine());

                if(numeroEscolhido == 7)
                {
                    break;
                }


                switch (numeroEscolhido)
                {
                    case 1:
                        conjunto1.armazenarNumerosDigitadosConsecutivamente();
                        conjunto1.compararArrys();
                        conjunto1.imprimirArrayBooleanoAtualizado();
                        break;

                    case 2:
                        Console.WriteLine("\nPor favor insira o numero do novo elemento: ");
                        int novoElemento = Convert.ToInt32(Console.ReadLine());
                        conjunto1.inserirElemento(novoElemento);
                        break;

                    case 3:
                        Console.WriteLine("\nPor favor insira o numero para ser removido: ");
                        int numero = Convert.ToInt32(Console.ReadLine());
                        conjunto1.deletarElemento(numero);
                        break;

                    case 4:
                        conjunto1.toSetString();
                        break;

                    case 5:
                        conjunto1.eIgualA();
                        break;

                    case 6:
                        conjunto1.intervaloContido();
                        break;

                    case 7:
                        Console.WriteLine("Finalizado!");
                        break;

                    default:
                        Console.WriteLine("Você digitou uma opção invalida!");
                        break;
                }

            }

            Console.WriteLine("Programa Finalizado!");
        }
    }
}

