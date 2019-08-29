using UnityEngine;
using System.Collections;

public class SurfaceGraphInitializer : GraphInitializer
{
    public override Transform[] Initialize(int domainLength)
    {
        Transform[] points = new Transform[resolution * resolution];

        float step = (float)domainLength / (float)resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;

        for(int i = 0, z = 0; z < resolution; z++)
        {
            position.z = (z + 0.5f) * step - (float)domainLength / 2;

            for(int x = 0; x < resolution; x++, i++)
            {
                points[i] = Instantiate(pointPrefab, transform);

                position.x = (x + 0.5f) * step - (float)domainLength / 2;

                points[i].localPosition = position;
                points[i].localScale = scale;
            }
        }

        return points;
    }
}
