# Milestones & Build Plan

## Step‑by‑step Implementation
Each step must run before moving on.

1. Unity scene + SimRunner + fixed tick loop
2. One creature moving + basic drives
3. World objects affect drives
4. Reward/punishment learning (rule‑based)
5. Brain lobes + decision layer
6. Biochemistry engine
7. Genome + reproduction
8. Teaching + save/load

## Unity Requirements
- SimRunner MonoBehaviour owns simulation
- CreatureView renders state
- Debug UI shows drives, chemicals, attention, action
- Gizmos visualize sensors & attention
- JSON save/load for world & genomes

## Testing
Automated tests for:
- genome safety
- SVRule determinism
- biochemical reactions
- reinforcement behavior

## Completion Criteria
5–10 creatures running autonomously in a sandbox world,
learning, aging, reproducing, and dying.
