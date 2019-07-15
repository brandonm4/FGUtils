using Darkspyre.DnD.Data.Entities;
using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Darkspyre.DnD.FantasyGrounds
{
    public partial class Import : IImportData
    {


        public async Task<DataLibrary> ImportFile(string dbPath, string definitionPath, int sourceType)
        {
            var dl = new DataLibrary();
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try
            {
                doc.Load(dbPath);
                XmlNode spellbookNode = null;
                XmlNode rootNode = null;
                XmlNode referenceNode = null;
                XmlNode NPCNode = null;
                foreach (XmlNode n in doc.ChildNodes)
                {
                    if (n.Name == "root")
                    {
                        rootNode = n;
                        referenceNode = n;
                        break;
                    }
                }
                foreach(XmlNode n in rootNode.ChildNodes)
                {
                    if (n.Name == "reference")
                    {
                        referenceNode = n;
                        break;
                    }
                }

                if (rootNode != null)
                {
                    foreach (XmlNode n in rootNode.ChildNodes)
                    {
                        if (n.Name == "spell") //spelldata in modules db/client
                        {
                            spellbookNode = n;
                        }
                        if (n.Name == "npc")
                        {
                            NPCNode = n;
                        }
                    }
                }
                if (spellbookNode == null || NPCNode == null)
                {
                    foreach (XmlNode n in referenceNode.ChildNodes)
                    {
                        if (n.Name == "spelldata") //spells store in spell in campaign db
                        {
                            spellbookNode = n;
                        }
                        if (n.Name == "npcdata")
                        {
                            NPCNode = n;
                        }
                    }
                }
                
                var tasks = new List<Task>();

                if (spellbookNode != null)
                {
                    tasks.Add(ImportSpells(spellbookNode, dl));
                }
                if (NPCNode != null)
                {
                    tasks.Add(ImportNPC(NPCNode, dl));
                }
                //add task to import charsheets
               
                //add task to import items
                //add task to import other things
                //Will need to check and see if async updating the same object but different lists will matter.

                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dl;
        }

        

        private async Task ImportCharacters(XmlNode charsheet, DataLibrary dl)
        {

        }
    }
}

/*


 * 
 * 
 * List<Race> races = new List<Race>();
            string path = "C:\\Development\\Brandon\\darkspyre.dnd\\Darkspyre.DnD.FantasyGrounds\\spellmodule.xml";

            List<Spell> spells = new List<Spell>();

            List<string> SourceLIst = new List<string>();


            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try
            {
                doc.Load(path);
                XmlNode spellbook = null;

                foreach (XmlNode n in doc.ChildNodes)
                {
                    if (n.Name == "spelldata")
                    {
                        spellbook = n;
                        break;

                    }                   
                }

                if (spellbook != null)
                {
                    foreach (XmlNode spelldata  in spellbook.ChildNodes)
                    {
                        if (spelldata.HasChildNodes)
                        {
                            var spell = new Spell();
                            spell.FormId = spelldata.Name;
                            foreach(XmlNode c in spelldata.ChildNodes)
                            {
                                switch(c.Name.ToLower().Trim())
                                {
                                    case "name":
                                        spell.Name = c.InnerText;
                                        break;
                                    case "school":
                                        spell.School = c.InnerText;
                                        break;
                                    case "level":
                                        spell.Level = Convert.ToByte(c.InnerText);
                                        break;
                                    case "source":
                                        spell.Source = c.InnerText;
                                        var sources = spell.Source.Split(',');
                                        foreach(var sc in sources)
                                        {
                                            if (!SourceLIst.Contains(sc.ToLower().Trim()))
                                            {
                                                SourceLIst.Add(sc.ToLower().Trim());
                                            }
                                        }
                                        break;
                                }
                            }
                            spells.Add(spell);
                        }
                    }
                }*/
