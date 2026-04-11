using HarmonyLib;
using StardewValley.Menus;

namespace PanSlotMod.InventoryPatches
{
    [HarmonyPatch(typeof(InventoryPage), nameof(InventoryPage.performHoverAction))]
    public class InventoryPageHoverPatch
    {
        public static void Postfix(InventoryPage __instance, int x, int y)
        {
            foreach (var c in __instance.equipmentIcons)
            {
                if (c.name == "PanSlot" && c.containsPoint(x, y))
                {
                    if (PanSlotState.StoredPan != null)
                    {
                        __instance.hoveredItem = PanSlotState.StoredPan;
                        __instance.hoverText = PanSlotState.StoredPan.getDescription();
                        __instance.hoverTitle = PanSlotState.StoredPan.DisplayName;
                    }
                }
            }
        }
    }
}