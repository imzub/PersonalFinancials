using System;
using System.Configuration;
using System.IO;

public static class ConfigHelper
{
    // 🔹 Get Export Location
    public static string GetExportLocation()
    {
        return ConfigurationManager.AppSettings["ExportLocation"];
    }

    // 🔹 Get Import Location
    public static string GetImportLocation()
    {
        return ConfigurationManager.AppSettings["ImportLocation"];
    }

    // 🔹 Update Export Location
    public static void UpdateExportLocation(string newPath)
    {
        UpdateAppSetting("ExportLocation", newPath);
    }

    // 🔹 Update Import Location
    public static void UpdateImportLocation(string newPath)
    {
        UpdateAppSetting("ImportLocation", newPath);
    }

    // 🔹 Generic Method to Update `App.config` Values
    private static void UpdateAppSetting(string key, string value)
    {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        config.AppSettings.Settings[key].Value = value;
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
    }
}
