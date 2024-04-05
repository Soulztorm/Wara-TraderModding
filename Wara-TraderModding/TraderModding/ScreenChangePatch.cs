using System;
using System.Reflection;
using Aki.Reflection.Patching;
using EFT.UI;
using EFT.UI.Screens;

namespace TraderModding
{
	// Token: 0x02000008 RID: 8
	public class ScreenChangePatch : ModulePatch
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000021CC File Offset: 0x000003CC
		protected override MethodBase GetTargetMethod()
		{
			return typeof(MenuTaskBar).GetMethod("OnScreenChanged", BindingFlags.Instance | BindingFlags.Public);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021F4 File Offset: 0x000003F4
		[PatchPrefix]
		private static void Prefix(EEftScreenType eftScreenType)
		{
			bool flag = eftScreenType == EEftScreenType.Inventory || eftScreenType == EEftScreenType.MainMenu || eftScreenType == EEftScreenType.Hideout;
			if (flag)
			{
				TraderModdingUtils.EndTraderModding();
			}
		}
	}
}
