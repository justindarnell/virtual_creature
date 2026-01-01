# Architecture & Systems Design

## World
2D world with interactive objects (Food, Bed, Toy, Hazard, Shower).
Objects are data‑driven via JSON scripts.

## Creatures
Creatures are autonomous agents with:
- symbolic senses (vision, sound, touch)
- attention system (one attended object)
- discrete action set

## Drives & Reinforcement
Drives:
- Hunger
- Fatigue
- Pain/Avoidance
- Boredom/Social

Drive reduction → Reward chemical  
Drive increase → Punishment chemical  

Learning modifies action selection over time.

## Biochemistry
- Chemicals indexed 0–255
- Reactions: iA + [jB] → [kC] + [lD]
- Emitters write chemicals from loci
- Receptors read chemicals to loci
- Entirely data‑driven

## Brain
Lobe‑based heterogeneous neural system:
- Perception
- Attention
- Concept Space
- Decision Layer

Neurons:
- state, rest, threshold, relaxation
- SVRule bytecode (mutation‑safe)

Synapses:
- STW / LTW
- susceptibility for delayed reinforcement

## Genetics
Genome = byte array with gene boundaries.

Genes encode:
- brain parameters
- SVRules
- biochemistry
- drives
- lifespan & life stages
- appearance seeds

Sexual reproduction with crossover, mutation, duplication/omission.
Ontogeny via gene activation times.
