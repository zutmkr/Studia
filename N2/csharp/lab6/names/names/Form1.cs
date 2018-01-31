using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace names
{
    public partial class Form1 : Form
    {
        public string[] text;
        List<string> listx2 = new List<string>();
        List<string> listx3 = new List<string>();
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        public void generate_list_x2()
        {
            foreach (var line in text)
            {
                var temp = line.Substring(line.LastIndexOf(' ') + 1);
                char[] chars = {temp[0], temp[1]};
                var temp2 = new string(chars);

                string result = listx2.FirstOrDefault(x => x.Contains(temp2));
                if (result != null)
                {
                    for (int i = 0; i < listx2.Count; i++)
                    {
                        if (listx2[i].Contains(result))
                            listx2[i] = result + " " + temp;
                    }
                }
                else
                {
                    listx2.Add(temp2 + " " + temp);
                }
            }
        }

        public void generate_list_x3()
        {
            foreach (var line in text)
            {
                var temp = line.Substring(line.LastIndexOf(' ') + 1);
                if (temp.Length <= 2)
                    continue;
                char[] chars = { temp[0], temp[1], temp[2] };
                var temp2 = new string(chars);

                string result = listx3.FirstOrDefault(x => x.Contains(temp2));
                if (result != null)
                {
                    for (int i = 0; i < listx3.Count; i++)
                    {
                        if (listx3[i].Contains(result))
                            listx3[i] = result + " " + temp;
                    }
                }
                else
                {
                    listx3.Add(temp2 + " " + temp);
                }
            }
        }


        public string[] read_file()
        {
            return File.ReadAllLines(@"nazwiska.txt", Encoding.GetEncoding("Windows-1250"));
        }

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

            sw = Stopwatch.StartNew();
            generate_list_x2();
            sw.Stop();
            label2.Text = sw.Elapsed.TotalMilliseconds.ToString() + " ms";

            sw = Stopwatch.StartNew();
            generate_list_x3();
            sw.Stop();
            label3.Text = sw.Elapsed.TotalMilliseconds.ToString() + " ms";        
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox1.TextLength >=3)
            {
                string result = listx3.FirstOrDefault(x => x.Contains(textBox1.Text));
                if (result != null)
                {
                    string[] t_result = result.Split(' ');
                    t_result = t_result.Skip(1).ToArray();
                    source.AddRange(t_result);
                }
            }
            else if (textBox1.TextLength == 2)
            {
                string result = listx2.FirstOrDefault(x => x.Contains(textBox1.Text));
                if (result != null)
                {
                    string[] t_result = result.Split(' ');
                    t_result = t_result.Skip(1).ToArray();
                    source.AddRange(t_result);
                }      
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.AutoCompleteCustomSource = source;
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}
