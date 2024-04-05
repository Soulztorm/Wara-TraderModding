using System;
using System.Collections.Generic;
using System.Linq;
using Aki.Reflection.Utils;
using EFT.InventoryLogic;
using EFT.UI;
using IcyClawz.CustomInteractions;

namespace TraderModding
{
	// Token: 0x02000004 RID: 4
	internal sealed class CustomInteractionsProvider : IItemCustomInteractionsProvider, ICustomInteractionsProvider
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020AC File Offset: 0x000002AC
		internal static StaticIcons StaticIcons
		{
			get
			{
				return EFTHardSettings.Instance.StaticIcons;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020B8 File Offset: 0x000002B8
		public IEnumerable<CustomInteraction> GetCustomInteractions(ItemUiContext uiContext, EItemViewType viewType, Item item)
		{
			object isInRaid = PatchConstants.EftTypes.Single((Type x) => x.GetField("IsNetworkGame") != null).GetField("InRaid").GetValue(null);
			bool flag = viewType != EItemViewType.Inventory || (bool)isInRaid;
			if (flag)
			{
				yield break;
			}

			if ((item as Weapon) != null)
			{
				CustomInteraction customInteraction = new CustomInteraction();
				customInteraction.Caption = () => "TRADER MODDING";
				customInteraction.Icon = () => CustomInteractionsProvider.StaticIcons.GetAttributeIcon(EItemAttributeId.RaidModdable);
				customInteraction.Enabled = () => true;
				customInteraction.Action = delegate
				{
					ComponentUtils.TraderModding(uiContext, item);
				};
				yield return customInteraction;
			}

			yield break;
		}
	}
}
