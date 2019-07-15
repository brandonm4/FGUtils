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
        private async Task ImportNPC(XmlNode NPCs, DataLibrary dl)
        {
            // await Task.Run(() =>
            //{
            foreach (XmlNode npcData in NPCs.ChildNodes)
            {
                if (npcData.Name != "#whitespace" && npcData.HasChildNodes)
                {
                    var npc = new NonPlayerCharacter();
                    npc.Id = npcData.Name.Trim();
                    foreach (XmlNode c in npcData.ChildNodes)
                   {
                        if (c.Name != "#whitespace")
                        {
                            switch (c.Name.ToLower().Trim())
                            {

                                case "abilities":
                                    
                                    break;
                                case "ac":
                                    npc.AC = Convert.ToInt32(c.InnerText);
                                    break;
                                case "actext":
                                    npc.ACText = c.InnerText;
                                    break;
                                case "actions":
                                    foreach (XmlNode a in c.ChildNodes)
                                    {
                                        if (a.Name != "#whitespace")
                                        {
                                            npc.Actions.Add(await ImportNameValue(a));
                                        }
                                    }
                                    break;
                                case "alignment":
                                    npc.Alignment =  c.InnerText;
                                    break;
                                case "conditionimmunities":
                                    npc.ConditionImmunities = c.InnerText;
                                    break;
                                case "cr":
                                    npc.CR = c.InnerText;
                                    break;
                                case "damageimmunities":
                                    npc.DamageImmunities = c.InnerText;
                                    break;
                                case "damageresistances":
                                    npc.DamageResistances = c.InnerText;
                                    break;
                                case "damagevulnerabilities":
                                    npc.DamageVulnerabilities = c.InnerText;
                                    break;
                                case "hd":
                                    npc.HD = c.InnerText;
                                    break;
                                case "hp":
                                    npc.HP = Convert.ToInt32(c.InnerText);
                                    break;
                                case "innatespells":
                                    foreach (XmlNode a in c.ChildNodes)
                                    {
                                        if (a.Name != "#whitespace")
                                        {
                                            npc.InnateSpells.Add(await ImportNameValue(a));
                                        }
                                    }
                                    break;
                                case "lairactions":
                                    foreach (XmlNode a in c.ChildNodes)
                                    {
                                        if (a.Name != "#whitespace")
                                        {
                                            npc.LairActions.Add(await ImportNameValue(a));
                                        }
                                    }
                                    break;
                                case "languages":
                                    npc.Languages = c.InnerText;
                                    break;
                                case "legendaryactions":
                                    foreach (XmlNode a in c.ChildNodes)
                                    {
                                        if (a.Name != "#whitespace")
                                        {
                                            npc.LegendaryActions.Add(await ImportNameValue(a));
                                        }
                                    }
                                    break;
                                case "name":
                                    npc.Name = c.InnerText;
                                    break;
                                case "reactions":
                                    foreach (XmlNode a in c.ChildNodes)
                                    {
                                        if (a.Name != "#whitespace")
                                        {
                                            npc.Reactions.Add(await ImportNameValue(a));
                                        }
                                    }
                                    break;
                                case "savingthrows":
                                    npc.SavingThrows = c.InnerText;
                                    break;
                                case "senses":
                                    npc.Senses = c.InnerText;
                                    break;
                                case "size":
                                    npc.Size = c.InnerText;
                                    break;
                                case "skills":
                                    npc.Skills = c.InnerText;
                                    break;
                                case "speed":
                                    npc.Speed = c.InnerText;
                                    break;
                                case "spells":
                                    foreach (XmlNode a in c.ChildNodes)
                                    {
                                        if (a.Name != "#whitespace")
                                        {
                                            npc.Spells.Add(await ImportNameValue(a));
                                        }
                                    }
                                    break;
                                case "spellslots":
                                    foreach (XmlNode a in c.ChildNodes)
                                    {
                                        if (a.Name != "#whitespace")
                                        {
                                            npc.SpellSlots.Add(new NameValue { Name=a.Name, Value=a.InnerText });
                                        }
                                    }
                                    break;
                                case "text":
                                    npc.Text = c.InnerText;
                                    break;
                                case "token":
                                    npc.Token = c.InnerText;
                                    break;
                                case "traits":
                                    foreach (XmlNode a in c.ChildNodes)
                                    {
                                        if (a.Name != "#whitespace")
                                        {
                                            npc.Traits.Add(await ImportNameValue(a));
                                        }
                                    }
                                    break;
                                case "type":
                                    npc.Type = c.InnerText;
                                    break;
                                case "xp":
                                    npc.XP = Convert.ToInt32(c.InnerText);
                                    break;
                                case "locked":
                                    npc.Locked = Convert.ToInt32(c.InnerText);
                                    break;
                                default:
                                    Console.WriteLine(c.Name);
                                    break;
                            }
                        }                        												 
                    }
                    dl.NonPlayerCharacters.Add(npc);
                }
            }
        }

		private async Task<NameValue> ImportNameValue(XmlNode node)
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
    }
}
