# GitHub Copilot Instructions for [KYD] Igor Raid Mechanics for All Storytellers (Continued)

## Mod Overview and Purpose
Welcome to the [KYD] Igor Raid Mechanics for All Storytellers (Continued) mod! This mod brings the thrilling raid mechanics from Vanilla Storytellers Expanded - Igor Invader to all storytellers in RimWorld. The mod enhances raid experiences by adjusting damage multipliers, minimum population requirements for threats, rewarding successful defenses, and allowing user-adjustable raid warnings. It operates seamlessly in the background without altering the base frequency of raids.

## Key Features and Systems

- **Damage Multiplier:** Modify the lethality of raids by adjusting the damage multiplier, with options ranging from 0.10 (minor tickle) to 5.00 (maximum danger).
- **Minimum Population for Threats:** Control when your colony is open to raids by setting the minimum population required for threats. Choose a number from 0 to 99 based on your readiness.
- **Raid Rewards:** After defeating a raid, choose from a selection of potential rewards or consequences. The fate of your colony is in your hands!
- **Raid Reinforcements:** If enemies breach your defenses, expect them to be reinforced, adding an extra challenge to your defenses.
- **Raid Warning System:** Enable a warning period before raids occur, ranging from 1 to 24 hours, to better prepare your defenses.

## Coding Patterns and Conventions
- The project uses conventional C# naming conventions, including PascalCase for class and method names.
- Consistent indentation and code structure are maintained for clarity and maintainability.
- XML and C# files are organized clearly, with explicit separation between logic (`.cs files`) and configuration (`.xml files`).

## XML Integration
The project comprises one XML file (`About.xml`) that handles dependency management, specifying the requirement for the Vanilla Factions Expanded Core mod by Oskar Potocki. Ensure that this dependency is loaded before the Igor Raid Mechanics mod.

## Harmony Patching
Harmony is utilized to safely apply changes to the game without altering core files directly, ensuring compatibility with other mods and maintaining save game integrity. This approach reduces the likelihood of conflicts and enhances the mod's stability.

## Suggestions for Copilot
- Leverage Copilot to suggest optimized code patterns and best practices while ensuring the modification logic aligns with the Vanilla Factions Expanded framework.
- Use Copilot's autocomplete for generating boilerplate code, such as Harmony patching templates and XML configuration structures, to enhance productivity.
- With the comprehensive key features list, employ Copilot to experiment with potential optimizations or additional settings that could further enhance raid mechanics.
- Integrate Copilot's suggestions for error handling and logging best practices to provide informative feedback for mod users, aiding in troubleshooting and enhancing user experience.

Enjoy enhancing your RimWorld experience with the improved raid mechanics! Your tactical prowess will be tested as you defend against the ever-adaptive threats of the rim.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

