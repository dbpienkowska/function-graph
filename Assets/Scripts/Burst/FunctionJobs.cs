using Unity.Burst;
using UnityEngine;
using UnityEngine.Jobs;

[BurstCompile]
public struct LineFunctionJob : IJobParallelForTransform
{
    public float time;
    public LineFunctionName name;

    public void Execute(int index, TransformAccess point)
    {
        Vector3 pos = point.localPosition;
        pos.y = LineFunctions.LineFunction(name, pos.x, time);
        point.localPosition = pos;
    }
}

[BurstCompile]
public struct SurfaceFunctionJob : IJobParallelForTransform
{
    public float time;
    public SurfaceFunctionName name;

    public void Execute(int index, TransformAccess point)
    {
        Vector3 pos = point.localPosition;
        pos.y = SurfaceFunctions.SurfaceFunction(name, pos.x, pos.z, time);
        point.localPosition = pos;
    }
}