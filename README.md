# FGUtils
Fantasy Grounds Utilities

Instructions for End-Users

1. Download the latest release from the releases page - https://github.com/brandonm4/FGUtils/releases
2. Extract this file somewhere.  
3. In the extracted folder - run FGSpellListGen.exe
4. In the form that pops up, it has 4 inputs.
    Input - This is path to either a campaign db.xml, or a module client.xml
    Output - Enter the name the file you'd like to save to.  At the moment this creates /only/ the spelllists section of the module, so this should be a new file.  Do NOT overwrite your campaign or module xml file.
    Levels - Comma delimited list of spell levels to creats.  Leave blank for all.  example:  0,1,2,3 would generate lists for spell levels 0 through 3.
    Module Name - you should put in the ID of your module.  From the <name> entry in your modules definitions.xml file.
5. Once it completes, you can open the new file in a text editor and copy and paste the spelllists from the new file into the resource section of the module.


Notes for Developers

1. This is a DotNet Core 3.0 Preview6 code-base.  I don't think I did anything fancy so it can probably be compiled into any other variation of .net.
2. Darkspyre.DnD.FantasyGrounds - this contains the Import and Export functions.  It can currently read <spell> and <spelldata> sections from db and client.xml created by FantasyGrounds.  I've started on charsheets but this is in the early stages.  The Export currently only exports <spelllists>.
3. Darkspyre.DnD.Data - this has the data objects.  These are standard Entity-type classes.  Ignore the dbcontext parts.  
4. Darkspyre.DnD.Shell - this is a little console app to test/use the import/export.  It takes the following params:
     -input="PathToDBXml"   Path to the input db.xml or campaign.xml.  Put in quotes if there's a space.
     -output="PathToOutputXml"  Where it saves the generated spelllists.
     -levels="0,1,2,3" Comma delimited list of levels to include, leave blank for all
     -modulename="DSTestModule" you should put in the ID of your module.  From the <name> entry in your modules definitions.xml
5. Darkspyre.DnD.SpellTool.Win - WinForms version of #4
