using Darkspyre.DnD.Data.Entities;
using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;

namespace Darkspyre.Ruleset
{
    public class DnD : IRuleSet
    {
        public List<AbilityScore> InitializeAbilityScores()
        {
            var lst = new List<AbilityScore>();
            foreach (AbilityType a in (AbilityType[])Enum.GetValues(typeof(AbilityType)))
            {
                lst.Add(new AbilityScore
                {
                    AbilityType = a,
                    Bonus = 0,
                    Save = 0,
                    SaveModifer = 0,
                    SaveProf = 0,
                    Score = 10,
                });
            }
            return lst;
        }
    }
}
