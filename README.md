# NightReign Mods Merger

一个用于合并《ELDEN RING NIGHTREIGN》模组的工具，专门处理regulation.bin文件的智能合并。

## 🎯 项目概述

本项目基于对现有模组合并工具的深入分析，特别是：
- **ERModsMerger**: 学习其regulation.bin合并算法和冲突解决机制
- **Smithbox**: 借鉴其文件处理方式和架构设计

针对《ELDEN RING NIGHTREIGN》进行了优化和定制。

## 🚀 快速开始

### 前置要求

- .NET 8.0 SDK
- Windows/Linux/macOS

### 1. 配置设置

编辑 `config/config.json` 文件，设置您的游戏路径：

```json
{
  "GamePath": "C:\\Games\\ELDEN RING NIGHTREIGN\\Game",
  "ModsToMergeFolderPath": "ModsToMerge",
  "MergedModsFolderPath": "MergedMods",
  "BackupEnabled": true,
  "LogLevel": "Information"
}
```

### 2. 准备模组

将您的模组放置在 `ModsToMerge` 目录中：

```
ModsToMerge/
├── WeaponMod/
│   └── regulation.bin
├── EnemyMod/
│   └── regulation.bin
└── BalanceMod/
    └── regulation.bin
```

### 3. 运行合并

```bash
# 构建项目
dotnet build

# 运行控制台版本
dotnet run --project src/NightReignModsMerger.Console

# 运行GUI版本
dotnet run --project src/NightReignModsMerger.GUI
```

## 📋 功能特性

### 当前实现 (v0.1.0)
- ✅ 项目架构和基础框架
- ✅ 配置管理系统
- ✅ 日志记录功能
- ✅ 控制台应用界面
- ✅ GUI应用界面 (WPF)

### 计划实现
- 🔄 智能regulation.bin文件合并
- ⚡ 冲突检测和解决
- 💾 自动备份功能
- 🎯 高级合并策略
- 🌐 多语言支持

## 🛠️ 技术架构

### 核心组件

```
src/
├── NightReignModsMerger.Core/          # 核心库
│   ├── Models/                         # 数据模型
│   ├── Services/                       # 业务服务
│   ├── Utils/                          # 工具类
│   └── Formats/                        # 文件格式处理
├── NightReignModsMerger.Console/       # 控制台应用
└── NightReignModsMerger.GUI/           # GUI应用 (WPF)
```

## 🔧 regulation.bin合并原理

基于对ERModsMerger的分析，regulation.bin合并的核心流程：

### 1. 文件结构理解
```
regulation.bin (BND4容器)
├── AtkParam_Npc.param          # NPC攻击参数
├── AtkParam_Pc.param           # 玩家攻击参数  
├── EquipParamWeapon.param      # 武器参数
├── CharaInitParam.param        # 角色初始参数
└── ... (其他PARAM文件)
```

### 2. 合并策略
1. **加载原版regulation.bin**作为基准
2. **逐个处理模组文件**按优先级顺序
3. **解析PARAM文件**提取数据表
4. **检测修改内容**对比原版找出差异
5. **智能合并数据**处理冲突和新增内容
6. **生成最终文件**保存合并结果

## ⚠️ 重要说明

**当前状态**: 这是一个项目框架和概念验证 (v0.1.0)。

### 要实现完整功能，还需要：

1. **集成SoulsFormats库**
2. **实现regulation.bin解析**
3. **添加合并逻辑**
4. **完善错误处理**

## 🔧 开发计划

### 短期目标 (v0.2)
- [ ] 集成SoulsFormats库
- [ ] 实现基础的regulation.bin读取
- [ ] 添加简单的文件合并功能

### 中期目标 (v0.5)
- [ ] 完整的PARAM合并逻辑
- [ ] 冲突检测和解决
- [ ] 完善GUI界面

### 长期目标 (v1.0)
- [ ] 高级合并策略
- [ ] 模组兼容性检查
- [ ] 自动化测试套件
- [ ] 多语言支持

## 🤝 贡献指南

欢迎提交Issue和Pull Request！

### 开发环境设置
```bash
# 克隆项目
git clone https://github.com/QykXczj/NightReignModsMerger.git
cd NightReignModsMerger

# 安装依赖
dotnet restore

# 构建项目
dotnet build

# 运行测试
dotnet test
```

## 📄 许可证

MIT License

## 🙏 致谢

- [SoulsMods社区](https://github.com/soulsmods) - 提供SoulsFormats库
- [ERModsMerger](https://github.com/MadTekN1/ERModsMerger) - 合并算法参考
- [Smithbox](https://github.com/vawser/Smithbox) - 架构设计参考
- 魂系游戏模组社区的所有贡献者

---

**注意**: 请在使用前备份您的游戏存档，并建议使用ModEngine2等工具来加载合并后的文件。