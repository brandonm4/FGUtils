using Darkspyre.DnD.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Darkspyre.DnD.Data.Entities;
using Darkspyre.DnD.FantasyGrounds;
using Darkspyre.DnD.Interface;

namespace Darkspyre.Dnd.Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "C:\\\Development\\Brandon\\darkspyre.dnd\\Darkspyre.DnD.FantasyGrounds\\spellmodule.xml";
            string path = "";
            string outputFIle = "";
            List<int> limitLevels = new List<int> { };
            string moduleId = "*";

            foreach (var a in args)
            {
                var arg = a.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (arg.Length > 1)
                {
                    switch (arg[0].ToLower())
                    {
                        case "-input":
                            path = arg[1];
                            break;
                        case "-output":
                            outputFIle = arg[1];
                            break;
                        case "-levels":
                            var levels = arg[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                            limitLevels = new List<int>();
                            foreach (var l in levels)
                            {
                                int x = 0;
                                if (Int32.TryParse(l, out x))
                                {
                                    limitLevels.Add(x);
                                }
                            }
                            break;
                        case "-modulename":
                            moduleId = arg[1];
                            break;
                    }
                }
            }

            var bDoImport = true;

            if (!String.IsNullOrWhiteSpace(path) && !File.Exists(path))
            {
                Console.WriteLine("Input file not found.");
                bDoImport = false;
            }
            if (bDoImport && !String.IsNullOrWhiteSpace(outputFIle) && !Directory.Exists(Path.GetDirectoryName(outputFIle)))
            {
                bDoImport = false;
                Console.WriteLine("Output Directory not found");
            }

            if (bDoImport)
            {
                var importer = new Import();
                DataLibrary library = importer.ImportFile(path, "", (int)FGSourceType.Campaign).Result;

                if (library.Spells.Count > 0)
                {
                    using (StreamWriter sw = new StreamWriter(outputFIle, false))
                    {
                        sw.WriteLine(Export.CreateSpellList(library.Spells, new List<string>(), limitLevels, moduleId));
                    }
                }

            }
        }

    }
}


/*
<bard>
        <description type="string">Bard Spells</description>
        <groups>
          <level9>
            <description type="string">Level 9 Spells</description>
            <index>
              <powerwordheal>
                <link type="windowreference">
                  <class>reference_spell</class>
                  <recordname>reference.spelldata.powerwordheal@DSSpellbook</recordname>
                  <description>
                    <field>name</field>
                  </description>
                </link>
                <source>Class Bard</source>
              </powerwordheal>
              <foresight>
                <link type="windowreference">
                  <class>reference_spell</class>
                  <recordname>reference.spelldata.foresight@DSSpellbook</recordname>
                  <description>
                    <field>name</field>
                  </description>
                </link>
                <source>Class Bard</source>
              </foresight>
              <powerwordkill>
                <link type="windowreference">
                  <class>reference_spell</class>
                  <recordname>reference.spelldata.powerwordkill@DSSpellbook</recordname>
                  <description>
                    <field>name</field>
                  </description>
                </link>
                <source>Class Bard</source>
              </powerwordkill>
              <truepolymorph>
                <link type="windowreference">
                  <class>reference_spell</class>
                  <recordname>reference.spelldata.truepolymorph@DSSpellbook</recordname>
                  <description>
                    <field>name</field>
                  </description>
                </link>
                <source>Class Bard</source>
              </truepolymorph>
            </index>
          </level9>
 */
