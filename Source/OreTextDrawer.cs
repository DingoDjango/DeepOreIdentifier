using UnityEngine;
using Verse;

namespace DeepOreIdentifier
{
	public class OreTextDrawer : GameComponent
	{
		private readonly float LabelOffsetFromMouse = 2f;

		private readonly Color MessageBackgroundColour = new Color(0.15f, 0.15f, 0.15f, 0.8f);

		public static bool CheckForDraw;

		private void DrawOreLabelOnMouseover()
		{
			IntVec3 mouseIntVec = UI.MouseCell();

			if (!mouseIntVec.InBounds(Find.CurrentMap))
			{
				return;
			}

			ThingDef ore = Find.CurrentMap.deepResourceGrid.ThingDefAt(mouseIntVec);

			if (ore != null)
			{
				string label = ore.label.CapitalizeFirst();
				Vector2 mousePosition = Event.current.mousePosition;
				Vector2 labelSize = Text.CalcSize(label);
				Rect labelRect = new Rect(mousePosition.x - this.LabelOffsetFromMouse - labelSize.x, mousePosition.y - this.LabelOffsetFromMouse - labelSize.y, labelSize.x, labelSize.y);

				if (Settings.TextBackground)
				{
					Rect backgroundRect = labelRect.ExpandedBy(1f);

					//Verse.Messages.LiveMessage.Draw
					GUI.color = this.MessageBackgroundColour;
					GUI.DrawTexture(backgroundRect, BaseContent.WhiteTex);
					GUI.color = Color.white;
				}

				Widgets.Label(labelRect, label);
			}
		}

		public override void GameComponentOnGUI()
		{
			base.GameComponentOnGUI();

			if (CheckForDraw && Event.current.type == EventType.Repaint)
			{
				this.DrawOreLabelOnMouseover();

				CheckForDraw = false;
			}
		}

		public OreTextDrawer()
		{
		}

		public OreTextDrawer(Game game)
		{
		}
	}
}
