using InfoRetrieval.Model;
using System;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace InfoRetrieval
{
    public partial class FIndexer : Form
    {
        Index i;
        //A mettre dans un controlleur 
        //Faut un gros controlleur ?
        public FIndexer()
        {
            InitializeComponent();
            this.i = new Index();
            i.ZIPName = "bird";
            i.IndexZip();

            vScrollBar1.Value = flowLayoutPanel1.VerticalScroll.Value;
            vScrollBar1.Minimum = flowLayoutPanel1.VerticalScroll.Minimum;
            vScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;

            flowLayoutPanel1.ControlAdded += FlowLayoutPanel1_ControlAdded;
            flowLayoutPanel1.ControlRemoved += FlowLayoutPanel1_ControlRemoved;
        }

        private void FlowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            vScrollBar1.Minimum = flowLayoutPanel1.VerticalScroll.Minimum;
        }

        private void FlowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

            vScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;
        }

        private void bt_test_Click(object sender, EventArgs e)
        {
            //Index i = new Index();
            //String r = i.TestReg();
            //L_res.Text = r;
        }

        private void bt_indexation_Click(object sender, EventArgs e)
        {
            Index i = new Index();
            i.ZIPName = this.txt_ZIPname.Text;
            L_res.Text = "Opération finie : \n" + i.IndexZip();

            string fileName = "Index.json";
            string jsonString = JsonSerializer.Serialize(i);
            File.WriteAllText(fileName, jsonString);
            long length = new System.IO.FileInfo(fileName).Length;
            L_res.Text += "\n" + length;
        }

        private void bt_recherche_Click(object sender, EventArgs e)
        {
            l_recherche.Text = "Résultats : \n";
            List<String> result = i.resResearch(this.txt_recherche.Text);
            l_recherche.Text += "\n" + i.mapName.Count;
            l_recherche.Text += "\n" + result.Count +"\n";
            foreach (String s in result)
            {
                l_recherche.Text += s + "\n";
            }
               
        }

        

        private void FIndexer_Load(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = vScrollBar1.Value;
        }
    }
}
