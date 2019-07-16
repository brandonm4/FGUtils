using Darkspyre.DnD.Data.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data
{
    public class DnDdbContext : DbContext
    {
        public DbSet<AbilityScore> AbilityScores { get; set; }
        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<CharClass> CharacterClasses { get; set; }
        public DbSet<CharSheet> CharacterSheets { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<NameValue> NameValues { get; set; }
        public DbSet<NonPlayerCharacter> NonPlayerCharacters { get; set; }
        public DbSet<Spell> Spells { get; set; }        
  
        public DnDdbContext(DbContextOptions<DnDdbContext> options) 
            : base(options)
        {
            
        }
    }
}
