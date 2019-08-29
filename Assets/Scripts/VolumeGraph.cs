using UnityEngine;
using System;

public class VolumeGraph : Graph
{
    public VolumeFunctionName function;

    protected override int domainLength => VolumeFunctions.DOMAIN_LENGTH;

    public override int functionIndex
    {
        get => (int)function;
        set { function = (VolumeFunctionName)value; }
    }
    public override string[] functionNames => Enum.GetNames(typeof(VolumeFunctionName));

    protected override float Function(Vector3 position, float time)
    {
        throw new System.NotImplementedException();
    }

    private Vector3[] _positions;

    private void _InitPositions()
    {
        _positions = new Vector3[points.Length];
        for(int i = 0; i < points.Length; i++)
            _positions[i] = points[i].transform.localPosition;
    }

    protected override void Awake()
    {
        base.Awake();
        _InitPositions();
    }

    protected override void Phase()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].localPosition = VolumeFunctions.VolumeFunction(function, _positions[i].x, _positions[i].z, time);
        }
    }
}
