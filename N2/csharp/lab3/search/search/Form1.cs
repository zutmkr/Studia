using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;

namespace search
{
    public partial class Form1 : Form
    {

        static string choosen_path;
        static string copy_dest;
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

            XmlDocument doc = new XmlDocument();
            doc.Load(to_copy[1]);

            XmlNodeList elemList = doc.GetElementsByTagName("Compile");
            for (int i = 0; i < elemList.Count; i++)
            {
                to_copy.Add(Path.GetDirectoryName(to_copy[1]) + "\\" + elemList[i].Attributes["Include"].Value);
            }
            var root_folder = Path.GetFileNameWithoutExtension(to_copy[0]);

            
            //System.Diagnostics.Debug.Print(root_folder);

            Directory.CreateDirectory(copy_dest);
            Directory.CreateDirectory(copy_dest + root_folder);
            Directory.CreateDirectory(copy_dest + root_folder + "\\Properties");

            File.Copy(to_copy[0], copy_dest + Path.GetFileName(to_copy[0]), true);
            File.Copy(to_copy[1], copy_dest + "\\" + root_folder + "\\" + Path.GetFileName(to_copy[1]), true);
            foreach (string x in to_copy)
            {
                if (x.Contains(".sln") || x.Contains(".csproj"))
                    continue;

                if (x.Contains("Properties"))
                    File.Copy(x, copy_dest + "\\" + root_folder + "\\Properties\\" + Path.GetFileName(x), true);
                else
                    File.Copy(x, copy_dest + "\\" + root_folder + "\\" + Path.GetFileName(x), true);
            }
           
            ZipFile.CreateFromDirectory(copy_dest, Directory.GetParent(copy_dest).FullName + @"_kopia.zip", CompressionLevel.Fastest, true);
            

        }
        

        public Form1()
        {
            InitializeComponent();
            this.Text = "VS project files searcher by Mateusz Krusinski."
;        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "C:\\kopia\\";
            copy_dest = "C:\\kopia\\";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            copy_dest = textBox1.Text;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog2.SelectedPath + "\\";
            }
        }
    }
}
