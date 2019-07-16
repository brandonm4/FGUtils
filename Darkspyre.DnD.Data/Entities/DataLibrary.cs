using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class DataLibrary
    {
        //public List<EquipmentItem> Items { get; set; } = new List<EquipmentItem>();
        //  public List<Class> Classes { get; set; } = new List<Class>();
        //   public List<Race> Races { get; set; } = new List<Race>();

        public List<Background> Backgrounds { get; set; } = new List<Background>();
        public List<CharClass> CharacterClasses { get; set; } = new List<CharClass>();
        public List<CharSheet> CharacterSheets { get; set; } = new List<CharSheet>();
        public List<NonPlayerCharacter> NonPlayerCharacters { get; set; } = new List<NonPlayerCharacter>();
        public List<Spell> Spells { get; set; } = new List<Spell>();
        

    }
}
