using Darkspyre.DnD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkspyre.DnD.FantasyGrounds
{
    public static partial class Export
    {

        public static string CreateSpellList(List<Spell> spells, List<string> sources, List<int> spellLevels = null, string moduleId = "*")
        {
            var spellsF = spells.ToList();

            if (spellLevels != null && spellLevels.Count > 0)
            {
                spellsF = spells.Where(x => spellLevels.Contains(x.Level)).ToList();
            }

            var sl = "<spelllists>" + Environment.NewLine;
            //Get Sources
            if (sources == null || sources.Count ==0)
            {
                sources = new List<string>();
                foreach (var s in spellsF)
                {
                    var src_arr = s.Source.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var src in src_arr)
                    {
                        var tempSrc = src.ToLower().Trim();
                        if (!sources.Contains(tempSrc))
                        {
                            sources.Add(tempSrc);
                        }
                    }
                }
            }

            //Create List Links
            sl += CreateSpellListLinks(sources, moduleId) + Environment.NewLine;

            //Create Index
            sl += CreateIndex(spellsF, moduleId) + Environment.NewLine;

            //Create Each List
            foreach (var s in sources)
            {
                sl += Export.CreateSpellListForClass(s, spellsF, moduleId) + Environment.NewLine;
            }

            sl += "</spelllists>";

            return sl;
        }

        //public static string APCStory(PlayerCharacter pc, string playerName = "", string recordid = "")
        //{
        //    var sb = new StringBuilder();

        //    if (String.IsNullOrWhiteSpace(recordid))
        //    {
        //        recordid = "apc-" + pc.Name.ToLower();
        //    }


        //    sb.Append("<");
        //    sb.Append(recordid);
        //    sb.AppendLine(">");

        //    if (!String.IsNullOrWhiteSpace(playerName))
        //    {
        //        sb.AppendLine("<holder name=\"" + playerName + "\"/>");
        //    }

        //    sb.AppendLine("<locked type=\"number\">1</locked>");
        //    sb.AppendLine("<name type=\"string\">APC: " + pc.Name + "</name>");
        //    sb.AppendLine("<text type=\"formattedtext\">");
        //    sb.AppendLine("	<p>This APC Generator rolls and converts tables into draggable actions and speech so you can pre-roll a set of reactions, hot key them, and drag the results into chat throughout the game.</p>");
        //    sb.AppendLine("<linklist >");
        //    sb.AppendLine(" link class=\"encounter\" recordname=\"encounter.id-00001@SquareWareFG Alpha by GTW 2019\">USING THE APC</link>");
        //    sb.AppendLine("</linklist>");
        //    sb.AppendLine("<p><b>Hold CTRL when posting an action into the chat to have it highlighted as an action not a comment.</b></p>");
        //    sb.AppendLine("<linklist>");
        //    sb.AppendLine(" link class=\"encounter\" recordname=\"encounter.id-00151@SquareWareFG Alpha by GTW 2019\">APC Changeability - The Sway Table</link>");
        //    sb.AppendLine("<link class=\"storytemplate\" recordname=\"storytemplate.id-00114@SquareWareFG Alpha by GTW 2019\">APC STATE : SWAY TABLE</link>");
        //    sb.AppendLine("<link class=\"table\" recordname=\"tables.id-00550@SquareWareFG Alpha by GTW 2019\">Conflict Table</link>");
        //    sb.AppendLine("</linklist>");



        //    sb.AppendLine("<h>Movement Pattern</h>");
        //    sb.AppendLine(frameText(pc.APC.MovementPattern));
        //    sb.AppendLine("<h>Combat - Active</h>");

        //    sb.AppendLine("<p><b>Active Combat Tactic Mechanic</b></p>");
        //    sb.AppendLine(frameText(pc.APC.TacticActiveCombat));
        //    sb.AppendLine("<h>Active Melee Tactic</h>");
        //    sb.AppendLine(frameText(pc.APC.TacticActiveMelee));
        //    sb.AppendLine("<h>Active Ranged Tactic</h>");
        //    sb.AppendLine(frameText(pc.APC.TacticActiveRanged));
        //    sb.AppendLine("<p><b>Active Assistance</b></p>");
        //    sb.AppendLine(frameText(pc.APC.TacticActiveAssist));
        //    sb.AppendLine("<h>Non-Combat - Passive</h>");

        //    sb.AppendLine("<p><b>Post-Combat Tactics</b></p>");
        //    sb.AppendLine(frameText(pc.APC.TacticPostCombat));
        //    sb.AppendLine("<p><b>Active Exploration Tactic Mechanic</b></p>");
        //    sb.AppendLine(frameText(pc.APC.TacticActiveExplorationMechanic));
        //    sb.AppendLine("<p><b>Complaints/Issues</b></p>");
        //    sb.AppendLine(frameText(pc.APC.Compaints));
        //    sb.AppendLine("<p><b>Idle Habits</b></p>");
        //    sb.AppendLine(frameText(pc.APC.IdleHabits));
        //    sb.AppendLine("<p><b>Mood</b></p>");
        //    sb.AppendLine(frameText(pc.APC.GeneralMood));
        //    sb.AppendLine("<p><b>Agreeability</b></p>");
        //    sb.AppendLine(frameText(pc.APC.GeneralAgreeability));
        //    sb.AppendLine("<h>Speech - Active</h>");

        //    sb.AppendLine("<p><b>Speech - Solution Suggestion</b></p>");
        //    sb.AppendLine(frameText(pc.APC.SpeechSolutionSuggestion));
        //    sb.AppendLine("<p><b>Speech - Exploring</b></p>");
        //    sb.AppendLine(frameText(pc.APC.SpeechExploring));
        //    sb.AppendLine("<p><b>Speech - Strategy</b></p>");
        //    sb.AppendLine(frameText(pc.APC.SpeechStrategy));
        //    sb.AppendLine("<p><b>Speech - In Combat</b></p>");
        //    sb.AppendLine(frameText(pc.APC.SpeechInCombat));
        //    sb.AppendLine("<p><b>Speech - Challenges to NPC</b></p>");
        //    sb.AppendLine(frameText(pc.APC.SpeechChallengeToNPC));
        //    sb.AppendLine("<p><b>Speech - Challenges to PC</b></p>");
        //    sb.AppendLine(frameText(pc.APC.SpeechChallengeToPC));
        //    sb.AppendLine("<p><b>Speech - Throw-Away</b></p>");
        //    sb.AppendLine(frameText(pc.APC.SpeechThrowAway));
        //    sb.AppendLine("<h>Speech - Passive</h>");
        //    sb.AppendLine("<p><b>At Rest - Camp</b></p>");
        //    sb.AppendLine(frameText(pc.APC.SpeechRestCamp));
        //    sb.AppendLine("<p><b>At Rest - Inside</b></p>");
        //    sb.AppendLine(frameText(pc.APC.SpeechRestInside));
        //    sb.AppendLine("<p><b>Vote Lean</b></p>");
        //    sb.AppendLine(frameText(pc.APC.VoteLeanings));
        //    sb.AppendLine("</text>");
        //    sb.Append("</");
        //    sb.Append(recordid);
        //    sb.AppendLine(">");
        //    return sb.ToString();
        //}

        private static string frameText(string text)
        {
            if (text.Contains("|"))
            {
                var tsplit = text.Split('|', StringSplitOptions.RemoveEmptyEntries);
                var s = "";
                foreach (var t in tsplit)
                {
                    if (!String.IsNullOrWhiteSpace(s))
                    {
                        s += Environment.NewLine;
                    }
                    s += "<frame>" + t.Trim() + "</frame>";
                }
                return s;
            }
            else
            {
                return "<frame>" + text.Trim() + "</frame>";
            }
        }


        static string FormatName(string name)
        {
            if (name == "_index_")
                return "(Index)";

            var words = name.ToLower().Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var f = "";
            foreach (var w in words)
            {
                f += w[0].ToString().ToUpper() + w.Substring(1) + " ";
            }

            return f.Trim();
        }

        static string NameToId(string name)
        {
            return name.ToLower().Replace(" ", "_").Replace("(", "").Replace(")", "");
        }

        public static string CreateSpellListForClass(string source, List<Spell> spells, string moduleId)
        {
            string list = "";
            list = "<" + NameToId(source) + ">" + Environment.NewLine;
            list += "<description type = \"string\">" + FormatName(source) + " Spells</description>" + Environment.NewLine;
            list += "<groups>" + Environment.NewLine;
            for (int i = 0; i < 13; i++)
            {
                list += CreateSpellListForClassLevel(source, spells, i, moduleId);
            }
            list += "</groups>" + Environment.NewLine;
            list += "</" + NameToId(source) + ">" + Environment.NewLine;
            return list;
        }

        public static string CreateSpellListEntry(Spell spell, string source, string moduleId)
        {
            string s = "";

            s += "<" + spell.FormId + ">" + Environment.NewLine;
            s += "<link type=\"windowreference\">" + Environment.NewLine;
            s += "<class>reference_spell</class>" + Environment.NewLine;
            s += "<recordname>reference.spelldata." + spell.FormId + "@" + moduleId + "</recordname>" + Environment.NewLine;
            s += "<description>" + Environment.NewLine;
            s += "<field>name</field>" + Environment.NewLine;
            s += "</description>" + Environment.NewLine;
            s += "</link>" + Environment.NewLine;
            s += "<source>Class " + FormatName(source) + "</source>" + Environment.NewLine;
            s += "</" + spell.FormId + ">" + Environment.NewLine;
            return s;
        }

        public static string CreateSpellListForClassLevel(string source, List<Spell> spells, int level, string moduleId)
        {
            string list = "";
            if (spells.Where(s => s.Level == level && s.Source.ToLower().Contains(source)).Count() > 0)
            {
                list += "<level" + level.ToString() + ">" + Environment.NewLine;
                var slevel = level.ToString();
                if (level == 0)
                    slevel = "(Cantrip)";

                list += "<description type=\"string\">Level " + slevel + " Spells</description>" + Environment.NewLine;
                list += "<index>" + Environment.NewLine;

                foreach (Spell s in spells.Where(s => s.Level == level && s.Source.ToLower().Contains(source)))
                {
                    list += CreateSpellListEntry(s, source, moduleId);
                }

                list += "</index>" + Environment.NewLine;
                list += "</level" + level.ToString() + ">" + Environment.NewLine;
            }

            return list;
        }

        public static string CreateIndexTypeLetter(List<Spell> spells, char letter, string moduleId)
        {
            if (spells.Where(s => s.Name.ToLower().StartsWith(letter.ToString().ToLower())).Count() == 0)
                return "";

            var list = "";
            list += "<typeletter" + letter.ToString().ToUpper() + ">" + Environment.NewLine;
            list += "<description type=\"string\">" + letter.ToString().ToUpper() + "</description>" + Environment.NewLine;
            list += "<index>" + Environment.NewLine;

            foreach (var s in spells.Where(s => s.Name.ToLower().StartsWith(letter.ToString().ToLower())))
            {
                list += "<" + s.FormId + ">" + Environment.NewLine;
                list += "<link type=\"windowreference\">" + Environment.NewLine;
                list += "<class>reference_spell</class>" + Environment.NewLine;
                list += "<recordname>reference.spelldata." + s.FormId + "@" + moduleId + "</recordname>" + Environment.NewLine;
                list += "<description>" + Environment.NewLine;
                list += " <field>name</field>" + Environment.NewLine;
                list += " </description>" + Environment.NewLine;
                list += "</link>" + Environment.NewLine;
                list += "<source type=\"string\" />" + Environment.NewLine;
                list += "</" + s.FormId + ">" + Environment.NewLine;
            }
            list += "</index>" + Environment.NewLine;
            list += "</typeletter" + letter.ToString().ToUpper() + ">" + Environment.NewLine;
            return list;
        }

        public static string CreateIndex(List<Spell> spells, string moduleId)
        {
            var alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var list = "";
            list += "<_index_>" + Environment.NewLine;
            list += "<description type=\"string\">Spell Index</description>" + Environment.NewLine;
            list += "<groups>" + Environment.NewLine;

            foreach (var c in alpha)
            {
                list += CreateIndexTypeLetter(spells, c, moduleId);
            }

            list += "</groups>" + Environment.NewLine;
            list += "</_index_>" + Environment.NewLine;
            return list;
        }

        public static string CreateSpellListLinks(List<string> sources, string moduleId)
        {
            var list = "";

            list += "<spells>" + Environment.NewLine;
            list += "<name type=\"string\">Spells</name>" + Environment.NewLine;
            list += "<index>" + Environment.NewLine;

            list += "<id-00001>" + Environment.NewLine;
            list += "<listlink type=\"windowreference\">" + Environment.NewLine;
            list += "<class>reference_colindex</class>" + Environment.NewLine;
            list += "<recordname>reference.spelllists._index_@" + moduleId + "</recordname>" + Environment.NewLine;
            list += "</listlink>" + Environment.NewLine;
            list += "<name type=\"string\">(Index)</name>" + Environment.NewLine;
            list += "</id-00001>" + Environment.NewLine;

            foreach (var s in sources)
            {
                list += CreateSpellLinkSourceLink(s, moduleId);
            }
            list += "</index>" + Environment.NewLine;
            list += "</spells>" + Environment.NewLine;
            return list;
        }
        public static string CreateSpellLinkSourceLink(string source, string moduleId)
        {
            var list = "";
            list += "<ll-" + NameToId(source) + ">" + Environment.NewLine;
            list += "<listlink type=\"windowreference\">" + Environment.NewLine;
            list += "<class>reference_colindex</class>" + Environment.NewLine;
            list += "<recordname>reference.spelllists." + NameToId(source) + "@" + moduleId + "</recordname>" + Environment.NewLine;
            list += "</listlink>" + Environment.NewLine;
            list += "<name type=\"string\">" + FormatName(source) + "</name>" + Environment.NewLine;
            list += "</ll-" + NameToId(source) + ">" + Environment.NewLine;

            return list;

        }
    }
}

/*
 * <spells>
    <name type="string">Spells</name>
    <index>
      <id-00001>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists._index_@DSSpellbook</recordname>
        </listlink>
        <name type="string">(Index)</name>
      </id-00001>
      <id-00002>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.arcanetrickster@DSSpellbook</recordname>
        </listlink>
        <name type="string">Arcane Trickster</name>
      </id-00002>
      <id-00003>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.bard@DSSpellbook</recordname>
        </listlink>
        <name type="string">Bard</name>
      </id-00003>
      <id-00004>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.cleric@DSSpellbook</recordname>
        </listlink>
        <name type="string">Cleric</name>
      </id-00004>
      <id-00005>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.clericknowledgedomain@DSSpellbook</recordname>
        </listlink>
        <name type="string">Cleric Knowledge Domain</name>
      </id-00005>
      <id-00006>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.clericlifedomain@DSSpellbook</recordname>
        </listlink>
        <name type="string">Cleric Life Domain</name>
      </id-00006>
      <id-00007>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.clericlightdomain@DSSpellbook</recordname>
        </listlink>
        <name type="string">Cleric Light Domain</name>
      </id-00007>
      <id-00008>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.clericnaturedomain@DSSpellbook</recordname>
        </listlink>
        <name type="string">Cleric Nature Domain</name>
      </id-00008>
      <id-00009>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.clerictempestdomain@DSSpellbook</recordname>
        </listlink>
        <name type="string">Cleric Tempest Domain</name>
      </id-00009>
      <id-00010>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.clerictrickerydomain@DSSpellbook</recordname>
        </listlink>
        <name type="string">Cleric Trickery Domain</name>
      </id-00010>
      <id-00011>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.clericwardomain@DSSpellbook</recordname>
        </listlink>
        <name type="string">Cleric War Domain</name>
      </id-00011>
      <id-00012>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.druid@DSSpellbook</recordname>
        </listlink>
        <name type="string">Druid</name>
      </id-00012>
      <id-00013>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.druidarcticcircle@DSSpellbook</recordname>
        </listlink>
        <name type="string">Druid Arctic Circle</name>
      </id-00013>
      <id-00014>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.druidcoastcircle@DSSpellbook</recordname>
        </listlink>
        <name type="string">Druid Coast Circle</name>
      </id-00014>
      <id-00015>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.druiddesertcircle@DSSpellbook</recordname>
        </listlink>
        <name type="string">Druid Desert Circle</name>
      </id-00015>
      <id-00016>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.druidforestcircle@DSSpellbook</recordname>
        </listlink>
        <name type="string">Druid Forest Circle</name>
      </id-00016>
      <id-00017>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.druidgrasslandcircle@DSSpellbook</recordname>
        </listlink>
        <name type="string">Druid Grassland Circle</name>
      </id-00017>
      <id-00018>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.druidmountaincircle@DSSpellbook</recordname>
        </listlink>
        <name type="string">Druid Mountain Circle</name>
      </id-00018>
      <id-00019>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.druidswampcircle@DSSpellbook</recordname>
        </listlink>
        <name type="string">Druid Swamp Circle</name>
      </id-00019>
      <id-00020>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.druidunderdarkcircle@DSSpellbook</recordname>
        </listlink>
        <name type="string">Druid Underdark Circle</name>
      </id-00020>
      <id-00021>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.eldritchinvocations@DSSpellbook</recordname>
        </listlink>
        <name type="string">Eldritch Invocations</name>
      </id-00021>
      <id-00022>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.eldritchknight@DSSpellbook</recordname>
        </listlink>
        <name type="string">Eldritch Knight</name>
      </id-00022>
      <id-00023>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.monk@DSSpellbook</recordname>
        </listlink>
        <name type="string">Monk</name>
      </id-00023>
      <id-00024>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.paladin@DSSpellbook</recordname>
        </listlink>
        <name type="string">Paladin</name>
      </id-00024>
      <id-00025>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.ranger@DSSpellbook</recordname>
        </listlink>
        <name type="string">Ranger</name>
      </id-00025>
      <id-00026>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.sorcerer@DSSpellbook</recordname>
        </listlink>
        <name type="string">Sorcerer</name>
      </id-00026>
      <id-00027>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.warlock@DSSpellbook</recordname>
        </listlink>
        <name type="string">Warlock</name>
      </id-00027>
      <id-00028>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.warlock_archfey_@DSSpellbook</recordname>
        </listlink>
        <name type="string">Warlock (Archfey)</name>
      </id-00028>
      <id-00029>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.warlock_fiend_@DSSpellbook</recordname>
        </listlink>
        <name type="string">Warlock (Fiend)</name>
      </id-00029>
      <id-00030>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.warlock_greatoldone_@DSSpellbook</recordname>
        </listlink>
        <name type="string">Warlock (Great Old One)</name>
      </id-00030>
      <id-00031>
        <listlink type="windowreference">
          <class>reference_colindex</class>
          <recordname>reference.spelllists.wizard@DSSpellbook</recordname>
        </listlink>
        <name type="string">Wizard</name>
      </id-00031>
    </index>
  </spells>
*/
