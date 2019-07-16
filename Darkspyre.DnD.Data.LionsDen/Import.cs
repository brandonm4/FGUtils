using Darkspyre.DnD.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Darkspyre.DnD.Data.Entities;
using Darkspyre.DnD.Interface;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Darkspyre.Extensions;
using System.Threading.Tasks;

namespace Darkspyre.DnD.Data.LionsDen
{
    public class Import : IImportData
    {
        public async Task<DataLibrary> ImportFile(string filePath, string definitionPath = "", int sourceType = 0)
        {
            var dl = new DataLibrary();

            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                using (FileStream xmlStream = new FileStream(filePath, FileMode.Open))
                {
                    using (XmlReader xmlReader = XmlReader.Create(xmlStream))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(compendium));
                        compendium deserializedCompendium = serializer.Deserialize(xmlReader) as compendium;

                        foreach (var i in deserializedCompendium.race)
                        {
                            // dl.Races.Add(ConvertRace(i));
                        }
                        foreach (var i in deserializedCompendium.item)
                        {
                            //     dl.Items.Add(ConvertItem(i));
                        }

                        foreach (var s in deserializedCompendium.spell)
                        {
                            dl.Spells.Add(ConvertSpell(s));
                        }

                        foreach (var c in deserializedCompendium.@class)
                        {
                            //     dl.Classes.Add(ConvertClass(c));
                        }

                    }
                }
            }

            return dl;
        }


        /*
        public Race ConvertRace(object data)
        {
            compendiumRace irace = (compendiumRace)data;
            var r = new Race()
            {
                Name = irace.name,
                Ability = irace.ability,
                Proficiency = irace.proficiency,
                //Modifier = irace.modifier,
                Size = irace.size,
                Speed = irace.speed,
                SpellAbility = irace.spellAbility,
                ImportDate = DateTime.UtcNow,
                ImportSource = "Lion's Den XML",
            };
            if (irace.modifier != null)
            {
                r.Modifier = new RaceModifier()
                {
                    Category = irace.modifier.category,
                    Value = irace.modifier.Value,
                };
            }
            r.Traits = new List<RaceTrait>();
            foreach (var t in irace.trait)
            {
                var rt = new RaceTrait
                {
                    Name = t.name,
                    Special = t.special,                    
                };
                rt.Text = "";
                foreach (var s in t.text)
                {
                    if (s.Trim().StartsWith("Source:"))
                    {
                        r.Source = s.Replace("Source:", "").Trim();
                        r.SourceAbr = DConvert.SourceAbbreviation(r.Source);
                    }
                    else
                    {
                        rt.Text += s;
                    }
                }
                r.Traits.Add(rt);
            }
            return r;
        }
        */
        /*
        public EquipmentItem ConvertItem(object data)
        {
            compendiumItem iItem = (compendiumItem)data;
            var item = new EquipmentItem();
            item.ImportDate = DateTime.UtcNow;
            item.ImportSource = "Lion's Den XML";

            for (int i = 0; i < iItem.ItemsElementName.Length; i++)
            {
                switch (iItem.ItemsElementName[i])
                {
                    case ItemsChoiceType.ac:
                        item.AC = (int)iItem.Items[i];
                        break;
                    case ItemsChoiceType.detail:
                        item.Detail = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.dmg1:
                        item.Dmg1 = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.dmg2:
                        item.Dmg2 = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.dmgType:
                        item.DmgType = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.magic:
                        item.Magic = ((int)iItem.Items[i] > 0 ? true : false);
                        break;
                    case ItemsChoiceType.modifier:
                        item.Modifier.Category = ((compendiumItemModifier)iItem.Items[i]).category;
                        item.Modifier.Value = ((compendiumItemModifier)iItem.Items[i]).Value;
                        break;
                    case ItemsChoiceType.name:
                        item.Name = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.property:
                        item.Property = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.range:
                        item.Range = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.roll:
                        item.Roll = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.stealth:
                        item.Stealth = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.strength:
                        item.Strength = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.text:
                        if (((string)iItem.Items[i]).StartsWith("Source:"))
                        {
                            item.Source = ((string)iItem.Items[i]).Replace("Source:", "").Trim();
                            item.SourceAbr = DConvert.SourceAbbreviation(item.Source);
                        }
                        else
                        {
                            item.Text += (string)iItem.Items[i];
                        }
                        break;
                    case ItemsChoiceType.type:
                        item.Type = (string)iItem.Items[i];
                        break;
                    case ItemsChoiceType.value:
                        item.Value = (decimal)iItem.Items[i];
                        break;
                    case ItemsChoiceType.weight:
                        item.Weight = (string)iItem.Items[i];
                        break;
                }
            }

            return item;
        }
        */
        public Spell ConvertSpell(object data)
        {
            compendiumSpell iSpell = (compendiumSpell)data;
            var spell = new Spell()
            {
                Classes = iSpell.classes,
                Components = iSpell.components,
                Duration = iSpell.duration,
                Level = iSpell.level,
                Name = iSpell.name,
                Range = iSpell.range,
                //Ritual
                School = iSpell.school,
                Time = iSpell.time,
                //Source
                Roll = "",
                Text = "",
                ImportDate = DateTime.UtcNow,
                ImportSource = "Lion's Den XML",
            };

            spell.Ritual = (iSpell.ritual.ToLower().Trim() == "no" ? false : true);
            if (iSpell.roll != null)
            {
                foreach (var r in iSpell.roll)
                {
                    if (!String.IsNullOrWhiteSpace(r.Trim()))
                    {
                        spell.Roll += r.Trim();
                    }
                }
            }
            if (iSpell.text != null)
            {
                foreach (var t in iSpell.text)
                {
                    if (t.StartsWith("Source:"))
                    {
                        spell.SourceBook = t.Replace("Source:", "").Trim();
                        spell.SourceBookAbr = DConvert.SourceAbbreviation(spell.Source);
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(t.Trim()))
                        {
                            spell.Text += Environment.NewLine;
                            spell.Text += Environment.NewLine;
                        }
                        else
                        {
                            spell.Text = (spell.Text.Trim() + " " + t.Trim()).Trim();
                        }
                    }
                }
            }
            if (spell.School == null)
            {
                spell.School = "";
            }
            return spell;
        }
        /*
        public Class ConvertClass(object data)
        {
            var iClass = (compendiumClass)data;
            var c = new Class();
            c.ImportDate = DateTime.UtcNow;
            c.ImportSource = "Lion's Den XML";
           
            for (int i = 0; i < iClass.ItemsElementName.Length; i++)
            {
                switch (iClass.ItemsElementName[i])
                {
                    case ItemsChoiceType1.armor:
                        c.Armor = (string)iClass.Items[i];
                        break;
                    case ItemsChoiceType1.autolevel:

                        compendiumClassAutolevel cca = (compendiumClassAutolevel)iClass.Items[i];
                        
                        var a = new ClassAutoLevel()
                        {
                            Level = cca.level,
                           // ScoreImprovement = cca.scoreImprovement,
                        };
                        if (cca.scoreImprovement != null && cca.scoreImprovement == "YES")
                        {
                            a.ScoreImprovement = true;
                        }


                        if (cca.slots != null)
                        {
                            a.Slots = new ClassAutolevelSlots()
                            {
                                Value = cca.slots.Value,
                                Optional = false,
                            };
                            if (cca.slots.Value != null && cca.slots.Value == "YES") a.Slots.Optional = true;
                        }

                        if (cca.feature != null)
                        {
                            //Add the auto level feature
                            a.Feature = new ClassAutolevelFeature()
                            {
                                Name = cca.feature.name,
                               Optional = false,
                                Proficiency = cca.feature.proficiency,
                                Special = cca.feature.special,
                                Text = "",
                                Modifiers = new List<ClassAutolevelFeatureModifier>(),
                                Source = "",
                            };
                            if (a.Feature.Proficiency == null) a.Feature.Proficiency = "";
                            if (a.Feature.Special == null) a.Feature.Special = "";
                            if (cca.feature.optional != null && cca.feature.optional == "YES")
                            {
                                a.Feature.Optional = true;
                            }
                            //Add the feature text
                            if (cca.feature.text != null)
                            {
                                foreach (var t in cca.feature.text)
                                {
                                    var t2 = t.Trim();
                                    if (t2.StartsWith("Source:"))
                                    {
                                        a.Feature.Source = t.Replace("Source:", "").Trim();
                                        a.Feature.SourceAbr = DConvert.SourceAbbreviation(a.Feature.Source);
                                    }
                                    else
                                    {
                                        if (String.IsNullOrWhiteSpace(t2))
                                        {
                                            a.Feature.Text += Environment.NewLine;
                                            a.Feature.Text += Environment.NewLine;
                                        }
                                        else
                                        {
                                            a.Feature.Text += t2;
                                        }
                                    }
                                }
                            }
                            //add the modifiers
                            if (cca.feature.modifier != null)
                            {
                                foreach (var cm in cca.feature.modifier)
                                {
                                    a.Feature.Modifiers.Add(new ClassAutolevelFeatureModifier()
                                    {
                                        Category = cm.category,
                                        Value = cm.Value,
                                    });
                                }
                            }                           
                        }
                        c.Autolevels.Add(a);
                        break;
                    case ItemsChoiceType1.hd:
                        c.HD = (int)iClass.Items[i];
                        break;
                    case ItemsChoiceType1.name:
                        c.Name = (string)iClass.Items[i];
                        break;
                    case ItemsChoiceType1.numSkills:
                        c.NumSkills = (string)iClass.Items[i];
                        break;
                    case ItemsChoiceType1.proficiency:
                        c.Proficiency = (string)iClass.Items[i];
                        break;
                    case ItemsChoiceType1.spellAbility:
                        c.SpellAbility = (string)iClass.Items[i];
                        break;
                    case ItemsChoiceType1.tools:
                        c.Tools = (string)iClass.Items[i];
                        break;
                    case ItemsChoiceType1.wealth:
                        c.Wealth = (string)iClass.Items[i];
                        break;
                    case ItemsChoiceType1.weapons:
                        c.Weapons = (string)iClass.Items[i];
                        break;
                }
            }

            c.Source = c.Autolevels.OrderBy(x => x.Level).First().Feature.Source;
            c.SourceAbr = DConvert.SourceAbbreviation(c.Source);

            return c;
        }
        */

    }
}
