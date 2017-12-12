using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace search
{
    public partial class Form1 : Form
    {

        string choosen_path;
        List<string> to_copy = new List<string>();


        public void Search_for_files()
        {
            var sln_file = Directory.GetFiles(choosen_path, "*.sln", SearchOption.AllDirectories);
            if (sln_file.Length == 0)
            {
                MessageBox.Show("[ERROR]\n\t*.sln file not found.\n\tPlease select diffrent folder.");
                return;
            }
            else if (sln_file.Length > 1)
            {
                MessageBox.Show("[ERROR]\n\tFound multiple *.sln files.\n\tPlease select diffrent folder.");
                return;
            }

            to_copy.Add(sln_file[0]);

            string[] temp = new String[0];
            foreach (string line in File.ReadAllLines(to_copy[0]))
            {
                if (line.Contains("Project("))
                {
                    temp = line.Split();

                }
            }
            foreach (string x in temp)
            {
                if (x.EndsWith(".csproj\","))
                {
                    to_copy.Add(Path.GetDirectoryName(to_copy[0]) + x);
                    to_copy[1] = to_copy[1].Replace("\"", "\\").Substring(0, to_copy[1].Length - 2);
                }
            }

            //System.Diagnostics.Debug.Print(to_copy[1]);
        }


        public Form1()
        {
            InitializeComponent();
            this.Text = "VS project files searcher by Mateusz Krusinski."
;        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                choosen_path = folderBrowserDialog1.SelectedPath;
                Search_for_files();
            }
        }
    }
}
