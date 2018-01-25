using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace names
{
    public partial class Form1 : Form
    {
        string text;


        public Form1()
        {
            InitializeComponent();
            
            label2.Text = "";
            label3.Text = "";
            textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);


            Stopwatch sw = Stopwatch.StartNew();
            text = read_file();
            sw.Stop();
            label1.Text = sw.Elapsed.TotalMilliseconds.ToString() + " ms";
        }

        public string read_file()
        {
            return File.ReadAllText(@"nazwiska.txt", Encoding.UTF8);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //TODO
        }

    }
}
