﻿using System;
namespace CriptografiaDeNavio
{

    class Program
    {
        const int DuasUltimasCasas = 2;
        static void Main(string[] args)
        {
            string mensagemCriptografada = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";
            string[] Blocos = mensagemCriptografada.Split(' ');
            Console.WriteLine("Mensagem original: " + mensagemCriptografada);
            Blocos = InverteBitsFinais(Blocos);
            Console.WriteLine("Mensagem com bits finais invertidos: ");
            foreach (string b in Blocos)
            {
                Console.Write(b.ToString() + " ");
            }
            Blocos = Inverte4Bits(Blocos);
            Console.WriteLine("\nMensagem com 4 bits invertidos: ");
            foreach (string b in Blocos)
            {
                Console.Write(b.ToString() + " ");
            }



            string mensagemFinal = ConverteBinarioParaAscii(Blocos);
            Console.WriteLine("\nMensagem decifrada: " + mensagemFinal);
            Console.ReadLine();
        }

        public static string ConverteBinarioParaAscii(string[] mensagem)
        {
            string mensagemFinal = string.Empty;
            foreach (string i in mensagem)
            {
                int ascii = Convert.ToInt32(i, 2);
                char caractere = Convert.ToChar(ascii);
                mensagemFinal += caractere;
            }
            return mensagemFinal;
        }

        public static string[] InverteBitsFinais(string[] mensagem)
        {
            for (int i = 0; i < mensagem.Length; i++)
            {
                char[] chars = mensagem[i].ToCharArray();

                for (int j = chars.Length - 2; j < chars.Length; j++)
                {
                    chars[j] = InverteBit(chars[j]);
                }

                mensagem[i] = new string(chars);
            }
            return mensagem;
        }

        public static char InverteBit(char bit)
        {
            return bit == '0' ? '1' : '0';
        }

        public static string[] Inverte4Bits(string[] mensagem)
        {
            string[] mensagemFinal = new string[mensagem.Length];
            for (int i = 0; i < mensagem.Length; i++)
            {
                var parte1 = mensagem[i].Substring(0, 4);
                var parte2 = mensagem[i].Substring(4);
                mensagemFinal[i] = parte2 + parte1;
            }
            return mensagemFinal;
        }
    }

}