using Darkspyre.DnD.Data.Entities.Darkspyre.DnD.Data.CharSheetData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class CharSheet
    {
        public string Holder { get; set; }
        public List<AbilityScore> Abilities { get; set; } = new List<AbilityScore>();
        public string Alignment { get; set; }
        public string Background { get; set; }
        public RecordLink BackgroundLink { get; set; }
        public string Bonds { get; set; }
        public List<ClassEntry> Classes { get; set; } = new List<ClassEntry>();
    }
    public class RecordLink
    {
        public string RecordClass { get; set; } = "reference_background";
        public string RecordName { get; set; }
    }

    namespace Darkspyre.DnD.Data.CharSheetData
    {
        public class AbilityScore
        {
            public string Name { get; set; } = "";
            public int Bonus { get; set; } = 0;
            public int Save { get; set; } = 0;
            public int SaveModifer { get; set; } = 0;
            public int SaveProf { get; set; } = 0;
            public int Score { get; set; } = 10;
        }
       
        public class ClassEntry
        {
            public string ClassEntryId { get; set; }
            public string CasterLevelInvMult { get; set; }
            public string HDDie { get; set; }
            public int HDUsed { get; set; }
            public int Level { get; set; }
            public string Name { get; set; }
            public RecordLink Shortcut { get; set; }
        }
    }
       
}
