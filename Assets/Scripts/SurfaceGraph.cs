using System;
using UnityEngine;

public class SurfaceGraph : Graph
{
    public SurfaceFunctionName function = 0;
    
    protected override int _domainLength => SurfaceFunctions.DOMAIN_LENGTH;

    protected override float _Function(Vector3 position, float time)
    {
        return SurfaceFunctions.SurfaceFunction(function, position.x, position.z, time);
    }
}
