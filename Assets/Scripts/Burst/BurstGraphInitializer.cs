using UnityEngine;

public class BurstGraphInitializer : GraphInitializer
{
    public GraphInitializer initializer;
    [Range(1, 8)]
    public int parentsCount = 4;

    public override Transform[] Initialize(int domainLength)
    {
        Transform[] parents = new Transform[parentsCount];

        for(int i = 0; i < parentsCount; i++)
        {
            parents[i] = new GameObject("Burst Group").transform;
            parents[i].localPosition = transform.position;
        }

        Transform[] points = initializer.Initialize(domainLength);

        for(int i = 0; i < points.Length; i++)
            points[i].SetParent(parents[i % parentsCount]);

        return points;
    }
}
