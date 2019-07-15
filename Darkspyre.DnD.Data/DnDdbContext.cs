using Darkspyre.DnD.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data
{
    public class DnDdbContext : IdentityDbContext
    {
      //  public DbSet<Race> Races { get; set; }
       // public DbSet<EquipmentItem> EquipmentItems { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<NonPlayerCharacter> NonPlayerCharacters { get; set; }
       // public DbSet<Class> Classes { get; set; }

       // public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
       // public DbSet<PlayerCharacterAPC> PlayerCharacterAPCs { get; set; }
        

        public DnDdbContext(DbContextOptions<DnDdbContext> options) 
            : base(options)
        {
            
        }
    }
}
