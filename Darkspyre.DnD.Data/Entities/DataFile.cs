using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class DataFile : BaseEntity
    {
        public int SourceType { get; set; }
        public string DefinitionFile { get; set; }
        public string DatabaseFile { get; set; }

        public DataLibrary Library { get; set; } = new DataLibrary();
    }
}
