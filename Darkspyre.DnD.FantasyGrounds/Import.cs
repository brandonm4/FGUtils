using Darkspyre.DnD.Data.Entities;
using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Darkspyre.DnD.FantasyGrounds
{
    public class Import : IImportData
    {


        public async Task<DataLibrary> ImportFile(FGDataType dataType, string dbPath, string definitionPath = "")
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
                foreach (XmlNode n in doc.ChildNodes)
                {
                    if (n.Name == "root")
                    {
                        rootNode = n;
                        referenceNode = n;
                        break;
                    }
                }

                if (rootNode != null)
                {
                    foreach (XmlNode n in rootNode.ChildNodes)
                    {
                        if (n.Name == "spelldata") //spelldata in modules db/client
                        {
                            spellbookNode = n;
                            break;
                        }
                    }
                }
                if (spellbookNode == null)
                {
                    foreach (XmlNode n in rootNode.ChildNodes)
                    {
                        if (n.Name == "spell") //spells store in spell in campaign db
                        {
                            spellbookNode = n;
                            break;
                        }
                    }
                }
                var tasks = new List<Task>();

                if (spellbookNode != null)
                {
                    tasks.Add(ImportSpells(spellbookNode, dl));
                }
                //add task to import charsheets
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

        private async Task ImportSpells(XmlNode spellbook, DataLibrary dl)
        {
           // await Task.Run(() =>
           //{
               foreach (XmlNode spelldata in spellbook.ChildNodes)
               {
                   if (spelldata.HasChildNodes)
                   {
                       var spell = new Spell();
                       spell.FormId = spelldata.Name;
                       foreach (XmlNode c in spelldata.ChildNodes)
                       {
                           switch (c.Name.ToLower().Trim())
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
                                   break;
                               case "castingtime":
                                   spell.Time = c.InnerText;
                                   break;
                               case "components":
                                   spell.Components = c.InnerText;
                                   break;
                               case "description":
                                   spell.Text = c.InnerText;
                                   break;
                               case "duration":
                                   spell.Duration = c.InnerText;
                                   break;
                               case "range":
                                   spell.Range = c.InnerText;
                                   break;
                               case "ritual":
                                   spell.Ritual = (c.InnerText == "0") ? false : true;
                                   break;
                           }
                       }
                       dl.Spells.Add(spell);  //Should probably check to see if the spell exists and update it, but for now this is a pure import to a fresh list.
                   }
               }
          // });
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
