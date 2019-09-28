using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Sunstones.Items
{
	public class SunstoneBlank : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Rightclick to awaken.");
		}
		
		public override void SetDefaults()
		{
			item.height = 32;
			item.width = 32;
			
			item.rare = 2;
			item.maxStack = 9999;
			item.SetNameOverride("Sunstone (Dormant)");
		}
		
		public override bool CanRightClick()
		{
			return true;
		}
		
		public override void RightClick(Player player)
		{
			int roll = Main.rand.Next(4);
			
			ModItem item = null;
			
			if (roll == 1)
			{
				item = mod.GetItem("SunstoneAccessory");
			}
			else if (roll == 2)
			{
				item = mod.GetItem("SunstoneMelee");
			}
			else if(roll == 3)
			{
				item = mod.GetItem("SunstoneRanged");
			}
			else
			{
				item = mod.GetItem("SunstoneArcane");
			}
			
			int prefix = item.ChoosePrefix(Main.rand);
			
			Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, item.item.type, 1, false, prefix, false, false);
		}
	}
}
