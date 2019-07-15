using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{

    public enum AbilityType
    {
        Strength,
        Dexterity,
        Constitution,
        Wisdom,
        Intelligence,
        Charisma
    }
    public class AbilityScore : BaseEntity
    {
        public AbilityType AbilityType { get; set; }
        public int Bonus { get; set; } = 0;
        public int Save { get; set; } = 0;
        public int SaveModifer { get; set; } = 0;
        public int SaveProf { get; set; } = 0;
        public int Score { get; set; } = 10;
    }
}
