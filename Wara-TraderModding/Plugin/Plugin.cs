using System;
using BepInEx;
using IcyClawz.CustomInteractions;
using TraderModding;

namespace Plugin
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("com.tradermodding.aki", "Trader Modding", "1.0.1")]
	public class Plugin : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			CustomInteractionsManager.Register(new CustomInteractionsProvider());
			new ModsHidePatch().Enable();
			new ScreenChangePatch().Enable();
		}
	}
}
