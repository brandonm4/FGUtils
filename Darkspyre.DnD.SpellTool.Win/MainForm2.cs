
using Darkspyre.DnD.Data.Entities;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darkspyre.DnD.SpellTool.Win
{
    public partial class MainForm2 : MetroForm
    {
        public DataLibrary dataLibrary { get; set; } = new DataLibrary();
        public MainForm2()
        {
            InitializeComponent();
            
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.SpellsManager spellsManager1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm2));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.spellsManager1 = new Darkspyre.DnD.SpellTool.Win.Controls.SpellsManager(dataLibrary);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1164, 556);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.spellsManager1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1156, 530);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Spells";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // spellsManager1
            // 
            this.spellsManager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spellsManager1.Location = new System.Drawing.Point(3, 3);
            this.spellsManager1.Name = "spellsManager1";
            this.spellsManager1.Size = new System.Drawing.Size(1150, 524);
            this.spellsManager1.TabIndex = 0;
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 580);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm2";
            this.Text = "FG Data Manager v2.0";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
