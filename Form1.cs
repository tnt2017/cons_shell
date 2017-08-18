using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;


namespace cons
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern uint WinExec(string lpCmdLine, uint uCmdShow);

        [DllImport("shell32.dll")]
        private static extern int ShellExecute(int hWnd, string Operation, string File, string Parameters,
                                           string Directory, int nShowCmd);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Ваш логин: " + Environment.UserName;
            if (Environment.UserName == "Администратор" || Environment.UserName == "User")
            {
                ShellExecute(0, "open", "explorer.exe", "", "C:\\WINDOWS", 1);
                ///MessageBox.Show("Запустили рабочий стол");
                Close();
            }
            else
            {
                string url = "http://192.168.1.100:888/dolg.php?login=" + Environment.UserName;

                using (var client = new System.Net.WebClient())
                {
                    string sitetext = client.DownloadString(url);
                    textBox2.Text = sitetext;
                    if (sitetext.IndexOf("закончился")>0)
                    {
                        button2.Enabled = false;
                        button6.Enabled = false;
                        button1.Enabled = false;
                        MessageBox.Show("Вышел срок оплаты. Пополните баланс !","Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("explorer.exe");
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            //Process.Start("explorer.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path1 = Directory.GetCurrentDirectory();
            //MessageBox.Show(path1);
            Environment.CurrentDirectory = ("D:\\Veda\\");

            string path2 = Directory.GetCurrentDirectory();
            //MessageBox.Show(path2);

            ProcessStartInfo startInfo = new ProcessStartInfo("D:\\!!! SPS !!!\\Veda\\cons.exe");
            startInfo.WorkingDirectory = "D:\\Veda\\";
            Process.Start(startInfo);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
