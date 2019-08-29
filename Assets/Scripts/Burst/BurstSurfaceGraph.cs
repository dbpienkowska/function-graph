using System;
using Unity.Jobs;
using UnityEngine.Jobs;

public class BurstSurfaceGraph : BurstGraph
{
    public SurfaceFunctionName function = 0;

    public override int functionIndex
    {
        get => (int)function;
        set { function = (SurfaceFunctionName)value; }
    }
    public override string[] functionNames => Enum.GetNames(typeof(SurfaceFunctionName));
    protected override int domainLength => SurfaceFunctions.DOMAIN_LENGTH;
    
    protected override void Awake()
    {
        var points = initializer.Initialize(domainLength);
        base.points = new TransformAccessArray(points);
    }

    protected override void Update()
    {
        UpdateTime();

        SurfaceFunctionJob job = new SurfaceFunctionJob
        {
            time = time,
            name = function
        };

        handle = job.Schedule(points);
    }
}
