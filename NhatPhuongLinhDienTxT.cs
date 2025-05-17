using BepInEx;
using BepInEx.Unity.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using UnityEngine;
using System.Timers;

/// Tốn nửa buổi với GPT đẻ ra được cái plugin này để nghịch cho dễ
/// Code bởi ChatGPT
/// nuocda
/// @_@

[BepInPlugin("NhatPhuongLinhDien", "ImmortalLife TXT MOD", "1.0")]
public class ImmortalLifeTextOverride : BasePlugin
{
    private ManualLogSource logger;
    private static Harmony harmony;
    public override void Load()
    {
        logger = Log;
        var harmony = new Harmony("NhatPhuongLinhDien");
        harmony.PatchAll();

        string configDir = Path.Combine(Paths.PluginPath, "ImmortalLife");
        if (!Directory.Exists(configDir))
        {
            Directory.CreateDirectory(configDir);
            logger.LogInfo($"Tao thu muc moi: {configDir}");
        }

        logger.LogInfo("Nhat Phuong Linh Dien Txt Mod 1.0");
        // Hiển thị số file đã patch sau khi load xong
        var delayTimer = new Timer(10000); // 5000ms = 5s
        delayTimer.Elapsed += (sender, e) =>
        {
            logger.LogInfo($"Patch {Patch_TextAsset_get_text.successfulPatches} file.");
            delayTimer.Stop();
            delayTimer.Dispose();
        };
        delayTimer.AutoReset = false; // Chỉ chạy 1 lần
        delayTimer.Start();
    }
}

[HarmonyPatch(typeof(TextAsset), "get_text")]
class Patch_TextAsset_get_text
{
    public static int successfulPatches = 0; // Biến đếm số lần patch thành công
    static bool Prefix(TextAsset __instance, ref string __result)
    {
        if (__instance == null || string.IsNullOrEmpty(__instance.name))
            return true;

        string configDir = Path.Combine(Paths.PluginPath, "ImmortalLife");
        string overridePath = Path.Combine(configDir, __instance.name + ".txt");

        if (File.Exists(overridePath))
        {
            try
            {
                __result = File.ReadAllText(overridePath);
                successfulPatches++; // Tăng biến đếm khi patch thành công
                return false; // chặn hàm gốc, trả nội dung thay thế
            }
            catch
            {
                // đọc lỗi thì vẫn dùng text gốc
                return true;
            }
        }

        return true; // không tìm thấy file ghi đè, dùng nội dung gốc
    }
}
