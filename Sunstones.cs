using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.IO;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;

using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Sunstones
{
	class Sunstones : Mod
	{
		public override void Load()
		{
			Config.Load();
		}
		
		public Sunstones()
		{
			
		}
	}
}
