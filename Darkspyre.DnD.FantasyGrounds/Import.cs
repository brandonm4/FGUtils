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

                //check root node for our data nodes - campaign mode
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
                // if we haven't found our nodes, then they are probably in the reference node - module mode
                if (spellbookNode == null || NPCNode == null)
                {
                    foreach (XmlNode n in referenceNode.ChildNodes)
                    {
                        if (n.Name == "spelldata") 
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

        private NameValue ImportNameValue(XmlNode node)
        {
            var nv = new NameValue();
            nv.Id = node.Name.Trim();
            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.Name != "#whitespace")
                {
                    switch (n.Name.ToLower().Trim())
                    {
                        case "name":
                            nv.Name = n.InnerText;
                            break;
                        case "desc":
                            nv.Value = n.InnerText;
                            break;
                    }
                }
            }
            return nv;
        }

        private AbilityScore ImportAbilityScore(XmlNode data)
        {
            var a = new AbilityScore();
            switch (data.Name.ToLower())
            {
                case "strength":
                    a.AbilityType = AbilityType.Strength;
                    break;
                case "dexterity":
                    a.AbilityType = AbilityType.Dexterity;
                    break;
                case "constitution":
                    a.AbilityType = AbilityType.Constitution;
                    break;
                case "wisdom":
                    a.AbilityType = AbilityType.Wisdom;
                    break;
                case "intelligence":
                    a.AbilityType = AbilityType.Intelligence;
                    break;
                case "charisma":
                    a.AbilityType = AbilityType.Charisma;
                    break;
            }
            foreach (XmlNode n in data.ChildNodes)
            {
                if (n.Name != "#whitespace")
                {
                    switch (n.Name)
                    {
                        case "score":
                            a.Score = Convert.ToInt32(n.InnerText);
                            break;
                        case "bonus":
                            a.Bonus = Convert.ToInt32(n.InnerText);
                            break;
                    }
                }
            }
            return a;
        }


    }
}
