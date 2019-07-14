using Darkspyre.DnD.Data.Entities;
using Darkspyre.DnD.FantasyGrounds;
using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace Darkspyre.DnD.SpellTool.Win
{
    public partial class MainForm : Form
    {
        private Label label1;
        private TextBox txtInput;
        private TextBox txtOutput;
        private Label label2;
        private TextBox txtLevels;
        private Label label3;
        private TextBox txtModule;
        private Label label4;
        private Button btnInput;
        private Button btnOutput;
        private Button btnGenerate;

        IConfigurationBuilder builder;
        IConfigurationRoot configuration;
        SpellListConfig spellListConfig;

        public MainForm()
        {
            InitializeComponent();

            builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", false);
            configuration = builder.Build();

            spellListConfig = new SpellListConfig();
            var section = configuration.GetSection("SpellListConfig");
            spellListConfig = section.Get<SpellListConfig>();

            txtInput.Text = spellListConfig.InputFilePath;
            txtOutput.Text = spellListConfig.OutputFilePath;
            txtModule.Text = spellListConfig.ModuleName;
            txtLevels.Text = spellListConfig.SpellLevels;

            
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLevels = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(102, 33);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(408, 20);
            this.txtInput.TabIndex = 1;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(102, 62);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(408, 20);
            this.txtOutput.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output File";
            // 
            // txtLevels
            // 
            this.txtLevels.Location = new System.Drawing.Point(102, 91);
            this.txtLevels.Name = "txtLevels";
            this.txtLevels.Size = new System.Drawing.Size(408, 20);
            this.txtLevels.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Levels";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(102, 120);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(408, 20);
            this.txtModule.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Module Name";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(516, 170);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(516, 31);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 9;
            this.btnInput.Text = "Browse";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.BtnInput_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(516, 60);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 10;
            this.btnOutput.Text = "Browse";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.BtnOutput_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(622, 205);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLevels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "FG SpellList Creator v1.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            var msg = "";
            DataLibrary dl = new DataLibrary();

            var path = txtInput.Text;
            var outputFIle = txtOutput.Text;
            List<int> limitLevels = new List<int> { };
            string moduleId = "*";

            var bDoImport = true;

            if (!String.IsNullOrWhiteSpace(path) && !File.Exists(path))
            {
                msg += "Input file not found." + Environment.NewLine;
                bDoImport = false;
            }
            if (bDoImport && !String.IsNullOrWhiteSpace(outputFIle) && !Directory.Exists(Path.GetDirectoryName(outputFIle)))
            {
                bDoImport = false;
                msg += "Output Directory not found" + Environment.NewLine;
            }

            if (!String.IsNullOrWhiteSpace(txtLevels.Text))
            {
                var levels = txtLevels.Text.Split(',', StringSplitOptions.RemoveEmptyEntries);
                limitLevels = new List<int>();
                foreach (var l in levels)
                {
                    int x = 0;
                    if (Int32.TryParse(l, out x))
                    {
                        limitLevels.Add(x);
                    }
                }
            }
            if (!String.IsNullOrWhiteSpace(txtModule.Text))
            {
                moduleId = txtModule.Text;
            }

            if (!String.IsNullOrWhiteSpace(msg))
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var importer = new Import();
                DataLibrary library = importer.ImportFile(FGDataType.Campaign, path, "").Result;

                if (library.Spells.Count > 0)
                {
                    using (StreamWriter sw = new StreamWriter(outputFIle, false))
                    {
                        sw.WriteLine(Export.CreateSpellList(library.Spells, new List<string>(), limitLevels, moduleId));
                    }
                }

                SaveSettings();
                

                MessageBox.Show("Done");
            }
        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            using (var ofb = new OpenFileDialog())
            {
                ofb.DefaultExt = ".xml";

                if (ofb.ShowDialog() == DialogResult.OK)
                {
                    txtInput.Text = ofb.FileName;
                }
            }
        }

        private void BtnOutput_Click(object sender, EventArgs e)
        {
            using (var ofb = new SaveFileDialog())
            {
                ofb.DefaultExt = ".xml";

                if (ofb.ShowDialog() == DialogResult.OK)
                {
                    txtOutput.Text = ofb.FileName;
                }
            }
        }

        //This is probably a horrible way to do this
        private void SaveSettings()
        {
            using (var sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")))
            {
                sw.WriteLine("{");

                sw.WriteLine("\"SpellListConfig\": {");
    sw.WriteLine("\"InputFilePath\" :  \"" + txtInput.Text.Replace(@"\", @"\\") + "\", ");
    sw.WriteLine("\"OutputFilePath\": \"" + txtOutput.Text.Replace(@"\", @"\\") + "\", ");
    sw.WriteLine("\"ModuleName\": \"" + txtModule.Text + "\", ");
    sw.WriteLine("\"SpellLevels\" :  \"" + txtLevels.Text + "\"");
  sw.WriteLine("}");

                sw.WriteLine("}");
            }
        }
    }
}
