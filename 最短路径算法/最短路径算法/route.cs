using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最短路径算法
{
    class route
    {
        public route(string i, string j, int k)
        {
            Get_Start = i;
            Get_End = j;
            Get_Dis = k;
        }

        private string Start_Point;
        private string End_Point;
        private int distance;

        public string Get_Start
        {
            set { Start_Point = value; }
            get { return Start_Point; }
        }

        public string Get_End
        {
            set { End_Point = value; }
            get { return End_Point; }
        }

        public int Get_Dis
        {
            set { distance = value; }
            get { return distance; }
        }

    }
}
