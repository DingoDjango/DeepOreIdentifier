using HarmonyLib;
using Verse;

namespace Deep_Ore_Identifier
{
	public class HarmonyPatches
	{
		[HarmonyPatch(typeof(DeepResourceGrid))]
		[HarmonyPatch(nameof(DeepResourceGrid.MarkForDraw))]
		public class Patch_DeepResourceGrid
		{
			public static void Postfix()
			{
				OreTextDrawer.CheckForDraw = true;
			}
		}
	}
}
