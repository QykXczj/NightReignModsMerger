using NightReignModsMerger.Core.Services;
using NightReignModsMerger.Core.Utils;

namespace NightReignModsMerger.Console;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // 初始化日志
            Logger.Initialize("Information", "logs/merger.log");
            Logger.Info("NightReign Mods Merger 启动");

            System.Console.WriteLine("🎮 NightReign Mods Merger v0.1.0");
            System.Console.WriteLine("================================");
            System.Console.WriteLine();

            // 加载配置
            var configManager = new ConfigManager();
            var config = configManager.LoadConfig();

            // 验证配置
            if (string.IsNullOrEmpty(config.GamePath))
            {
                System.Console.WriteLine("⚠️  请在 config/config.json 中设置游戏路径 (GamePath)");
                System.Console.WriteLine();
                System.Console.WriteLine("示例配置:");
                System.Console.WriteLine("{");
                System.Console.WriteLine("  \"GamePath\": \"C:\\\\Games\\\\ELDEN RING NIGHTREIGN\\\\Game\"");
                System.Console.WriteLine("}");
                System.Console.WriteLine();
            }
            else
            {
                System.Console.WriteLine($"🎯 游戏路径: {config.GamePath}");
                System.Console.WriteLine($"📁 模组目录: {config.ModsToMergeFolderPath}");
                System.Console.WriteLine($"📦 输出目录: {config.MergedModsFolderPath}");
                System.Console.WriteLine();
            }

            System.Console.WriteLine("📋 功能特性:");
            System.Console.WriteLine("- 🔄 智能regulation.bin文件合并");
            System.Console.WriteLine("- ⚡ 冲突检测和解决");
            System.Console.WriteLine("- 💾 自动备份功能");
            System.Console.WriteLine("- 📝 详细的日志记录");
            System.Console.WriteLine("- 🖥️ 图形用户界面");
            System.Console.WriteLine();

            System.Console.WriteLine("⚠️  当前状态: 项目框架 v0.1.0");
            System.Console.WriteLine("完整的regulation.bin合并功能需要集成SoulsFormats库");
            System.Console.WriteLine();

            System.Console.WriteLine("🚀 下一步开发计划:");
            System.Console.WriteLine("1. 集成SoulsFormats库");
            System.Console.WriteLine("2. 实现regulation.bin解析");
            System.Console.WriteLine("3. 添加PARAM文件合并逻辑");
            System.Console.WriteLine("4. 实现冲突检测和解决");
            System.Console.WriteLine("5. 完善GUI界面功能");
            System.Console.WriteLine();

            // 检查命令行参数
            if (args.Contains("--gui"))
            {
                System.Console.WriteLine("🖥️  启动GUI模式...");
                System.Console.WriteLine("请运行: dotnet run --project src/NightReignModsMerger.GUI");
            }
            else if (args.Contains("--merge"))
            {
                System.Console.WriteLine("🔄 开始自动合并模式...");
                // TODO: 实现自动合并逻辑
                System.Console.WriteLine("⚠️  自动合并功能尚未实现");
            }
            else
            {
                System.Console.WriteLine("✅ 项目框架创建完成！");
                System.Console.WriteLine();
                System.Console.WriteLine("💡 使用提示:");
                System.Console.WriteLine("  --gui     启动图形界面");
                System.Console.WriteLine("  --merge   自动合并模式");
                System.Console.WriteLine("  --help    显示帮助信息");
            }

            if (args.Length == 0 || !args.Contains("--no-pause"))
            {
                System.Console.WriteLine();
                System.Console.WriteLine("按任意键退出...");
                System.Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"程序发生错误: {ex.Message}");
            Logger.Error(ex, "程序异常退出");
        }
    }
}