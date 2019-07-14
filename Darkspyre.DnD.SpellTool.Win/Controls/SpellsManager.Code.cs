using Darkspyre.DnD.Data.Entities;
using Darkspyre.DnD.FantasyGrounds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Darkspyre.DnD.SpellTool.Win.Controls
{
    public partial class SpellsManager
    {
        DataLibrary dl;
        List<DataFile> DataFiles;
        public SpellsManager(DataLibrary _dl)
        {
            InitializeComponent();
            dl = _dl;
            DataFiles = new List<DataFile>();
        }

        private void BtnAddSource_Click(object sender, EventArgs e)
        {
            //Need to move the data file source into its own area
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "XML files(*.xml) | *.xml";
                ofd.DefaultExt = ".xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var filePath = ofd.FileName;
                    var fileName = Path.GetFileName(filePath);
                    DataFile df = new DataFile();
                    string dbFile = "";
                    string defFIle = "";
                    //Try to figure out what they just picked
                    FGSourceType stype = FGSourceType.Campaign;
                    switch (fileName)
                    {
                        case "campaign.xml":
                            df.SourceType = (int)FGSourceType.Campaign;
                            df.DefinitionFile = filePath;
                            dbFile = Path.Combine(Path.GetDirectoryName(filePath), "db.xml");
                            if (File.Exists(dbFile))
                                df.DatabaseFile = dbFile;
                            break;
                        case "db.xml":
                            //stype = FGSourceType.Campaign;
                            df.DatabaseFile = filePath;
                            defFIle = Path.Combine(Path.GetDirectoryName(filePath), "campaign.xml");
                            if (File.Exists(defFIle))
                            {
                                df.SourceType = (int)FGSourceType.Campaign;
                                df.DefinitionFile = defFIle;
                            }
                            else
                            {
                                defFIle = Path.Combine(Path.GetDirectoryName(filePath), "definition.xml");
                                if (File.Exists(defFIle))
                                {
                                    df.SourceType = (int)FGSourceType.Module;
                                    df.DefinitionFile = defFIle;
                                }
                            }
                            break;
                        case "definition.xml":
                            df.SourceType = (int)FGSourceType.Module;
                            dbFile = Path.Combine(Path.GetDirectoryName(filePath), "db.xml");
                            if (File.Exists(dbFile))
                                df.DatabaseFile = dbFile;
                            else
                            {
                                dbFile = Path.Combine(Path.GetDirectoryName(filePath), "client.xml");
                                if (File.Exists(dbFile))
                                    df.DatabaseFile = dbFile;
                            }
                            break;
                        case "client.xml":
                            df.SourceType = (int)FGSourceType.Module;
                            defFIle = Path.Combine(Path.GetDirectoryName(filePath), "definition.xml");
                            if (File.Exists(defFIle))
                            {
                                df.SourceType = (int)FGSourceType.Module;
                                df.DefinitionFile = defFIle;
                            }
                            break;
                    }

                    var importer = new Import();
                    df.Library = importer.ImportFile(df.DatabaseFile, df.DefinitionFile, df.SourceType).Result;

                    DataFiles.Add(df);

                    AddSpellsToMasterList(df.Library.Spells);
                    BuildSpellTree();
                }
            }
        }

        private void BtnRemoveSource_Click(object sender, EventArgs e)
        {

        }

        private async System.Threading.Tasks.Task ImportData()
        {
            var importer = new Import();

            foreach (var f in DataFiles)
            {
                f.Library = await importer.ImportFile(f.DatabaseFile, f.DefinitionFile, f.SourceType);
            }
        }

        private void AddSpellsToMasterList(List<Spell> spells)
        {
            foreach (var s in spells)
            {
                var extSpell = dl.Spells.Where(x => x.Name == s.Name).SingleOrDefault();
                if (extSpell != null)
                {
                    extSpell = s;
                }
                else
                {
                    dl.Spells.Add(s);
                }
            }
        }

        private void BuildSpellTree()
        {
            treeView1.Nodes.Clear();
            var levels = dl.Spells.Select(s => s.Level).Distinct().OrderBy(x => x);
            foreach (var l in levels)
            {
                var levelNode = new TreeNode("Level " + l.ToString());
                treeView1.Nodes.Add(levelNode);
                foreach (var s in dl.Spells.Where(x => x.Level == l).OrderBy(x=>x.Name))
                {
                    levelNode.Nodes.Add(s.Name);
                }
            }
        }
    }
}
