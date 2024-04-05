using System;
using System.Linq;
using System.Reflection;
using Aki.Reflection.Patching;
using EFT.InventoryLogic;
using EFT.UI.WeaponModding;
using HarmonyLib;
using UnityEngine;

namespace TraderModding
{
	// Token: 0x02000007 RID: 7
	public class ModsHidePatch : ModulePatch
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002120 File Offset: 0x00000320
		protected override MethodBase GetTargetMethod()
		{
			return AccessTools.GetDeclaredMethods(typeof(DropDownMenu)).Single(delegate(MethodInfo m)
			{
				ParameterInfo[] parameters = m.GetParameters();
				return parameters.Length == 4 && parameters[0].Name == "sourceContext" && parameters[3].Name == "container";
			});
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002168 File Offset: 0x00000368
		[PatchPrefix]
		private static bool Prefix(Item item, ref RectTransform container)
		{
			bool flag = Globals.isTraderModding && Globals.traderMods.Length != 0;
			if (flag)
			{
				bool flag2 = Globals.traderMods.All((string mod) => mod != item.TemplateId);
				if (flag2)
				{
					return false;
				}
			}
			return true;
		}
	}
}
