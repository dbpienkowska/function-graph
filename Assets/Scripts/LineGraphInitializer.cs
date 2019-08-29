using UnityEngine;

public class LineGraphInitializer : GraphInitializer
{
    public override Transform[] Initialize(int domainLength)
    {
        Transform[] points = new Transform[resolution];

        float step = (float)domainLength / (float)resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;

        if(scale.x < minPointLength)
            scale = Vector3.one * minPointLength;

        for(int i = 0; i < resolution; i++)
        {
            points[i] = Instantiate(pointPrefab, transform);

            position.x = (i + 0.5f) * step - (float)domainLength / 2;

            points[i].localPosition = position;
            points[i].localScale = scale;
        }

        return points;
    }
}
