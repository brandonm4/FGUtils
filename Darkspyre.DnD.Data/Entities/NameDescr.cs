using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class NameValue : BaseEntity, IName
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
