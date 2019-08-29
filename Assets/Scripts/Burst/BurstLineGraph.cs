using System;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Jobs;

public class BurstLineGraph : BurstGraph
{
    public LineFunctionName function = 0;

    public override int functionIndex
    {
        get => (int)function;
        set { function = (LineFunctionName)value; }
    }
    public override string[] functionNames => Enum.GetNames(typeof(LineFunctionName));

    protected override int domainLength => LineFunctions.DOMAIN_LENGTH;

    protected override void Awake()
    {
        var points = initializer.Initialize(domainLength);
        base.points = new TransformAccessArray(points);
    }

    protected override void Update()
    {
        UpdateTime();

        LineFunctionJob job = new LineFunctionJob
        {
            time = time,
            name = function
        };

        handle = job.Schedule(points);
    }
}

