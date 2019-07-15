using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class Background: BaseEntity, IName
    {        
        public string Name { get; set; }
        public string Text { get; set; }
        public string Skill { get; set; }
        public string Languages { get; set; }
        public string Equipment { get; set; }
        public List<Feature> Features { get; set; } = new List<Feature>();
        public string SupportingTables { get; set; }        
    }
}
