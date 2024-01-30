using System;

class Program
{
    static void Main(string[] args)
    {

        int[] array1 = new int[10];
        int[] array2 = new int[10];
        PopulaArray(array1);
        PopulaArray(array2);
        
        Console.WriteLine(EscreveArray(array1));
        Console.WriteLine(EscreveArray(array2));
        MenorDistancia(array1, array2);

       
    }
    public static string EscreveArray(int[] array)
    {
        string arrayEscrito = "";
        foreach (int i in array)
        {
            arrayEscrito += i + " ";
        }
        return arrayEscrito;
    }
    public static int PopulaArray(int[] array)
    {
        Random random = new();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-100, 100);
        }
        return array.Length;
    }
    public static int MenorDistancia(int[] array1, int[] array2)
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
        return menorDistancia;
    }
}
