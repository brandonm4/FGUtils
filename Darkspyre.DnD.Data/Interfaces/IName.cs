using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darkspyre.DnD.Interface
{
    public interface IName
    {
        string Name { get; set; }

        
        //public string NameToId()
        //{            
        //        return Name.ToLower().Replace(" ", "_").Replace("(", "").Replace(")", "");            
        //}
    }
}
