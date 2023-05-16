using HarmonyLib;
using NeosModLoader;
using FrooxEngine;
using BaseX;
using System;

namespace DebugNeos
{
    public class DebugNeos : NeosMod
    {
        public override string Name => "DebugNeos";
        public override string Author => "plyshka";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/plyshka/DebugNeos";
        public override void OnEngineInit()
        {
            new Harmony("com.plyshka.DebugNeos").PatchAll();
            Msg("Patched neos debug variable");
        }

        [HarmonyPatch(typeof(UnityNeos.UnityAssetIntegrator), "get_IsDebugBuild")]
        public class UnityAssetIntegratorPatch
        {
            [HarmonyPrefix]
            public static bool IsDebugBuildPatch(ref bool __result)
            {
                __result = true;
                return false;
            }
        }
    }
}
