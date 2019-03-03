using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sunstones.NPCs
{
	public class CustomGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		public override void NPCLoot(NPC npc)
		{
			if (npc.lifeMax > 100 && npc.value > 0f && Main.rand.Next(200) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SunstoneBlank"));
			}
		}
	}
}
