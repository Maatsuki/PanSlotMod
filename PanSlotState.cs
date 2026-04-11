using StardewValley;
using StardewValley.Tools;

namespace PanSlotMod
{
    public static class PanSlotState
    {
        private const string ModDataKey = "PanSlotMod.StoredPan";

        private static Pan _storedPan;
        public static Pan StoredPan
        {
            get => _storedPan;
            set => _storedPan = value;
        }

        public static void Save()
        {
            if (_storedPan != null)
            {
                Game1.player.modData[ModDataKey] = "true";
                Game1.player.addItemToInventory(_storedPan);
            }
            else
            {
                Game1.player.modData.Remove(ModDataKey);
            }
        }

        public static void Load()
        {
            _storedPan = null;

            if (!Game1.player.modData.ContainsKey(ModDataKey)) return;

            for (int i = 0; i < Game1.player.Items.Count; i++)
            {
                if (Game1.player.Items[i] is Pan pan)
                {
                    _storedPan = pan;
                    Game1.player.Items[i] = null;
                    break;
                }
            }
        }

        public static void AfterSave()
        {
            if (_storedPan == null) return;

            for (int i = 0; i < Game1.player.Items.Count; i++)
            {
                if (Game1.player.Items[i] is Pan)
                {
                    Game1.player.Items[i] = null;
                    break;
                }
            }
        }
    }
}