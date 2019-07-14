using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.Extensions
{
    public static class DConvert
    {
        public static string SourceAbbreviation(string input)
        {
            input = input.Trim().ToLower();
            if (input.StartsWith("player's handbook"))
            {
                return "PHB";
            }
            if (input.StartsWith("xanathar"))
            {
                return "XGE";
            }
            if (input.StartsWith("unearthed"))
            {
                return "UA";
            }
            if (input.StartsWith("volo"))
            {
                return "VGM";
            }
            if (input.StartsWith("elemental evil"))
            {
                return "EEPG";
            }
            if (input.StartsWith("sword coast"))
            {
                return "SCAG";
            }
            if (input.StartsWith("dungeon master")) return "DMG";
            if (input.StartsWith("mordenkainen's")) return "MTF";
            if (input.StartsWith("one grung above")) return "OGA";
            if (input.StartsWith("the tortle pack")) return "TTP";
            if (input.StartsWith("wayfinder's gui")) return "WGE";
            if (input.StartsWith("curse of strahd")) return "COFT";
            return "";
        }
    }
}
