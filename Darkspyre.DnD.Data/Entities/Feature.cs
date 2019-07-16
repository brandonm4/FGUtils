using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class Feature : BaseEntity, IName
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Level { get; set; }

        

    }
}
