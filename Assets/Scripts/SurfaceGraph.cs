using System;
using UnityEngine;

public class SurfaceGraph : Graph
{
    public SurfaceFunctionName function = 0;

    public override int functionIndex
    {
        get => (int)function;
        set { function = (SurfaceFunctionName)value; }
    }
    public override string[] functionNames => Enum.GetNames(typeof(SurfaceFunctionName));

    protected override int domainLength => SurfaceFunctions.DOMAIN_LENGTH;

    protected override float Function(Vector3 position, float time)
    {
        return SurfaceFunctions.SurfaceFunction(function, position.x, position.z, time);
    }
}
