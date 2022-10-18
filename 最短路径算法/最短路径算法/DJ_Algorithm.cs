using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 最短路径算法
{
    class DJ_Algorithm
    {
        //创建路径表格
        public static List<route> GetList(string text)
        {
            List<route> list = new List<route>();//创建路径集合
            string line;//读取行数
            string[] str = text.Split('\n');//存储每行数据
            string[] temp = new string[1000000];//创建集合存储起点，终点，距离数据

            //存储路径数据
            for (int x = 0; x < str.Length; x++)
            {
                line = str[x];
                string Start = null;
                string End = null;
                int distance = 0;
                temp = line.Split(',');
                Start = temp[0];
                //MessageBox.Show(Start + "");//起点数据检测
                End = temp[1];
                //MessageBox.Show(End + "");终点数据检测
                distance = Convert.ToInt32(temp[2]);
                //MessageBox.Show(distance + "");距离数据检测
                route r = new route(Start, End, distance);
                list.Add(r);
            }

            return list;
        }

        //获取节点数量与名称
        public static List<string> GetNode(List<route> list, string start)
        {
            List<string> Node_name = new List<string>();//存储路径名称用于构造矩阵
            Node_name.Add(correct_Node(start));//确定起点
            for (int i = 0; i < list.Count; i++)
            {
               
                string Str = correct_Node(list[i].Get_Start);
                if (!Node_name.Contains(Str))
                {
                    Node_name.Add(Str);
                }
            }

            return Node_name;
        }

        
        //创建邻接矩阵矩阵
        public static Matrix Creat_Matrix(List<string> Node, List<route> r)
        {
            
            int x = 0;
            Hashtable node = new Hashtable();
            foreach (var name in Node)//创建哈希表，用于存储路径数据
            {
                node.Add(name, x);
                x++;
            }

            int[] m = new int[r.Count];
            int[] n = new int[r.Count];
            int c = 0;

            foreach (route temp in r)
            {
                string str = correct_Node(temp.Get_Start);
                m[c] = (int)node[str];
                n[c] = (int)node[temp.Get_End];
                c++;
            }//创建邻接矩阵的

            double INF = 999999999.9;
            int M = Node.Count;
            Matrix a = new Matrix(M, M);
           
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    for (int k = 0; k < c; k++)
                    {
                        if (i == j)
                        {
                            a.Matrix_a[i, j] = 0.0;
                            break;
                        }
                        else if (i == m[k] && j == n[k])
                        {
                            a.Matrix_a[i, j] = r[k].Get_Dis;
                            break;
                        }
                        a.Matrix_a[i, j] = INF;
                    }
                }
            }

            return a;

            
        }


        public static double[]  Dijkstra(Matrix a, List<string> Node) //Dijkstra算法为单源最短路径算法 s 为起点 
        {
            double[] dist = new double[Node.Count];// dist用来记录每次操作时s到每个点的最短路径 
            int[] s = new int[Node.Count];
            int v = 0;//源点为标识成0的点；
            double max = 9999999;//最大值
            double wmin;
            int num = 1;
            int u; //u代表其最小值指向的顶点

            for (int i = 0; i < Node.Count; i++)//数组dist及集合S赋初值
            {
                dist[i] = a.Matrix_a[v,i];
                s[i] = 0;
            }
            s[v] = 1; //把顶点v加入集合s中,1表示在集合S当中，0表示不在集合s中;

            do
            {
                wmin = max;
                u = v;//选择顶点u
                for (int i = 0; i < Node.Count; i++)
                {
                    if (s[i] == 0) //不在集合S中的顶点
                    {
                        if (dist[i] < wmin)   //找到最小值及其顶点
                        {
                            u = i;
                            wmin = dist[i];
                        }
                    }
                }

                s[u] = 1;
                for (int i = 0; i < Node.Count; i++)
                {
                    if (s[i] == 0)  //不在集合S中的顶点
                    {
                        if (dist[u] + a.Matrix_a[u, i] < dist[i])  //u为最小值指向的顶点，dist[u]+G[u][i]表示从源点v0先到顶点u再到其他顶点的路径，dist[i]表示从源点v0直接到其他顶点的路径
                            dist[i] = dist[u] + a.Matrix_a[u, i];   //取两者最小的作为源点v0直接到其他顶点的路径
                    }
                }
                num++;

            } while ((num != Node.Count - 1));

            return dist;
        }

     
        

        public static string correct_Node(string s)//反正字符串中有其他字符产生
        {
            string pattern = @"[A-Za-z0-9\u4e00-\u9fa5-]+";//正则表达式（防止存储过程中出现符号错误）
            string Str = "";
            MatchCollection i = Regex.Matches(s, pattern);
            foreach (var q in i)
            {
                Str += q;
            }

            return Str;
        }


    }
}
