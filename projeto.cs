using System;

namespace BibliotecaMatrizes
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("   BIBLIOTECA DE ÁLGEBRA LINEAR (C#)    ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Testar Leitura de Matriz (Matrix_Read)");
                Console.WriteLine("2. Multiplicação por Escalar");
                Console.WriteLine("3. Soma de duas Matrizes");
                Console.WriteLine("4. Multiplicação de duas Matrizes");
                Console.WriteLine("5. Determinante e Inversa (2x2)");
                Console.WriteLine("6. Determinante (3x3 por Laplace)");
                Console.WriteLine("7. Transposta de uma Matriz");
                Console.WriteLine("8. Verificar se é Diagonal / Triangular");
                Console.WriteLine("9. Funções Adicionais (Traço, Potência, etc.)");
                Console.WriteLine("0. Sair");
                Console.WriteLine("========================================");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\nOpção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("--- Teste: Matrix_Read ---");
                        Console.Write("Número de linhas: ");
                        int r = int.Parse(Console.ReadLine());
                        Console.Write("Número de colunas: ");
                        int c = int.Parse(Console.ReadLine());

                        double[,] matrizLida = Matrix_Read(r, c);
                        Console.WriteLine("\nMatriz introduzida:");
                        Matrix_Print(matrizLida);
                        break;

                    case 2:
                        Console.WriteLine("--- Teste: Matrix_Scalar_Mult ---");
                        double[,] A1 = LerMatrizRapida("Matriz A");
                        Console.Write("Introduza o valor do escalar: ");
                        double escalar = double.Parse(Console.ReadLine());

                        double[,] resScalar = Matrix_Scalar_Mult(A1, escalar);
                        Console.WriteLine("\nResultado:");
                        Matrix_Print(resScalar);
                        break;

                    case 3:
                        Console.WriteLine("--- Teste: Matrix_Add ---");
                        Console.WriteLine("Defina a Matriz A:");
                        double[,] A_add = LerMatrizRapida("Matriz A");
                        Console.WriteLine("Defina a Matriz B:");
                        double[,] B_add = LerMatrizRapida("Matriz B");

                        double[,] resAdd = Matrix_Add(A_add, B_add);
                        if (resAdd != null)
                        {
                            Console.WriteLine("\nResultado (A + B):");
                            Matrix_Print(resAdd);
                        }
                        break;

                    case 4:
                        Console.WriteLine("--- Teste: Matrix_Mult ---");
                        Console.WriteLine("Defina a Matriz A:");
                        double[,] A_mult = LerMatrizRapida("Matriz A");
                        Console.WriteLine("Defina a Matriz B:");
                        double[,] B_mult = LerMatrizRapida("Matriz B");

                        double[,] resMult = Matrix_Mult(A_mult, B_mult);
                        if (resMult != null)
                        {
                            Console.WriteLine("\nResultado (A * B):");
                            Matrix_Print(resMult);
                        }
                        break;

                    case 5:
                        Console.WriteLine("--- Teste: Matriz 2x2 (Determinante e Inversa) ---");
                        double[,] M2 = LerMatrizFixaTamanho(2, 2, "Matriz 2x2");
                        Console.WriteLine("\nMatriz inserida:");
                        Matrix_Print(M2);
                        
                        double det2 = Matrix_Determinant_2x2(M2);
                        Console.WriteLine($"Determinante: {det2:F2}");

                        double[,] inv = Matrix_Inverse_2x2(M2);
                        if (inv != null)
                        {
                            Console.WriteLine("Inversa:");
                            Matrix_Print(inv);
                        }
                        break;

                    case 6:
                        Console.WriteLine("--- Teste: Determinante 3x3 por Laplace ---");
                        double[,] M3 = LerMatrizFixaTamanho(3, 3, "Matriz 3x3");
                        Console.WriteLine("\nMatriz inserida:");
                        Matrix_Print(M3);
                        
                        double det3 = Matrix_Determinant_3x3(M3);
                        Console.WriteLine($"Determinante (Laplace): {det3:F2}\n");
                        break;

                    case 7:
                        Console.WriteLine("--- Teste: Matrix_Transpose ---");
                        double[,] M_trans = LerMatrizRapida("Matriz");
                        Console.WriteLine("\nMatriz Transposta:");
                        Matrix_Print(Matrix_Transpose(M_trans));
                        break;

                    case 8:
                        Console.WriteLine("--- Teste: Diagonal e Triangular Superior ---");
                        double[,] M_sq = LerMatrizRapida("Matriz Quadrada");
                        Console.WriteLine($"É Diagonal? {Matrix_IsDiagonal(M_sq)}");
                        Console.WriteLine($"É Triangular Superior? {Matrix_IsUpperTriangular(M_sq)}\n");
                        break;

                    case 9:
                        Console.WriteLine("--- Teste: Funções Adicionais ---");
                        double[,] M_ad = LerMatrizRapida("Matriz Quadrada");
                        if (M_ad.GetLength(0) == M_ad.GetLength(1))
                        {
                            Console.WriteLine($"Traço: {Matrix_Trace(M_ad)}");
                            Console.WriteLine($"Soma dos Quadrados da Diagonal: {Matrix_DiagonalSquareSum(M_ad)}");
                            Console.WriteLine($"É Simétrica? {Matrix_IsSymmetric(M_ad)}");
                        }
                        else
                        {
                            Console.WriteLine("As funções adicionais exigem uma matriz quadrada.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("\nA sair, muito obrigado por ter utilizado a nossa calculadora!");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        // FUNÇÕES AUXILIARES DE LEITURA (FORA DO MAIN)
        

        public static double[,] LerMatrizRapida(string nome)
        {
            Console.Write($"Linhas da {nome}: ");
            int r = int.Parse(Console.ReadLine());
            Console.Write($"Colunas da {nome}: ");
            int c = int.Parse(Console.ReadLine());
            return Matrix_Read(r, c);
        }

        public static double[,] LerMatrizFixaTamanho(int r, int c, string nome)
        {
            Console.WriteLine($"A introduzir elementos para uma {nome} ({r}x{c}):");
            return Matrix_Read(r, c);
        }

        
        // FUNÇÕES AUXILIARES OBRIGATÓRIAS DAS AULAS
        

        public static void Matrix_Print(double[,] M)
        {
            if (M == null)
            {
                Console.WriteLine("[Matriz Nula / Inválida]\n");
                return;
            }

            int rows = M.GetLength(0);
            int cols = M.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{M[i, j],8:F2} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine();
        }

        public static double Matrix_Determinant_2x2(double[,] M)
        {
            if (M.GetLength(0) != 2 || M.GetLength(1) != 2)
                throw new ArgumentException("A matriz tem de ser 2x2.");

            return (M[0, 0] * M[1, 1]) - (M[0, 1] * M[1, 0]);
        }

        
        // 4.1. FUNÇÕES BÁSICAS A DESENVOLVER (13 VALORES)
        

        public static double[,] Matrix_Read(int rows, int cols)
        {
            double[,] M = new double[rows, cols];
            Console.WriteLine($"Introduza os elementos da matriz ({rows}x{cols}):");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Elemento [{i + 1},{j + 1}]: ");
                    while (!double.TryParse(Console.ReadLine(), out M[i, j]))
                    {
                        Console.Write("Valor inválido. Tente novamente: ");
                    }
                }
            }
            return M;
        }

        public static double[,] Matrix_Scalar_Mult(double[,] M, double scalar)
        {
            int rows = M.GetLength(0);
            int cols = M.GetLength(1);
            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = M[i, j] * scalar;
                }
            }
            return result;
        }

        public static double[,] Matrix_Add(double[,] A, double[,] B)
        {
            int rowsA = A.GetLength(0), colsA = A.GetLength(1);
            int rowsB = B.GetLength(0), colsB = B.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
            {
                Console.WriteLine("Erro: As matrizes devem ter as mesmas dimensões para serem somadas.");
                return null;
            }

            double[,] result = new double[rowsA, colsA];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    result[i, j] = A[i, j] + B[i, j];
                }
            }
            return result;
        }

        public static double[,] Matrix_Mult(double[,] A, double[,] B)
        {
            int rowsA = A.GetLength(0), colsA = A.GetLength(1);
            int rowsB = B.GetLength(0), colsB = B.GetLength(1);

            if (colsA != rowsB)
            {
                Console.WriteLine("Erro: O número de colunas de A tem de ser igual ao número de linhas de B.");
                return null;
            }

            double[,] result = new double[rowsA, colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static double[,] Matrix_Inverse_2x2(double[,] M)
        {
            if (M.GetLength(0) != 2 || M.GetLength(1) != 2)
            {
                Console.WriteLine("Erro: A matriz deve ser 2x2.");
                return null;
            }

            double det = Matrix_Determinant_2x2(M);
            if (Math.Abs(det) < 1e-9)
            {
                Console.WriteLine("Erro: A matriz é singular (determinante = 0), não tem inversa.");
                return null;
            }

            double[,] adj = {
                {  M[1, 1], -M[0, 1] },
                { -M[1, 0],  M[0, 0] }
            };

            return Matrix_Scalar_Mult(adj, 1.0 / det);
        }

        public static double Matrix_Determinant_3x3(double[,] M)
        {
            if (M.GetLength(0) != 3 || M.GetLength(1) != 3)
                throw new ArgumentException("A matriz tem de ser 3x3.");

            double[,] sub00 = { { M[1, 1], M[1, 2] }, { M[2, 1], M[2, 2] } };
            double[,] sub01 = { { M[1, 0], M[1, 2] }, { M[2, 0], M[2, 2] } };
            double[,] sub02 = { { M[1, 0], M[1, 1] }, { M[2, 0], M[2, 1] } };

            double det = M[0, 0] * Matrix_Determinant_2x2(sub00)
                       - M[0, 1] * Matrix_Determinant_2x2(sub01)
                       + M[0, 2] * Matrix_Determinant_2x2(sub02);

            return det;
        }

        public static double[,] Matrix_Transpose(double[,] M)
        {
            int rows = M.GetLength(0);
            int cols = M.GetLength(1);
            double[,] result = new double[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = M[i, j];
                }
            }
            return result;
        }

        public static bool Matrix_IsDiagonal(double[,] M)
        {
            int rows = M.GetLength(0);
            int cols = M.GetLength(1);

            if (rows != cols) return false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i != j && Math.Abs(M[i, j]) > 1e-9)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool Matrix_IsUpperTriangular(double[,] M)
        {
            int rows = M.GetLength(0);
            int cols = M.GetLength(1);

            if (rows != cols) return false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Math.Abs(M[i, j]) > 1e-9)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        
        // 4.3. FUNÇÕES ADICIONAIS PARA OS 5 VALORES EXTRA 


        public static double[,] Matrix_Identity(int n)
        {
            double[,] I = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                I[i, i] = 1.0;
            }
            return I;
        }

        public static double Matrix_Trace(double[,] M)
        {
            if (M.GetLength(0) != M.GetLength(1))
                throw new ArgumentException("O traço só existe para matrizes quadradas.");

            double trace = 0;
            for (int i = 0; i < M.GetLength(0); i++)
            {
                trace += M[i, i];
            }
            return trace;
        }

        public static double Matrix_DiagonalSquareSum(double[,] M)
        {
            if (M.GetLength(0) != M.GetLength(1))
                throw new ArgumentException("A matriz tem de ser quadrada.");

            double sum = 0;
            for (int i = 0; i < M.GetLength(0); i++)
            {
                sum += M[i, i] * M[i, i];
            }
            return sum;
        }

        public static bool Matrix_IsSymmetric(double[,] M)
        {
            int rows = M.GetLength(0);
            int cols = M.GetLength(1);

            if (rows != cols) return false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < cols; j++)
                {
                    if (Math.Abs(M[i, j] - M[j, i]) > 1e-9)
                        return false;
                }
            }
            return true;
        }

        public static double[,] Matrix_Power(double[,] M, int exponent)
        {
            int n = M.GetLength(0);
            if (n != M.GetLength(1) || exponent < 0)
            {
                Console.WriteLine("Erro: A matriz deve ser quadrada e o expoente >= 0.");
                return null;
            }

            if (exponent == 0) return Matrix_Identity(n);

            double[,] result = (double[,])M.Clone();
            for (int i = 1; i < exponent; i++)
            {
                result = Matrix_Mult(result, M);
            }
            return result;
        }
    }
}
