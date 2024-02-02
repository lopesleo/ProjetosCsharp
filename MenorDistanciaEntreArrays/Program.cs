
using System;

namespace MenorDistanciaEntreArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("digite 1 para usar arrays aleatorios ou 2 para inserir arrays ");
            short escolha = short.Parse(Console.ReadLine());
            List<int> array1 = new List<int>();
            List<int> array2 = new List<int>();

            if (escolha == 1)
            {
                PopulaArray(array1);
                PopulaArray(array2);
            }
            else if (escolha == 2)
            {

                array1 = InsereNumeroArray(1);
                array2 = InsereNumeroArray(2);

            }
            else
            {
                Console.WriteLine("Escolha inválida");
            }

            Console.WriteLine(EscreveArray(array1));
            Console.WriteLine(EscreveArray(array2));

            var resultado = MenorDistancia(array1, array2);
            
            int menorDistancia = resultado["Menor Distancia"];
            int numero1 = resultado["valor1"];
            int numero2 = resultado["valor2"];
           
            
            Console.WriteLine("Menor distancia: " + menorDistancia);
            Console.WriteLine("Numeros utilizados: " + numero1 + " e " + numero2);
            

            Console.ReadLine();
        }

        public static List<int> InsereNumeroArray(int index)
        {
            var array = new List<int>();
            Console.WriteLine($"Digite os números do array {index} (digite 'pronto' para finalizar):");
            while (true)
            {
                string linha = Console.ReadLine();
                if (linha.ToLower().Trim() == "pronto")
                {
                    break;
                }
                
                if (int.TryParse(linha, out int numero))
                {
                    array.Add(numero);
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite um número ou 'pronto' para finalizar.");
                }
            }
            return array;
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
                array.Add(random.Next(0, 1000));
            }
        }

        public static Dictionary<string,int> MenorDistancia(List<int> array1, List<int> array2)
        {

            Dictionary<string, int> resultado = new();
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

            resultado.Add("Menor Distancia", menorDistancia);
            foreach(var item in numerosUtilizados)
            {
                resultado.Add("valor" + (Array.IndexOf(numerosUtilizados, item) + 1), item);
            }

            return resultado;
            
        }
    }
}