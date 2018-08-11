using System.Reflection;
using Harmony;
using UnityEngine;
using Verse;

namespace DeepOreIdentifier
{
	public class Main : Mod
	{
		public Main(ModContentPack content) : base(content)
		{
			GetSettings<Settings>();

#if DEBUG
			HarmonyInstance.DEBUG = true;
#endif

			HarmonyInstance harmony = HarmonyInstance.Create("dingo.deeporeidentifier");
			harmony.PatchAll(Assembly.GetExecutingAssembly());

#if DEBUG
			Log.Message("Deep Ore Identifier :: Injected Harmony patches.");
#endif
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
