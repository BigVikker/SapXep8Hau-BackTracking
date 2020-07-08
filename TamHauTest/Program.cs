using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamHauTest
{
    class GFG
    {
        static int dem = 0;
        static int N = 8;
        void print(int[,] board)
        {
            if(board[0,0] == 1)
            for(int i =0; i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    Console.Write(" " + board[i, j]
                                      + " ");
                }
                Console.WriteLine();
            }
        }

        void printSolution(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + board[i, j]
                                      + " ");
                
                Console.WriteLine();
            }
            dem++;
            Console.WriteLine("Cach giai thu: " + dem );
        }
        bool isSafe(int[,] board, int row, int col)
        {
            int i, j;

            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;
            for (i = row, j = col; i < N && j < N; i++, j++)
            {
                if (board[i, j] == 1)
                    return false;
            }
            for (i = row, j = col; i >= 0 && j < N; i--, j++)
            {
                if (board[i, j] == 1)
                    return false;
            }
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            for (i = row, j = col; j >= 0 && i < N; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        void Try1(int[,] board, int col)
        {
            if (col >= N)
            {
                printSolution(board);
            }
            board[0, 0] = 1;
            for (int i = 1; i < N; i++)
            {
                if (isSafe(board, i, col))
                {
                    board[i, col] = 1;
                    Try(board, col + 1);
                    board[i, col] = 0;
                }
            }
        }
        void Try(int[,] board, int col)
        {
            if (col >= N)
            {
                printSolution(board);
            }
           
            for (int i = 0; i < N; i++)
            {
                if(isSafe(board,i,col))
                {
                    board[i, col] = 1;
                    Try(board, col + 1);
                    board[i, col] = 0;
                }
            }
        }
        bool solveNQ()
        {
            int[,] board = {{ 0, 0, 0, 0, 0, 0, 0, 0 },
                           { 0, 0, 0, 0 ,0, 0, 0, 0 },
                           { 0, 0, 0, 0 ,0, 0, 0, 0 },
                           { 0, 0, 0, 0 ,0, 0, 0, 0 },
                           { 0, 0, 0, 0 ,0, 0, 0, 0 },
                           { 0, 0, 0, 0 ,0, 0, 0, 0 },
                           { 0, 0, 0, 0 ,0, 0, 0, 0 },
                           { 0, 0, 0, 0 ,0, 0, 0, 0 }};

            Try(board, 0);
            return true;
        }

        // Driver Code 
        public static void Main(String[] args)
        {
            GFG Queen = new GFG();
            Queen.solveNQ();
            Console.ReadLine();
        }
    }

}
