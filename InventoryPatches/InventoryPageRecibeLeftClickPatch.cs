using HarmonyLib;
using StardewValley.Menus;
using StardewValley;
using StardewValley.Tools;

namespace PanSlotMod.InventoryPatches
{
    [HarmonyPatch(typeof(InventoryPage), nameof(InventoryPage.receiveLeftClick))]
    public class InventoryPageClickPatch
    {
        public static bool Prefix(InventoryPage __instance, int x, int y)
        {
            foreach (var c in __instance.equipmentIcons)
            {
                if (c.name == "PanSlot" && c.containsPoint(x, y))
                {
                    HandlePanSlotClick(__instance);
                    return false; 
                }
            }

            return true;
        }

        private static void HandlePanSlotClick(InventoryPage page)
        {
            Item heldItem = Game1.player.CursorSlotItem;

            if (heldItem is Pan heldPan)
            {
                Pan oldPan = PanSlotState.StoredPan;

                PanSlotState.StoredPan = heldItem as Pan;
                Game1.player.CursorSlotItem = oldPan;

                Game1.playSound("dwop");
            }
            else if (heldItem == null && PanSlotState.StoredPan != null)
            {
                Game1.player.CursorSlotItem = PanSlotState.StoredPan;
                PanSlotState.StoredPan = null;

                Game1.playSound("dwop");
            }
        }
    }
}