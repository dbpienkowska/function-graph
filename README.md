# Function Graph

Experiments with [this tutorial](https://catlikecoding.com/unity/tutorials/basics/building-a-graph/) and [that tutorial](https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/).

<p align="center">
<img src="Presentation/LineGraph.gif" width="400"> <img src="Presentation/SurfaceGraph.gif" width="400"> <img src="Presentation/VolumeGraph.gif" width="400">
</p>

## Features

- Manipulating points (cube prefab) based on selected function
- Nice looking function formulas
- Cool, position based coloring shader

## Tweaks

- Use of abstract classes to reuse code
- UI stuff
- Job System
- Burst Compiling

## Performance tests

**LineGraph (Sine, 16 000 points)**

|     | fps | ms |
| --- | --- | ---- |
| no burst | 43 | 4.02 |
| burst | 57 | 0.34 |

**SurfaceGraph (Ripple, 16 384 points)**

|     | fps | ms |
| --- | --- | ---- |
| no burst | 37 | 4.78 |
| burst | 52 | 0.40 |

## Try it
1. [Download](https://github.com/dbpienkowska/function-graph/raw/master/Game/FunctionGraph.zip)
2. Unpack
3. Run `FunctionGraph.exe`
4. Play

To play with parameters - clone or download project and open in Unity.
