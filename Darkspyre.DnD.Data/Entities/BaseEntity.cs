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


        
    }

    public interface ISource
    {        
        public string SourceBook { get; set; }
        public string SourceBookAbr { get; set; }
        public DateTime ImportDate { get; set; }
        public string ImportSource { get; set; }
    }
}
