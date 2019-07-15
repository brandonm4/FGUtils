using Darkspyre.DnD.Data.Entities;
using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Darkspyre.DnD.FantasyGrounds
{
    public partial class Import
    {
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

                            case "aoe":
                            case "effect":
                                spell.AreaOfEffect = c.InnerText;
                                break;
                            case "locked":
                                spell.Locked = (c.InnerText == "0") ? false : true;
                                break;
                            case "mac":
                                spell.MAC = Int32.Parse(c.InnerText);
                                break;
                            case "pspcost":
                                spell.PSPCost = Int32.Parse(c.InnerText);
                                break;
                            case "pspfail":
                                spell.PSPFail = Int32.Parse(c.InnerText);
                                break;
                            case "save":
                                spell.Save = c.InnerText;
                                break;
                            case "sphere":
                                spell.Sphere = c.InnerText;
                                break;
                            case "shortdescription":
                                spell.ShortDescription = c.InnerText;
                                break;
                            case "type":
                                spell.SpellType = c.InnerText;
                                break;
                            case "sr":
                                spell.SpellResistance = c.InnerText;
                                break;
                        }
                    }
                    dl.Spells.Add(spell);  //Should probably check to see if the spell exists and update it, but for now this is a pure import to a fresh list.
                }
            }
            // });
        }
    }
}
