
using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class NonPlayerCharacter : BaseEntity
    {
        public List<AbilityScore> Abilities { get; set; } = new List<AbilityScore>();
        public int AC { get; set; }
        public string ACText { get; set; }
        public List<NameValue> Actions { get; set; } = new List<NameValue>();
        public string Alignment { get; set; }
        public string ConditionImmunities { get; set; }
        public string CR { get; set; }
        public string DamageImmunities { get; set; }
        public string DamageResistances { get; set; }
        public string DamageVulnerabilities { get; set; }
        public string HD { get; set; }
        public int HP { get; set; }
        public List<NameValue> InnateSpells { get; set; } = new List<NameValue>();
        public List<NameValue> LairActions { get; set; } = new List<NameValue>();
        public string Languages { get; set; }
        public List<NameValue> LegendaryActions { get; set; } = new List<NameValue>();
        public string Name { get; set; }
        public List<NameValue> Reactions { get; set; } = new List<NameValue>();
        public string SavingThrows { get; set; }
        public string Senses { get; set; }
        public string Size { get; set; }
        public string Skills { get; set; }
        public string Speed { get; set; }
        public List<NameValue> Spells { get; set; } = new List<NameValue>();
        public List<NameValue> SpellSlots { get; set; } = new List<NameValue>();
        public string Text { get; set; }
        public string Token { get; set; }
        public List<NameValue> Traits { get; set; } = new List<NameValue>();
        public string Type { get; set; }
        public int XP { get; set; }
        public int Locked { get; set; }
    }

}
