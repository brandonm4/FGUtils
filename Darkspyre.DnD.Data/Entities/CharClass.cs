using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class CharClass : BaseEntity, IName
    {
        public string Name { get; set; } = "";
        public string Text { get; set; } = "";
        public NameValue HitDice { get; set; } = new NameValue();
        public NameValue HitDice1stLevel { get; set; } = new NameValue();
        public NameValue HitDiceAdditional { get; set; } = new NameValue();
        public NameValue ProfArmor { get; set; } = new NameValue();
        public NameValue ProfWeapons { get; set; } = new NameValue();
        public NameValue ProfTools { get; set; } = new NameValue();
        public NameValue ProfSavingThrows { get; set; } = new NameValue();
        public NameValue ProfSkills { get; set; } = new NameValue();
        public List<NameValue> MulticlassProficiencies { get; set; } = new List<NameValue>();
        public List<Feature> Features { get; set; } = new List<Feature>();
        public List<NameValue> Equipment { get; set; } = new List<NameValue>();

    }
}
