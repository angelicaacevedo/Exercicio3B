using System;

namespace Exercicio3B
{
    public class ConjuntosDeInteiros
    {
        //declaraçao de uma constante
        public const int N = 10;
        //conjunto de bool vazio
        List<bool> arrayConjunto = new List<bool>();
        //armazena os valores digitados pelo usuario já ordenados
        SortedSet<int> numerosDigitados = new SortedSet<int>();

        SortedSet<int> conjuntoDeNumeros1 = new SortedSet<int>();
        SortedSet<int> conjuntoDeNumeros2 = new SortedSet<int>();

        //construtor
        public ConjuntosDeInteiros()
        {
            inicializarConjunto();
        }

        private void inicializarConjunto()
        {
            for (int i = 0; i <= N; i++)
            {
                arrayConjunto.Add(false);
            }
        }

        //2 Forma
        public void armazenarNumerosDigitadosConsecutivamente()
        {
            //Ler a linha inteira como string
            //Nao passar pelo conversor de inteiro
            //O split, pega uma string e splita pelo caracter especial (que você definiu), e cria um array com o resultado.
            //Exemplo: "12, 4,3,5,2,6,7,45,8" (Split pelo ,) -> [ "12", " 4", "3", "5", "2", "6", "7", "45", "8"]

            Console.WriteLine("\nDigite todos os números separados por vírgula(,), seguindo o padrão que deseja armazenar no conjunto e no final pressione o ENTER: ");
            Console.WriteLine("Exemplo: 1,2,3,4,5");

            string valor = Console.ReadLine() ?? "";

            string[] valoresArray = valor.Replace(" ", "").Split(",");

            foreach (string s in valoresArray)
            {
                int valorConvertido = Convert.ToInt32(s);

                numerosDigitados.Add(valorConvertido);
            }

            imprimir(numerosDigitados, "Conjunto Ordenado");
        }

        //Comparando os array incializado false com o array de valores passados pelo usuario
        public void compararArrys()
        {
            //criar uma prorpiedade para guardar o novo array de comparação
            //fazer um for percorrendo a lista de numerosDigitados pelo usuario
            //para cada valor encontrado guardar o index

            foreach (int indice in numerosDigitados)
            {
                if (indice <= N)
                {
                    arrayConjunto[indice] = true;
                }
            }
        }

        public void imprimir(SortedSet<int> conjunto, string nomeConjunto)
        {
            if (conjunto.Count != 0)
            {
                Console.Write($"\n{nomeConjunto}: ");
                Console.Write("[ ");

                foreach (int numero in conjunto)
                {
                    Console.Write($"{numero} ");
                }
                Console.Write("]");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("-");
            }
        }

        public void imprimir(List<bool> conjunto, string nomeConjunto)
        {
            if (conjunto.Count != 0)
            {
                Console.Write($"\n{nomeConjunto}: ");
                Console.Write("[ ");

                foreach (bool valor in conjunto)
                {
                    Console.Write($"{valor} ");
                }
                Console.Write("]");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("-");
            }
        }

        public void imprimirContido(SortedSet<int> conjunto1, SortedSet<int> conjunto2, string msg)
        {
            if ((conjunto1.Count != 0) && (conjunto2.Count != 0))
            { 
                Console.Write("\n[ ");

                foreach (int numero in conjunto1)
                {
                    Console.Write($"{numero} ");
                }

                Console.Write("] {0} em [ ", msg);

                foreach (int numero in conjunto2)
                {
                    Console.Write($"{numero} ");
                }

                Console.Write("]");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("-");
            }
        }

        //Imprimir Array atualizado
        public void imprimirArrayBooleanoAtualizado()
        {
            imprimir(arrayConjunto, "Array booleano atualizado");
        }

        public void inserirElemento(int k)
        {
            numerosDigitados.Add(k);

            if (k <= N)
            {
                atualizarElementoDoArray(k, true);
            }
            compararArrys();
            imprimirArrayBooleanoAtualizado();
        }

        //method para atualizar um elemento só do array
        public void atualizarElementoDoArray(int k, bool added)
        {
            arrayConjunto[k] = added;
        }

        public void deletarElemento(int m)
        {
            bool isExists = numerosDigitados.Contains(m);

            if (isExists)
            {
                numerosDigitados.Remove(m);
                atualizarElementoDoArray(m, false);
            }
            compararArrys();
            imprimirArrayBooleanoAtualizado();
        }

        public void toSetString()
        {
            if(numerosDigitados.Count != 0)
            {
                Console.WriteLine("\n\nArray toSetString:");
                Console.Write("[ ");

                foreach(int numero in numerosDigitados)
                {
                    Console.Write($"{numero} ");
                }
                Console.Write("]");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("-");
            }
        }

        public void eIgualA()
        {
            mensagemIgualA(1);
            conjuntoDeNumeros1 = capturarNumerosDigitados();
            imprimir(conjuntoDeNumeros1, "CONJUNTO 1");
            mensagemIgualA(2);
            conjuntoDeNumeros2 = capturarNumerosDigitados();
            imprimir(conjuntoDeNumeros2, "CONJUNTO 2");

            bool resultado = conjuntoDeNumeros1.SequenceEqual(conjuntoDeNumeros2);

            if (resultado)
            {
                Console.WriteLine("Os conjuntos são iguais!!");
            } else
            {
                Console.WriteLine("Os conjuntos NÃO são iguais!!");
            }
        }

        public void intervaloContido()
        {
            int numeroMenorConjunto1 = 0;
            int numeroMaiorConjunto1 = 0;
            int numeroMenorConjunto2 = 0;
            int numeroMaiorConjunto2 = 0;

            mensagemIgualA(1);
            conjuntoDeNumeros1 = capturarNumerosDigitados();
            imprimir(conjuntoDeNumeros1, "CONJUNTO 1");
            mensagemIgualA(2);
            conjuntoDeNumeros2 = capturarNumerosDigitados();
            imprimir(conjuntoDeNumeros2, "CONJUNTO 2");


            bool resultado = conjuntoDeNumeros1.SequenceEqual(conjuntoDeNumeros2);

            if((numeroMenorConjunto2 >= numeroMenorConjunto1) && (numeroMaiorConjunto2 <= numeroMaiorConjunto1))
            {
                imprimirContido(conjuntoDeNumeros1, conjuntoDeNumeros2, "está contido");
            } else {
                imprimirContido(conjuntoDeNumeros1, conjuntoDeNumeros2, "não está contido");
            }
        }

        private void mensagemIgualA(int numero)
        {
            Console.WriteLine("\nPor favor, digite os numeros do conjunto {0} separados por virgula (,), e sem seguida pressione Enter.", numero);
            Console.WriteLine("Exemplo: 1,2,3,4,5");
        }

        private SortedSet<int> capturarNumerosDigitados()
        {
            SortedSet<int> numerosCapturados = new SortedSet<int>();

            string valor = Console.ReadLine() ?? "";

            string[] valoresArray = valor.Replace(" ", "").Split(",");

            foreach (string s in valoresArray)
            {
                int valorConvertido = Convert.ToInt32(s);
                numerosCapturados.Add(valorConvertido);
            }

            return numerosCapturados;
        }
    }
}

