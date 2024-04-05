using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aki.Common.Http;
using EFT.InventoryLogic;
using Newtonsoft.Json;

namespace TraderModding
{
	// Token: 0x02000009 RID: 9
	public class TraderModdingUtils
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002228 File Offset: 0x00000428
		public static string[] GetTraderMods()
		{
			string json = RequestHandler.GetJson("/trader-modding/json");
			return JsonConvert.DeserializeObject<string[]>(json);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000224C File Offset: 0x0000044C
		public static string[] GetData()
		{
			string[] mods = null;
			Task task = Task.Run(delegate
			{
				mods = TraderModdingUtils.GetTraderMods();
			});
			task.Wait();
			return mods;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000228A File Offset: 0x0000048A
		public static void EndTraderModding()
		{
			Globals.isTraderModding = false;
			Globals.traderMods = null;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000229C File Offset: 0x0000049C
		public static void AddGunParts(Item weapon)
		{
			bool flag = weapon != null;
			if (flag)
			{
				IEnumerable<Item> allVisibleItems = weapon.GetAllVisibleItems();
				List<string> list = Globals.traderMods.ToList<string>();
				foreach (Item item in allVisibleItems)
				{
					list.Add(item.TemplateId);
				}
				Globals.traderMods = list.ToArray();
			}
		}
	}
}
