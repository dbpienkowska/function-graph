using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Jobs;

public class BurstLineGraph : BurstGraph
{
    public LineFunctionName function = 0;

    protected override int _domainLength => LineFunctions.DOMAIN_LENGTH;

    protected override void Awake()
    {
        var points = initializer.Initialize(_domainLength);
        _points = new TransformAccessArray(points);
    }

    protected override void Update()
    {
        _UpdateTime();

        LineFunctionJob job = new LineFunctionJob
        {
            time = _time,
            name = function
        };

        _handle = job.Schedule(_points);
    }
}

