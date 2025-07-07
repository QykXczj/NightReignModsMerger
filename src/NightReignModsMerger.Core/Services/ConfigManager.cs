using Newtonsoft.Json;
using NightReignModsMerger.Core.Models;
using NightReignModsMerger.Core.Utils;

namespace NightReignModsMerger.Core.Services;

public class ConfigManager
{
    private const string DefaultConfigPath = "config/config.json";
    private AppConfig? _config;

    public AppConfig LoadConfig(string? configPath = null)
    {
        configPath ??= DefaultConfigPath;

        try
        {
            if (File.Exists(configPath))
            {
                var json = File.ReadAllText(configPath);
                _config = JsonConvert.DeserializeObject<AppConfig>(json) ?? new AppConfig();
                Logger.Info($"配置文件已加载: {configPath}");
            }
            else
            {
                _config = new AppConfig();
                SaveConfig(_config, configPath);
                Logger.Info($"创建默认配置文件: {configPath}");
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex, $"加载配置文件失败: {configPath}");
            _config = new AppConfig();
        }

        return _config;
    }

    public void SaveConfig(AppConfig config, string? configPath = null)
    {
        configPath ??= DefaultConfigPath;

        try
        {
            var directory = Path.GetDirectoryName(configPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(configPath, json);
            Logger.Info($"配置文件已保存: {configPath}");
        }
        catch (Exception ex)
        {
            Logger.Error(ex, $"保存配置文件失败: {configPath}");
        }
    }

    public AppConfig GetConfig() => _config ?? new AppConfig();

    public bool ValidateConfig(AppConfig config)
    {
        var isValid = true;
        var errors = new List<string>();

        if (string.IsNullOrEmpty(config.GamePath))
        {
            errors.Add("游戏路径不能为空");
            isValid = false;
        }
        else if (!Directory.Exists(config.GamePath))
        {
            errors.Add($"游戏路径不存在: {config.GamePath}");
            isValid = false;
        }

        if (string.IsNullOrEmpty(config.ModsToMergeFolderPath))
        {
            errors.Add("模组输入目录不能为空");
            isValid = false;
        }

        if (string.IsNullOrEmpty(config.MergedModsFolderPath))
        {
            errors.Add("合并输出目录不能为空");
            isValid = false;
        }

        if (!isValid)
        {
            foreach (var error in errors)
            {
                Logger.Error($"配置验证失败: {error}");
            }
        }

        return isValid;
    }

    public void ResetToDefaults()
    {
        _config = new AppConfig();
        SaveConfig(_config);
        Logger.Info("配置已重置为默认值");
    }
}