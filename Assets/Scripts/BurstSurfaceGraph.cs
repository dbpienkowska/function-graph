using Unity.Jobs;
using UnityEngine.Jobs;

public class BurstSurfaceGraph : BurstGraph
{
    public SurfaceFunctionName function = 0;

    protected override int _domainLength => SurfaceFunctions.DOMAIN_LENGTH;
    
    protected override void Awake()
    {
        var points = initializer.Initialize(_domainLength);
        _points = new TransformAccessArray(points);
    }

    protected override void Update()
    {
        _UpdateTime();

        SurfaceFunctionJob job = new SurfaceFunctionJob
        {
            time = _time,
            name = function
        };

        _handle = job.Schedule(_points);
    }
}
