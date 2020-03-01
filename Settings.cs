using Verse;

namespace Deep_Ore_Identifier
{
	public class Settings : ModSettings
	{
		public static bool TextBackground = true;

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look(ref TextBackground, "DOI_TextBackground", true);
		}
	}
}
