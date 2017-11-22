using Harmony;
using Verse;

namespace Deep_Ore_Identifier
{
	[HarmonyPatch(typeof(DeepResourceGrid))]
	[HarmonyPatch(nameof(DeepResourceGrid.MarkForDraw))]
	public class Patch_DeepResourceGrid
	{
		public static void Postfix()
		{
			Main.CheckForDraw = true;
		}
	}
}
