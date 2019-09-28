using System;
using System.IO;

using Terraria;
using Terraria.IO;

using Terraria.ModLoader;

namespace Sunstones
{
	public static class Config
	{
		static string filename = "Sunstones Config v1.json";
		public static int SunstoneDropRate;
		
		static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", filename);
		
		static Preferences Configuration = new Preferences(ConfigPath);
		
		public static void Load()
		{
			bool ReadConfigSuccess = ReadConfig();
			if(!ReadConfigSuccess)
			{
				ErrorLogger.Log("Failed to read Sunstones config file! Recreating config...");
				CreateConfig();
			}
		}
		
		static bool ReadConfig()
		{
			if(Configuration.Load())
			{
				Configuration.Get("SunstoneDropRate", ref SunstoneDropRate);
				return true;
			}
			else
			return false;
		}

		static void CreateConfig()
		{
			SunstoneDropRate = 100;
			Configuration.Clear();
			Configuration.Put("The Droprate is calculated with the odds of 1 in X where X is the specified value", 0);
			Configuration.Put("If you put 0 then the item will never drop", 0);
			Configuration.Put("SunstoneDropRate", SunstoneDropRate);
			Configuration.Save();
		}
		
	}
}