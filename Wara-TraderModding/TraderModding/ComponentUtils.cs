using System;
using EFT.InventoryLogic;
using EFT.UI;

namespace TraderModding
{
	// Token: 0x02000005 RID: 5
	internal static class ComponentUtils
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000020E6 File Offset: 0x000002E6
		public static void TraderModding(ItemUiContext uiContext, Item weapon)
		{
			Globals.isTraderModding = true;
			Globals.traderMods = TraderModdingUtils.GetData();
			TraderModdingUtils.AddGunParts(weapon);
			uiContext.EditWeaponBuild((Weapon)weapon);
		}
	}
}
