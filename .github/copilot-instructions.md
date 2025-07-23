# Copilot Instructions for Igor Raid Mechanics Mod

## Mod Overview and Purpose

The **Igor Raid Mechanics** mod aims to enhance the raid experience in RimWorld by introducing unique mechanics and challenges. This mod is designed to make raids more dynamic and engaging, providing players with additional strategic elements to consider during gameplay.

## Key Features and Systems

- **Advanced Raid Logic**: Utilizes new algorithms to alter raid behavior, making them more unpredictable and challenging.
- **Customizable Mod Settings**: Through the settings menu, players can tweak the raid parameters to suit their playstyle.
- **Harmony Patching**: Seamless integration with existing game mechanics using Harmony library to ensure compatibility with other mods.
- **XML-Driven Definitions**: Easy customization of raid definitions and parameters using XML files, allowing for modification without altering the base code.

## Coding Patterns and Conventions

- **Singleton Pattern**: Utilized for managing settings within `IgorRaidMechanicsMod.cs` to ensure a single point of access to mod configurations.
- **Static Classes**: Used for utility methods in `DefsAlterer.cs` and `SettingsHelper.cs` to provide general functionality that does not require instantiation.
- **Consistent Naming Conventions**: Uses PascalCase for class names and methods, ensuring code readability and consistency.
- **Encapsulation**: Public methods are used for interaction with external classes, while internal details are kept private or internal wherever possible.

## XML Integration

- **XML Files**: Used primarily for defining raid parameters and behaviors. This allows modders to easily adjust how raids operate without modifying C# code.
- **Loading XML**: The game loads and parses XML definitions at runtime, integrating them seamlessly with the mod’s C# logic.

## Harmony Patching

- **Harmony Library**: Implemented to patch original game methods, allowing for the interception and modification of raid mechanics without directly altering game code.
- **Method Patching**: Focus on prefix and postfix methods to inject custom logic before and after the base game method executions.

## Suggestions for Copilot

- **Auto-Completion**: Suggest relevant Harmony decoration attributes (e.g., `[HarmonyPatch]`) when modifying game methods.
- **Helper Methods**: Recommend creation of helper functions in `SettingsHelper.cs` to handle common settings logic.
- **XML Schema**: Provide suggestions for defining XML structure for raid settings, including examples and common uses.
- **Parameter Suggestions**: Propose likely parameters and settings that could be tweaked within `IgorRaidMechanicsSettings.cs`.
- **Error Handling**: Encourage the use of try-catch blocks when loading XML or applying Harmony patches to prevent runtime errors.

This guide provides a comprehensive framework for using GitHub Copilot effectively within the Igor Raid Mechanics mod development context, helping streamline coding tasks and enhance creativity.
