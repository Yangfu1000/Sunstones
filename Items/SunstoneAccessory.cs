using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Sunstones.Items
{
	public class SunstoneAccessory: ModItem
	{
		int[] best = {65, 66, 68, 72, 76, 80};
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Rightclick to apply its modifier to your held accessory.");
		}

		public override void SetDefaults()
        {
			item.height = 32;
			item.width = 32;
			
            item.value = 10000;
			item.rare = 2;
            item.maxStack = 1;
            item.SetNameOverride("Sunstone (Accessory)");
			
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
			int[] best = {65, 66, 68, 72, 76, 80};
			
			byte pfix = (byte)rand.Next(62, 80);
			
			foreach (int x in best)
			{
				if ((int)pfix == x)
				{
					item.rare = 10;
				}
			}
			
			return pfix;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            Item item = player.HeldItem;
            if (item != null && item.accessory)
            {
                item.prefix = this.item.prefix;
            }
            else
            {
                int number = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, this.item.type, 1, false, this.item.prefix, false, false);
				
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, null, number, 1f, 0f, 0f, 0, 0, 0);
                }
            }
        }
	}
}