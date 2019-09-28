using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Sunstones.Items
{
	public class SunstoneMelee : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Rightclick to apply its modifier to your held weapon.");
		}

		public override void SetDefaults()
		{
			item.height = 32;
			item.width = 32;
			
			item.damage = 5;
			item.knockBack = 5;
			
			item.rare = 2;
			item.maxStack = 1;
			item.SetNameOverride("Sunstone (Melee)");
		}

		public override int ChoosePrefix(UnifiedRandom rand)
		{
			int roll = rand.Next(41);
			byte pfix;
			
			if (roll <= 15)
			{
				pfix = (byte)rand.Next(1, 16);
			}
			else if (roll <= 31)
			{
				pfix = (byte)rand.Next(36, 52);
			}
			else if (roll <= 36)
			{
				pfix = (byte)rand.Next(53, 58);
			}
			else if (roll <= 39)
			{
				pfix = (byte)rand.Next(59, 62);
			}
			else
			{
				pfix = (byte)81;
				item.rare = 10;
			}
			
			return pfix;
		}
		
		public override bool OnPickup(Player player)
		{
			if (item.prefix == 81)
			{
				item.rare = 10;
			}
			
			return true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			Item item = player.HeldItem;
			
			if (item != null && item.damage > 0)
			{
				item.prefix = this.item.prefix;
			}
			else
            {
				Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, this.item.type, 1, false, this.item.prefix, false, false);
            }
		}
	}
}