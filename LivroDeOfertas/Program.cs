namespace LivroDeOfertas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o número de notificações");
            int numNotificacoes = int.Parse(Console.ReadLine());
            List<string> notificacoes = new List<string>();
            Console.WriteLine("Digite as notificações no formato: posicao,acao,preco,quantidade");

            for (int i = 0; i < numNotificacoes; i++)
            {
                notificacoes.Add(Console.ReadLine());
            }

           var livroDeOfertas =  ProcessaNotificacoes(notificacoes, numNotificacoes);


              int j = 1;
            foreach (var item in livroDeOfertas)
            {
               Console.WriteLine(j + "," + item.Value.Item1 + "," + item.Value.Item2);
                j++;
            }

        }

        static Dictionary<int, Tuple<double, int>> ProcessaNotificacoes(List<string> strings, int notificacoes)
        {
            Dictionary<int, Tuple<double, int>> livroDeOfertas = new Dictionary<int, Tuple<double, int>>();

            foreach (var item in strings)
            {
                string[] valores = item.Split(',');
                int posicao = int.Parse(valores[0]);
                if (posicao <= 0)
                {
                    Console.WriteLine($"Entrada inválida. posicao {posicao}");
                    continue;
                }
                int acao = int.Parse(valores[1]);
                double preco = double.Parse(valores[2], System.Globalization.CultureInfo.InvariantCulture);
                int quantidade = int.Parse(valores[3]);

                if (acao == 0)
                {
                    try
                    {
                        if (preco > 0 && quantidade > 0)
                            livroDeOfertas.Add(posicao, new Tuple<double, int>(preco, quantidade));
                        else
                            Console.WriteLine($"Entrada inválida para o item na posicao {posicao}. verifique o preco ou a quantidade");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Entrada inválida. A posicao {posicao} já existe." + e.Message);
                    }

                }
                else if (acao == 1)
                {
                    if (livroDeOfertas.ContainsKey(posicao))
                    {
                        if (preco > 0 && quantidade > 0)
                        {
                            livroDeOfertas[posicao] = new Tuple<double, int>(preco, quantidade);
                        }
                        else
                        {
                            Console.WriteLine($"Entrada inválida para o item na posicao {posicao}. verifique o preco ou a quantidade");
                        }

                    }
                }
                else if (acao == 2)
                {
                    livroDeOfertas.Remove(posicao);
                }

            }

         
            return livroDeOfertas;
       
        }
    }
}
