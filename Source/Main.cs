using HugsLib;
using HugsLib.Settings;
using UnityEngine;
using Verse;

namespace Deep_Ore_Identifier
{
	public class Main : ModBase
	{
		private readonly float LabelOffsetFromMouse = 2f;

		private readonly Color MessageBackgroundColour = new Color(0.15f, 0.15f, 0.15f, 0.8f);

		public static SettingHandle<bool> DrawMouseoverBackground;

		public static bool CheckForDraw;

		public override string ModIdentifier => "DeepOreIdentifier";

		private void DrawOreLabelOnMouseover()
		{
			IntVec3 mouseIntVec = UI.MouseCell();

			if (!mouseIntVec.InBounds(Find.VisibleMap))
			{
				return;
			}

			ThingDef ore = Find.VisibleMap.deepResourceGrid.ThingDefAt(mouseIntVec);

			if (ore != null)
			{
				string label = ore.label.CapitalizeFirst();
				Vector2 mousePosition = Event.current.mousePosition;
				Vector2 labelSize = Text.CalcSize(label);
				Rect labelRect = new Rect(mousePosition.x - this.LabelOffsetFromMouse - labelSize.x, mousePosition.y - this.LabelOffsetFromMouse - labelSize.y, labelSize.x, labelSize.y);

				if (DrawMouseoverBackground)
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

		public override void DefsLoaded()
		{
			base.DefsLoaded();

			DrawMouseoverBackground = this.Settings.GetHandle("DrawMouseoverBackground", "DeepOreIdentifier_DrawMouseoverBackground".Translate(), "DeepOreIdentifier_Tooltip_DrawMouseoverBackground".Translate(), true);
		}

		public override void OnGUI()
		{
			base.OnGUI();

			if (CheckForDraw && Event.current.type == EventType.Repaint)
			{
				this.DrawOreLabelOnMouseover();

				CheckForDraw = false;
			}
		}
	}
}
