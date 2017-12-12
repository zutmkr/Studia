using System;
using System.IO;
using System.Windows.Forms;

namespace search
{
    public partial class Form1 : Form
    {

        string choosen_path;

        public void Search_for_files()
        {
            var allFiles = Directory.GetFiles(choosen_path, "*.sln", SearchOption.AllDirectories);

            System.Diagnostics.Debug.Print(allFiles.Length.ToString());
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
