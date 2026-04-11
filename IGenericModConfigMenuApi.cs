using StardewModdingAPI;

namespace PanSlotMod
{
    public interface IGenericModConfigMenuApi
    {
        void Register(IManifest mod, System.Action reset, System.Action save, bool titleScreenOnly = false);

        void AddTextOption(
            IManifest mod,
            System.Func<string> getValue,
            System.Action<string> setValue,
            System.Func<string> name,
            System.Func<string> tooltip = null,
            string[] allowedValues = null,
            System.Func<string, string> formatAllowedValue = null,
            string fieldId = null
        );
    }
}