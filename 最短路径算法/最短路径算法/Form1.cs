using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace 最短路径算法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public string path;
        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


            
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<route> Route_list = new List<route>();//创建路径集合
            Route_list = DJ_Algorithm.GetList(txtSource.Text);//路径集合存储

            List<string> Node_name = DJ_Algorithm.GetNode(Route_list, txtStart.Text);//路径节点存储
            //MessageBox.Show(Node_name.Count + "");
            Matrix a = DJ_Algorithm.Creat_Matrix(Node_name, Route_list);
            txtResult.Text = Matrix.Display(a);
            double[] djlist = DJ_Algorithm.Dijkstra(a, Node_name);
            string result = "";
            for (int i = 0; i < Node_name.Count; i++)
            {
                result += Node_name[i] + ":" + djlist[i] + "\r\n";
            }

            txtResult.Text  += "----------------------------" + "\r\n";
            txtResult.Text += result;

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择打开的文件";
            ofd.Filter = "txt|*.txt|all|*.*";

            ofd.ShowDialog();

            path = ofd.FileName;
            if (path == "")
            {
                return;
            }
            using (FileStream FsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 104 * 5];
                int r = FsRead.Read(buffer, 0, buffer.Length);
                txtSource.Text = Encoding.UTF8.GetString(buffer, 0, r);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("设置成功");
        }

        private void 结果导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请选择保存路径";
            sfd.Filter = "tx|*.txt|All|*.*";
            sfd.ShowDialog();

            string outcome = sfd.FileName;
            if (outcome == "")
            {
                return;
            }
            using (FileStream FsWrite = new FileStream(outcome, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(txtResult.Text);
                FsWrite.Write(buffer, 0, buffer.Length);

            }
        }
    }
}
