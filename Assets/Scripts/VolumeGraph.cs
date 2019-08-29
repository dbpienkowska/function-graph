using UnityEngine;
using System.Collections;

public class VolumeGraph : Graph
{
    public VolumeFunctionName function;

    protected override int _domainLength => VolumeFunctions.DOMAIN_LENGTH;

    protected override float _Function(Vector3 position, float time)
    {
        throw new System.NotImplementedException();
    }

    private Vector3[] _positions;

    private void _InitPositions()
    {
        _positions = new Vector3[_points.Length];
        for(int i = 0; i < _points.Length; i++)
            _positions[i] = _points[i].transform.localPosition;
    }

    protected override void Awake()
    {
        base.Awake();
        _InitPositions();
    }

    protected override void _Phase()
    {
        for(int i = 0; i < _points.Length; i++)
        {
            _points[i].localPosition = VolumeFunctions.VolumeFunction(function, _positions[i].x, _positions[i].z, _time);
        }
    }
}
