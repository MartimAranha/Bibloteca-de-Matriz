using System;

namespace BibliotecaMatrizes
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            // CICLO CRIADO POR MARTIM E PEDRO
            do
            {
                Console.Clear();
                Console.WriteLine("=== CALCULADORA DE MATRIZES ===");
                Console.WriteLine("1. Ler e imprimir matriz");
                Console.WriteLine("2. Multiplicar por um escalar");
                Console.WriteLine("3. Somar duas matrizes");
                Console.WriteLine("4. Multiplicar duas matrizes");
                Console.WriteLine("5. Determinante e Inversa (2x2)");
                Console.WriteLine("6. Determinante (3x3)");
                Console.WriteLine("7. Matriz Transposta");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opcao: ");

                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (opcao == 1)
                {
                    Console.WriteLine("--- Leitura de Matriz ---");
                    Console.Write("Linhas: ");
                    int l = int.Parse(Console.ReadLine());
                    Console.Write("Colunas: ");
                    int c = int.Parse(Console.ReadLine());

                    double[,] m = LerMatriz(l, c);
                    Console.WriteLine("\nMatriz inserida:");
                    ImprimirMatriz(m);
                }
                else if (opcao == 2)
                {
                    Console.WriteLine("--- Multiplicacao por Escalar ---");
                    double[,] m = PedirMatrizGenerica();
                    Console.Write("Digite o valor do escalar: ");
                    double esc = double.Parse(Console.ReadLine());

                    double[,] res = MultiplicarEscalar(m, esc);
                    Console.WriteLine("\nResultado:");
                    ImprimirMatriz(res);
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("--- Soma de Matrizes ---");
                    Console.WriteLine("Matriz A:");
                    double[,] a = PedirMatrizGenerica();
                    Console.WriteLine("Matriz B:");
                    double[,] b = PedirMatrizGenerica();

                    double[,] res = SomarMatrizes(a, b);
                    if (res != null)
                    {
                        Console.WriteLine("\nResultado (A + B):");
                        ImprimirMatriz(res);
                    }
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("--- Multiplicacao de Matrizes ---");
                    Console.WriteLine("Matriz A:");
                    double[,] a = PedirMatrizGenerica();
                    Console.WriteLine("Matriz B:");
                    double[,] b = PedirMatrizGenerica();

                    double[,] res = MultiplicarMatrizes(a, b);
                    if (res != null)
                    {
                        Console.WriteLine("\nResultado (A * B):");
                        ImprimirMatriz(res);
                    }
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("--- Matriz 2x2 (Determinante e Inversa) ---");
                    double[,] m = LerMatriz(2, 2);
                    Console.WriteLine("\nMatriz:");
                    ImprimirMatriz(m);

                    double det = Determinante2x2(m);
                    Console.WriteLine("Determinante: " + det);

                    double[,] inv = Inversa2x2(m);
                    if (inv != null)
                    {
                        Console.WriteLine("Inversa:");
                        ImprimirMatriz(inv);
                    }
                }
                else if (opcao == 6)
                {
                    Console.WriteLine("--- Determinante 3x3 ---");
                    double[,] m = LerMatriz(3, 3);
                    Console.WriteLine("\nMatriz:");
                    ImprimirMatriz(m);

                    double det = Determinante3x3(m);
                    Console.WriteLine("Determinante (Laplace): " + det);
                }
                else if (opcao == 7)
                {
                    Console.WriteLine("--- Matriz Transposta ---");
                    double[,] m = PedirMatrizGenerica();
                    double[,] trans = Transposta(m);
                    Console.WriteLine("\nTransposta:");
                    ImprimirMatriz(trans);
                }
                else if (opcao != 0)
                {
                    Console.WriteLine("Opcao invalida!");
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);

            Console.WriteLine("\nA sair do programa...");
        }

        // --- FUNÇÕES BÁSICAS CRIADAS POR JOELSON ---

        public static double[,] LerMatriz(int linhas, int colunas)
        {
            double[,] m = new double[linhas, colunas];
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    Console.Write("Elemento [" + (i + 1) + "," + (j + 1) + "]: ");
                    m[i, j] = double.Parse(Console.ReadLine());
                }
            }
            return m;
        }

        public static double[,] PedirMatrizGenerica()
        {
            Console.Write("Numero de linhas: ");
            int l = int.Parse(Console.ReadLine());
            Console.Write("Numero de colunas: ");
            int c = int.Parse(Console.ReadLine());
            return LerMatriz(l, c);
        }

        public static void ImprimirMatriz(double[,] m)
        {
            int linhas = m.GetLength(0);
            int colunas = m.GetLength(1);

            for (int i = 0; i < linhas; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < colunas; j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine();
        }

        public static double[,] MultiplicarEscalar(double[,] m, double escalar)
        {
            int linhas = m.GetLength(0);
            int colunas = m.GetLength(1);
            double[,] resultado = new double[linhas, colunas];

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    resultado[i, j] = m[i, j] * escalar;
                }
            }
            return resultado;
        }

        public static double[,] SomarMatrizes(double[,] a, double[,] b)
        {
            int lA = a.GetLength(0), cA = a.GetLength(1);
            int lB = b.GetLength(0), cB = b.GetLength(1);

            if (lA != lB || cA != cB)
            {
                Console.WriteLine("Erro: As matrizes têm de ter o mesmo tamanho!");
                return null;
            }

            double[,] resultado = new double[lA, cA];
            for (int i = 0; i < lA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    resultado[i, j] = a[i, j] o + b[i, j]; // Corrigido por joelson
                }
            }
            return resultado;
        }

        public static double[,] MultiplicarMatrizes(double[,] a, double[,] b)
        {
            int lA = a.GetLength(0), cA = a.GetLength(1);
            int lB = b.GetLength(0), cB = b.GetLength(1);

            if (cA != lB)
            {
                Console.WriteLine("Erro: Colunas de A têm de ser iguais às linhas de B!");
                return null;
            }

            double[,] resultado = new double[lA, cB];
            for (int i = 0; i < lA; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    double soma = 0;
                    for (int k = 0; k < cA; k++)
                    {
                        soma = soma + (a[i, k] * b[k, j]);
                    }
                    resultado[i, j] = soma;
                }
            }
            return resultado;
        }

        public static double Determinante2x2(double[,] m)
        {
            return (m[0, 0] * m[1, 1]) - (m[0, 1] * m[1, 0]);
        }

        public static double[,] Inversa2x2(double[,] m)
        {
            double det = Determinante2x2(m);
            if (det == 0) //  se o determinante for 0 ele vai assumir que nao tem inversa
            {
                Console.WriteLine("Erro: O determinante é zero, logo não tem inversa.");
                return null;
            }

            double[,] adjunta = new double[,] {
                {  m[1, 1], -m[0, 1] },
                { -m[1, 0],  m[0, 0] }
            };

            return MultiplicarEscalar(adjunta, 1.0 / det);
        }

        public static double Determinante3x3(double[,] m)
        {
            // Regra de Laplace simples usando submatrizes 2x2
            double[,] sub1 = new double[,] { { m[1, 1], m[1, 2] }, { m[2, 1], m[2, 2] } };
            double[,] sub2 = new double[,] { { m[1, 0], m[1, 2] }, { m[2, 0], m[2, 2] } };
            double[,] sub3 = new double[,] { { m[1, 0], m[1, 1] }, { m[2, 0], m[2, 1] } };

            double det = (m[0, 0] * Determinante2x2(sub1)) 
                       - (m[0, 1] * Determinante2x2(sub2)) 
                       + (m[0, 2] * Determinante2x2(sub3));

            return det;
        }

        public static double[,] Transposta(double[,] m)
        {
            int linhas = m.GetLength(0);
            int colunas = m.GetLength(1);
            double[,] resultado = new double[colunas, linhas];

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    resultado[j, i] = m[i, j];
                }
            }
            return resultado;
        }
    }
}
