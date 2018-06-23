using Harmony;
using Verse;

namespace DeepOreIdentifier
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
