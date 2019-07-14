namespace Darkspyre.DnD.SpellTool.Win.Controls
{
    partial class SpellsManager
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.headerLabel1 = new Darkspyre.DnD.SpellTool.Win.Controls.HeaderLabel();
            this.lstSources = new System.Windows.Forms.ListView();
            this.headerLabel2 = new Darkspyre.DnD.SpellTool.Win.Controls.HeaderLabel();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.btnRemoveSource = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(3, 34);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(268, 487);
            this.treeView1.TabIndex = 0;
            // 
            // headerLabel1
            // 
            this.headerLabel1.AutoSize = true;
            this.headerLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel1.Location = new System.Drawing.Point(3, 6);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Size = new System.Drawing.Size(61, 25);
            this.headerLabel1.TabIndex = 1;
            this.headerLabel1.Text = "Spells";
            // 
            // lstSources
            // 
            this.lstSources.Location = new System.Drawing.Point(296, 65);
            this.lstSources.Name = "lstSources";
            this.lstSources.Size = new System.Drawing.Size(298, 204);
            this.lstSources.TabIndex = 2;
            this.lstSources.UseCompatibleStateImageBehavior = false;
            // 
            // headerLabel2
            // 
            this.headerLabel2.AutoSize = true;
            this.headerLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel2.Location = new System.Drawing.Point(291, 34);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Size = new System.Drawing.Size(122, 25);
            this.headerLabel2.TabIndex = 3;
            this.headerLabel2.Text = "Data Sources";
            // 
            // btnAddSource
            // 
            this.btnAddSource.Location = new System.Drawing.Point(296, 293);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(132, 43);
            this.btnAddSource.TabIndex = 4;
            this.btnAddSource.Text = "Add Source";
            this.btnAddSource.UseVisualStyleBackColor = true;
            this.btnAddSource.Click += new System.EventHandler(this.BtnAddSource_Click);
            // 
            // btnRemoveSource
            // 
            this.btnRemoveSource.Location = new System.Drawing.Point(471, 293);
            this.btnRemoveSource.Name = "btnRemoveSource";
            this.btnRemoveSource.Size = new System.Drawing.Size(123, 43);
            this.btnRemoveSource.TabIndex = 5;
            this.btnRemoveSource.Text = "Remove Source";
            this.btnRemoveSource.UseVisualStyleBackColor = true;
            this.btnRemoveSource.Click += new System.EventHandler(this.BtnRemoveSource_Click);
            // 
            // SpellsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemoveSource);
            this.Controls.Add(this.btnAddSource);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.lstSources);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.treeView1);
            this.Name = "SpellsManager";
            this.Size = new System.Drawing.Size(1150, 524);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private HeaderLabel headerLabel1;
        private System.Windows.Forms.ListView lstSources;
        private HeaderLabel headerLabel2;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Button btnRemoveSource;
    }
}
