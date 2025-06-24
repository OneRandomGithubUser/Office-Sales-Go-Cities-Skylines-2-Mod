using System.Reflection;
using Colossal.Logging;
using CitiesHarmony.API;
using HarmonyLib;

namespace OfficeSalesGo.Systems
{
    [HarmonyPatch]
    public static class DisableIndustrialAIModPatch
{
    public static ILog log = LogManager.GetLogger($"{nameof(OfficeSalesGo)}.{nameof(DisableIndustrialAIModPatch)}").SetShowsErrorsInUI(false);

    // This method is called by Harmony to apply the patches
    public static void Apply()
    {
        log.Info("DisableModifedIndustrialAIModPatch started.");
        var harmony = new Harmony("Cimplicity.OfficeSalesGo.DisableIndustrialAI"); // Use a unique ID for your Harmony instance
        harmony.PatchAll(Assembly.GetExecutingAssembly());
        log.Info("DisableModifedIndustrialAIModPatch applied.");
    }

        /*
    // Target the specific method that registers ModifiedIndustrialAISystem
    [HarmonyPatch(typeof(ProfitBasedIndustryAndOffice.ModSystem.Mod), "RegisterModifiedSystem")]
    [HarmonyPrefix]
    public static bool PrefixRegisterModifiedSystem()
    {
        log.Info("Attempting to disable ModifiedIndustrialAISystem registration.");
        // Return false to skip the original method's execution
        return false;
    }*/

    // Target the specific method that registers ModifiedIndustrialAISystem
    [HarmonyPatch(typeof(ProfitBasedIndustryAndOffice.ModSystem.ModifiedIndustrialAISystem), "OnUpdate")]
    [HarmonyPrefix]
    public static bool PrefixOnUpdate()
    {
        log.Info("Attempting to disable ModifiedIndustrialAISystem OnUpdate.");
        // Return to skip the original method's execution
        return false;
    }
}
}