using UnityEngine;

[RequireComponent(typeof(GraphInitializer))]
public abstract class Graph : MonoBehaviour
{
    [Range(-8, 8)]
    public float animationSpeed = 1f;

    public int pointsCount { get; protected set; }

    public abstract int functionIndex { get; set; }
    public abstract string[] functionNames { get; }

    protected abstract int domainLength { get; }

    protected Transform[] points;
    protected float time;

    protected abstract float Function(Vector3 position, float time);

    protected void InitPoints()
    {
        points = GetComponent<GraphInitializer>().Initialize(domainLength);
        pointsCount = points.Length;
    }

    protected virtual void Phase()
    {
        Vector3 pos;

        for(int i = 0; i < points.Length; i++)
        {
            pos = points[i].localPosition;
            pos.y = Function(pos, time);
            points[i].localPosition = pos;
        }
    }

    protected void UpdateTime()
    {
        time += Time.deltaTime * animationSpeed;
    }

    protected virtual void Awake()
    {
        InitPoints();
    }

    protected virtual void Update()
    {
        UpdateTime();
        Phase();
    }
}
