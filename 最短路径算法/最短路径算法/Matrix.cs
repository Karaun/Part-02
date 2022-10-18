using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最短路径算法
{
    class Matrix
    {
        public Matrix(int am, int an)
        {
            M = am;
            N = an;
            Matrix_a = new double[M, N];
        }


        int M;
        int N;
        double[,] matrix;

        public int GetN
        {
            set { N = value; }
            get { return N; }
        }

        public int GetM
        {
            set { M = value; }
            get { return M; }
        }

        public double[,] Matrix_a
        {
            set { matrix = value; }
            get { return matrix; }
        }

        public static string Display(Matrix mm)
        {
            string str = "";
            for (int i = 0; i < mm.GetM; i++)
            {
                for (int j = 0; j < mm.GetN; j++)
                {
                    if (j < mm.GetN - 1)
                    {
                        if (mm.Matrix_a[i, j] == 999999999.9)
                        {
                            str += "INF" + "   ";
                        }
                        else
                        { str += mm.Matrix_a[i, j].ToString("#0.00") + " "; }
                    }
                    else if (j == mm.GetM - 1)
                    {
                        if (mm.Matrix_a[i, j] == 999999999.9)
                        {
                            str += "INF" + "\r\n";
                        }
                        else
                        { str += mm.Matrix_a[i, j].ToString("#0.00") + "\r\n"; }
                    }
                }
            }

            return str;
        }
    }
}


