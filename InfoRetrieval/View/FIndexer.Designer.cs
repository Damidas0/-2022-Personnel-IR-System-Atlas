namespace InfoRetrieval
{
    partial class FIndexer
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_indexation = new System.Windows.Forms.Button();
            this.bt_test = new System.Windows.Forms.Button();
            this.txt_ZIPname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.L_res = new System.Windows.Forms.Label();
            this.txt_recherche = new System.Windows.Forms.TextBox();
            this.bt_recherche = new System.Windows.Forms.Button();
            this.l_recherche = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_indexation
            // 
            this.bt_indexation.Location = new System.Drawing.Point(137, 90);
            this.bt_indexation.Name = "bt_indexation";
            this.bt_indexation.Size = new System.Drawing.Size(75, 23);
            this.bt_indexation.TabIndex = 0;
            this.bt_indexation.Text = "IndexZIP";
            this.bt_indexation.UseVisualStyleBackColor = true;
            this.bt_indexation.Click += new System.EventHandler(this.bt_indexation_Click);
            // 
            // bt_test
            // 
            this.bt_test.Location = new System.Drawing.Point(137, 132);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(75, 23);
            this.bt_test.TabIndex = 1;
            this.bt_test.Text = "Test";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Click += new System.EventHandler(this.bt_test_Click);
            // 
            // txt_ZIPname
            // 
            this.txt_ZIPname.Location = new System.Drawing.Point(137, 64);
            this.txt_ZIPname.Name = "txt_ZIPname";
            this.txt_ZIPname.Size = new System.Drawing.Size(72, 20);
            this.txt_ZIPname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ZIP Name : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_res
            // 
            this.L_res.AutoSize = true;
            this.L_res.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.L_res.Location = new System.Drawing.Point(70, 167);
            this.L_res.Name = "L_res";
            this.L_res.Size = new System.Drawing.Size(0, 20);
            this.L_res.TabIndex = 4;
            // 
            // txt_recherche
            // 
            this.txt_recherche.Location = new System.Drawing.Point(83, 290);
            this.txt_recherche.Name = "txt_recherche";
            this.txt_recherche.Size = new System.Drawing.Size(180, 20);
            this.txt_recherche.TabIndex = 7;
            // 
            // bt_recherche
            // 
            this.bt_recherche.Location = new System.Drawing.Point(137, 326);
            this.bt_recherche.Name = "bt_recherche";
            this.bt_recherche.Size = new System.Drawing.Size(75, 23);
            this.bt_recherche.TabIndex = 6;
            this.bt_recherche.Text = "Rechercher";
            this.bt_recherche.UseVisualStyleBackColor = true;
            this.bt_recherche.Click += new System.EventHandler(this.bt_recherche_Click);
            // 
            // l_recherche
            // 
            this.l_recherche.AutoSize = true;
            this.l_recherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.l_recherche.Location = new System.Drawing.Point(3, 0);
            this.l_recherche.Name = "l_recherche";
            this.l_recherche.Size = new System.Drawing.Size(0, 20);
            this.l_recherche.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.l_recherche);
            this.flowLayoutPanel1.Controls.Add(this.vScrollBar1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(21, 358);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(315, 130);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(6, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(16, 130);
            this.vScrollBar1.TabIndex = 9;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // FIndexer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 509);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txt_recherche);
            this.Controls.Add(this.bt_recherche);
            this.Controls.Add(this.L_res);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ZIPname);
            this.Controls.Add(this.bt_test);
            this.Controls.Add(this.bt_indexation);
            this.Name = "FIndexer";
            this.Text = "Indexation";
            this.Load += new System.EventHandler(this.FIndexer_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_indexation;
        private System.Windows.Forms.Button bt_test;
        private System.Windows.Forms.TextBox txt_ZIPname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_res;
        private System.Windows.Forms.TextBox txt_recherche;
        private System.Windows.Forms.Button bt_recherche;
        private System.Windows.Forms.Label l_recherche;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

