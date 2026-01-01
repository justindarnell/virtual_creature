# Codex Prompt: Creatures-Inspired Virtual Life (Unity + C#)

You are building a **Creatures-inspired virtual life simulation** from scratch using **Unity (C#)**.
I am an **expert C# developer** but **new to Unity**, so:
- Keep Unity-specific explanations short and practical.
- Treat Unity as a host/editor/renderer, not the core of the system.
- All real logic must live in **pure C#**, engine-agnostic code.

## Engine & Project Setup
- Unity 2022 LTS, 2D project
- Project name: VirtualLife
- Folder structure:
```
Assets/
  SimCore/
  UnityAdapter/
  Content/
  Tools/
  Tests/
```
- Use asmdef files to enforce SimCore ↔ Unity separation.

## Non‑negotiable rules
- Fixed‑timestep simulation
- Deterministic option (seeded RNG)
- Unity only visualizes and forwards input

## Start Condition
Begin by creating the project, folder structure, and implementing Steps 1–2 from the milestones.
