using System;
using System.Reflection;
using EFT;

namespace TraderModding
{
	// Token: 0x02000003 RID: 3
	internal static class PlayerExtensions
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000207D File Offset: 0x0000027D
		public static InventoryControllerClass GetInventoryController(this Player player)
		{
			return PlayerExtensions.InventoryControllerField.GetValue(player) as InventoryControllerClass;
		}

		// Token: 0x04000001 RID: 1
		private static readonly FieldInfo InventoryControllerField = typeof(Player).GetField("_inventoryController", BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
