using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace QualityofPvP.Keys
{
    public static partial class InTooltip
    {
        public static string KeytoString(this ModKeybind Key)
        {
            if (Main.dedServ || Key is null)
                return "";

            List<string> keys = Key.GetAssignedKeys();
            if (keys.Count == 0)
                return "[未绑定]";
            else
            {
                StringBuilder sb = new StringBuilder(16);
                sb.Append(keys[0]);

                // 下面的代码几乎在所有情况中都不会运行，因为一个东西的按键基本不会出现绑定很多个的情况，但是以防万一...
                for (int i = 1; i < keys.Count; ++i)
                    sb.Append(" / ").Append(keys[i]);
                return sb.ToString();
            }
        }
    }
}
