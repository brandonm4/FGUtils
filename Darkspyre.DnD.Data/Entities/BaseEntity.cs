using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();



        /* Both of these Name methods need to go into IName as a default implementation */

        [NotMapped]
        public string NamedId
        {
            get
            {
                var n = (IName)this;
                if (n != null)
                {
                    return n.Name.ToLower().Replace(" ", "_").Replace("(", "").Replace(")", "");
                }
                return Id;
            }
        }
        [NotMapped]
        public string FormatedName
        {
            get
            {
                var n = (IName)this;
                if (n != null)
                {
                    if (n.Name == "_index_")
                        return "(Index)";

                    var words = n.Name.ToLower().Trim().Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var f = "";
                    foreach (var w in words)
                    {
                        f += w[0].ToString().ToUpper() + w.Substring(1) + " ";
                    }

                    return f.Trim();
                }
                return Id;
            }
        }

    }

    public interface ISource
    {        
         string SourceBook { get; set; }
         string SourceBookAbr { get; set; }
         DateTime ImportDate { get; set; }
         string ImportSource { get; set; }
    }
}
