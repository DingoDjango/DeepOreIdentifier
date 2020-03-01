using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace Deep_Ore_Identifier
{
	public class Main : Mod
	{
		public Main(ModContentPack content) : base(content)
		{
			this.GetSettings<Settings>();

#if DEBUG
			HarmonyInstance.DEBUG = true;
#endif

			Harmony harmony = new Harmony("dingo.deeporeidentifier");

			harmony.PatchAll(Assembly.GetExecutingAssembly());
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);

			Listing_Standard modOptions = new Listing_Standard();
			modOptions.Begin(inRect.LeftHalf());
			modOptions.CheckboxLabeled("DeepOre.TextBackground".Translate(), ref Settings.TextBackground, "DeepOre.TextBackground.Tooltip".Translate());
			modOptions.End();
		}

		public override string SettingsCategory()
		{
			return "Deep Ore Identifier";
		}
	}
}
