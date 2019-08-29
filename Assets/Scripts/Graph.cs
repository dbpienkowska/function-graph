using UnityEngine;

[RequireComponent(typeof(GraphInitializer))]
public abstract class Graph : MonoBehaviour
{
    [Range(-8, 8)]
    public float animationSpeed = 1f;

    protected abstract int _domainLength { get; }

    protected Transform[] _points;
    protected float _time;

    protected abstract float _Function(Vector3 position, float time);

    protected void _InitPoints()
    {
        _points = GetComponent<GraphInitializer>().Initialize(_domainLength);
    }

    protected virtual void _Phase()
    {
        Vector3 pos;

        for(int i = 0; i < _points.Length; i++)
        {
            pos = _points[i].localPosition;
            pos.y = _Function(pos, _time);
            _points[i].localPosition = pos;
        }
    }

    protected void _UpdateTime()
    {
        _time += Time.deltaTime * animationSpeed;
    }

    protected virtual void Awake()
    {
        _InitPoints();
    }

    protected virtual void Update()
    {
        _UpdateTime();
        _Phase();
    }
}
