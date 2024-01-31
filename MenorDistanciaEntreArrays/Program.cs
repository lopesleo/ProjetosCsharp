
using System;

namespace MenorDistanciaEntreArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("digite 1 para usar arrays aleatorios ou 2 para inserir arrays ");
            int escolha = int.Parse(Console.ReadLine());
            List<int> array1 = new List<int>();
            List<int> array2 = new List<int>();

            if (escolha == 1)
            {
                PopulaArray(array1);
                PopulaArray(array2);
            }
            else if (escolha == 2)
            {
                Console.WriteLine("Digite os números do primeiro array (digite 'pronto' para finalizar):");
                while (true)
                {
                    string linha = Console.ReadLine();
                    if (linha.ToLower() == "pronto")
                    {
                        break;
                    }
                    int numero;
                    if (int.TryParse(linha, out numero))
                    {
                        array1.Add(numero);
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Digite um número ou 'pronto' para finalizar.");
                    }
                }

                Console.WriteLine("Digite os números do segundo array (digite 'pronto' para finalizar):");
                while (true)
                {
                    string linha = Console.ReadLine();
                    if (linha.ToLower() == "pronto")
                    {
                        break;
                    }
                    int numero;
                    if (int.TryParse(linha, out numero))
                    {
                        array2.Add(numero);
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Digite um número ou 'pronto' para finalizar.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Escolha inválida");
            }

            Console.WriteLine(EscreveArray(array1));
            Console.WriteLine(EscreveArray(array2));
            MenorDistancia(array1, array2);
            Console.ReadLine();
        }

        public static string EscreveArray(List<int> array)
        {
            string arrayEscrito = "";
            foreach (int i in array)
            {
                arrayEscrito += i + " ";
            }
            return arrayEscrito;
        }

        public static void PopulaArray(List<int> array)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                array.Add(random.Next(-100, 100));
            }
        }

        public static void MenorDistancia(List<int> array1, List<int> array2)
        {
            int menorDistancia = int.MaxValue;
            int[] numerosUtilizados = new int[2];
            foreach (int i in array1)
            {
                foreach (int j in array2)
                {
                    int distancia = Math.Abs(i - j);
                    if (distancia < menorDistancia)
                    {
                        menorDistancia = distancia;
                        numerosUtilizados[0] = i;
                        numerosUtilizados[1] = j;
                    }
                }
            }
            Console.WriteLine("Menor distancia: " + menorDistancia);
            Console.WriteLine("Numeros utilizados: " + numerosUtilizados[0] + " e " + numerosUtilizados[1]);
        }
    }
}